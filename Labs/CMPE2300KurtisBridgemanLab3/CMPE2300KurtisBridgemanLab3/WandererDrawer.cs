﻿using System;
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
        public CTracker(int width, int height)
            : base(width, height, bContinuousUpdate: false)
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
            Render();

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
        protected static List<Point> pList;
        protected Stack<Point> pStack;
        protected Color wanderColor;
        protected Random rnd;
        protected CTracker canv;

        static Wanderer()
        {
            pList = new List<Point>();

            pList.Add(new Point(0, -1));  //up
            pList.Add(new Point(0, 1));   //down   
            pList.Add(new Point(-1, 0));  //left  
            pList.Add(new Point(1, 0));   //right
        }

        public Wanderer(Point startPoint, Color wColor, CTracker drawer)
        {
            pStack = new Stack<Point>();
            pStack.Push(startPoint);
            wanderColor = wColor;
            canv = drawer;
            rnd = new Random();
        }

        public bool Move()
        {
            return vMove();
        }

        protected abstract bool vMove();
    }

    class RandomWanderer : Wanderer
    {
        public RandomWanderer(Point p, Color c, CTracker d) : base(p, c, d) { }

        protected override bool vMove()
        {
            if (pStack.Count == 0)
                return false;

            Stack<Point> possibleDirections = new Stack<Point>(pList.FisherYatesShuffle(rnd));
            Point nextLocation = pStack.Peek();

            System.Threading.Thread.Sleep(1);

            while (possibleDirections.Count != 0)
            {
                Point nextMove = possibleDirections.Pop();

                nextLocation.X = nextLocation.X + nextMove.X;
                nextLocation.Y = nextLocation.Y + nextMove.Y;

                if (canv.SetBBScaledPixel(nextLocation.X, nextLocation.Y, wanderColor))
                {
                    pStack.Push(nextLocation);
                    return true;
                }
            }

            //   while (pStack.Count > 1)
            pStack.Pop();

            return true;
        }

    }

}
