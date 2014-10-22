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

namespace CMPE2300KurtisBridgemanICA09
{
    public partial class Form1 : Form
    {

        static Random rnd = new Random();
        List<Point> liPoint;
        LinkedList<Point> llPoint;
        CDrawer canvas = new CDrawer(bContinuousUpdate: false);


        public Form1()
        {
            InitializeComponent();
        }

        private void btnMakeList_Click(object sender, EventArgs e)
        {
            liPoint = new List<Point>();


            int div = (int)numericUpDown1.Value;
            int i = 0;

            while (i < (canvas.ScaledWidth / div) * (canvas.ScaledHeight / div))
            {
                Point tP = new Point(rnd.Next(0, (canvas.ScaledWidth / div)) * div, rnd.Next(0, (canvas.ScaledHeight / div)) * div);

                if (!liPoint.Contains(tP))
                {
                    liPoint.Add(tP);
                    i++;
                }
            }

            canvas.Clear();

            for (int ii = 0; ii < liPoint.Count - 1; ii++)
                canvas.AddLine(liPoint[ii].X, liPoint[ii].Y, liPoint[ii + 1].X, liPoint[ii + 1].Y, Color.Fuchsia, 1);

            canvas.Render();

            btnMakeList.Text = String.Format("List Contains: {0}", liPoint.Count);
        }

        private void btnPopulateList_Click(object sender, EventArgs e)
        {
            llPoint = new LinkedList<Point>();

            foreach (Point p in liPoint)
            {
                if (llPoint.First == null)
                    llPoint.AddFirst(p);

                else
                {
                    LinkedListNode<Point> tPNode = llPoint.First;

                    while (tPNode != null && tPNode.Next != null && (tPNode.Next.Value.Y * canvas.ScaledWidth + tPNode.Next.Value.X) > (tPNode.Value.Y * canvas.ScaledHeight + tPNode.Value.X))
                    {
                        tPNode = tPNode.Next;


                    }

                }



            }

        }






    }
}
