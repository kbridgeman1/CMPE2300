using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using KurtisBridgeman_Drawers;
using GDIDrawer;


namespace CMPE2300KurtisBridgemanICA13
{
    class Light //base class
    {
        protected Point _liCenter;
        protected bool _killMe;
        protected Color _liColor;

        //custom constructor
        public Light(Point drawPoint)
        {
            _liCenter = drawPoint;
            _killMe = false;
            _liColor = RandColor.GetColor();
        }

        //virtual methods
        virtual public void Animate() { } //intentionally empty, without knowing what to animate we can't animate anything

        virtual public void Draw(CDrawer canv)
        {
            canv.AddCenteredEllipse(_liCenter.X, _liCenter.Y, 8, 8, Color.Red);
        }


        //predicates
        public static bool KillMe(Light li)
        {
            return li._killMe;
        }
    }

    class FadeLight : Light //derived class
    {
        int _alpha = 255;

        public FadeLight(Point msLocation) : base(msLocation) { }

        //override for base virtual methods
        public override void Animate()
        {
            _alpha -= 10;
            _killMe = (_alpha < 10) ? true : false;
        }

        public override void Draw(CDrawer canv)
        {
            canv.AddCenteredEllipse(_liCenter.X, _liCenter.Y, 60, 60, Color.FromArgb(_alpha, _liColor));
            base.Draw(canv);
        }

    }

    class ShrinkLight : Light //derived class
    {
        double radius = 40;

        public ShrinkLight(Point msLocation) : base(msLocation) { }

        public override void Animate()
        {
            radius = radius * 0.97;
            _killMe = (radius < 2) ? true : false;
        }

        public override void Draw(CDrawer canv)
        {
            canv.AddPolygon(_liCenter.X - (int)radius, _liCenter.Y - (int)radius, (int)radius, 8, FillColor: _liColor);
            base.Draw(canv);
        }
    }

    class SpinLight : Light //derived  class
    {
        double angle = Math.PI * 2;

        public SpinLight(Point msLoaction) : base(msLoaction) { }

        public override void Animate()
        {
            angle = angle * 0.9;
            _killMe = (angle < 0.1) ? true : false;
        }

        public override void Draw(CDrawer canv)
        {
            canv.AddPolygon(_liCenter.X - 40, _liCenter.Y - 40, 40, 3, angle, _liColor);
            base.Draw(canv);
        }

    }

    class GrowLight : Light //derived class
    {
        double radius = 40;

        public GrowLight(Point msLocation) : base(msLocation) { }

        public override void Animate()
        {
            radius = radius * 1.1;
            _killMe = (radius > 500) ? true : false;
        }

        public override void Draw(CDrawer canv)
        {
            canv.AddPolygon(_liCenter.X - (int)radius, _liCenter.Y - (int)radius, (int)radius, 8, FillColor: _liColor);
            base.Draw(canv);
        }

    }
}
