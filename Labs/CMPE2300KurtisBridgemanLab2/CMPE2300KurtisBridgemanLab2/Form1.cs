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

        List<Missile> friendsList = new List<Missile>();
        List<Missile> foesList = new List<Missile>();
        List<Missile> collided = new List<Missile>();
        List<Missile> cityList = new List<Missile>();
        List<Missile> cannonList = new List<Missile>();

        Point pollMouseLocation;
        Bitmap bmp = new Bitmap(@"..\..\Background Image\background.jpg");
        Random rnd = new Random();
       
        double foesDestroyed;
        double friendsLaunched;
        int difficualtyCounter;
        int cmFoeCount;
        int cmFoeTotal;
        int lvlBonus;
        bool autoFire;
        int autoFireCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (Missile.Canvas != null)
                Missile.Canvas.Close();

            Missile.Canvas = new GDIDrawer.CDrawer(bContinuousUpdate: false);

            Point p = new Point(this.Location.X + this.Width, this.Location.Y);
            Missile.Canvas.Position = p;

            for (int row = 500; row < Missile.Canvas.ScaledHeight; row++)
                for (int col = 0; col < Missile.Canvas.ScaledWidth; col++)
                    Missile.Canvas.SetBBScaledPixel(col, row, bmp.GetPixel(col, row));

            friendsList.Clear();
            foesList.Clear();
            cityList.Clear();
            cannonList.Clear();

            int x = 200;
            for (int ii = 0; ii < 2; ii++)
            {
                for (int i = 0; i < 3; i++)
                {
                    cityList.Add(new Missile(new Point(x, Missile.Canvas.ScaledHeight - Missile.Canvas.ScaledHeight * 4 / 60), "city"));
                    x += 50;
                }
                x = 500;
            }

            x = 100;
            for (int i = 0; i < 3; i++)
            {
                cannonList.Add(new Missile(new Point(x, Missile.Canvas.ScaledHeight - Missile.Canvas.ScaledHeight * 1 / 10), "cannon"));
                x += 300;
            }

            foreach (Missile c in cityList)
                c.RenderCity();

            foreach (Missile c in cannonList)
                c.RenderCannon(new Point(400, 200));

            Missile.ExplosionRadius = trackBarExplRad.Value;

            if (chkBoxEnemysAim.Checked)
                Missile.EnemysAim = true;
            else
                Missile.EnemysAim = false;

            foesDestroyed = 0;
            friendsLaunched = 0;
            lvlBonus = 0;
            difficualtyCounter = 1;

            Missile.Loading = false;

            lblTotalEnemies.Text = "0";
            lblMisslesFired.Text = "0";
            lblEnemiesDestroyed.Text = "0";
            lblKillPerShot.Text = "0";
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnNewGame.Enabled = false;
            labelExpl.Enabled = false;
            trackBarExplRad.Enabled = false;
            chkBoxEnemysAim.Enabled = false;
            groupBox1.Enabled = false;

            timer1.Enabled = true;

            if (radioButtonMarathon.Checked)
                Missile.Difficulty = 20;

            if (radioButtonClassic.Checked)
            {
                Missile.Difficulty = 20;
                cmFoeCount = 0;
                cmFoeTotal = 10;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                Missile.Canvas.AddText("Paused", 100, Color.Blue);
                Missile.Canvas.Render();

            }

            else
                timer1.Enabled = true;
        }

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButtonMarathon.Checked)
            {
                if (difficualtyCounter % 100 == 0)
                {
                    foreach (Missile msl in cannonList)
                    {
                        msl.Ammo += (int)(Missile.Difficulty / 10) - 2;
                    }
                    Missile.Difficulty += 2;
                    difficualtyCounter = 0;
                }

                if (foesList.Count < Missile.Difficulty / 5 && rnd.Next(1, 20) == 1)
                    foesList.Add(new Missile());
            }


            if (radioButtonClassic.Checked)
            {
                if (cmFoeCount < cmFoeTotal && rnd.Next(1, 20) == 1)
                {

                    foesList.Add(new Missile());
                    cmFoeCount++;
                }

                else if (cmFoeCount == cmFoeTotal && foesList.Count == 0)
                {
                    if (friendsLaunched != 0)
                    {
                        lblMisslesFired.Text = friendsLaunched.ToString();
                        lblKillPerShot.Text = (Math.Round(foesDestroyed / friendsLaunched, 2)).ToString();
                    }

                    Missile.Loading = true;
                    Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + lvlBonus), 15, 10, 530, 250, 100, Color.Black);
                    Missile.Canvas.AddText("Good Job", 100, Color.Blue);
                    Missile.Canvas.AddText(String.Format("Citys: 100pts x{0} ", cityList.Count), 20, 250, 330, 350, 100, Color.Blue);
                    Missile.Canvas.AddText(String.Format("Extra Missiles: 50pts x{0}", cannonList[0].Ammo + cannonList[1].Ammo + cannonList[2].Ammo), 20, 250, 360, 350, 100, Color.Blue);
                    lvlBonus += 100 * cityList.Count();
                    lvlBonus += (cannonList[0].Ammo + cannonList[1].Ammo + cannonList[2].Ammo)*50;
                    Missile.Loading = false;

                    System.Threading.Thread.Sleep(5000);

                    Missile.Difficulty += 20;
                    cmFoeTotal += 10;
                    cmFoeCount = 0;

                    foreach (Missile msl in cannonList)
                    {
                        msl.Ammo = (int)(Missile.Difficulty / 10) + 5;
                        msl.exploding = false;
                    }
                }

            }



            bool bLMouseClick = Missile.Canvas.GetLastMouseLeftClickScaled(out pollMouseLocation);

            if (bLMouseClick)
            {
                Missile m = new Missile(pollMouseLocation, cannonList);
                if (m.StartLocation.X != 0 && m.StartLocation.Y != 0)
                {
                    friendsList.Add(m);
                    friendsLaunched++;
                }
            }

            bool bRMouseClick = Missile.Canvas.GetLastMouseRightClickScaled(out pollMouseLocation);

            if (bRMouseClick)
            {
                autoFire = true;
                autoFireCount = 0;
            }

            if (autoFire)
            {
                Missile.Canvas.GetLastMousePositionScaled(out pollMouseLocation);
                Missile m = new Missile(pollMouseLocation, cannonList);
                if (m.StartLocation.X != 0 && m.StartLocation.Y != 0)
                {
                    friendsList.Add(m);
                    friendsLaunched++;
                    autoFireCount++;
                }
                
                if (autoFireCount >= 5)
                    autoFire = false;
            }

      //      if (bRMouseClick)
      //          cityList.Clear();

            foreach (Missile msl in friendsList)
                msl.Move();

            foreach (Missile msl in foesList)
                msl.Move();

            friendsList.RemoveAll(Missile.MissileDone);
            friendsList.RemoveAll(Missile.LeavingScreen);
            foesList.RemoveAll(Missile.MissileDone);
            foesList.RemoveAll(Missile.LeavingScreen);

            collided = friendsList.Intersect(foesList).ToList();

            foreach (Missile msl in collided)
                msl.exploding = true;

            collided = foesList.Intersect(friendsList).ToList();

            foreach (Missile msl in collided)
            {
                msl.exploding = true;
                foesDestroyed++;
            }

            collided = cityList.Intersect(foesList).ToList();

            foreach (Missile msl in collided)
                while (cityList.Remove(msl)) ;

            collided = cannonList.Intersect(foesList).ToList();

            foreach (Missile msl in collided)
            {
                msl.exploding = true;
            }

            

            Missile.Loading = true;

            foreach (Missile msl in friendsList)
                msl.Render();

            foreach (Missile msl in foesList)
                msl.Render();

            foreach (Missile c in cityList)
                c.RenderCity();

            Missile.Canvas.GetLastMousePositionScaled(out pollMouseLocation);

            foreach (Missile c in cannonList)
                c.RenderCannon(pollMouseLocation);

            Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + lvlBonus), 15, 10, 530, 250, 100, Color.Black);
            Missile.Canvas.AddText("Diffuculty: " + Missile.DiffucultyString(), 15, 500, 530, 250, 100, Color.Black);

            Missile.Loading = false;

            lblTotalEnemies.Text = foesList.Count.ToString();
            lblEnemiesDestroyed.Text = foesDestroyed.ToString();
            lblMisslesFired.Text = friendsLaunched.ToString();

            if (friendsLaunched != 0)
                lblKillPerShot.Text = (Math.Round(foesDestroyed / friendsLaunched, 2)).ToString();

            difficualtyCounter++;

            if (cityList.Count <= 0)
            {
                difficualtyCounter = 2;
                Missile.Canvas.Clear();
                timer2.Enabled = true;
                timer1.Enabled = false;
            }
        }


        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Missile.Loading = true;

            if (difficualtyCounter % 2 == 0)
                Missile.Canvas.BBColour = Color.FromArgb(50, Color.Red);
            else if (difficualtyCounter % 3 == 0)
                Missile.Canvas.BBColour = Color.FromArgb(100, Color.Red);
            else
                Missile.Canvas.BBColour = Color.Black;

            difficualtyCounter++;

            if (difficualtyCounter == 17)
            {
                Missile.Canvas.AddText("Game Over", 100, Color.Black);
                Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + lvlBonus), 25, 200, 400, 400, 50, Color.Black);
                Missile.Canvas.AddText("Diffuculty: " + Missile.DiffucultyString(), 25, 200, 450, 400, 50, Color.Black);
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

            Missile.Loading = false;
        }





    }
}
