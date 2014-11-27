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
        Point msLocation;

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

            CShape.Canvas.Clear();

            foreach (CShape shp in shapeList)
            {

                if (shp is IMoveable)
                    (shp as IMoveable).Move();

                if (shp is IAnimate)
                    (shp as IAnimate).Animate();

                shp.Render();
            }

            CShape.Canvas.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            CShape.Canvas.GetLastMousePositionScaled(out msLocation);

            switch (e.KeyCode)
            {
                case Keys.C:
                    shapeList.Clear();
                    break;

                case Keys.S:
                    shapeList.Add(new SpinnerBall(msLocation));
                    break;

                case Keys.M:
                    shapeList.Add(new MovingBall(msLocation));
                    break;

                case Keys.P:
                    shapeList.Add(new PentoBall(msLocation));
                    break;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CShape.Canvas.Position = new Point(this.Location.X + this.Width, this.Location.Y);
        }

    }
}
