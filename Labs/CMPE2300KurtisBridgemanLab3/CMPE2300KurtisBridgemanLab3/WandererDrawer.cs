using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;

namespace CMPE2300KurtisBridgemanLab3
{
    class CTracker:CDrawer
    {
        HashSet<Point> hashPoints;
        Dictionary<Color, List<Point>> dicColorAndPoint;

        public CTracker() : base() { }

        new public bool SetBBScaledPixel(int xCoord, int yCoord, Color pixelColor) 
        {
            if (hashPoints.Contains(new Point(xCoord, yCoord)))
                return false;

            hashPoints.Add(new Point(xCoord, yCoord));

            if (!dicColorAndPoint.ContainsKey(pixelColor))
                dicColorAndPoint.Add(pixelColor, new List<Point> { new Point(xCoord, yCoord) });

            else
                dicColorAndPoint[pixelColor].Add(new Point(xCoord, yCoord));

            return true;
        }

        public event dBackFull Full = null;
    
        public void Reset()
        {
            BBColour = Color.Black;

        }
    

    }
}
