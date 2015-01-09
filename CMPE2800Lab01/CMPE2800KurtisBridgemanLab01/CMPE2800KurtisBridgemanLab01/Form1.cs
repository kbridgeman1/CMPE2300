using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using GDIDrawer;


namespace CMPE2800KurtisBridgemanLab01
{
    public partial class Form1 : Form
    {
        static CDrawer canvas;
        Color[,] colArray;
        Thread m_tThread;
        volatile bool dirtFlg;
        object lockObj = new object();

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

            DrawGridLines();

            m_tThread = new Thread(Rendering);
            m_tThread.IsBackground = true;
            m_tThread.Start();

            m_tThread = new Thread(Clicking);
            m_tThread.IsBackground = true;
            m_tThread.Start();
        }

        //checks the dirty flag, if true, clears/renders our drawer then sets dirty flag to false
        private void Rendering()
        {
            System.Diagnostics.Trace.WriteLine("Rendering Started");

            do
            {
                if (dirtFlg)
                {

                    Color[,] tColorArr = colArray as Color[,];

                    lock (lockObj)
                    {
                        canvas.Clear();
                        for (int iR = 0; iR < canvas.ScaledHeight; iR++)
                            for (int iC = 0; iC < canvas.ScaledWidth; iC++)
                                canvas.SetBBScaledPixel(iC, iR, tColorArr[iC, iR]);

                        DrawGridLines();
                    }

                    dirtFlg = false;
                }

                Thread.Sleep(1);

            } while (true);

            System.Diagnostics.Trace.WriteLine("Rendering Ended");
        }


        private void Clicking(object ob)
        {
            System.Diagnostics.Trace.WriteLine("Clicking Started");
            Point msCLocation;

            do
            {
                lock (lockObj)
                    if (canvas.GetLastMouseLeftClickScaled(out msCLocation)
                     && (colArray[msCLocation.X, msCLocation.Y] == Color.Salmon))
                    {
                        colArray[msCLocation.X, msCLocation.Y] = Color.Green;
                        dirtFlg = true;
                    }

                lock (lockObj)
                    if (canvas.GetLastMouseRightClickScaled(out msCLocation)
                     && (colArray[msCLocation.X, msCLocation.Y] == Color.Green))
                    {
                        colArray[msCLocation.X, msCLocation.Y] = Color.Salmon;
                        dirtFlg = true;
                    }

                Thread.Sleep(1);

            } while (true);

            System.Diagnostics.Trace.WriteLine("Clicking Ended");
        }

        private void Moving()
        {
            Point msLocation;

            do
            {
                canvas.GetLastMousePosition(out msLocation);



                Thread.Sleep(1);

            } while (true);
        }



        //helper methods
        private void DrawGridLines()
        {
            for (int i = 0; i < canvas.ScaledWidth; i++)
                canvas.AddLine(i, 0, i, canvas.ScaledWidth, Color.Black, 1);

            for (int i = 0; i < canvas.ScaledHeight; i++)
                canvas.AddLine(0, i, canvas.ScaledWidth, i, Color.Black, 1);

            canvas.Render();
        }

    }
}
