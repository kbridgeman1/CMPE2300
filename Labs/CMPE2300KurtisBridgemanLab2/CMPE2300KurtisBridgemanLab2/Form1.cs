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
        List<Building> bldList = new List<Building>();
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

            for (int row = 500; row < Missile.Canvas.ScaledHeight; row++)
                for (int col = 0; col < Missile.Canvas.ScaledWidth; col++)
                    Missile.Canvas.SetBBScaledPixel(col, row, bmp.GetPixel(col, row));

            timer1.Enabled = true;
            Missile.Difficulty = 20;

            friendsList.Clear();
            foesList.Clear();
            bldList.Clear();

            if (chkBoxEnemysAim.Checked)
                Missile.EnemysAim = true;
            else
                Missile.EnemysAim = false;

            bldList = Building.CreateBuildings();

            foreach (Building b in bldList)
                b.Render();

            Missile.Canvas.Render();
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnNewGame.Enabled = false;

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
            {
                friendsList.Add(new Missile(pollMouseLocation));
            }

            foreach (Missile msl in friendsList)
                msl.Move();

            foreach (Missile msl in foesList)
                msl.Move();

            List<Missile> collidedA = foesList.Intersect(friendsList).ToList();
            List<Missile> collidedB = friendsList.Intersect(foesList).ToList();

            collidedA = collidedA.Concat(collidedB).ToList();

            foreach (Missile msl in collidedA)
                msl.exploding = true;

            friendsList.RemoveAll(Missile.MissileDone);
            friendsList.RemoveAll(Missile.LeavingScreen);
            foesList.RemoveAll(Missile.MissileDone);
            foesList.RemoveAll(Missile.LeavingScreen);

            Missile.Canvas.Clear();

            foreach (Missile msl in friendsList)
                msl.Render();

            foreach (Missile msl in foesList)
                msl.Render();

            foreach (Building bl in bldList)
                bl.Render();

            Missile.Canvas.AddText((Missile.Difficulty - 20).ToString(), 100, Color.Red);

            Missile.Canvas.Render();

            difficualtyCounter++;

        }








    }
}
