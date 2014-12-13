//********************************************************************************
//Program:  WandererDrawer.cs
//Author:   Kurtis Bridgeman
//Class:    CMPE2300
//********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace CMPE2300KurtisBridgemanLab3
{
    //delegate which will be assigned to our event
    public delegate void dBackFull(object sender, EventArgs e);

    class CTracker : CDrawer
    {
        //static members
        public static object thLock = new object(); //lock object for modifying collections
        private static HashSet<Point> hashPoints;   //hold all colored points
        
        //hold each color, and a List Point drawn in that color
        private static Dictionary<Color, List<Point>> dicColorPoint;    
        
        //static properties
        public static HashSet<Point> HashPoints
        { get { return hashPoints; } }

        public static Dictionary<Color, List<Point>> DicColorPoint
        { get { return dicColorPoint; } }

        //custom constructor leveraging base, initializes static members
        public CTracker(int width, int height)
            : base(width, height, bContinuousUpdate: false)
        {
            hashPoints = new HashSet<Point>();
            dicColorPoint = new Dictionary<Color, List<Point>>();
        }

        //override of the inherited SetBBScaledPixel
        new public bool SetBBScaledPixel(int xCoord, int yCoord, Color pixelColor)
        {
            //return false if the argument pixel is already colored
            if (hashPoints.Contains(new Point(xCoord, yCoord)))
                return false;

            //return false if the argument pixel is out of bounds
            if (xCoord < 0 || xCoord > ScaledWidth - 1 || yCoord < 0 || yCoord > ScaledHeight - 1)
                return false;

            //lock our lock object, then add the new point/color to our static collections
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

            //trigger the event if all pixel have been colored
            if (HashPoints.Count >= ScaledWidth * ScaledHeight)
                if (Full != null)
                    Full(this, EventArgs.Empty);           

            //true indicates the pixel has been successfully set
            return true;
        }

        //an event that will be triggered when the drawer is finished
        public event dBackFull Full;
    }


    abstract class Wanderer
    {
        protected static List<Point> pList; //possible move directions (up,down,left,right)
        protected Stack<Point> pStack;      //points which the Wanderer has already traversed
        protected Color wanderColor;        //color of our Wanderer
        protected Random rnd;               //Random object to pass into our shuffle
        protected CTracker canv;            //our CTracker

        //static constructor to add the possible directions to pList
        static Wanderer()
        {
            pList = new List<Point>();
            pList.Add(new Point(0, -1));  //up
            pList.Add(new Point(0, 1));   //down   
            pList.Add(new Point(-1, 0));  //left  
            pList.Add(new Point(1, 0));   //right
        }

        //custom constructor, initializes our class members
        public Wanderer(Point startPoint, Color wColor, CTracker drawer)
        {
            pStack = new Stack<Point>();
            pStack.Push(startPoint);
            wanderColor = wColor;
            canv = drawer;
            rnd = new Random();
        }

        //public acces for NVI
        public bool Move()
        {
            return vMove();
        }

        protected abstract bool vMove();
    }

    class RandomWanderer : Wanderer
    {
        //custom constructor leveraging the base
        public RandomWanderer(Point p, Color c, CTracker d) : base(p, c, d) { }

        protected override bool vMove()
        {
            if (pStack.Count == 0)
                return false;
            
            //shuffle our 4 possible directions, return as a stack
            Stack<Point> possibleDirections = new Stack<Point>(pList.FisherYatesShuffle(rnd));

            //store our next move without taking it off the stack
            Point nextLocation = pStack.Peek();

            //brief pause
            System.Threading.Thread.Sleep(1);

            //attempts to move 1 of 4 directions until no possible direction remain
            while (possibleDirections.Count != 0)
            {
                //removes the next direction from our stack, storing it in nextMove
                Point nextMove = possibleDirections.Pop();

                //SetBBScaledPixel returns true if the pixel was set successfully
                if (canv.SetBBScaledPixel(nextLocation.X + nextMove.X, nextLocation.Y + nextMove.Y, wanderColor))
                {
                    //add our x & y values to move our point then push to our stack
                    nextLocation.X += nextMove.X;
                    nextLocation.Y += nextMove.Y;
                    pStack.Push(nextLocation);

                    //indicates that our Wanderer should keep moving
                    return true;
                }
            }

            //non of the 4 directions are possible, backtrack one point
            pStack.Pop();

            //indicates that the Wanderer should keep moving
            return true;
        }
    }
}
