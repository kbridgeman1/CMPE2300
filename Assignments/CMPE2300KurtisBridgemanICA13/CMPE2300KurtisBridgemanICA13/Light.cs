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
    class Light
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

    class FadeLight : Light
    {
        int _alpha = 255;

        public FadeLight(Point msLocation) : base(msLocation) { }

        //override for base virtual methods
        public override void Animate()
        {
            _alpha -= 10;

            if (_alpha < 10) _killMe = true;
        }

        public override void Draw(CDrawer canv)
        {
            canv.AddCenteredEllipse(_liCenter.X, _liCenter.Y, 60, 60, Color.FromArgb(_alpha, _liColor));

            base.Draw(canv);
        }

    }


}
