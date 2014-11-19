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
        public void iMoveBall()
        {
            Move();
        }
        public void iAnimate()
        {
            Animate();
        }

        //Non-virtual interfaces
        protected abstract void VirtualRender();
        protected abstract void Move();
        protected abstract void Animate();
    }



    class MovingBall : CShape
    {

        protected override void Move()
        {
            throw new NotImplementedException();
        }
    }

}
