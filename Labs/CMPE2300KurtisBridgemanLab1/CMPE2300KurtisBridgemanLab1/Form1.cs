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

                if (toolStripComboBox1.Text != "Color")
                {
                    toolStripButtonDecode.Enabled = true;
                    toolStripButtonDecodeImage.Enabled = true;
                }
            }

            toolStrip1.Enabled = true;

        }

        private void toolStripButtonDecode_Click(object sender, EventArgs e)
        {
            if (bMapOrig != null)
            {

                Color tmpColor;
                bMapDecode = new Bitmap(bMapOrig.Width, bMapOrig.Height);

                for (int iirow = 0; iirow < bMapDecode.Width; iirow++)
                    for (int iicol = 0; iicol < bMapDecode.Height; iicol++)
                        bMapDecode.SetPixel(iirow, iicol, Color.Black);

                for ( int irow =0; irow<bMapOrig.Width;irow++)
                    for (int icol = 0; icol < bMapOrig.Height; icol++)
                    {
                        tmpColor = bMapOrig.GetPixel(irow, icol);

                        switch (toolStripComboBox1.Text)
                        {
                            case "Red":
                                if (((byte)tmpColor.R & (0x01 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Red);
                                break;

                            case"Green":
                                if (((byte)tmpColor.G & (0x01 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Green);
                                break;

                            case "Blue":
                                if (((byte)tmpColor.B & (0x01 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Blue);
                                break;

                            case "All":
                                if (((byte)tmpColor.R & (0x01 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Red);
                                if (((byte)tmpColor.G & (0x01 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Green);
                                if (((byte)tmpColor.B & (0x01 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Blue);
                                break;

                        }
                        progressBar1.Maximum = bMapDecode.Width;
                        progressBar1.Value = irow;
                    }

                pictureBox1.Image = bMapDecode;
                progressBar1.Value = 0;

            }
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "Color")
            {
                toolStripButtonDecode.Enabled = false;
                toolStripButtonDecodeImage.Enabled = false;
            }

            else
            {
                toolStripButtonDecode.Enabled = true;
                toolStripButtonDecodeImage.Enabled = true;
            }
        }

        








    }
}
