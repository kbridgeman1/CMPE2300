using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA07
{
    class Block : IComparable
    {
        //static variables
        private static Random _Random = new Random(1);

        //static properties
        public static CDrawer Canvas { get; private set; }
        public static int Height { get; private set; }
        public static int HighlightWidth { get; set; }


        //instance properties
        public int Width { get; set; }
        public bool Highlight { get; set; }

        //instance variables
        private Color _color;

        //static constructor
        static Block()
        {
            Height = 20;
            HighlightWidth = 0;
            Canvas = new CDrawer(bContinuousUpdate: false);
            Canvas.BBColour = Color.White;
        }

        //instance constructor
        public Block()
        {
            Width = _Random.Next(1, 19) * 10;
            Highlight = false;
            _color = Color.FromArgb(_Random.Next(2, 8) * 32, _Random.Next(2, 8) * 16, _Random.Next(2, 8) * 16);
        }

        //override functions
        public override bool Equals(object obj)
        {
            if (!(obj is Block))
                return false;

            Block tempBlock = obj as Block;

            if (tempBlock.Width == this.Width && tempBlock._color == this._color)
                return true;

            else
                return false;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        //extension methods
        public int CompareTo(object obj)
        {
            if (!(obj is Block))
                throw new Exception("not is block");

            Block tBlock = obj as Block;

            int compI = 0;

            compI = _color.ToArgb() - tBlock._color.ToArgb();

            return compI;

        }

        public static int CompareWidth(Block arg1, Block arg2)
        {
            return arg1.Width.CompareTo(arg2.Width);
        }

        public static int CompareWidthDesc(Block arg1, Block arg2)
        {
            return arg2.Width.CompareTo(arg1.Width);
        }

        public static int CompareWidthThenCol(Block arg1, Block arg2)
        {
            int compI = 0;

            compI = arg1.Width - arg2.Width;

            if (compI != 0)
                return compI;
            
            else
                compI = arg1._color.ToArgb() - arg2._color.ToArgb();

            return compI;
        }

        //predicates
        public static bool BrightEnough(Block arg)
        {
            return arg._color.GetBrightness() > 0.5;
        }

        public static bool LongEnough(Block arg)
        {
            return arg.Width > 100;
        }

        public static bool CloseEnough(Block arg)
        {
            if (arg.Width > HighlightWidth - 10 && arg.Width < HighlightWidth + 10)
            {
                return true;
            }

            else
                return false;
        }


        //public methods
        public void ShowBlock(Point startPoint)
        {
            if(Highlight==true)
                Canvas.AddRectangle(startPoint.X, startPoint.Y, Width, Height, _color, 2, Color.Yellow);

            else
                Canvas.AddRectangle(startPoint.X, startPoint.Y, Width, Height, _color, 1, Color.Black);
        }


    }
}
