using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA2
{
    class Ball
    {
        private static Random _rndGen = new Random();
        private Point _point;
        private int _xVelocity;
        private int _yVelocity;
        private Color _ballColor;
        public const int _ballRadius = 40;


        //properties
        public Point Location
        {
            get { return _point; }
        }

        public int xVelocity
        {
            set { _xVelocity = value; }
        }

        public int yVelocity
        {
            set
            {
                if (value > 10)
                    value = 10;

                if (value < -10)
                    value = 10;

                _yVelocity = value;
            }
        }

        public int BallOpacity { private get; set; }

        //constructors
        public Ball(Point drawPoint)
        {
            _point = drawPoint;
            _ballColor = RandColor.GetColor();
            _xVelocity = _rndGen.Next(-10, 11);
            _yVelocity = _rndGen.Next(-10, 11);
            BallOpacity = 128;
        }

        //methods
        public void MoveBall(CDrawer GDI_canvas)
        {
            if (_point.X + _xVelocity >= GDI_canvas.ScaledWidth - _ballRadius)
            {
                _point.X = GDI_canvas.ScaledWidth - _ballRadius;
                _xVelocity *= -1;
            }

            if (_point.X + _xVelocity <= _ballRadius)
            {
                _point.X = _ballRadius;
                _xVelocity *= -1;
            }


            if (_point.Y + _yVelocity >= GDI_canvas.ScaledHeight - _ballRadius)
            {
                _point.Y = GDI_canvas.ScaledHeight - _ballRadius;
                _yVelocity *= -1;
            }

            if (_point.Y + _yVelocity <= _ballRadius)
            {
                _point.Y = _ballRadius;
                _yVelocity *= -1;
            }


            _point.X += _xVelocity;
            _point.Y += _yVelocity;
        }

        public void ShowBall(CDrawer GDI_canvas)
        {
                GDI_canvas.AddCenteredEllipse(_point.X, _point.Y, _ballRadius*2, _ballRadius*2, Color.FromArgb(BallOpacity, _ballColor));
        }

        public override string ToString()
        {
            return _point.ToString() + " - Vel: " + _xVelocity.ToString() + ", " + _yVelocity.ToString() + ", Opacity: ";
        }


    }
}
