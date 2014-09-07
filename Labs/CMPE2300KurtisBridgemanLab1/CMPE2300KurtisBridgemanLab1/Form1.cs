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

namespace CMPE2300KurtisBridgemanLab1
{
    public partial class FormImageSecrets : Form
    {
        Bitmap bMapOrig;
        Bitmap bMapDecode;

        public FormImageSecrets()
        {
            InitializeComponent();
        }

        private void toolStripButtonLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files|*.*|Jpeg Files|*.jpeg|Png Files|*.png|Bmp Files|*.bmp|Gif Files|*.gif";

            toolStrip1.Enabled = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bMapOrig = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bMapOrig;

                

              //  bMap.SetResolution(pictureBox1.Height, pictureBox1.Width); 

                this.Width = bMapOrig.Width;
                this.Height = bMapOrig.Height;


            }

            toolStrip1.Enabled = true;

        }

        private void toolStripButtonDecode_Click(object sender, EventArgs e)
        {
            if (bMapOrig != null)
            {
                


            }
        }

        








    }
}
