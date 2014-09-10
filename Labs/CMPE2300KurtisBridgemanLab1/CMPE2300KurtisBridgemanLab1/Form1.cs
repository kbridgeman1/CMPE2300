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
                }

                progressBar1.Maximum = bMapOrig.Width;
                toolStripButtonDecodeImage.Enabled = true;
            }

            toolStrip1.Enabled = true;
        }

        private void toolStripButtonDecode_Click(object sender, EventArgs e)
        {
            if (bMapOrig != null)
            {
                bMapDecode = new Bitmap(bMapOrig.Width, bMapOrig.Height);

         //       for (int iirow = 0; iirow < bMapDecode.Width; iirow++)
           //         for (int iicol = 0; iicol < bMapDecode.Height; iicol++)
             //           bMapDecode.SetPixel(iirow, iicol, Color.Black);


                for (int irow = 0; irow < bMapOrig.Width; irow++)
                {
                    for (int icol = 0; icol < bMapOrig.Height; icol++)
                    {
                        Color tmpColor = bMapOrig.GetPixel(irow, icol);
                        byte drawColorR=0;
                        byte drawColorG=0;
                        byte drawColorB=0;


                        switch (toolStripComboBox1.Text)
                        {
                            case "Red":
                                if (((byte)tmpColor.R & (1 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Red);
                                break;

                            case "Green":
                                if (((byte)tmpColor.G & (1 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Green);
                                break;

                            case "Blue":
                                if (((byte)tmpColor.B & (1 << 0)) != 0)
                                    bMapDecode.SetPixel(irow, icol, Color.Blue);
                                break;

                            case "All":
                                if (((byte)tmpColor.R & (1 << 0)) != 0)
                                    drawColorR = 255;
                                if (((byte)tmpColor.G & (1 << 0)) != 0)
                                    drawColorG = 255;
                                if (((byte)tmpColor.B & (1 << 0)) != 0)
                                    drawColorB = 255;

                                bMapDecode.SetPixel(irow,icol,Color.FromArgb(drawColorR,drawColorG,drawColorB));
                                break;

                        }
                        progressBar1.Value = irow;
                    }
                }

                pictureBox1.Image = bMapDecode;
                progressBar1.Value = 0;

            }
        }

        private void toolStripButtonDecodeImage_Click(object sender, EventArgs e)
        {
            if (bMapOrig != null)
            {
                int bitCounter = 0;
                bool[] bits = new bool[bMapOrig.Width*bMapOrig.Height];
                byte[] bytArr = new byte[bMapOrig.Width * bMapOrig.Height/8];

                for (int irow = 0; irow < bMapOrig.Height; irow++)
                {
                    for (int icol = 0; icol < bMapOrig.Width; icol++)
                    {
                        Color tmpColor = bMapOrig.GetPixel(icol,irow);

                        if (((byte)tmpColor.B & (1 << 0)) != 0)
                            bits[bitCounter] = true;

                        else
                            bits[bitCounter] = false;

                        bitCounter++;
                    }
                    progressBar1.Value = irow;
                }

                progressBar1.Value = 0;
                bytArr = BoolArrayToByteArray(bits);

                foreach (byte b in bytArr)
                {
                    if(b != 0xFF )
                        labelResults.Text += (char)b;
                }

            }


        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (bMapOrig == null)
            {
                toolStripButtonDecode.Enabled = false;
            }

            if (toolStripComboBox1.Text == "Color")
            {
                toolStripButtonDecode.Enabled = false;
            }

            else
            {
                toolStripButtonDecode.Enabled = true;
            }
        }

        private byte[] BoolArrayToByteArray(bool[] bArray)
        {
            int bytes = bArray.Length / 8;
            int bitIndex = 7;
            int byteIndex = 0;

           // if ((bArray.Length % 8) != 0)
            //    bytes++;

            byte[] bytArray = new byte[bytes];

            for (int i = 0; i < bArray.Length; i++)
            {
                if (bArray[i])
                {
                    bytArray[byteIndex] |= (byte)(1 << bitIndex);
                }

                bitIndex--;

                if (bitIndex == -1)
                {
                    bitIndex = 7;
                    byteIndex++;
                }
            }

            return bytArray;
        }

    }
}
