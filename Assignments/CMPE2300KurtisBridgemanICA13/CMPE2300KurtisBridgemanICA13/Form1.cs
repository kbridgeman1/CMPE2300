using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KurtisBridgeman_Drawers;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA13
{
    public partial class Form1 : Form
    {
        CDrawer pDrawer;
        List<Light> liLight;
        MyRandom mR = new MyRandom(1);

        public Form1()
        {
            InitializeComponent();
            pDrawer = new PicDrawer(Properties.Resources.ImageInImageMedium);
            pDrawer.Render();
            liLight = new List<Light>();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point mouseLocation;

            if (pDrawer.GetLastMouseLeftClickScaled(out mouseLocation))
                switch (mR.RandFour())
                {
                    case 1:
                        liLight.Add(new SpinLight(mouseLocation));
                        break;
                    case 2:
                        liLight.Add(new ShrinkLight(mouseLocation));
                        break;
                    case 3:
                        liLight.Add(new FadeLight(mouseLocation));
                        break;
                    case 4:
                        liLight.Add(new GrowLight(mouseLocation));
                        break;
                }

            pDrawer.Clear();

            foreach (Light li in liLight)
            {
                li.Animate();
                li.Draw(pDrawer);
            }

            liLight.RemoveAll(Light.KillMe);

            pDrawer.Render();
        }






    }
}
