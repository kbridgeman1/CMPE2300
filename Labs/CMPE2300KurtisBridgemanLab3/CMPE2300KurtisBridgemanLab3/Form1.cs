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

        public Form1()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canvas = new CTracker(800, 600);
            thList = new List<Thread>();
            canvas.Scale = 5;
            canvas.Reset();

            button1.Enabled = false;
            timer1.Enabled = true;
            canvas.Full += new dBackFull(BackFull);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (canvas.GetLastMouseLeftClickScaled(out msLocation))
            {
                //loops until a unused color is found
                Color testCol;
                do
                    testCol = GDIDrawer.RandColor.GetColor();
                while (CTracker.dicColorPoint.ContainsKey(testCol));

                //creates a new RandomWanderer once a color is found
                RandomWanderer rWander = new RandomWanderer(new Point(msLocation.X, msLocation.Y), testCol, canvas);

                //creates a new thread for Wandering, passes in our RandomWanderer and starts
                m_tWander = new Thread(Wandering);
                m_tWander.IsBackground = true;
                m_tWander.Start(rWander);
                thList.Add(m_tWander);
            }

            if (CTracker.hashPoints.Count >= canvas.ScaledWidth * canvas.ScaledHeight)
            {
                foreach (Thread th in thList)
                    th.Abort();
                
                thList.Clear();
                button1.Enabled = true;
            }
        }

        private void Wandering(object rndWan)
        {
            RandomWanderer rndWanderer = rndWan as RandomWanderer;
            
            while (rndWanderer.Move())
                canvas.Render();
        }

        private void BackFull(object send, EventArgs evt)
        {
            canvas.Reset();
        }
    }
}
