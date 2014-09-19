//*****************************************************************************************************
//Program:    Lab 01 - Decodatron
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
        //open file dialog to select an image. The user selected image is assiged to bMapOrig.
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

                //displays bMapOrig in the forms picturebox
                pictureBox1.Image = bMapOrig;

                //sets the max progressbar value to with width of bMapOrig
                progressBar1.Maximum = bMapOrig.Width;

                //enables the "Decode Text" button
                toolStripButtonDecodeImage.Enabled = true;

                //clears the text in labelResults
                labelResults.Text = "";
            }

        }

        //Occurs when the user presses the "Decode Image" toolstrip button. 
        //Calls DecodeImage and displays the returned Bitmap in pictureBox1.
        private void toolStripButtonDecodeImage_Click(object sender, EventArgs e)
        {
            //assigns the CallBackGetInt method to the _dCallBackGetInt delegate
            dm._dCallBackGetInt = CallBackGetInt;

            //calls DecodeImage and assigns the returned value to bMapDecode
            bMapDecode = dm.DecodeImage(bMapOrig, toolStripComboBox1.Text);

            //displays bMapDecode in the forms picturebox
            pictureBox1.Image = bMapDecode;

            //resets the progress bar's value
            progressBar1.Value = progressBar1.Minimum;

        }

        //Occurs when the usesr presses the "Decode Text" toolstrip button. 
        //Casts each byte from a byte array as a char and adds it the forms label.
        private void toolStripButtonDecodeText_Click(object sender, EventArgs e)
        {
            bool[] bits = null;     //bit array used to store blue LSB of each pixel
            byte[] bytes = null;    //byte array where each byte will be the data of a character

            //assigns the CallBackGetInt method to the _dCallBackGetInt delegate
            dm._dCallBackGetInt = CallBackGetInt;

            //clears LabelResults text property when the DecodeText tooltip button is pressed
            labelResults.Text = "";

            //calls DecodeText and assigns the returned bool array to bits
            bits = dm.DecodeTextModified(bMapOrig);

            //calls BoolArrayToByteArray and assigns the returned byte array to bytes
            bytes = dm.BoolArrayToByteArray(bits);

            //iterates through each byte in bytes
            foreach (byte b in bytes)
            {
                //checks if the value of the byte is 0xFF
                if (b != byte.MaxValue)
                    //cast the byte as char and add it to the forms label
                    labelResults.Text += (char)b;
            }

            //occurs if the first character added to bytes was not an english ascii character 
            if (bytes.Length <= 1)
                //sets the labelResults text property to reflect this
                labelResults.Text += "There is no text encoded in this image.";

            //resets the progress bar's value
            progressBar1.Value = progressBar1.Minimum;

        }

        //Occurs when the forms comboBox has it's text changed. Enables/disables form controls based
        //on whether or not a color or image have been selected.
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

        //Callback method for setting the progress bar's value through a delegate
        private void CallBackGetInt(int _rowNum)
        {
            //sets progressBar1's value to the int passed in from the delegate 
            progressBar1.Value = _rowNum;
        }


    }
}
