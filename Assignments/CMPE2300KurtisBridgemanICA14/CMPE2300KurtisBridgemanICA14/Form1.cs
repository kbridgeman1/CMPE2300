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

namespace CMPE2300KurtisBridgemanICA14
{
    public partial class Form1 : Form
    {

        List<CShape> shapeList;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Enabled = true;
            shapeList = new List<CShape>();

            CShape.Canvas = new PicDrawer(Properties.Resources.ImageInImageMedium);
            CShape.Canvas.Render();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point msLocation;

            CShape.Canvas.GetLastMouseLeftClickScaled(out msLocation);
          


        }










    }
}
