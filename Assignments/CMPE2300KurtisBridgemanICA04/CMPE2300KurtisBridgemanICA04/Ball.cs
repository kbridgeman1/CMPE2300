using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA04
{
    class Ball
    {
        //static variables
        static private CDrawer canvas = null;
        static private Random rnd = new Random();

        //instance variables
        private Color _ballColor;
        private int _ballRadius;
        private Point _ballLocation;


        //static properties
        public static bool Loading
        {
            set
            {
                if (value)
                    canvas.Clear();

                if (!value)
                    canvas.Render();
            }
        }

        //instance properties
        public int Radius
        {
            set { _ballRadius = Math.Abs(value); }
        }


        //static constructors
        static Ball()
        {
            canvas = new CDrawer(800, 600, false, false);
        }

        //instance constructor
        public Ball(int ballRad)
        {
            Radius = ballRad;
            _ballColor = RandColor.GetColor();
            _ballLocation = new Point(rnd.Next(_ballRadius, canvas.ScaledWidth - _ballRadius), rnd.Next(_ballRadius, canvas.ScaledHeight - _ballRadius));

        }


        //instance methods
        public void AddBall()
        {
            if (_ballRadius > 0)
                canvas.AddCenteredEllipse(_ballLocation.X, _ballLocation.Y, _ballRadius * 2, _ballRadius * 2, _ballColor, _ballRadius / 10, Color.White);
        }

        //override functions
        public override bool Equals(object obj)
        {
            if (!(obj is Ball))
                return false;

            Ball testBall = (Ball)obj;

            if (Math.Sqrt((Math.Pow((_ballLocation.X - testBall._ballLocation.X), 2)) + (Math.Pow((_ballLocation.Y - testBall._ballLocation.Y), 2))) <= _ballRadius + testBall._ballRadius)
                return true;

            else
                return false;
        }


        public override int GetHashCode()
        {
            return 1;
        }

    }
}
