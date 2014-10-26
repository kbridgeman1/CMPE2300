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
        Point pollMouseLocation;
        Bitmap bmp = new Bitmap(@"..\..\Background Image\background.jpg");
        int difficualtyCounter = 0;

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
            for (int ii = 0; ii < 3; ii++)
            {
                for (int i = 0; i < 3; i++)
                {
                    cityList.Add(new Missile(new Point(x, Missile.Canvas.ScaledHeight - 40), "city"));
                    x += 50;
                }
                x = 500;
            }
            
            foreach (Missile c in cityList)
                c.RenderCity();

            Missile.ExplosionRadius = trackBarExplRad.Value;

            if (chkBoxEnemysAim.Checked)
                Missile.EnemysAim = true;
            else
                Missile.EnemysAim = false;

            timer1.Enabled = true;
            Missile.Difficulty = 20;

            Missile.Canvas.Render();

            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnNewGame.Enabled = false;
            labelExpl.Enabled = false;
            trackBarExplRad.Enabled = false;
            chkBoxEnemysAim.Enabled = false;

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
            if (difficualtyCounter % 100 == 0)
            {
                Missile.Difficulty++;
                difficualtyCounter = 0;
            }

            if (foesList.Count < Missile.Difficulty / 5)
                foesList.Add(new Missile());

            bool bLMouseClick = Missile.Canvas.GetLastMouseLeftClickScaled(out pollMouseLocation);

            if (bLMouseClick)           
                friendsList.Add(new Missile(pollMouseLocation));
            
            foreach (Missile msl in friendsList)
                msl.Move();

            foreach (Missile msl in foesList)
                msl.Move();

            collided = friendsList.Intersect(foesList).ToList();

            foreach (Missile msl in collided)
                msl.exploding = true;

            collided = foesList.Intersect(friendsList).ToList();

            foreach (Missile msl in collided)
                msl.exploding = true;

            collided = cityList.Intersect(foesList).ToList();

            foreach (Missile msl in collided)
                while(cityList.Remove(msl));
            
            friendsList.RemoveAll(Missile.MissileDone);
            friendsList.RemoveAll(Missile.LeavingScreen);
            foesList.RemoveAll(Missile.MissileDone);
            foesList.RemoveAll(Missile.LeavingScreen);

            Missile.Canvas.Clear();

            foreach (Missile msl in friendsList)
                msl.Render();

            foreach (Missile msl in foesList)
                msl.Render();

            foreach (Missile c in cityList)
                c.RenderCity();

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
                
            Missile.Canvas.AddText("Diffuculty: "+ Missile.DiffucultyString(), 15, 10, 530,250,100,Color.Black);

            Missile.Canvas.Render();

            difficualtyCounter++;

        }








    }
}
