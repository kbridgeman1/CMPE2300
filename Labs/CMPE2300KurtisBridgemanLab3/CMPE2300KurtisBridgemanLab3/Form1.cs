//********************************************************************************
//Program:  Lab 03 - Wanderers
//Author:   Kurtis Bridgeman
//Class:    CMPE2300
//********************************************************************************

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
        CTracker canvas;                //our Drawer derived from CDrawer
        List<Thread> thList;            //List to hold our Wanderers
        Thread m_tWander;               //assigned to a method when a Wanderer is created
        Point msLocation;               //holds our last mouse left click point coords
        volatile bool isAlive;          //determines whether our threads should end
        int renderCounter;              //used to slow down the render speed of the ListView
        int threadCounter;              //used to assign an index to each thread

        DrawerDone drawerDone;          //dialog to alert user when drawer has finished

        public Form1()
        {
            InitializeComponent();
        }

        //Occurs when the New Canvas button is clicked. Cleans up any threads from previous
        //drawers, then starts a new drawer.
        private void button1_Click(object sender, EventArgs e)
        {
            //tells our threads to finish, then waits a moment for them to do so
            isAlive = false;
            Thread.Sleep(100);
            isAlive = true;

            if (canvas != null)
                canvas.Close();
            
            //creates a new CTracker using form values
            canvas = new CTracker((int)numericUpDownWidth.Value, (int)numericUpDownHeight.Value);
            canvas.Scale = (int)numericUpDownScale.Value;
            canvas.Position = new Point(Location.X + Width, Location.Y);
            
            //assigns our event handler to the event created in CTracker
            canvas.Full += canvas_Full;

            listView1.Items.Clear();
            thList = new List<Thread>();
            timer1.Enabled = true;
        }

        //Occurs when all pixels have been colored. Clears our Thread List, tells any
        //remaining threads to end, and displays a dialog to the user.
        void canvas_Full(object sender, EventArgs e)
        {
            if (thList != null)
                thList.Clear();

            isAlive = false;
            timer1.Enabled = false;

            drawerDone = new DrawerDone();
            drawerDone.ShowDialog();
        }

        //Occurs at 100ms intervals. Checks for mouse left clicks, in which case it adds a
        //Wanderer at the mouse location. Updates the ListView items every ten ticks.
        private void timer1_Tick(object sender, EventArgs e)
        {
            //limits us to having a max of 40 threads
            if (canvas.GetLastMouseLeftClickScaled(out msLocation) && thList.Count < 40)
            {                
                Color testCol;

                //loops until a unused color is found
                do
                    testCol = GDIDrawer.RandColor.GetColor();
                while (CTracker.DicColorPoint.ContainsKey(testCol));

                //creates a new RandomWanderer once a color is found
                RandomWanderer rWander = new RandomWanderer(new Point(msLocation.X, msLocation.Y), testCol, canvas);

                //creates a new thread for Wandering, passes in our RandomWanderer and start
                m_tWander = new Thread(Wandering);
                m_tWander.IsBackground = true;
                m_tWander.Start(rWander);
                thList.Add(m_tWander);
            }

            //listview only updates once a second
            if (renderCounter % 10 == 0)
            {
                listView1.BeginUpdate();
                listView1.Items.Clear();

                lock (CTracker.thLock)
                    //adds the contents of our CTracker's dictionary to our Form's ListView
                    foreach (KeyValuePair<Color, List<Point>> kvp in CTracker.DicColorPoint)
                    {
                        ListViewItem lvi = listView1.Items.Add("");
                        lvi.BackColor = kvp.Key;
                        lvi.UseItemStyleForSubItems = false;
                        lvi.SubItems.Add(Math.Round(((double)kvp.Value.Count / (double)(canvas.ScaledWidth * canvas.ScaledHeight) * 100), 0).ToString() + "%");
                    }
                listView1.EndUpdate();
            }

            //for tracking the number of ticks
            renderCounter++;
        }


        //Function:     Wandering
        //Description:  Moves Wanderers until it can not move any more, or it has been told
        //              to end via isAlive being set to false.
        //Return:       void
        //Parameters:   object rndWand - our RandomWanderer created via mouse left click
        private void Wandering(object rndWan)
        {
            int thCount = threadCounter;    //get the current thread count and store it in this thread
            threadCounter++;

            System.Diagnostics.Trace.WriteLine(String.Format("Thread {0} Started",thCount));

            //cast our parameter back into a RandomWanderer
            RandomWanderer rndWanderer = rndWan as RandomWanderer;

            //loop until no moves can be made, or isAlive was set to false
            while (rndWanderer.Move() && isAlive)
                canvas.Render();

            System.Diagnostics.Trace.WriteLine(String.Format("Thread {0} Ended", thCount));
        }
    }
}
