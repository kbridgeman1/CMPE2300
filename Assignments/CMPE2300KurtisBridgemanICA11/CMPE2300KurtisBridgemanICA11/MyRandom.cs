using System;
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

        public MyRandom(int maxsize)
            : base(maxsize)
        {
            MaxSize = maxsize;
        }

        public Rectangle NextDrawerRect(CDrawer canv)
        {
            int rWidth = Next(10, MaxSize);
            int rHeight = Next(10, MaxSize);

            return new Rectangle(Next(0, canv.ScaledWidth - rWidth),
                Next(0, canv.ScaledHeight - rHeight), rWidth, rHeight);
        }

    }

    class RectDrawer : GDIDrawer.CDrawer
    {
        MyRandom myRND;

        public RectDrawer()
            : base(800, 400, false, false)
        {
            myRND = new MyRandom(ScaledWidth / 5);
            BBColour = Color.White;

            for (int i = 0; i < 100; i++)
            {
                Rectangle tRect = myRND.NextDrawerRect(this);
                AddRectangle(tRect.X, tRect.Y, tRect.Width, tRect.Height, RandColor.GetKnownColor());
            }

            //   List<Rectangle> lRect = new List<Rectangle>();

            //     for (int i = 0; i < 100; i++)
            //         lRect.Add(myRND.NextDrawerRect(this));

            //   foreach (Rectangle rect in lRect)
            //       AddRectangle(rect.X, rect.Y, rect.Width, rect.Height, RandColor.GetKnownColor());

            Render();
        }

    }

    class PicDrawer : GDIDrawer.CDrawer
    {
        public PicDrawer()
            : base(Properties.Resources.ImageInImageMedium.Width, Properties.Resources.ImageInImageMedium.Height, false, false)
        {
            Bitmap bMap = Properties.Resources.ImageInImageMedium;
            Color pixelColor;

            for (int iRow = 0; iRow < bMap.Height; iRow++)
                for (int iCol = 0; iCol < bMap.Width; iCol++)
                {
                    pixelColor = bMap.GetPixel(iCol, iRow);
                    double red = pixelColor.R;
                    double green = pixelColor.G;
                    double blue = pixelColor.B;
                    int rgb = (int)Math.Round(((red + green + blue) / 3), 0);

                    SetBBScaledPixel(iCol, iRow, Color.FromArgb(rgb, rgb, rgb));
                }

            Render();
        }

    }



}
