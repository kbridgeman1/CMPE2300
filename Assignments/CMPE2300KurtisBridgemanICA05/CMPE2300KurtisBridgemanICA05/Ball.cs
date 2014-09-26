using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA05
{
    


    class Ball : IComparable
    {
        //enums
        public enum ESortType { eRadius, eDistance, eColor }
        //static private ESortType eSort;


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

                else
                    canvas.Render();
            }
        }

        //static properties
        public static ESortType CompareType { get; set; }



        //instance properties
        public int Radius
        {
            set { _ballRadius = Math.Abs(value); }
        }


        //static constructors
        static Ball()
        {
            canvas = new CDrawer(rnd.Next(600,901), rnd.Next(500,801), false, false);
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

        public int CompareTo(object obj)
        {
            if (!(obj is Ball))
                throw new ArgumentException("Not a valid Ball, or is null");

            Ball tempBall = obj as Ball;
            int itemp = 0;

            switch (Ball.CompareType)
            {
                case ESortType.eRadius:
                    itemp = _ballRadius - tempBall._ballRadius;
                    break;

                case ESortType.eDistance:
                    itemp = Math.Sign(Math.Sqrt((Math.Pow((0 - _ballLocation.X), 2)) + (Math.Pow((0 - _ballLocation.Y), 2))) - Math.Sqrt((Math.Pow((0 - tempBall._ballLocation.X), 2)) + (Math.Pow((0 - tempBall._ballLocation.Y), 2))));
                    break;

                case ESortType.eColor:
                    itemp = _ballColor.ToArgb() - tempBall._ballColor.ToArgb();
                    break;

            }

            return itemp;

        }

    }
}
