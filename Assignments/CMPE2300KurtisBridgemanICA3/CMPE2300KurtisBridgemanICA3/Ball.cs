using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA3
{
    class Ball
    {
        //static variables
        static Random rnd = new Random();
        static CDrawer canvas = null;
        static int ballRadius;

        //member variables
        private Color _ballColor;
        private Point _ballLocation;
        private int _xVel;
        private int _yVel;
        private int _iAlive = rnd.Next(50, 128);

        //properties
        public static int Radius
        {
            set { ballRadius = Math.Abs(value); }
        }

        public static bool Loading
        {
            set
            {
                if (value == true)
                {
                    canvas.Clear();
                }

                if (value == false)
                {
                    canvas.Render();
                }
            }
        }

        //static constructor
        static Ball()
        {
            canvas = new CDrawer(rnd.Next(600,901), rnd.Next(500,801), false, false);
            ballRadius = rnd.Next(10, 81);
        }

        //constructor
        public Ball()
        {
            _ballColor = RandColor.GetColor();
            _xVel = rnd.Next(-10, 11);
            _yVel = rnd.Next(-10, 11);
            _ballLocation = new Point(rnd.Next(ballRadius*2, canvas.ScaledWidth-ballRadius*2), rnd.Next(ballRadius*2, canvas.ScaledHeight-ballRadius*2));
        }

        //methods
        public void ShowBall()
        {
            canvas.AddCenteredEllipse(_ballLocation.X, _ballLocation.Y, ballRadius * 2, ballRadius * 2, Color.FromArgb(_iAlive,_ballColor));
        }

        public void MoveBall()
        {
            if (_ballLocation.X + _xVel >= canvas.ScaledWidth - ballRadius)
            {
                _ballLocation.X = canvas.ScaledWidth - ballRadius;
                _xVel *= -1;
            }

            if (_ballLocation.X + _xVel <= ballRadius)
            {
                _ballLocation.X = ballRadius;
                _xVel *= -1;
            }

            if (_ballLocation.Y + _yVel >= canvas.ScaledHeight - ballRadius)
            {
                _ballLocation.Y = canvas.ScaledHeight - ballRadius;
                _yVel *= -1;
            }

            if (_ballLocation.Y + _yVel <= ballRadius)
            {
                _ballLocation.Y = ballRadius;
                _yVel *= -1;
            }

            _ballLocation.X += _xVel;
            _ballLocation.Y += _yVel;

            _iAlive--;

            if (_iAlive < 1)
            {
                _ballLocation.X = rnd.Next(ballRadius * 2, canvas.ScaledWidth - ballRadius * 2);
                _ballLocation.Y = rnd.Next(ballRadius * 2, canvas.ScaledHeight - ballRadius * 2);
                _iAlive = rnd.Next(50, 128);
            }

        }

    }
}
