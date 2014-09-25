﻿//*****************************************************************************************************
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
            int bytes = boolArray.Length / 8;   //int for storing the number of bytes required to represent boolArray
            int bitIndex = 7;                   //int for tracking the index in the current byte
            int byteIndex = 0;                  //int for tracking the index in bytArray

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
        public Bitmap OpenFileDialogToBitMap()
        {
            Bitmap bMap;                                        //Bitmap for storing the openFileDlg result
            OpenFileDialog openFileDlg = new OpenFileDialog();  //OpenFileDialog for providing the user friendly file selection

            //sets the initial path for openFileDlg to the users MyPictures folder
            openFileDlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

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
                //returns null in this case
                return null;
        }


        //Function:     DecodeImage
        //Description:  Iterates through each pixel in bMapOrig inspecting the color specified by the comboBoxColor.
        //              Sets each pixel in bMapDecoded based on the LSB of the specified color.
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
                        Color tmpColor = bMapOriginal.GetPixel(icol, irow);     //Color for storing the coloe of the current pixel

                        byte drawColorR = 0;                                    //byte for storing the Red value of a pixel
                        byte drawColorG = 0;                                    //byte for storing the Green value of a pixel
                        byte drawColorB = 0;                                    //byte for storing the Blue value of a pixel

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
                                bMapDecoded.SetPixel(icol, irow, Color.FromArgb(drawColorR, drawColorG, drawColorB));
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


        //Function:     DecodeText
        //Description:  Iterates through each pixel in bMapOrig inspecting the blue color.
        //              Stores the LSB of each byte in a boolean array.
        //Return:       bool[] bits         - bool array containing the blue LSB of each pixel 
        //Parameters:   Bitmap bMapOriginal - original Bitmap to be decoded
        public bool[] DecodeText(Bitmap bMapOriginal)
        {
            //a new bool[] for storing the blue LSB of each pixel 
            bool[] bits = new bool[bMapOriginal.Width * bMapOriginal.Height];

            //checks if bMapOrig has been initialized
            if (bMapOriginal != null)
            {
                //int used to index the bits array
                int bitIndex = 0;

                //iterates though each pixel in bMapOrig
                for (int irow = 0; irow < bMapOriginal.Height; irow++)
                {
                    for (int icol = 0; icol < bMapOriginal.Width; icol++)
                    {
                        //Color for storing the color of the current pixel
                        Color tmpColor = bMapOriginal.GetPixel(icol, irow);

                        //checks if the LSB of the blue byte is equal to 1
                        if (((byte)tmpColor.B & 1) == 1)
                            //assigns true to the bool indexed at bitIndex
                            bits[bitIndex] = true;

                        //add one to the number of bits in the array
                        bitIndex++;
                    }

                    //updates the forms progress bar after iterating through each row
                    if (_dCallBackGetInt != null)
                        _dCallBackGetInt.Invoke(irow);
                }

            }

            //returns the bool[] containing the blue LSB of each pixel
            return bits;
        }

        //Function:     DecodeTextModified
        //Description:  Iterates through each pixel in bMapOrig inspecting the blue color.
        //              Stores the LSB of each byte in a boolean array.
        //Return:       bool[] bits         - bool array containing the blue LSB of each pixel 
        //Parameters:   Bitmap bMapOriginal - original Bitmap to be decoded
        public bool[] DecodeTextModified(Bitmap bMapOriginal)
        {
            List<bool> listBits = new List<bool>();     //a new list of bool to store each pixel's blue LSB
            bool[] bits = null;                         //a bool array of unknown size, will be assigned the data contained in ListBits

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
                            byte b = 0;                         //temporary byte used to check the character formed from each set of 8 bits
                            int listIndex = bitIndex - 8;       //temporary int used to index listBits

                            for (int i = 7; i > -1; i--)
                            {
                                if (listBits[listIndex])
                                    b |= (byte)(1 << i);

                                listIndex++;
                            }

                            if (((char)b == byte.MaxValue) || b < 32|| b > 122)
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
            bits = listBits.ToArray();
            return bits;
        }

    }
}