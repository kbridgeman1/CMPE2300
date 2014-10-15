using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA08
{
    class Sheeple
    {
        //static variables
        public static Random Rand = new Random();

        //instance properties auto
        public int ItemsTotal { get; set; }
        public int ItemsRemain { get; set; }
        public int SheepleColor { get; set; }

        //instance properties manual
        public bool Done
        {
            get
            {
                if (ItemsRemain == 0)
                    return true;

                else
                    return false;
            }
        }

        //default constructor
        public Sheeple()
        {
            ItemsTotal = Rand.Next(2, 6);
            ItemsRemain = ItemsTotal;
            SheepleColor = RandColor.GetColor().ToArgb();
        }

        //instance method
        public void Process()
        {
            ItemsRemain--;
        }

    }
}
