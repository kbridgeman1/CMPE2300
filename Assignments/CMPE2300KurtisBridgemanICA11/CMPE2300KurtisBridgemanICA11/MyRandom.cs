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

        public RectDrawer()
        {
            
        }

    }



}
