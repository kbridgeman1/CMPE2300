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
                liLight.Add(new FadeLight(mouseLocation));

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
