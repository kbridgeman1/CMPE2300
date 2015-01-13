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
    public delegate void delVoidPointInt(Point pt, int aCount);

    public partial class Form1 : Form
    {
        static CDrawer canvas;
        static Color[,] colArray;
        static List<Point> liPoint;
        volatile bool dFlag = true;
        object lockObj = new object();
        object lockFlg = new object();

        public Form1()
        {
            InitializeComponent();

            canvas = new CDrawer(bContinuousUpdate: false);
            canvas.Scale = 20;

            liPoint = new List<Point>();

            colArray = new Color[canvas.ScaledHeight, canvas.ScaledWidth];
            for (int iR = 0; iR < canvas.ScaledHeight; iR++)
                for (int iC = 0; iC < canvas.ScaledWidth; iC++)
                    colArray[iR, iC] = Color.Salmon;

            InitThreadsBackground();
        }

        //checks the dirty flag, if true, clears/renders our drawer then sets dirty flag to false
        private void Rendering()
        {
            System.Diagnostics.Trace.WriteLine("Rendering Started");

            while (true)
            {
                if (dFlag)
                {
                    lock (lockObj)
                        RenderGrid(canvas, colArray);

                    lock (lockFlg)
                        dFlag = false;
                }

                Thread.Sleep(1);
            }

        }


        private void Clicking()
        {
            System.Diagnostics.Trace.WriteLine("Clicking Started");
            Point msCLocation;

            while (true)
            {
                if (canvas.GetLastMouseLeftClickScaled(out msCLocation))
                {
                    lock (lockObj)
                        if (colArray[msCLocation.Y, msCLocation.X] == Color.Salmon)
                            colArray[msCLocation.Y, msCLocation.X] = Color.Green;

                    lock (lockFlg)
                        dFlag = true;
                }

                if (canvas.GetLastMouseRightClickScaled(out msCLocation))
                {
                    lock (lockObj)
                        if (colArray[msCLocation.Y, msCLocation.X] == Color.Green)
                            colArray[msCLocation.Y, msCLocation.X] = Color.Salmon;

                    lock (lockFlg)
                        dFlag = true;
                }

                Thread.Sleep(1);
            }

        }

        private void Moving()
        {
            Point msLocation;
            int adjCount;

            while (true)
            {
                canvas.GetLastMousePositionScaled(out msLocation);

                adjCount = 0;
                liPoint.Clear();
                Color[,] colArrayCopy = (Color[,])colArray.Clone();

                if (msLocation.X >= 0 && msLocation.Y >= 0)
                    RecursiveCheck(ref adjCount, msLocation.X, msLocation.Y, colArrayCopy[msLocation.Y, msLocation.X], colArrayCopy);

                UpdateFormText(msLocation, adjCount);

                Thread.Sleep(1);
            }
        }

        private void UpdateFormText(Point msLocation, int adjCount)
        {
            if (textBoxStatus.InvokeRequired)
            {
                delVoidPointInt _dUpdateFormText = new delVoidPointInt(UpdateFormText);
                Invoke(_dUpdateFormText, new object[] { msLocation, adjCount });
            }

            else
                textBoxStatus.Text = String.Format("Block: {{X={0},Y={1}}}, {2} adjacent blocks.", msLocation.X, msLocation.Y, adjCount);
        }

        //helper methods
        private static void RenderGrid(CDrawer canvas, Color[,] colAr)
        {
            canvas.Clear();

            for (int iR = 0; iR < canvas.ScaledHeight; iR++)
                for (int iC = 0; iC < canvas.ScaledWidth; iC++)
                    canvas.SetBBScaledPixel(iC, iR, colAr[iR, iC]);

            for (int i = 0; i < canvas.ScaledWidth; i++)
                canvas.AddLine(i, 0, i, canvas.ScaledWidth, Color.Black, 1);

            for (int i = 0; i < canvas.ScaledHeight; i++)
                canvas.AddLine(0, i, canvas.ScaledWidth, i, Color.Black, 1);

            canvas.Render();
        }


        private void InitThreadsBackground()
        {
            Thread m_tThread;

            m_tThread = new Thread(Rendering);
            m_tThread.IsBackground = true;
            m_tThread.Start();

            m_tThread = new Thread(Clicking);
            m_tThread.IsBackground = true;
            m_tThread.Start();

            m_tThread = new Thread(Moving, 200000);
            m_tThread.IsBackground = true;
            m_tThread.Start();
        }


        private void RecursiveCheck(ref int aCount, int xCoord, int yCoord, Color matchColor, Color[,] colArr)
        {
            if (liPoint.Contains(new Point(xCoord, yCoord)))
                return;

            if (xCoord < 0 || xCoord >= canvas.ScaledWidth || yCoord < 0 || yCoord >= canvas.ScaledHeight)
                return;

            if (colArray[yCoord, xCoord] != matchColor)
                return;

            liPoint.Add(new Point(xCoord, yCoord));

            aCount++;

            if (xCoord - 1 >= 0)
                RecursiveCheck(ref aCount, xCoord - 1, yCoord, matchColor, colArr);

            if (yCoord - 1 >= 0)
                RecursiveCheck(ref aCount, xCoord, yCoord - 1, matchColor, colArr);

            if (xCoord + 1 < canvas.ScaledWidth)
                RecursiveCheck(ref aCount, xCoord + 1, yCoord, matchColor, colArr);

            if (yCoord + 1 < canvas.ScaledHeight)
                RecursiveCheck(ref aCount, xCoord, yCoord + 1, matchColor, colArr);

            return;
        }

    }
}
