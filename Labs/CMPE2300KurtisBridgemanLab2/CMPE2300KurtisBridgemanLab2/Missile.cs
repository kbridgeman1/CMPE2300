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
        Point _mslLocation;

        double _mslAngle;
        double _mslPathLength;
        double _mslAltitute;

        int _mslRadius;
        int _mslAlpha;
        int _mslVelocity;

        bool _friend;

        Color _explosionColor;
        public bool exploding { get; set; }

        public int Ammo { get; set; }

        public Point StartLocation
        {
            get { return _mslLocation; }
        }

        static CDrawer canvas;
        static int explosionRadius;

        public static CDrawer Canvas
        {
            get { return canvas; }
            set { canvas = value; }
        }

        public static int ExplosionRadius
        {
            set { explosionRadius = value; }
        }

        public static bool Loading
        {
            set
            {
                if (value)
                    canvas.Clear();

                else canvas.Render();
            }
        }

        public static bool EnemysAim { get; set; }
        public static int Difficulty { get; set; }

        double Angle
        {
            set
            {
                if (value >= Math.PI / 3)
                    _mslAngle = (Math.PI / 3);

                else if (value <= -1 * Math.PI / 3)
                    _mslAngle =  (Math.PI* 5 / 3);

                else
                    _mslAngle = value;
            }
        }



        static Random rnd;

        //static constructor
        static Missile()
        {
            ExplosionRadius = 40;
            rnd = new Random();
            Canvas = null;
        }

        //default instance constructor "Foe"
        public Missile()
        {
            _mslLocation = new Point(rnd.Next(0, canvas.ScaledWidth), 0);
            _mslRadius = 2;
            _mslVelocity = Difficulty / 20;
            _mslAltitute = canvas.ScaledHeight - 40;
            _mslAlpha = 250;
            _friend = false;

            _explosionColor = Color.Red;

            if (EnemysAim)
                _mslAngle = EnemyTarget();
            else
                _mslAngle = rnd.Next(135, 226) * (Math.PI / 180);
        }

        //instance constructor "Friend"
        public Missile(Point destination, List<Missile> cannons)
        {
            _mslLocation = (Point)ClosestCannon(destination, cannons);

            Angle = Math.Atan(-1 * ((double)destination.X - (double)_mslLocation.X) / ((double)destination.Y - (double)_mslLocation.Y));
            _mslRadius = 2;
            _mslVelocity = 15;
            _mslAltitute = destination.Y;
            _mslAlpha = 255;
            _friend = true;

            _explosionColor = Color.Green;
        }

        //instance city/cannon constructor
        public Missile(Point startPoint, string city)
        {
            _mslLocation = startPoint;
            _mslRadius = 5;
            _mslVelocity = 0;
            _mslAlpha = 255;

            if (city == "cannon")
            {
                Ammo = 5;
                _mslRadius = 15;
            }
        }



        //instance methods
        public Point Where()
        {
            Point tp = new Point();
            tp.X = (int)(Math.Sin(_mslAngle) * _mslPathLength + _mslLocation.X);
            tp.Y = (int)(-1 * Math.Cos(_mslAngle) * _mslPathLength + _mslLocation.Y);

            return tp;
        }

        public void Move()
        {
            if (!_friend)
            {
                if (Where().Y < _mslAltitute && !exploding)
                    _mslPathLength += _mslVelocity;

                else if (_mslRadius < explosionRadius && exploding || _mslRadius < explosionRadius)
                {
                    _mslRadius += 3;
                    _explosionColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(200, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }

                else if (_mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                {
                    _mslAlpha -= 10;
                    _explosionColor = Color.FromArgb(_mslAlpha, rnd.Next(200, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }
            }

            else
            {
                if (Where().Y > _mslAltitute && !exploding)
                    _mslPathLength += _mslVelocity;

                else if (_mslRadius < explosionRadius && exploding || _mslRadius < explosionRadius)
                {
                    _mslRadius += 3;
                    _explosionColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(200, 256), rnd.Next(0, 256));
                }

                else if (_mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                {
                    _mslAlpha -= 5;
                    _explosionColor = Color.FromArgb(_mslAlpha, rnd.Next(0, 256), rnd.Next(200, 256), rnd.Next(0, 256));
                }
            }
        }

        public void Render()
        {
            if (_friend)
            {
                canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, _explosionColor);
                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI, Color.FromArgb(_mslAlpha, Color.Green), 2);
            }

            else
            {
                canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, _explosionColor));
                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI, Color.FromArgb(_mslAlpha, Color.Red), 2);
            }

        }

        //enhancement methods
        public void RenderCity()
        {
            canvas.AddCenteredRectangle(_mslLocation.X, _mslLocation.Y, _mslRadius * 3, _mslRadius, Color.Aqua);
        }

        public void RenderCannon(Point mouseLocation)
        {
            if (!exploding)
            {
                if(mouseLocation.Y <= canvas.ScaledHeight-61)
                    Angle = Math.Atan(-1 * ((double)mouseLocation.X - (double)_mslLocation.X) / ((double)mouseLocation.Y - (double)_mslLocation.Y));
                                
                canvas.AddLine(_mslLocation, 15, _mslAngle, Color.Green, 8);
                canvas.AddText(Ammo.ToString(), 15, _mslLocation.X - 15, _mslLocation.Y + 5, 30, 20, Color.Black);
            }

            else
                canvas.AddText("X", 15, _mslLocation.X - 15, _mslLocation.Y + 5, 30, 20, Color.Black);
        }

        object ClosestCannon(Point destination, List<Missile> cannon)
        {
            double a = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 1 / 8) - (double)destination.X, 2) + Math.Pow((canvas.ScaledHeight - 50) - (double)destination.Y, 2));
            double b = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 4 / 8) - (double)destination.X, 2) + Math.Pow((canvas.ScaledHeight - 50) - (double)destination.Y, 2));
            double c = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 7 / 8) - (double)destination.X, 2) + Math.Pow((canvas.ScaledHeight - 50) - (double)destination.Y, 2));
            double[] d = new double[] { a, b, c };

            bool canShootA = (!cannon[0].exploding && cannon[0].Ammo > 0) ? true : false;
            bool canShootB = (!cannon[1].exploding && cannon[1].Ammo > 0) ? true : false;
            bool canShootC = (!cannon[2].exploding && cannon[2].Ammo > 0) ? true : false;


            if (canShootA && (a == d.Min() || !canShootB && canShootC && a < c || !canShootC && canShootB && a < b || !canShootB && !canShootC))
            {
                cannon[0].Ammo -= 1;
                return new Point(canvas.ScaledWidth * 1 / 8 + ((int)(Math.Sin(cannon[0]._mslAngle) * cannon[0]._mslRadius)),
                    canvas.ScaledHeight - canvas.ScaledHeight * 1 / 10 + (int)(-1 * Math.Cos(cannon[0]._mslAngle) * cannon[0]._mslRadius));
            }

            else if (canShootB && (b == d.Min() || !canShootA && canShootC && b < c || !canShootC && canShootA && b < a || !canShootA && !canShootC))
            {
                cannon[1].Ammo -= 1;
                return new Point(canvas.ScaledWidth * 4 / 8 + ((int)(Math.Sin(cannon[1]._mslAngle) * cannon[1]._mslRadius)),
                    canvas.ScaledHeight - canvas.ScaledHeight * 1 / 10 + (int)(-1 * Math.Cos(cannon[1]._mslAngle) * cannon[1]._mslRadius));
            }

            else if (canShootC && (c == d.Min() || !canShootA && canShootB && c < b || !canShootB && canShootA && c < a || !canShootA && !canShootB))
            {
                cannon[2].Ammo -= 1;
                return new Point(canvas.ScaledWidth * 7 / 8 + ((int)(Math.Sin(cannon[2]._mslAngle) * cannon[2]._mslRadius)),
                    canvas.ScaledHeight - canvas.ScaledHeight * 1 / 10 + (int)(-1 * Math.Cos(cannon[2]._mslAngle) * cannon[2]._mslRadius));
            }

            else
                return new Point(0, 0); ;
        }

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

            return Math.Atan(-1 * ((double)target - (double)_mslLocation.X) / (((double)canvas.ScaledHeight - 40) - (double)_mslLocation.Y)) + Math.PI;
        }

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
        public static bool MissileDone(Missile msl)
        {
            return msl._mslAlpha <= 0;
        }

        public static bool LeavingScreen(Missile msl)
        {
            if (msl.Where().X > Missile.canvas.ScaledWidth || msl.Where().X < 0)
                return true;

            return false;
        }



        //overrides
        public override bool Equals(object obj)
        {
            if (!(obj is Missile))
                return false;

            Missile tMissile = obj as Missile;

            if (tMissile.exploding)
                return false;

            return (Math.Sqrt(Math.Pow(Where().X - tMissile.Where().X, 2) + Math.Pow(Where().Y - tMissile.Where().Y, 2)) <= _mslRadius + tMissile._mslRadius);

        }

        public override int GetHashCode()
        {
            return 1;
        }

    }
}
