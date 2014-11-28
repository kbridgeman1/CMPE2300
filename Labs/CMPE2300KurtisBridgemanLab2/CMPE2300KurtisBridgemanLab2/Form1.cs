using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2300KurtisBridgemanLab2
{
    public partial class Form1 : Form
    {
        List<Missile> friendsList = new List<Missile>();    //holds our friendly missiles
        List<Missile> foesList = new List<Missile>();       //holds our enemy missiles
        List<Missile> collided = new List<Missile>();       //holds our missiles that have collided
        List<Missile> cityList = new List<Missile>();       //holds our citys
        List<Missile> cannonList = new List<Missile>();     //holds our cannons

        Point pollMouseLocation;    //will hold our mouse click coordinates       
        Random rnd = new Random();  //used to limit foes to have a 1 in 20 chance to spawn each tick
        Bitmap bmp = new Bitmap(Properties.Resources.background); //background image

        double foesDestroyed;       //count for number of enemy missiles destroyed
        double friendsLaunched;     //count for friendly missiles fired
        int difficultyCounter;      //difficulty tracker, increases as timer ticks
        int cmFoeCount;             //classic mode, foes killed per level
        int cmFoeTotal;             //classic mode, total foes per level
        int lvlBonus;               //bonus points at the end of each level
        int score;                  //running total for the score of the player

        public Form1()
        {
            InitializeComponent();
        }

        //Occurs when the user presses the New Game button, sets the form members to prepare
        //for a new game.
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            //close the canvas if one already exists
            if (Missile.Canvas != null)
                Missile.Canvas.Close();

            Missile.Canvas = new GDIDrawer.CDrawer(bContinuousUpdate: false);

            //sets the canvas to appear next to the main form
            Point p = new Point(this.Location.X + this.Width, this.Location.Y);
            Missile.Canvas.Position = p;

            //sets the background to show the background image
            for (int row = 500; row < Missile.Canvas.ScaledHeight; row++)
                for (int col = 0; col < Missile.Canvas.ScaledWidth; col++)
                    Missile.Canvas.SetBBScaledPixel(col, row, bmp.GetPixel(col, row));

            //clears our lists upon starting a new game
            friendsList.Clear();
            foesList.Clear();
            cityList.Clear();
            cannonList.Clear();

            //adds 6 cities to our list of cities
            int x = Missile.Canvas.ScaledWidth / 4;
            for (int ii = 0; ii < 2; ii++)
            {
                for (int i = 0; i < 3; i++)
                {
                    cityList.Add(new Missile(new Point(x, Missile.Canvas.ScaledHeight
                        - Missile.Canvas.ScaledHeight * 4 / 60), "city"));

                    x += Missile.Canvas.ScaledWidth / 16;
                }
                x = Missile.Canvas.ScaledWidth * 5/8;
            }

            //adds 3 cannons to our list of cannons
            x = Missile.Canvas.ScaledWidth/8;
            for (int i = 0; i < 3; i++)
            {
                cannonList.Add(new Missile(new Point(x, Missile.Canvas.ScaledHeight
                    - Missile.Canvas.ScaledHeight * 1 / 10), "cannon"));

                x += Missile.Canvas.ScaledWidth * 3 / 8;
            }

            //renders all of our cities and cannons
            foreach (Missile c in cityList)
                c.RenderCity();

            foreach (Missile c in cannonList)
                c.RenderCannon(new Point(Missile.Canvas.ScaledWidth/2, Missile.Canvas.ScaledHeight/2));

            //sets Missiles static ExplosionRadius via trackbar value
            Missile.ExplosionRadius = trackBarExplRad.Value;

            //determines whether or not enemies will aim at friendly cannons/cities
            if (chkBoxEnemysAim.Checked)
                Missile.EnemysAim = true;
            else
                Missile.EnemysAim = false;

            //resets our tracking variables upon starting a new game
            foesDestroyed = 0;
            friendsLaunched = 0;
            lvlBonus = 0;
            difficultyCounter = 1;
            Missile.Difficulty = 20;

            if (radioButtonClassic.Checked)
            {
                cmFoeCount = 0;
                cmFoeTotal = 10;
            }

            //renders our CDrawer to display cannons/cities
            Missile.Loading = false;

            //sets the score text on the main form and enables/disables the form controls
            lblTotalEnemies.Text = foesList.Count.ToString();
            lblMisslesFired.Text = friendsList.Count.ToString();
            lblEnemiesDestroyed.Text = foesDestroyed.ToString(); ;
            lblKillPerShot.Text = "0";
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnNewGame.Enabled = false;
            labelExpl.Enabled = false;
            trackBarExplRad.Enabled = false;
            chkBoxEnemysAim.Enabled = false;
            groupBox1.Enabled = false;

            //enables timer1 to start the game
            timer1.Enabled = true;
        }

        //Occurs when the user clicks the Pause button, pauses the game and waits for the user
        //to resume.
        private void btnPause_Click(object sender, EventArgs e)
        {
            //if the game is running, stop the timer and notify the user via CDrawer text
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                Missile.Canvas.AddText("Paused", 100, Color.Blue);
                Missile.Canvas.Render();
            }

            else
                timer1.Enabled = true;
        }

        //Occurs when the user clicks the Stop button, disables the timer, closes the canvas,
        //and enables/disables form controls.
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Missile.Canvas.Close();

            btnNewGame.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            labelExpl.Enabled = true;
            trackBarExplRad.Enabled = true;
            chkBoxEnemysAim.Enabled = true;
            groupBox1.Enabled = true;
        }

        //Occurs each timer tick(30ms), moves, evalutes, and draws each missile. Adjusting difficulty
        //as the game progresses. Displays some informative text to the user on the canvas.
        private void timer1_Tick(object sender, EventArgs e)
        {
            //functionality for Marathon Game Mode
            if (radioButtonMarathon.Checked)
            {
                //every 100 difficulty ticks, gives each cannon more ammo, and increases
                //our static Missile Difficulty
                if (difficultyCounter % 100 == 0)
                {
                    foreach (Missile msl in cannonList)
                        msl.Ammo += (int)(Missile.Difficulty / 10) - 2;

                    Missile.Difficulty += 2;
                    difficultyCounter = 0;
                }

                //adds an enemy missile if enemy count is less than a value that scales with the
                //difficulty. With a 1 in 20 chance to add a missile per tick.
                if (foesList.Count < Missile.Difficulty / 5 && rnd.Next(1, 20) == 1)
                    foesList.Add(new Missile());
            }

            //functionality for Classic Game Mode
            if (radioButtonClassic.Checked)
            {
                //adds an enemy missile if the enemy count is less than the current levels 
                //total enemy value. With a 1 in 20 chance to add a missile per tick.
                if (cmFoeCount < cmFoeTotal && rnd.Next(1, 20) == 1)
                {
                    foesList.Add(new Missile());
                    cmFoeCount++;
                }

                //enough enemies have been destroyed, start a new round
                else if (cmFoeCount == cmFoeTotal && foesList.Count == 0)
                    NewRound();
            }

            //adds a new friendly missile if the user has left clicked on the CDrawer
            if (Missile.Canvas.GetLastMouseLeftClickScaled(out pollMouseLocation))
            {
                //the method for determining the closest available cannon returns (0,0) if no 
                //cannons are available. So only add a missile if the start point is not (0,0).
                Missile m = new Missile(pollMouseLocation, cannonList);
                if (m.StartLocation.X != 0 && m.StartLocation.Y != 0)
                {
                    friendsList.Add(m);
                    friendsLaunched++;
                }
            }

            //perfoms a move operation on each missile in both friend & foe lists
            foreach (Missile msl in friendsList)
                msl.Move();

            foreach (Missile msl in foesList)
                msl.Move();

            //removes all missiles that evaluate to true, via our predicates
            //from both friend & and foe lists
            friendsList.RemoveAll(Missile.MissileDone);
            friendsList.RemoveAll(Missile.LeavingScreen);
            foesList.RemoveAll(Missile.MissileDone);
            foesList.RemoveAll(Missile.LeavingScreen);

            //set friendly missiles to exploding if they are overlapping with a foe missile
            collided = friendsList.Intersect(foesList).ToList();
            foreach (Missile msl in collided)
                msl.exploding = true;

            //set foe missiles to exploding if they are overlapping with a friendly missile
            collided = foesList.Intersect(friendsList).ToList();
            foreach (Missile msl in collided)
            {
                msl.exploding = true;
                foesDestroyed++;
            }

            //remove cities that have been hit by enemy missiles
            collided = cityList.Intersect(foesList).ToList();
            foreach (Missile msl in collided)
                while (cityList.Remove(msl));

            //set cannons to exploding if they have been hit by enemy missiles
            collided = cannonList.Intersect(foesList).ToList();
            foreach (Missile msl in collided)
                msl.exploding = true;
            
            //clears our CDrawer
            Missile.Loading = true;

            //render each missile object in all of our missile lists
            foreach (Missile msl in friendsList)
                msl.Render();

            foreach (Missile msl in foesList)
                msl.Render();

            foreach (Missile c in cityList)
                c.RenderCity();

            //get the current mouse location before rendering the cannons
            Missile.Canvas.GetLastMousePositionScaled(out pollMouseLocation);
            foreach (Missile c in cannonList)
                c.RenderCannon(pollMouseLocation);

            //updates the Score and Difficulty text each tick
            Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + score),
                15, 10, 530, 250, 100, Color.Black);

            Missile.Canvas.AddText("Diffuculty: " + Missile.DiffucultyString(),
                15, 500, 530, 250, 100, Color.Black);

            //renders our CDrawer
            Missile.Loading = false;

            //updates the score text on the main form
            lblTotalEnemies.Text = foesList.Count.ToString();
            lblEnemiesDestroyed.Text = foesDestroyed.ToString();
            lblMisslesFired.Text = friendsLaunched.ToString();

            if (friendsLaunched != 0)
                lblKillPerShot.Text = (Math.Round(foesDestroyed / friendsLaunched, 2)).ToString();

            //used to set the Missile's static Difficulty after so many ticks
            difficultyCounter++;

            //the user has run out of cities and the game must end
            if (cityList.Count <= 0)
            {
                //ends the current game and starts timer2 for a little end game animation
                difficultyCounter = 2;
                Missile.Loading = true;
                timer2.Enabled = true;
                timer1.Enabled = false;
            }
        }

        //Occurs each timer tick(150ms), uses the difficultyCounter to provide the user
        //with a little end game animation. Then ends the game and presents them with their score.
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            //clear our CDrawer
            Missile.Loading = true;

            //adjust the background color each tick
            if (difficultyCounter % 2 == 0)
                Missile.Canvas.BBColour = Color.FromArgb(50, Color.Red);
            else if (difficultyCounter % 3 == 0)
                Missile.Canvas.BBColour = Color.FromArgb(100, Color.Red);
            else
                Missile.Canvas.BBColour = Color.Black;

            difficultyCounter++;

            //once the animation has finished, add informative text to the canvas, then
            //enable/disable main form controls. Putting the form back into it's original state.
            if (difficultyCounter == 17)
            {
                Missile.Canvas.AddText("Game Over", 100, Color.Black);
                Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + score),
                    25, 200, 400, 400, 50, Color.Black);

                Missile.Canvas.AddText("Diffuculty: " + Missile.DiffucultyString(),
                    25, 200, 450, 400, 50, Color.Black);

                btnNewGame.Enabled = true;
                btnPause.Enabled = false;
                btnStop.Enabled = false;
                labelExpl.Enabled = true;
                trackBarExplRad.Enabled = true;
                chkBoxEnemysAim.Enabled = true;
                groupBox1.Enabled = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
            }

            //render our CDrawer
            Missile.Loading = false;
        }

        //Function:     NewRound
        //Description:  Updates form values to prepare for a new level. Displays text and halts
        //              the program during intermission.
        //Return:       void
        private void NewRound()
        {
            //updates the score text in main form each round
            if (friendsLaunched != 0)
            {
                lblMisslesFired.Text = friendsLaunched.ToString();
                lblKillPerShot.Text = (Math.Round(foesDestroyed / friendsLaunched, 2)).ToString();
            }

            //clears our CDrawer in between levels
            Missile.Loading = true;

            //clears level bonus, then sums bonus points for unused ammo and each remaining city
            lvlBonus = 0;
            lvlBonus += 100 * cityList.Count();
            lvlBonus += (cannonList[0].Ammo + cannonList[1].Ammo + cannonList[2].Ammo) * 50;

            //adds informative text for the user to show their score and level bonus
            Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + score),
                15, 10, 530, 250, 100, Color.Black);

            Missile.Canvas.AddText("Good Job", 100, Color.LawnGreen);

            Missile.Canvas.AddText(String.Format("Citys: 100pts x{0} ", cityList.Count),
                20, 250, 330, 350, 100, Color.Chartreuse);

            Missile.Canvas.AddText(String.Format("Extra Missiles: 50pts x{0}",
                cannonList[0].Ammo + cannonList[1].Ammo + cannonList[2].Ammo),
                20, 250, 360, 350, 100, Color.Chartreuse);

            Missile.Canvas.AddText(String.Format("Level Bonus: {0}pts", lvlBonus),
                20, 250, 390, 350, 100, Color.Chartreuse);

            //adds the level bonus to the running sum of the users score, clears any remaining
            //friendly missiles, then renders our CDrawer.
            score += lvlBonus;
            friendsList.Clear();
            Missile.Loading = false;

            //halts the program for 5 seconds then sets values for next level
            System.Threading.Thread.Sleep(5000);
            Missile.Difficulty += 20;
            cmFoeTotal += 10;
            cmFoeCount = 0;

            //reset cannons each level, increasing the ammo they receive as difficulty increases
            foreach (Missile msl in cannonList)
            {
                msl.Ammo = (int)(Missile.Difficulty / 10) + 5;
                msl.exploding = false;
            }
        }
    }
}
