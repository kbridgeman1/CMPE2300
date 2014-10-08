using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA07
{
    class Block
    {
        //static variables
        private static Random _Random = new Random(1);

        //static properties
        public static CDrawer Canvas { get; private set; }
        public static int Height { get; private set; }
        public static int HighlightWith { get; set; }
        
        //instance properties
        public int Width { get; set; }
        public bool Highlight { get; set; }

        //instance variables
        private Color _color;
        
        //static constructor
        public static Block()
        {
            Height = 20;
            HighlightWith = 0;
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

        //public methods
        public void ShowBlock(Point startPoint)
        {
            if(Highlight == false)
                Canvas.AddRectangle(startPoint.X, startPoint.Y, Width, Height, _color, 1, Color.Black);

            else
                Canvas.AddRectangle(startPoint.X, startPoint.Y, Width, Height, _color, 2, Color.Yellow);
        }


    }
}
