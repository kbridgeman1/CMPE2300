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
            if (liPoint.Count != 0)
            {
                llPoint = new LinkedList<Point>();

                foreach (Point p in liPoint)
                {
                    if (llPoint.First == null)
                        llPoint.AddFirst(p);

                    else if (llPoint.First.Next == null)
                    {
                        if (llPoint.First.Value.Y * canvas.ScaledWidth + llPoint.First.Value.X < p.Y * canvas.ScaledWidth + p.X)
                            llPoint.AddLast(p);
                        else
                            llPoint.AddFirst(p);
                    }

                    else
                    {
                        LinkedListNode<Point> tPNode = llPoint.First;

                        while (tPNode != null && tPNode.Next != null && (tPNode.Value.Y * canvas.ScaledWidth + tPNode.Value.X < p.Y * canvas.ScaledWidth + p.X))
                            tPNode = tPNode.Next;

                        if (tPNode.Value.Y * canvas.ScaledWidth + tPNode.Value.X > p.Y * canvas.ScaledWidth + p.X)
                            llPoint.AddBefore(tPNode, p);

                        else
                            llPoint.AddLast(p);

                        //creates a sorted linked list, same as above using a for loop instead of a while loop to transverse the linked list
                        //for (LinkedListNode<Point> iPoint = llPoint.First; iPoint != null; iPoint = iPoint.Next)
                        //{
                        //    if (iPoint.Value.Y * canvas.ScaledWidth + iPoint.Value.X > p.Y * canvas.ScaledWidth + p.X)
                        //    {
                        //        llPoint.AddBefore(iPoint, p);
                        //        break;
                        //    }

                        //    else if (iPoint.Next == null)
                        //    {
                        //        llPoint.AddLast(p);
                        //        break;
                        //    }
                        //}

                    }
                }

                canvas.Clear();

                for (LinkedListNode<Point> iPoint = llPoint.First; iPoint.Next != null; iPoint = iPoint.Next)
                    canvas.AddLine(iPoint.Value.X, iPoint.Value.Y, iPoint.Next.Value.X, iPoint.Next.Value.Y, Color.Yellow, 1);

                canvas.Render();
                btnPopulateList.Text = String.Format("Linked List Contains: {0}", llPoint.Count);

            }
        }
    }
}
