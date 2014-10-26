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

namespace CMPE2300KurtisBridgemanLab2
{
    class Building
    {

        public Point bCenter;
        bool isCannon;
        int ammo;

        public static int bRadius = 10;

        //city constructor
        public Building(Point location)
        {
            bCenter = new Point(location.X, location.Y);
            isCannon = false;
        }

        //cannon constructor
        public Building(Point location, bool cannon)
        {
            bCenter = new Point(location.X, location.Y);
            isCannon = true;
            ammo = 10;
        }

        public void Fire()
        {
            ammo -= 1;
        }

        public static List<Building> CreateBuildings()
        {
            List<Building> liBld = new List<Building>();
            Point pt = new Point();

            pt.X = 100;
            pt.Y = 540;
            for (int i = 0; i < 3; i++)
            {
                liBld.Add(new Building(pt, true));
                pt.X += 300;
            }

            pt.X = 200;
            pt.Y = 560;
            for (int i = 0; i < 6; i++)
            {
                if (pt.X == 350)
                    pt.X = 500;

                liBld.Add(new Building(pt));

                pt.X += 50;
            }

            return liBld;
        }

        public void Render()
        {
            if (!isCannon)
                Missile.Canvas.AddCenteredEllipse(bCenter.X, bCenter.Y, bRadius * 2, bRadius * 2, Color.Blue);
        }


    }
}
