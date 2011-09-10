using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace kethua
{
    public abstract class HINHHOC
    {
        public Point _Tam;
        public Point Tam{get;set;}
        public abstract void Ve(Graphics g);
    }
    public class DoanThang:HINHHOC
    {
        private Point _A,_B;
        public Point A
        {
            get 
            {
                return _A;
            }
            set
            {
                _A=value;
            }
        }
         public Point B
        {
            get 
            {
                return _B;
            }
            set
            {
                _B=value;
            }
        }
        public DoanThang(Point a, Point b)
        {
            A=a;
            B=b;
        }
        public override  void Ve( Graphics g)
        {
            g.DrawLine(new Pen(Color.Red,5),_A,_B);
        }
    }
    public class TamGiac : HINHHOC
    {
        private Point _A, _B,_C;
        public Point A
        {
            get
            {
                return _A;
            }
            set
            {
                _A = value;
            }
        }
        public Point B
        {
            get
            {
                return _B;
            }
            set
            {
                _B = value;
            }
        }
         public Point C
        {
            get
            {
                return _C;
            }
            set
            {
                _C = value;
            }
        }
        public TamGiac(Point a, Point b,Point c)
        {
            A = a;
            B = b;
            C = c;
        }
        public override void Ve(Graphics g)
        {
            g.DrawLine(new Pen(Color.Red, 5), _A, _B);
            g.DrawLine(new Pen(Color.Red, 5), _A, _C);
            g.DrawLine(new Pen(Color.Red, 5), _B, _B);
        }
    }
}
