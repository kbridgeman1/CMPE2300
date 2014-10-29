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

        int difficualtyCounter = 0;
        double foesDestroyed;
        double friendsLaunched;
        int cmFoeCount;
        int cmFoeTotal;
        int lvlBonus;

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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButtonMarathon.Checked)
            {
                if (difficualtyCounter % 50 == 0)
                {
                    Missile.Difficulty++;
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
                    // if (foesList.Count != 0)
                    // {
                    if (friendsLaunched != 0)
                    {
                        lblMisslesFired.Text = friendsLaunched.ToString();
                        lblKillPerShot.Text = (Math.Round(foesDestroyed / friendsLaunched, 2)).ToString();
                    }
                    else
                        lblTotalEnemies.Text = "0";

                    lblEnemiesDestroyed.Text = foesDestroyed.ToString();
                    //  }
                    lvlBonus += 500 * cityList.Count();
                    Missile.Loading = true;
                    Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + lvlBonus), 15, 10, 530, 250, 100, Color.Black);
                    Missile.Canvas.AddText("Good Job", 100, Color.Blue);
                    Missile.Canvas.AddText(String.Format("Citys: {0} x 500", cityList.Count), 20, 250, 330, 250, 100, Color.Blue);
                    Missile.Loading = false;
                    System.Threading.Thread.Sleep(2000);
                    Missile.Difficulty += 20;
                    cmFoeTotal += 10;
                    cmFoeCount = 0;
                }

            }



            bool bLMouseClick = Missile.Canvas.GetLastMouseLeftClickScaled(out pollMouseLocation);

            if (bLMouseClick)
            {
                friendsList.Add(new Missile(pollMouseLocation, cannonList));
                friendsLaunched++;
            }

            foreach (Missile msl in friendsList)
                msl.Move();

            foreach (Missile msl in foesList)
                msl.Move();

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
                while (cannonList.Remove(msl)) ;

            friendsList.RemoveAll(Missile.MissileDone);
            friendsList.RemoveAll(Missile.LeavingScreen);
            foesList.RemoveAll(Missile.MissileDone);
            foesList.RemoveAll(Missile.LeavingScreen);

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

            if (cityList.Count <= 0)
            {
                Missile.Canvas.AddText("Game Over", 100, Color.Blue);
                timer1.Enabled = false;
                btnNewGame.Enabled = true;
                btnPause.Enabled = false;
                btnStop.Enabled = false;
                labelExpl.Enabled = true;
                trackBarExplRad.Enabled = true;
                chkBoxEnemysAim.Enabled = true;
            }

            Missile.Canvas.AddText("Score: " + (foesDestroyed * 100 + lvlBonus), 15, 10, 530, 250, 100, Color.Black);
            Missile.Canvas.AddText("Diffuculty: " + Missile.DiffucultyString(), 15, 500, 530, 250, 100, Color.Black);

            if (foesList.Count != 0)
                lblTotalEnemies.Text = foesList.Count.ToString();

            if (friendsLaunched != 0)
            {
                lblMisslesFired.Text = friendsLaunched.ToString();
                lblKillPerShot.Text = (Math.Round(foesDestroyed / friendsLaunched, 2)).ToString();
            }

            lblEnemiesDestroyed.Text = foesDestroyed.ToString();


            Missile.Loading = false;

            difficualtyCounter++;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }








    }
}
