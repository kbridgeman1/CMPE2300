using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace CMPE2300KurtisBridgemanLab3
{
    public delegate void dBackFull(object sender, EventArgs e);
    
    class CTracker : CDrawer
    {
        //static members
        private static HashSet<Point> hashPoints;
        private static Dictionary<Color, List<Point>> dicColorPoint;
        private static object thLock = new object();

        //custom constructor, initializes static members
        public CTracker(int width, int height) : base(width,height, bContinuousUpdate:false) 
        {
            hashPoints = new HashSet<Point>();
            dicColorPoint = new Dictionary<Color, List<Point>>();
        }
        
        //override of the inherited SetBBScaledPixel
        new public bool SetBBScaledPixel(int xCoord, int yCoord, Color pixelColor)
        {
            if (hashPoints.Contains(new Point(xCoord, yCoord)))
                return false;

            lock (thLock)
            {
                hashPoints.Add(new Point(xCoord, yCoord));

                if (!dicColorPoint.ContainsKey(pixelColor))
                    dicColorPoint.Add(pixelColor, new List<Point> { new Point(xCoord, yCoord) });

                else
                    dicColorPoint[pixelColor].Add(new Point(xCoord, yCoord));
            }

            base.SetBBScaledPixel(xCoord, yCoord, pixelColor);

            return true;
        }

        //an event that will be used from the main form
        public event dBackFull Full = null;

        //invoke the OnFill event, called when we want?
        protected virtual void OnFill(EventArgs ev)
        {
            if (Full != null)
                Full(this, ev);
        }

        public void Reset()
        {
            BBColour = Color.Black;
            Render();
            hashPoints.Clear();
            dicColorPoint.Clear();
        }
    }


    abstract class Wanderer
    {

        private static List<Point> pList;
        private Stack<Point> pStack;
        private Color wanderColor;
        private Random rnd;

        static Wanderer()
        {
            for (int x = 0; x < 2; x++)
                for (int y = 0; y < 2; y++)
                    pList.Add(new Point(x, y));
        }


        public Wanderer(Point startPoint, Color wColor)
        {
            pStack.Push(startPoint);
            wanderColor = wColor;
            //pList = pList.Sort(FisherYatesSuffle);
        }

        public static int FisherYatesSuffle(this List<Point> lPt)
        {
            List<Point> tLPt = lPt;




            return 1;
        }

        public bool Move()
        {
            vMove();
            return false;
        }

        protected abstract bool vMove();
    }



}
