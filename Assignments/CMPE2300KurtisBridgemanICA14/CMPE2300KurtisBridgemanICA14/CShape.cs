using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using KurtisBridgeman_Drawers;


namespace CMPE2300KurtisBridgemanICA14
{

    internal interface IMoveable
    {
        void Move();
    }

    internal interface IAnimate
    {
        void Animate();
    }


    abstract class CShape
    {
        public static PicDrawer Canvas { get; set; }
        protected static Random _rnd;
        protected Point _pLocation;
        protected Color _color = RandColor.GetColor();
        protected int _iRadius;

        static CShape()
        {
            _rnd = new Random(0);
        }

        public CShape(Point pt)
        {
            _pLocation = pt;
            _iRadius = _rnd.Next(25, 51);
        }

        //public interfaces   these are not actually interfaces though
        public void Render()
        {
            VirtualRender();
        }

        //Non-virtual interfaces
        protected abstract void VirtualRender();

    }

    //derived from CShape, supports IMovable interface
    class MovingBall : CShape, IMoveable
    {
        int xVel;
        int yVel;
        
        //custom constructor leveraging base constructor, to initialize radius and location
        public MovingBall(Point p)
            : base(p)
        {
            xVel = _rnd.Next(-8, 9); //random x velocity
            yVel = _rnd.Next(-8, 9); //random y velocity
        }

        //supports IMoveable, so we ,must provide a Move() function
        public void Move()
        {
            if (_pLocation.X + xVel >= Canvas.ScaledWidth - _iRadius || _pLocation.X + xVel <= _iRadius)
                xVel *= -1;

            if (_pLocation.Y + yVel >= Canvas.ScaledHeight - _iRadius || _pLocation.Y + yVel < _iRadius)
                yVel *= -1;

            _pLocation.X += xVel;
            _pLocation.Y += yVel;

        }

        
        protected override void VirtualRender()
        {
            Canvas.AddCenteredEllipse(_pLocation.X, _pLocation.Y, _iRadius / 2, _iRadius / 2, _color);
        }




    }

    //derived from CShape, supports IAnimate interface
    class SpinnerBall: CShape, IAnimate
    {
        double drawAngle;
        double incAngle;

        //custom constructor leveraging base constructor, to initialize radius and location
        public SpinnerBall(Point p)
            : base(p)
        {
            incAngle = _rnd.NextDouble() * 0.2;
        }

        //supports IAnimate , so we must provide a Animate() function
        public void Animate()
        {
            drawAngle += incAngle;
        }

        protected override void VirtualRender()
        {
            Canvas.AddCenteredEllipse(_pLocation.X, _pLocation.Y, _iRadius / 2, _iRadius / 2, _color);
            Canvas.AddLine(_pLocation, _iRadius, drawAngle, _color, 5);
        }

    }



}
