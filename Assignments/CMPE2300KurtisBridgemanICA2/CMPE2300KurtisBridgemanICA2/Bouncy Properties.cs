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

namespace CMPE2300KurtisBridgemanICA2
{
    public partial class Form1 : Form
    {

        CDrawer canvas;
        List<Ball> ballsList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new CDrawer(800, 600, false, false);
            timer1.Interval = 20;
            timer1.Enabled = true;
            ballsList = new List<Ball>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point mouseLocationL;
            Point tmpPoint;

            bool bLMouseClick = canvas.GetLastMouseLeftClick(out mouseLocationL);
            bool bRMouseClick = canvas.GetLastMouseRightClick(out tmpPoint);

            if (bLMouseClick)
            {
                ballsList.Add(new Ball(mouseLocationL));
            }

            if (bRMouseClick)
                ballsList.Clear();

            canvas.Clear();
            foreach (Ball b in ballsList)
            {
                b.MoveBall(canvas);
                b.ShowBall(canvas, ballsList);
            }

            if (ballsList.Count > 0)
            {
                this.Text = ballsList[ballsList.Count - 1].ToString() + trackBarOpacity.Value;
            }

            canvas.Render();
        }

        private void trackBarOpacity_Scroll(object sender, EventArgs e)
        {
            labelOpacity.Text = "Opacity: " + trackBarOpacity.Value;

            if (checkBoxAll.Checked)
                foreach (Ball b in ballsList)
                    b.BallOpacity = trackBarOpacity.Value;

            else if (ballsList.Count - 1 >= 0)
            {
                ballsList[ballsList.Count - 1].BallOpacity = trackBarOpacity.Value;
            }

        }

        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            labelX.Text = "X: " + trackBarX.Value;

            if (checkBoxAll.Checked)
                foreach (Ball b in ballsList)
                    b.xVelocity = trackBarX.Value;
            else if (ballsList.Count - 1 >= 0)
                ballsList[ballsList.Count - 1].xVelocity = trackBarX.Value;
        }

        private void trackBarY_Scroll(object sender, EventArgs e)
        {
            labelY.Text = "Y: " + trackBarY.Value;

            if (checkBoxAll.Checked)
                foreach (Ball b in ballsList)
                    b.yVelocity = trackBarY.Value;
            else if(ballsList.Count-1 >=0)
                ballsList[ballsList.Count - 1].yVelocity = trackBarY.Value;

        }






    }
}
