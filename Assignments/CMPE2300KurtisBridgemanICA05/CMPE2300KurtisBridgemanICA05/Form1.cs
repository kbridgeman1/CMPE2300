using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2300KurtisBridgemanICA05
{
    public partial class Form1 : Form
    {
        List<Ball> ballList = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            labelSizeValue.Text = trackBar1.Value.ToString();
        }

        private void bttnAddBalls_Click_1(object sender, EventArgs e)
        {
            if (trackBar1.Value != 0)
            {
                int iCount = 0;
                int iDiscard = 0;

                Ball.Loading = true;

                while (iCount < 25 && iDiscard < 1000)
                {
                    Ball tempBall = new Ball(trackBar1.Value);

                    if (ballList.IndexOf(tempBall) == -1)
                    {
                        ballList.Add(tempBall);
                        iCount++;
                    }

                    else
                        iDiscard++;
                }

                foreach (Ball b in ballList)
                    b.AddBall();

                Ball.Loading = false;

                progressBar1.Value = iDiscard;

                this.Text = String.Format("Loaded {0} distinct balls with {1} discards", iCount, iDiscard);
            }

            else
                this.Text = String.Format("Loaded {0} distinct balls with {1} discards", 0, 0);

            if (ballList.Count > 0)
                groupBox1.Enabled = true;
        }

        private void buttonClearBalls_Click(object sender, EventArgs e)
        {
            Ball.Loading = true;
            ballList.Clear();
            Ball.Loading = false;

            groupBox1.Enabled = false;
        }


        private void radioButtonRadius_Click(object sender, EventArgs e)
        {
            if (radioButtonRadius.Checked)
                Ball.CompareType = Ball.ESortType.eRadius;

            if (radioButtonDistance.Checked)
                Ball.CompareType = Ball.ESortType.eDistance;

            if (radioButtonColor.Checked)
                Ball.CompareType = Ball.ESortType.eColor;

            ballList.Sort();

            Ball.Loading = true;

            foreach (Ball b in ballList)
            {
                b.AddBall();
                Ball.Loading = false;
                System.Threading.Thread.Sleep(5);
            }
        }

        



    }
}
