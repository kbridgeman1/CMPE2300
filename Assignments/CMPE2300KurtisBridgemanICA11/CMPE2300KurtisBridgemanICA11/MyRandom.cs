﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA11
{
    class MyRandom : Random
    {
        protected int MaxSize;

        public MyRandom(int maxsize) : base(maxsize) { }

        public Rectangle NextDrawerRect(CDrawer canv)
        {
            int rWidth = Next(10, canv.ScaledWidth);
            int rHeight = Next(10, canv.ScaledHeight);
            return new Rectangle(Next(0, canv.ScaledWidth - rWidth), Next(0, canv.ScaledHeight - rHeight), rWidth, rHeight);
        }

    }


    class RectDrawer : GDIDrawer.CDrawer
    {
        MyRandom myRND;
        List<Rectangle> lRect = new List<Rectangle>();

        public RectDrawer()
            : base(800, 400, false, false)
        {
            myRND = new MyRandom(base.ScaledWidth / 5);
            BBColour = Color.White;

            for (int i = 0; i < 100; i++)
                lRect.Add(myRND.NextDrawerRect(this));

            foreach (Rectangle rect in lRect)
                AddRectangle(rect.X, rect.Y, rect.Width, rect.Height, RandColor.GetKnownColor());
        }

    }

    class PicDrawer : GDIDrawer.CDrawer
    {
        public PicDrawer()
            : base(Properties.Resources.chrysanthemum_koala.Width, Properties.Resources.chrysanthemum_koala.Height, false, false)
        {
            Bitmap bMap = Properties.Resources.chrysanthemum_koala;

            Color pixelColor;
            for (int iRow = 0; iRow<bMap.Width;iRow++)
                for (int iCol = 0; iCol < bMap.Height; iCol++)
                {
                    pixelColor = bMap.GetPixel(iCol, iRow);
                    bMap.SetPixel(iCol,iRow, Color.FromArgb(pixelColor.R + pixelColor.G + pixelColor.B / 3));
                      
                }
        }

    }



}
