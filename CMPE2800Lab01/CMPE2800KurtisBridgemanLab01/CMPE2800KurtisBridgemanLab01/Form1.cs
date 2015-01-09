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

namespace CMPE2800KurtisBridgemanLab01
{
    public partial class Form1 : Form
    {
        CDrawer canvas;
        Color[,] colArray;
        volatile bool dirtFlg;
        object lockObj =  new object();

        public Form1()
        {
            InitializeComponent();

            canvas = new CDrawer(bContinuousUpdate: false);
            canvas.Scale = 100;
            canvas.BBColour = Color.Salmon;
            

            colArray = new Color[canvas.ScaledWidth, canvas.ScaledHeight];
            for (int iR = 0; iR < canvas.ScaledHeight; iR++)
                for (int iC = 0; iC < canvas.ScaledWidth; iC++)
                    colArray[iC, iR] = Color.Salmon;

            for (int i = 0; i < canvas.ScaledWidth; i++)
                canvas.AddLine(i, 0, i, canvas.ScaledWidth, Color.Black, 1);

            for (int i = 0; i < canvas.ScaledHeight; i++)
                canvas.AddLine(0, i, canvas.ScaledWidth, i, Color.Black, 1);


            canvas.Render();
        }

        //checks the dirty flag, if true, clears/renders our drawer then sets dirty flag to false
        private void Rendering(object colorArr)
        {
            do
            {
                if (dirtFlg)
                {
                    lock (lockObj)
                    {
                        Color[,] tColorArr = colorArr as Color[,];

                        canvas.Clear();
                        for (int iR = 0; iR < canvas.ScaledHeight; iR++)
                            for (int iC = 0; iC < canvas.ScaledWidth; iC++)
                                canvas.SetBBScaledPixel(iC, iR, tColorArr[iC, iR]);

                        canvas.Render();
                        dirtFlg = false;
                    }
                }

                System.Threading.Thread.Sleep(1);

            } while (true);
        }






    }
}
