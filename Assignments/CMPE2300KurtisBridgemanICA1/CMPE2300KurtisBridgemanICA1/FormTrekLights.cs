using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace CMPE2300KurtisBridgemanICA1
{
    public partial class FormTrekLights : Form
    {
        CDrawer canvas;
        List<TrekLight> trekLightList;
        Random gen = new Random();

        public FormTrekLights()
        {
            InitializeComponent();
        }

        private void FormTrekLights_Load(object sender, EventArgs e)
        {
            canvas = new CDrawer(800, 600, false, false);
            trekLightList = new List<TrekLight>();

            canvas.Scale = 50;
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            canvas.Clear();

            int i =0;
            
            foreach (TrekLight t in trekLightList)
            {
                t.Tick();
                t.Render(canvas, i);
                i++;
            }

            canvas.Render();
        }

        private void FormTrekLights_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'd':
                    if(trekLightList.Count <192)
                    trekLightList.Add(new TrekLight());
                    break;

                case 'f':
                    if (trekLightList.Count < 192)
                    trekLightList.Add(new TrekLight(Color.Red, (byte)127, 5));
                    break;

                case 'g':
                    if (trekLightList.Count < 192)
                    trekLightList.Add(new TrekLight(RandColor.GetColor(), (byte)gen.Next(40, 201), 5));
                    break;

                case 'c':
                    if (trekLightList.Count > 0)
                        trekLightList.RemoveAt(trekLightList.Count - 1);
                    break;

            }


        }


    }
}
