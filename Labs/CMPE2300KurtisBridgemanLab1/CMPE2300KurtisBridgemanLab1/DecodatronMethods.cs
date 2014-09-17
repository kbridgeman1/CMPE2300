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
    class DecodatronMethods
    {
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
        //parameters:   null
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
                bMap = new Bitmap(openFileDlg.FileName);
                return bMap;
            }

            else
                return null;
        }


    }
}
