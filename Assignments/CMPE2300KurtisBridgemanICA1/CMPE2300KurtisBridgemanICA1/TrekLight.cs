using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA1
{
    class TrekLight
    {
        private Color _LightColor;
        private byte _byThreshold;
        private byte _byTick;
        private int _Border;

        //custom constuctor
        public TrekLight(Color color, byte threshold, int border = 0)
        {
            _LightColor = color;
            _byThreshold = threshold;
            _Border = border;
            _byTick = (byte)new Random().Next(0,201);
        }

        //default contructor
        public TrekLight(): this(RandColor.GetColor(), 64, 5) { }

        //tick method
        public void Tick()
        {
            if (_byTick > 200)
                _byTick -= 200;


            _byTick += 3;

        }

        //render method
        public void Render(CDrawer canvas, int lightNum)
        {
            int x;
            int y;

            x = lightNum % canvas.ScaledWidth;
            y = lightNum / canvas.ScaledWidth;

            if ((_byTick >= _byThreshold)&&(x<16)&&(y<12))
            {
                canvas.AddRectangle(x, y, 1, 1, _LightColor, _Border, Color.Black);
            }

            if ((_byTick < _byThreshold)&&(x<16)&&(y<12))
            {
                canvas.AddRectangle(x, y, 1, 1, Color.Black, _Border, Color.Black);
            }

        }

    }
}
