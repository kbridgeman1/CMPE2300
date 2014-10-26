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

        public static bool EnemysAim { get; set; }
        public static int Difficulty { get; set; }

        static Random rnd;

        //static constructor
        static Missile()
        {
            ExplosionRadius = 30;
            rnd = new Random();
            Canvas = null;
        }

        //default instance constructor "Foe"
        public Missile()
        {
            _mslLocation = new Point(rnd.Next(0, canvas.ScaledWidth), 0);
            _mslRadius = 1;
            _mslVelocity = Difficulty / 20;
            _mslAltitute = canvas.ScaledHeight - 40;
            _mslAlpha = 255;
            _friend = false;


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
            _mslRadius = 1;
            _mslVelocity = 10;
            _mslAltitute = destination.Y;
            _mslAlpha = 255;
            _friend = true;
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
                    _mslRadius += 2;
                    _explosionColor = Color.FromArgb(255, rnd.Next(200, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }

                else if (_mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                {
                    _mslAlpha -= 5;
                    _explosionColor = Color.FromArgb(255, rnd.Next(200, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                }
            }


            else
            {
                if (Where().Y > _mslAltitute && !exploding)
                    _mslPathLength += _mslVelocity;

                else if (_mslRadius < explosionRadius && exploding || _mslRadius < explosionRadius)
                {
                    _mslRadius += 2;
                    _explosionColor = Color.FromArgb(255, rnd.Next(0, 256), rnd.Next(200, 256), rnd.Next(0, 256));

                }

                else if (_mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                {
                    _mslAlpha -= 5;
                    _explosionColor = Color.FromArgb(255, rnd.Next(0, 256), rnd.Next(200, 256), rnd.Next(0, 256));
                }
            }


        }

        public void Render()
        {
            if (_friend)
            {
                if (exploding || _mslRadius < explosionRadius && exploding || _mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, _explosionColor));
                else
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, Color.Green));

                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI, Color.FromArgb(_mslAlpha, Color.Green));
            }

            else
            {
                if (exploding || _mslRadius < explosionRadius && exploding || _mslRadius >= explosionRadius && exploding || _mslRadius >= explosionRadius)
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, _explosionColor));

                else
                    canvas.AddCenteredEllipse(Where().X, Where().Y, _mslRadius * 2, _mslRadius * 2, Color.FromArgb(_mslAlpha, Color.Red));

                canvas.AddLine(new Point(Where().X, Where().Y), _mslPathLength, _mslAngle - Math.PI, Color.FromArgb(_mslAlpha, Color.Red));
            }

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
                    target = 200;
                    break;
                case 2:
                    target = 250;
                    break;
                case 3:
                    target = 300;
                    break;
                case 4:
                    target = 500;
                    break;
                case 5:
                    target = 550;
                    break;
                case 6:
                    target = 600;
                    break;
            }

            return Math.Atan(-1 * ((double)target - (double)_mslLocation.X) / (((double)canvas.ScaledHeight - 40) - (double)_mslLocation.Y)) + Math.PI;
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
