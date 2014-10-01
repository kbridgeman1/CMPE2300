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
    //declares a new delegate that returns nothing, and accepts an int
    public delegate void delVoidInt(int rowNum);

    class DecodatronMethods
    {
        //creates a new delegate of delVoidInt
        public delVoidInt _dCallBackGetInt;

        //Function:     BoolArrayToByteArray
        //Description:  Set each byte in bytArray to represent the bits from boolArray. 
        //Return:       byte[] bytArray - an array of bytes formed from the data in boolArray
        //Parameters:   bool[] boolArray - an array of bools, representing bits
        public byte[] BoolArrayToByteArray(bool[] boolArray)
        {
            int bytes = boolArray.Length / 8;   //int storing the number of bytes in boolArray
            int bitIndex = 7;                   //int tracking the index in the current byte
            int byteIndex = 0;                  //int tracking the index in bytArray

            byte[] bytArray = new byte[bytes];  //byte[] for storing the byte formed from boolArray

            //iterates through each cell boolArray
            for (int i = 0; i < boolArray.Length; i++)
            {
                //checks if the current cell in boolArray is set
                if (boolArray[i])
                    //sets the bit indexed by bitIndex to 1 in the byte indexed by byteIndex
                    bytArray[byteIndex] |= (byte)(1 << bitIndex);

                //decrements bitIndex from the MSB to LSB
                bitIndex--;

                //checks if the bitIndex has reached the end of a byte
                if (bitIndex == -1)
                {
                    //resets the bitIndex to the MSB
                    bitIndex = 7;
                    //increments the byteIndex after a byte has been set
                    byteIndex++;
                }
            }

            //returns the set bytArray
            return bytArray;
        }


        //Function:     OpenFileDialogToBitMap
        //Description:  Opens a new OpenFileDialog and stores the users selection as a bitmap.
        //Return:       Bitmap bMap - a Bitmap for containing the users selected pixel data
        //Parameters:   null
        public Bitmap OpenFileDialogToBitMap(Bitmap bMapOriginal)
        {
            Bitmap bMap;                                        //Bitmap to store the dialog result
            OpenFileDialog openFileDlg = new OpenFileDialog();  //new dialog for selecting a picture

            //sets the initial path for openFileDlg to the users MyPictures folder
            openFileDlg.InitialDirectory
                = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            //sets the file filter for openFileDlg to accept bmp and all files
            openFileDlg.Filter = "Bmp Files|*.bmp|All Files|*.*";

            //displays openFileDlg and checks the dialog result
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                //assigns the dialog file selection to a Bitmap
                bMap = new Bitmap(openFileDlg.FileName);
                //returns the Bitmap
                return bMap;
            }

            //occurs when no picture was selected from the dialog
            else
                return bMapOriginal;
        }


        //Function:     DecodeImage
        //Description:  Iterates through each pixel in bMapOrig inspecting the color specified by the
        //              comboBoxColor. Sets each pixel in bMapDecoded based on the LSB of that color.
        //Return:       Bitmap bMapDecoded   - a Bitmap for new decoded Bitmap
        //Parameters:   Bitmap bMapOriginal  - original Bitmap to be decoded
        //              string comboBoxColor - string containing the user selected color to decode
        public Bitmap DecodeImage(Bitmap bMapOriginal, string comboBoxColor)
        {
            //creates a new Bitmap with the same dimensions as bMapOrig
            Bitmap bMapDecoded = new Bitmap(bMapOriginal.Width, bMapOriginal.Height);

            //checks if bMapOrig has been initialized
            if (bMapOriginal != null)
            {


                //iterates through each pixel in bMapOrig
                for (int irow = 0; irow < bMapOriginal.Height; irow++)
                {
                    for (int icol = 0; icol < bMapOriginal.Width; icol++)
                    {
                        //Color for storing the coloe of the current pixel
                        Color tmpColor = bMapOriginal.GetPixel(icol, irow);     

                        byte drawColorR = 0;        //byte for storing the Red value of a pixel
                        byte drawColorG = 0;        //byte for storing the Green value of a pixel
                        byte drawColorB = 0;        //byte for storing the Blue value of a pixel

                        //checks the comboBox for the users color choice
                        switch (comboBoxColor)
                        {
                            case "Red":
                                //checks if the LSB of the red byte is equal to 1 
                                if (((byte)tmpColor.R & 1) == 1)
                                    //sets the current pixel in bMapDecode to red 
                                    bMapDecoded.SetPixel(icol, irow, Color.Red);
                                else
                                    //sets the current pixel in bMapDecode to black
                                    bMapDecoded.SetPixel(icol, irow, Color.Black);
                                break;

                            case "Green":
                                //checks if the LSB of the green byte is equal to 1
                                if (((byte)tmpColor.G & 1) == 1)
                                    //sets the current pixel in bMapDecode to green
                                    bMapDecoded.SetPixel(icol, irow, Color.Green);
                                else
                                    //sets the current pixel in bMapDecode to black
                                    bMapDecoded.SetPixel(icol, irow, Color.Black);
                                break;

                            case "Blue":
                                //checks if the LSB of the blue byte is equal to 1
                                if (((byte)tmpColor.B & 1) == 1)
                                    //sets the current pixel in bMapDecode to blue
                                    bMapDecoded.SetPixel(icol, irow, Color.Blue);
                                else
                                    //sets the current pixel in bMapDecode to black
                                    bMapDecoded.SetPixel(icol, irow, Color.Black);
                                break;

                            case "All":
                                //checks if the LSB of the red byte is equal to 1
                                if (((byte)tmpColor.R & 1) == 1)
                                    //sets the red byte value to 255
                                    drawColorR = 255;

                                //checks if the LSB of the red byte is equal to 1
                                if (((byte)tmpColor.G & 1) == 1)
                                    //sets the green byte value to 255
                                    drawColorG = 255;

                                //checks if the LSB of the red byte is equal to 1
                                if (((byte)tmpColor.B & 1) == 1)
                                    //sets the blue byte value to 255
                                    drawColorB = 255;

                                //sets the pixel in bMapDecode to a color using the previous color bytes
                                bMapDecoded.SetPixel
                                    (icol, irow, Color.FromArgb(drawColorR, drawColorG, drawColorB));
                                break;

                        }
                        //updates the forms progress bar after iterating through each row
                        if (_dCallBackGetInt != null)
                            _dCallBackGetInt.Invoke(irow);
                    }
                }

            }

            //returns the new Bitmap containing the decoded original image
            return bMapDecoded;
        }


        //Function:     DecodeTextModified
        //Description:  Iterates through each pixel in bMapOrig inspecting the blue color.
        //              Stores the LSB of each byte in a boolean array.
        //Return:       bool[] bits         - bool array containing the blue LSB of each pixel 
        //Parameters:   Bitmap bMapOriginal - original Bitmap to be decoded
        public bool[] DecodeText(Bitmap bMapOriginal)
        {
            List<bool> listBits = new List<bool>();     //each pixel's blue LSB as a bool
            bool[] bits = null;                         //bool array to return the content of listBits

            //checks if bMapOriginal has been initialized
            if (bMapOriginal != null)
            {
                //int used to index the listBits list
                int bitIndex = 0;

                //iterates though each pixel in bMapOriginal
                for (int irow = 0; irow < bMapOriginal.Height; irow++)
                {
                    for (int icol = 0; icol < bMapOriginal.Width; icol++)
                    {
                        //Color for storing the color of the current pixel
                        Color tempColor = bMapOriginal.GetPixel(icol, irow);

                        //checks if the LSB of the blue byte is equal to 1
                        if (((byte)tempColor.B & 1) == 1)
                            //assigns true to the bool indexed at bitIndex
                            listBits.Add(true);

                        //checks if the LSB of the blue byte is not equal to 1
                        else if (((byte)tempColor.B & 1) != 1)
                            //assigns flase to the bool indexed at bitIndex
                            listBits.Add(false);

                        //add one to the number of bits in the array
                        bitIndex++;

                        //checks if the current bitIndex is divisable by 8 (each new byte formed)
                        if (bitIndex % 8 == 0)
                        {
                            byte b = 0;                   //temporary byte to check each set of 8 bits
                            int listIndex = bitIndex - 8; //temporary int to index listBits

                            //forms a byte from MSB to LSB
                            for (int i = 7; i > -1; i--)
                            {
                                if (listBits[listIndex])
                                    b |= (byte)(1 << i);

                                listIndex++;
                            }

                            //checks the byte to make sure it is a english character
                            if ((b == byte.MaxValue) || b < 32 || b > 122)
                            {
                                bits = listBits.ToArray();
                                return bits;
                            }
                        }

                    }

                    //updates the forms progress bar after iterating through each row
                    if (_dCallBackGetInt != null)
                        _dCallBackGetInt.Invoke(irow);
                }

            }

            //if all bytes were accepted as english characters, return the list as a 
            bits = listBits.ToArray();
            return bits;
        }

    }
}
