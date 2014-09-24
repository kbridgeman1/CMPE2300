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
            if (ballList.Count > 0)
                ballList[ballList.Count - 1].Radius = trackBar1.Value;
        }

        private void bttnAddBalls_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            int iDiscard = 0;

            Ball.Loading = true;

            do
            {
                Ball tempBall = new Ball(trackBar1.Value);


                if (ballList.IndexOf(tempBall) == -1)
                {
                    ballList.Add(tempBall);
                    iCount++;
                }

                else
                    iDiscard++;


            } while (iCount < 25 && iDiscard < 1000);

            Ball.Loading = false;

        }



    }
}
