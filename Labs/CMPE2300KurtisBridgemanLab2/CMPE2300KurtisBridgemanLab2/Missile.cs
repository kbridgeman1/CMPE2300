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
    class Missile
    {
        private Point _mslLocation;         //center of the missile
        private double _mslAngle;           //angle of missile's path
        private double _mslPathLength;      //length from missile start point to it's destination
        private double _mslAltitute;        //destination altitude for missile
        private int _mslRadius;             //radius of the missile
        private int _mslAlpha;              //opacity of the missile
        private int _mslVelocity;           //velocity of the missile
        private bool _friend;               //true for friendly missiles, false for enemy missiles
        private Color _explosionColor;      //color for the missile, changes when exploding

        private double Angle                //limits _mslAngle to be between PI/3 and -PI/3
        {
            set
            {
                if (value >= Math.PI / 3)
                    _mslAngle = (Math.PI / 3);

                else if (value <= -1 * Math.PI / 3)
                    _mslAngle = (-1 * Math.PI / 3);

                else
                    _mslAngle = value;
            }
        }

        public bool exploding { get; set; } //flag for if the missile is currently exploding
        public int Ammo { get; set; }       //ammo count for each missile (cannon)
        public Point StartLocation          //public getter for retrieving the missile location
        {
            get { return _mslLocation; }
        }

        private static CDrawer canvas;      //CDrawer object for drawing our missiles
        private static Random rnd;          //Random object for randoming angles
        private static int explosionRadius; //stored as a variable to be modified from Main Form

        public static CDrawer Canvas        //getter and setter for accessing canvas from Main Form
        {
            get { return canvas; }
            set { canvas = value; }
        }
        public static int ExplosionRadius   //setter for adjusting the explosionRadius from Main Form
        {
            set { explosionRadius = value; }
        }
        public static bool Loading          //property for clearing and rendering our canvas
        {
            set
            {
                if (value)
                    canvas.Clear();

                else canvas.Render();
            }
        }
        public static bool EnemysAim { get; set; }  //flag to determine enemy missile targets
        public static int Difficulty { get; set; }  //used to set the missile velocity


        //static constructor for our missile class, initializes our static members
        static Missile()
        {
            ExplosionRadius = 40;
            rnd = new Random();
            Canvas = null;
        }

        //default instance constructor for "Foe" missiles
        public Missile()
        {
            _mslRadius = 2;
            _mslAlpha = 250;
            _friend = false;
            _explosionColor = Color.Red;

            //random point at top of drawer for start point
            _mslLocation = new Point(rnd.Next(0, canvas.ScaledWidth), 0);

            //starts at 1 then increases as Difficulty increases for new missiles
            _mslVelocity = Difficulty / 20;

            //destination altitute with an offset accounting for the height of the cities
            _mslAltitute = canvas.ScaledHeight - canvas.ScaledHeight * 4 / 60;

            //set angle to travel towards a "city", or "cannon" chosen at random            
            if (EnemysAim)
                _mslAngle = EnemyTarget();

            //set the angle to a random value between 135 and 225 degrees
            else
                _mslAngle = rnd.Next(135, 226) * (Math.PI / 180);
        }

        //custom instance constructor for "Friend" missiles
        public Missile(Point destination, List<Missile> cannons)
        {
            _mslRadius = 2;
            _mslVelocity = 15;
            _mslAltitute = destination.Y;
            _mslAlpha = 255;
            _friend = true;
            _explosionColor = Color.Green;

            //determines which cannons are available to shoot, returns the one with lowest path length
            _mslLocation = ClosestCannon(destination, cannons);

            //determines the angle between the mouse click, and start point
            Angle = Math.Atan(-1 * ((double)destination.X - (double)_mslLocation.X)
                / ((double)destination.Y - (double)_mslLocation.Y));
        }

        //custom instance constructor for city/cannon
        public Missile(Point startPoint, string city)
        {
            _mslLocation = startPoint;
            _mslRadius = 5;
            _mslAlpha = 255;

            //ammo is initialized if "cannon" is passed in as a string argument
            if (city == "cannon")
                Ammo = 5;

        }

        //Function:     Where
        //Description:  Returns a Point holding the x and y values of the missile.
        //Returns:      Point - the current x and y coordinates of the missile
        public Point Where()
        {
            Point tp = new Point();
            tp.X = (int)(Math.Sin(_mslAngle) * _mslPathLength + _mslLocation.X);
            tp.Y = (int)(-1 * Math.Cos(_mslAngle) * _mslPathLength + _mslLocation.Y);

            return tp;
        }

        //Function:     Move
        //Description:  Evaluates the state of the missile and either moves the missile,
        //              expands the radius and changes the color, or fades the missile
        //              while continuing to change the color. 
        //Returns:      Void
        public void Move()
        {
            //for foes
            if (!_friend)
            {
                //moves until target altitute is reached
                if (Where().Y < _mslAltitute && !exploding)
                    _mslPathLength += _mslVelocity;

                //expands until set size is reached
                else if (_mslRadius < explosionRadius && exploding || _mslRadius < explosionRadius)
                {
                    _mslRadius += 3;
                    _explosionColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(200, 256),
                        rnd.Next(0, 256), rnd.Next(0, 256));
                }

                //fades the missile away until min alpha is reached
                else if (_mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                {
                    _mslAlpha -= 10;
                    _explosionColor = Color.FromArgb(_mslAlpha, rnd.Next(200, 256), rnd.Next(0, 256),
                        rnd.Next(0, 256));
                }
            }

            //for friends
            else
            {
                //moves until target altitute is reached
                if (Where().Y > _mslAltitute && !exploding)
                    _mslPathLength += _mslVelocity;

                //expands until set size is reached
                else if (_mslRadius < explosionRadius && exploding || _mslRadius < explosionRadius)
                {
                    _mslRadius += 3;
                    _explosionColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256),
                        rnd.Next(200, 256), rnd.Next(0, 256));
                }

                //fades the missile away until min alpha is reached
                else if (_mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                {
                    _mslAlpha -= 5;
                    _explosionColor = Color.FromArgb(_mslAlpha, rnd.Next(0, 256),
                        rnd.Next(200, 256), rnd.Next(0, 256));
                }
            }
        }

        //Function:     Render
        //Description:  Draws ellipses and lines on the CDrawer, red for foe missiles, green for
        //              friends. Lines are drawn in a fixed red or green, ellipse color will
        //              vary if exploding. Both colors still share the same alpha.
        //Returns:      Void
        public void Render()
        {
            if (_friend)
            {
                canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2,
                    _explosionColor);

                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI,
                    Color.FromArgb(_mslAlpha, Color.Green), 2);
            }

            else
            {
                canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2,
                    Color.FromArgb(_mslAlpha, _explosionColor));

                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI,
                    Color.FromArgb(_mslAlpha, Color.Red), 2);
            }

        }

        //Function:     RenderCity
        //Description:  Draws a rectangle at the missile start point, these represent our cities.
        //Return:       Void
        public void RenderCity()
        {
            canvas.AddCenteredRectangle(_mslLocation.X, _mslLocation.Y, _mslRadius * 3,
                _mslRadius, Color.Aqua);
        }

        //Function:     RenderCannon
        //Description:  Draws a line with an angle from the cannons start point to the mouse location
        //              if the cannon is alive. Adds text below the cannon to show the ammo count or 
        //              an X if it is dead.
        //Return:       Void
        //Argument:     Point mouseLocation - the current x and y coordinates of the mouse.
        public void RenderCannon(Point mouseLocation)
        {
            if (!exploding)
            {
                //only update the angle if the mouse is above the cannon on the canvas
                if (mouseLocation.Y <= canvas.ScaledHeight - canvas.ScaledHeight / 10 - 1)
                    Angle = Math.Atan(-1 * ((double)mouseLocation.X - (double)_mslLocation.X)
                        / ((double)mouseLocation.Y - (double)_mslLocation.Y));

                canvas.AddLine(_mslLocation, 15, _mslAngle, Color.Green, 8);
                canvas.AddText(Ammo.ToString(), 15, _mslLocation.X - 15, _mslLocation.Y + 5,
                    30, 20, Color.Black);
            }

            else
                canvas.AddText("X", 15, _mslLocation.X - 15, _mslLocation.Y + 5, 30, 20, Color.Black);
        }

        //Function:     ClosestCannon
        //Description:  Determines the distance between each cannon and the destination. Sets a bool
        //              for each cannon if it is available to shoot. Finds the closest available 
        //              cannon decrementing it's ammo and returning it's Point coordinates.
        //Return:       Point - x and y coordinates of the closest cannon, (0,0) is returned if
        //              no cannons are available.
        //Arguments:    Point destination - x and y coordinates of where the mouse has clicked
        //              List<missile> cannon - list of cannons, needed to access ammo and status
        private Point ClosestCannon(Point destination, List<Missile> cannon)
        {
            //determines the distance from each cannon to the destination
            double a = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 1 / 8) - (double)destination.X, 2)
                + Math.Pow((canvas.ScaledHeight * 11 / 12) - (double)destination.Y, 2));

            double b = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 4 / 8) - (double)destination.X, 2)
                + Math.Pow((canvas.ScaledHeight * 11 / 12) - (double)destination.Y, 2));

            double c = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 7 / 8) - (double)destination.X, 2)
                + Math.Pow((canvas.ScaledHeight * 11 / 12) - (double)destination.Y, 2));

            double[] d = new double[] { a, b, c };
            
            //sets a bool for each cannon, if it can shoot
            bool canShootA = (!cannon[0].exploding && cannon[0].Ammo > 0) ? true : false;
            bool canShootB = (!cannon[1].exploding && cannon[1].Ammo > 0) ? true : false;
            bool canShootC = (!cannon[2].exploding && cannon[2].Ammo > 0) ? true : false;

            //checks for closest available cannon
            if (canShootA && (a == d.Min() || !canShootB && canShootC && a < c
                || !canShootC && canShootB && a < b || !canShootB && !canShootC))
            {
                cannon[0].Ammo -= 1;
                return new Point(canvas.ScaledWidth * 1 / 8 + ((int)(Math.Sin(cannon[0]._mslAngle)
                    * 15)), canvas.ScaledHeight - canvas.ScaledHeight * 1 / 10
                    + (int)(-1 * Math.Cos(cannon[0]._mslAngle) * 15));
            }

            else if (canShootB && (b == d.Min() || !canShootA && canShootC && b < c
                || !canShootC && canShootA && b < a || !canShootA && !canShootC))
            {
                cannon[1].Ammo -= 1;
                return new Point(canvas.ScaledWidth * 4 / 8 + ((int)(Math.Sin(cannon[1]._mslAngle)
                    * 15)), canvas.ScaledHeight - canvas.ScaledHeight * 1 / 10
                    + (int)(-1 * Math.Cos(cannon[1]._mslAngle) * 15));
            }

            else if (canShootC && (c == d.Min() || !canShootA && canShootB && c < b
                || !canShootB && canShootA && c < a || !canShootA && !canShootB))
            {
                cannon[2].Ammo -= 1;
                return new Point(canvas.ScaledWidth * 7 / 8 + ((int)(Math.Sin(cannon[2]._mslAngle)
                    * 15)), canvas.ScaledHeight - canvas.ScaledHeight * 1 / 10
                    + (int)(-1 * Math.Cos(cannon[2]._mslAngle) * 15));
            }

            //return (0,0) if no cannons are available
            else
                return new Point(0, 0);
        }

        //Function:     EnemyTarget
        //Description:  Randomly select one of ten possible x coordinates. Used to determine
        //              the angle from the enemy missile to it's target.
        //Return:       double - the angle between the city/cannon at the target location
        //              and the missile start point.
        double EnemyTarget()
        {
            double target = 0;
            switch (rnd.Next(1, 10))
            {
                case 1:
                    target = canvas.ScaledWidth * 1 / 10;
                    break;
                case 2:
                    target = canvas.ScaledWidth * 1 / 4;
                    break;
                case 3:
                    target = canvas.ScaledWidth * 2.5 / 8;
                    break;
                case 4:
                    target = canvas.ScaledWidth * 3 / 8;
                    break;
                case 5:
                    target = canvas.ScaledWidth * 1 / 2;
                    break;
                case 6:
                    target = canvas.ScaledWidth * 5 / 8;
                    break;
                case 7:
                    target = canvas.ScaledWidth * 5.5 / 8;
                    break;
                case 8:
                    target = canvas.ScaledWidth * 3 / 4;
                    break;
                case 9:
                    target = canvas.ScaledWidth * 9 / 10;
                    break;
            }

            return Math.Atan(-1 * ((double)target - (double)_mslLocation.X)
                / (((double)canvas.ScaledHeight *14/15) - (double)_mslLocation.Y)) + Math.PI;
        }


        //Function:     DifficultyString
        //Description:  Returns a different string depending on the static Difficulty member.
        //Return:       string - to be drawn on canvas to show difficulty
        public static string DiffucultyString()
        {
            if (Difficulty > 100)
                return "Unreasonable";

            else if (Difficulty > 80)
                return "Insane";

            else if (Difficulty > 60)
                return "Tough";

            else if (Difficulty > 40)
                return "Moderate";

            else
                return "Easy";
        }


        //predicates

        //returns true if missiles have faded away
        public static bool MissileDone(Missile msl)
        {
            return msl._mslAlpha <= 0;
        }

        //returns true if the missile has left the bounds of the canvas
        public static bool LeavingScreen(Missile msl)
        {
            return (msl.Where().X > Missile.canvas.ScaledWidth || msl.Where().X < 0);
        }



        //overrides

        //returns true when missiles being compared are overlapping
        public override bool Equals(object obj)
        {
            if (!(obj is Missile))
                return false;

            Missile tMissile = obj as Missile;

            if (tMissile.exploding)
                return false;

            return (Math.Sqrt(Math.Pow(Where().X - tMissile.Where().X, 2) + Math.Pow(Where().Y
                - tMissile.Where().Y, 2)) <= _mslRadius + tMissile._mslRadius);

        }

        public override int GetHashCode()
        {
            return 1;
        }

    }
}