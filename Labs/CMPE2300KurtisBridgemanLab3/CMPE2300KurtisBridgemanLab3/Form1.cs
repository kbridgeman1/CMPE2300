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


        public Form1()
        {
            InitializeComponent();
            canvas = new CTracker(800, 600);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int irow = 0; irow < canvas.ScaledHeight; irow++)
                for (int icol = 0; icol < canvas.ScaledWidth; icol++)
                {
                    canvas.SetBBScaledPixel(icol, irow, Color.Blue);
                    canvas.Render();
                }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            canvas.Reset();
        }


    }
}
