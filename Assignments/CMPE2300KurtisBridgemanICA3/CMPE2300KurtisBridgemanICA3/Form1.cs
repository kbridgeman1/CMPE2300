using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA3
{
    public partial class Form1 : Form
    {
        List<Ball> ballList = new List<Ball>();
        Thread AddBalls;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            AddBalls = new Thread(new ThreadStart(ThreadAddBalls));
            AddBalls.IsBackground = true;
            AddBalls.Start();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Text = "Size: " + trackBar1.Value.ToString();
            Ball.Radius = trackBar1.Value;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Add)
                for (int i = 0; i < 5; i++)
                    ballList.Add(new Ball());

            if (e.KeyData == Keys.Escape)
                ballList.Clear();
        }

        private void ThreadAddBalls()
        {
            do
            {
                Ball.Loading = true;
                
                foreach (Ball b in ballList)
                {
                    b.MoveBall();
                    b.ShowBall();
                }

                Ball.Loading = false;

                Thread.Sleep(25);

            } while (true);
        }

    }
}
