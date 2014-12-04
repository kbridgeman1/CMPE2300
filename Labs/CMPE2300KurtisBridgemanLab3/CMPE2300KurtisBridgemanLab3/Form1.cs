using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMPE2300KurtisBridgemanLab3
{

    

    public partial class Form1 : Form
    {

        CTracker canvas;
        Random rnd = new Random();

        RandomWanderer rw;

        public Form1()
        {
            InitializeComponent();
            canvas = new CTracker(800, 600);
            rw = new RandomWanderer(new Point(400, 300), Color.Blue, canvas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            canvas.Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (rw.Move())
                canvas.Render();
        }


    }
}
