using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA06
{
    public partial class Form1 : Form
    {
        CDrawer canvasA = new CDrawer(800, 500, false, false);
        CDrawer canvasB = new CDrawer(800, 500, false, false);

        List<Ball> bBalls = new List<Ball>();
        List<Ball> gBalls = new List<Ball>();
        List<Ball> rBalls = new List<Ball>();

        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            timer1.Interval = 30;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 340);

            Point p = new Point(0, 0);
            canvasA.Position = p;
            p.X = 820;
            canvasB.Position = p;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point mouseLocation;

            bool bLMouseClick = canvasA.GetLastMouseLeftClickScaled(out mouseLocation);

            if (bLMouseClick)
            {
                Ball tBall = new Ball(mouseLocation, Color.Green);

                if (!gBalls.Contains(tBall))
                    gBalls.Add(tBall);
            }

            bool bRMouseClick = canvasA.GetLastMouseRightClickScaled(out mouseLocation);

            if (bRMouseClick)
            {
                Ball tBall = new Ball(mouseLocation, Color.Blue);

                if (-1 == bBalls.IndexOf(tBall))
                    bBalls.Insert(0, tBall);
                    //bBalls.Add(tBall);
            }

            foreach (Ball b in bBalls)
                b.Move(canvasA);

            foreach (Ball b in gBalls)
                b.Move(canvasA);

            foreach (Ball b in rBalls)
                b.Move(canvasB);

            List<Ball> tBalls = bBalls.Intersect(gBalls).ToList();

            foreach (Ball b in tBalls)
            {
                while (bBalls.Remove(b)) ;
                while (gBalls.Remove(b)) ;

                b.BallColor = Color.Red;
            }

            rBalls = new List<Ball>(rBalls.Union(tBalls));

            canvasA.Clear();
            canvasA.AddText(String.Format("Blue: {0} {1} Green: {2}", bBalls.Count, Environment.NewLine, gBalls.Count), 50, Color.Gray);

            for (int i = 0; i < bBalls.Count; i++)
                bBalls[i].Show(canvasA, i);

            for (int ii = 0; ii < gBalls.Count; ii++)
                gBalls[ii].Show(canvasA, ii);

            canvasA.Render();

            canvasB.Clear();
            canvasB.AddText(String.Format("Red: {0}", rBalls.Count), 50, Color.Gray);

            for (int iii = 0; iii < rBalls.Count; iii++)
                rBalls[iii].Show(canvasB, iii);

            canvasB.Render();
        }


    }
}
