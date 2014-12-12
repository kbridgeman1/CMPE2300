using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CMPE2300KurtisBridgemanLab3
{
    public partial class Form1 : Form
    {
        CTracker canvas;
        List<Thread> thList;
        Thread m_tWander;
        Point msLocation;
        Random rnd = new Random();
        volatile bool isAlive;

        DrawerDone drawerDone;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (canvas != null)
                canvas.Close();

            isAlive = false;
            Thread.Sleep(100);
            isAlive = true;

            if (thList != null)
                thList.Clear();

            listView1.Items.Clear();
            
            canvas = new CTracker((int)numericUpDownWidth.Value, (int)numericUpDownHeight.Value);
            thList = new List<Thread>();
            canvas.Scale = 2;
            canvas.Position = new Point(Location.X + Width, Location.Y);
            
            canvas.Full += canvas_Full;
            timer1.Enabled = true;
        }

        void canvas_Full(object sender, EventArgs e)
        {
            if (thList != null)
                thList.Clear();

            isAlive = false;
//            timer1.Enabled = false;
//            button1.Enabled = true;
            drawerDone = new DrawerDone();
            drawerDone.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canvas.GetLastMouseLeftClickScaled(out msLocation))
            {
                //loops until a unused color is found
                Color testCol;
                do
                    testCol = GDIDrawer.RandColor.GetColor();
                while (CTracker.DicColorPoint.ContainsKey(testCol));

                //creates a new RandomWanderer once a color is found
                RandomWanderer rWander = new RandomWanderer(new Point(msLocation.X, msLocation.Y), testCol, canvas);

                //creates a new thread for Wandering, passes in our RandomWanderer and starts
                m_tWander = new Thread(Wandering);
                m_tWander.IsBackground = true;
                m_tWander.Start(rWander);
                thList.Add(m_tWander);
            }

            listView1.Items.Clear();

            lock (CTracker.thLock)
                foreach (KeyValuePair<Color, List<Point>> kvp in CTracker.DicColorPoint)
                {
                    ListViewItem lvi = listView1.Items.Add("");
                    lvi.BackColor = kvp.Key;
                    lvi.UseItemStyleForSubItems = false;
                    lvi.SubItems.Add(Math.Round(((double)kvp.Value.Count / (double)(canvas.ScaledWidth * canvas.ScaledHeight) * 100), 0).ToString() + "%");
                }
        }

        private void Wandering(object rndWan)
        {
            RandomWanderer rndWanderer = rndWan as RandomWanderer;

            while (rndWanderer.Move() && isAlive)
                canvas.Render();
        }
    }
}
