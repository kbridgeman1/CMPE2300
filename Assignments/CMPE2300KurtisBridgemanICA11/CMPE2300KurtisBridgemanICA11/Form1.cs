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
        MyRandom rnd;
        RectDrawer recDraw;
        PicDrawer picDraw;

        public Form1()
        {
            InitializeComponent();

            rnd = new MyRandom(1);            
        }

        private void btnNewRectDrawer_Click(object sender, EventArgs e)
        {
            if (recDraw != null)
                recDraw.Close();

            recDraw = new RectDrawer();

       //     recDraw.Clear();      //clears all shapes on the CDrawer which will not reappear when Render() is called
       //     recDraw.Render();

        }

        private void btnNewPicDrawer_Click(object sender, EventArgs e)
        {
            if (picDraw != null)
                picDraw.Close();

            picDraw = new PicDrawer();

        //    picDraw.Clear();    //pixels do not get cleared in Clear()
        //    picDraw.Render();   //shapes drawns to the CDrawer will be cleared and wont appear when Render() is called
        }

    }
}
