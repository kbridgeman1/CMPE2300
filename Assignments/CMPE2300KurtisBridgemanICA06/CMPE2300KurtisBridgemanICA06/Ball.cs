using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA06
{
    class Ball
    {
        //static variables
        static private Random rnd = new Random();

        //instance variables
        private Point _ballLocation;

        private int _ballRadius;
        private int _ballXVelocity;
        private int _ballYVelocity;   

        //instance properties
        public Color BallColor { get; set; }

        //instance constructor
        public Ball(Point location, Color color)
        {
            _ballLocation.X = location.X;
            _ballLocation.Y = location.Y;
            _ballXVelocity = rnd.Next(-5, 6);
            _ballYVelocity = rnd.Next(-5, 6);
            _ballRadius = rnd.Next(20, 51);
            BallColor = color;
        }


        //instance methods
        public void Move(CDrawer canvas)
        {
            if (_ballLocation.X + _ballXVelocity >= canvas.ScaledWidth - _ballRadius)
            {
                _ballLocation.X = canvas.ScaledWidth - _ballRadius;
                _ballXVelocity *= -1;
            }

            if (_ballLocation.X + _ballXVelocity <= _ballRadius)
            {
                _ballLocation.X = _ballRadius;
                _ballXVelocity *= -1;
            }

            if (_ballLocation.Y + _ballYVelocity >= canvas.ScaledHeight - _ballRadius)
            {
                _ballLocation.Y = canvas.ScaledHeight - _ballRadius;
                _ballYVelocity *= -1;
            }

            if (_ballLocation.Y + _ballYVelocity <= _ballRadius)
            {
                _ballLocation.Y = _ballRadius;
                _ballYVelocity *= -1;
            }

            _ballLocation.X += _ballXVelocity;
            _ballLocation.Y += _ballYVelocity;
        }

        public void Show(CDrawer canvas, int ballCount)
        {
            Color complimentColor = Color.FromArgb(BallColor.ToArgb() ^ 0x00FFFFFF);
            
            canvas.AddCenteredEllipse(_ballLocation.X, _ballLocation.Y, _ballRadius * 2, _ballRadius * 2, BallColor);
            canvas.AddText(ballCount.ToString(), 14, _ballLocation.X - _ballRadius, _ballLocation.Y - _ballRadius, _ballRadius*2, _ballRadius*2, complimentColor);
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
