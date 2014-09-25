using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2300KurtisBridgemanICA04
{
    public partial class FormICA04 : Form
    {
        List<Ball> ballList = new List<Ball>();

        public FormICA04()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelSizeValue.Text = trackBar1.Value.ToString();
        }

        private void bttnAddBalls_Click(object sender, EventArgs e)
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
        }



    }
}
