using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace KurtisBridgeman_Drawers
{
    public class MyRandom : Random
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

    public class RectDrawer : GDIDrawer.CDrawer
    {
        MyRandom myRND;
        List<Rectangle> lRect;

        public RectDrawer(int cWidth = 600, int cHeight = 300)
            : base(cWidth, cHeight, false, false)
        {
            myRND = new MyRandom(ScaledWidth / 5);
            BBColour = Color.White;

            lRect = new List<Rectangle>();

            for (int i = 0; i < 20; i++)
                lRect.Add(myRND.NextDrawerRect(this));
        }

        new public void Clear()
        {
            base.Clear();

            foreach (Rectangle rect in lRect)
                AddRectangle(rect.X, rect.Y, rect.Width, rect.Height, Color.Transparent, 2, Color.Blue);
        }

        new public void Render()
        {
            AddText(String.Format("{0}x{1} of {2}", ScaledWidth, ScaledHeight, GetType().Name), 20, 0, 0, 300, 50, Color.Red);

            base.Render();
        }
    }

    public class PicDrawer : GDIDrawer.CDrawer
    {
        public PicDrawer(Image img)
            : base(img.Width, img.Height, false, false)
        {
            Bitmap bMap = new Bitmap(img);
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

        }

        new public void Render()
        {
            AddText(String.Format("{0}x{1} of {2}", ScaledWidth, ScaledHeight, GetType().Name), 20, 0, 0, 300, 50, Color.Red);

            base.Render();
        }
    }
}
