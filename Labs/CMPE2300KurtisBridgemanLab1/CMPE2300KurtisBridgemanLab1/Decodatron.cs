//*****************************************************************************************************
//Program:    Lab 01 - Decodatron.cs
//Author:     Kurtis Bridgeman
//Class:      CMPE2300
//*****************************************************************************************************

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
        private Bitmap bMapOrig;                                //BitMap used to store the user selected image
        private Bitmap bMapDecode;                              //BitMap used to store the decoded image
        private DecodatronMethods dm = new DecodatronMethods(); //DecodatronMethods object used to call methods from seperate class


        public FormImageSecrets()
        {
            InitializeComponent();
        }

        //Occurs when the user presses the "Load Image" toolstrip button. Provides the user with an
        //open file dialog to select a image. The user selected image is assiged to bMapOrig.
        private void toolStripButtonLoadImage_Click(object sender, EventArgs e)
        {
            //creates a new OpenFileDialog and returns a user selected BitMap
            bMapOrig = dm.OpenFileDialogToBitMap();

            //checks if bMapOrig has been initialized
            if (bMapOrig != null)
            {
                //checks if the combobox has been changed from its initial value
                if (toolStripComboBox1.Text != "")
                    //enables the "Decode Image" button
                    toolStripButtonDecode.Enabled = true;

                //displays BMapOrig in the forms picturebox
                pictureBox1.Image = bMapOrig;

                //sets the max progressbar value to with width of bMapOrig
                progressBar1.Maximum = bMapOrig.Width;

                //enables the "Decode Text" button
                toolStripButtonDecodeImage.Enabled = true;

                //clears the text in labelResults
                labelResults.Text = "";
            }

        }

        //Occurs when the user presses the "Decode Image" toolstrip button. Iterates through each
        //pixel in bMapOrig inspecting the color specified by the comboBox. Sets each pixel in bMapDecode
        //based on the LSB of the specified color.
        private void toolStripButtonDecodeImage_Click(object sender, EventArgs e)
        {
            dm._dCallBackGetInt = CallBackGetInt;
            bMapDecode = dm.DecodeImage(bMapOrig, toolStripComboBox1.Text);

            //displays bMapDecode in the forms picturebox
            pictureBox1.Image = bMapDecode;

            //resets the progress bar
            progressBar1.Value = progressBar1.Minimum;

        }


        //Occurs when the usesr presses the "Decode Text" toolstrip button. Iterates through each
        //pixel in bMapOrig inspecting the blue color. Stores the LSB of each byte in a boolean array.
        //Casts each byte from a byte array as a char and adds it the forms label.
        private void toolStripButtonDecodeText_Click(object sender, EventArgs e)
        {
            //checks if bMapOrig has been initialized
            if (bMapOrig != null)
            {
                bool[] bits = new bool[bMapOrig.Width * bMapOrig.Height];   //bool array for storing bits
                int bitIndex = 0;                                           //int used to index the bits array

                //iterates though each pixel in bMapOrig
                for (int irow = 0; irow < bMapOrig.Height; irow++)
                {
                    for (int icol = 0; icol < bMapOrig.Width; icol++)
                    {
                        Color tmpColor = bMapOrig.GetPixel(icol, irow);     //Color for storing the coloe of the current pixel

                        //checks if the LSB of the blue byte is equal to 1
                        if (((byte)tmpColor.B & 1) == 1)
                            //assigns true to the bool indexed at bitIndex
                            bits[bitIndex] = true;

                        //add one to the number of bits in the array
                        bitIndex++;
                    }

                    //updates the forms progress bar after iterating through each row
                    progressBar1.Value = irow;
                }

                //resets the progress bar
                progressBar1.Value = progressBar1.Minimum;

                //iterates through each byte in a byte array returned by BoolArrayToByteArray()
                foreach (byte b in dm.BoolArrayToByteArray(bits))
                {
                    //checks if the value of the byte is 0xFF
                    if (b != byte.MaxValue)
                        //cast the byte as char and add it to the forms label
                        labelResults.Text += (char)b;
                }

            }

        }

        //Occurs when the forms comboBox has it's text changed. Enables/disables form controls based
        //on whether a color or image have been selected.
        private void toolStripComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            //checks if toolStripComboBox1 has it's defualt text or bMapOrig is uninitialized
            if (toolStripComboBox1.Text == "" || bMapOrig == null)
                //sets the "Decode Image" button to be disabled
                toolStripButtonDecode.Enabled = false;

            else
                //sets the "Decode Image" button to be enabled
                toolStripButtonDecode.Enabled = true;
        }

        private void CallBackGetInt(int _rowNum)
        {
            progressBar1.Value = _rowNum;
        }

        
    }
}
