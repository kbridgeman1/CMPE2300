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
        double _mslVelocity;

        bool _friend;

        Color _explosionColor;
        public bool exploding { get; set; }

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
            _mslAlpha = 255;
            _friend = false;

            _explosionColor = Color.Red;

            if (EnemysAim)
                _mslAngle = EnemyTarget();
            else
                _mslAngle = rnd.Next(135, 226) * (Math.PI / 180);


        }

        //instance constructor "Friend"
        public Missile(Point destination)
        {
            _mslLocation = new Point((int)ClosestCannon(destination), canvas.ScaledHeight - 60);


            _mslAngle = Math.Atan(-1 * ((double)destination.X - (double)_mslLocation.X) / ((double)destination.Y - (double)_mslLocation.Y));
            _mslRadius = 2;
            _mslVelocity = 15;
            _mslAltitute = destination.Y;
            _mslAlpha = 255;
            _friend = true;

            _explosionColor = Color.Green;

        }

        //instance city constructor
        public Missile(Point startPoint, string city)
        {
            _mslLocation = startPoint;
            _mslRadius = 5;
            _mslVelocity = 0;
            _mslAlpha = 255;
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
                    _mslRadius += 1;
                    _explosionColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(200, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }

                else if (_mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                {
                    _mslAlpha -= 5;
                    _explosionColor = Color.FromArgb(_mslAlpha, rnd.Next(200, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }
            }


            else
            {
                if (Where().Y > _mslAltitute && !exploding)
                    _mslPathLength += _mslVelocity;

                else if (_mslRadius < explosionRadius && exploding || _mslRadius < explosionRadius)
                {
                    _mslRadius += 1;
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
                if (exploding || _mslRadius < explosionRadius && exploding || _mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius || Where().Y <= _mslAltitute)
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, _explosionColor);
                else
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, Color.Green));

                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI, Color.FromArgb(_mslAlpha, Color.Green), 2);
            }

            else
            {
                if (exploding || _mslRadius < explosionRadius && exploding || _mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius || Where().Y >= _mslAltitute)
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, _explosionColor));

                else
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, Color.Red));

                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI, Color.FromArgb(_mslAlpha, Color.Red), 2);
            }

        }

        public void RenderCity()
        {
            canvas.AddCenteredRectangle(_mslLocation.X, _mslLocation.Y, _mslRadius * 3, _mslRadius, Color.Aqua);
        }

        double ClosestCannon(Point destination)
        {
            double a = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 1 / 8) - (double)destination.X, 2) + Math.Pow((canvas.ScaledHeight - 50) - (double)destination.Y, 2));
            double b = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 4 / 8) - (double)destination.X, 2) + Math.Pow((canvas.ScaledHeight - 50) - (double)destination.Y, 2));
            double c = Math.Sqrt(Math.Pow((canvas.ScaledWidth * 7 / 8) - (double)destination.X, 2) + Math.Pow((canvas.ScaledHeight - 50) - (double)destination.Y, 2));

            if (a < b && a < c)
                return canvas.ScaledWidth * 1 / 8;

            else if (b < a && b < c)
                return canvas.ScaledWidth * 4 / 8;

            return canvas.ScaledWidth * 7 / 8;
        }

        double EnemyTarget()
        {
            double target = 0;

            switch (rnd.Next(1, 7))
            {
                case 1:
                    target = canvas.ScaledWidth * 1/4;
                    break;
                case 2:
                    target = canvas.ScaledWidth * 2.5 / 8;
                    break;
                case 3:
                    target = canvas.ScaledWidth * 3 / 8;
                    break;
                case 4:
                    target = canvas.ScaledWidth * 5 / 8;
                    break;
                case 5:
                    target = canvas.ScaledWidth * 5.5 / 8;
                    break;
                case 6:
                    target = canvas.ScaledWidth * 3 / 4;
                    break;
            }

            return Math.Atan(-1 * ((double)target - (double)_mslLocation.X) / (((double)canvas.ScaledHeight - 40) - (double)_mslLocation.Y)) + Math.PI;
        }

        public static string DiffucultyString()
        {
            if (Difficulty > 80)
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

        public bool Equal(Building city)
        {
            if ((object)city == null)
                return false;

            return (Math.Sqrt(Math.Pow(Where().X - city.bCenter.X, 2) + Math.Pow(Where().Y - city.bCenter.Y, 2)) <= _mslRadius + Building.bRadius);

        }



        public override int GetHashCode()
        {
            return 1;
        }

    }
}
