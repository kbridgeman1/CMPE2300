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

namespace CMPE2300KurtisBridgemanICA08
{
    public partial class Form1 : Form
    {
        Stack<Sheeple> sheepStack = new Stack<Sheeple>();
        List<Queue<Sheeple>> sheepList = new List<Queue<Sheeple>>();

        CDrawer canvas;

        int itemsTotal;
        int tickRequired;
        int itemsPerTick;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnSimulate_Click(object sender, EventArgs e)
        {
            itemsTotal = 0;
            sheepStack.Clear();
            sheepList.Clear();

            if (canvas != null)
                canvas.Close();

            canvas = new CDrawer(900, 400, false, false);
            canvas.Scale = 20;


            for (int i = 0; i < 200; i++)
                sheepStack.Push(new Sheeple());
            
            for (int i = 0; i < numericUpDown1.Value; i++)
                sheepList.Add(new Queue<Sheeple>());

            this.Text = itemsTotal.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            itemsPerTick = 0;

            if (canvas != null)
            {
                //1st block
                if (sheepStack.Count != 0)
                    foreach (Queue<Sheeple> q in sheepList)
                    {
                        if (q.Count < 10 && sheepStack.Count != 0)
                        {
                            Sheeple tSheep = sheepStack.Pop();
                            q.Enqueue(tSheep);
                        }
                    }

                listBox1.Items.Clear();

                foreach (Sheeple sh in sheepStack)
                    listBox1.Items.Add(sh.ItemsTotal);


                if (tickRequired % -trackBar1.Value == 0)
                {

                    //2nd block
                    foreach (Queue<Sheeple> q in sheepList)
                        if (q.Count != 0)
                        {
                            //process the first item in the current queue
                            q.Peek().Process();
                            itemsPerTick++;

                            //if the first item has items remaining of 0, add items to itemsTotal and remove from the queue
                            if (q.Peek().Done)
                            {
                                //itemsTotal += q.Peek().ItemsTotal;
                                itemsTotal += q.Dequeue().ItemsTotal;
                            }
                        }

                    tickRequired = 0;
                }


                //3rd block
                int xDims = 0;
                int queueCount = 0;

                canvas.Clear();

                foreach (Queue<Sheeple> q in sheepList)
                {
                    xDims = 0;

                    foreach (Sheeple sh in q)
                    {
                        canvas.AddRectangle(xDims, queueCount, sh.ItemsRemain, 1, Color.FromArgb(sh.SheepleColor));
                        xDims += sh.ItemsRemain;
                    }

                    queueCount++;
                }

                canvas.Render();
                this.Text = String.Format("I: {0}, I/tick: {1}", itemsTotal, itemsPerTick);
                tickRequired++;
            }

        }


    }
}
