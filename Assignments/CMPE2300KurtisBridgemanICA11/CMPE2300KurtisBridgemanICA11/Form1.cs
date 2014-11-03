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

namespace CMPE2300KurtisBridgemanICA11
{
    public partial class Form1 : Form
    {
        RectDrawer recDraw = new RectDrawer();

        public Form1()
        {
            InitializeComponent();
            MyRandom rnd = new MyRandom(1);
        }



    }
}
