using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace kethua
{
    public abstract class HINHHOC
    {
        public virtual Nhap()
        { }
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
        public TamGiac()
        {
            Point A = _A;
            Point B = _B;
            Point C = _C;
        }
        public TamGiac(Point c)
        {
            C = c;
        }
        public override void Ve(Graphics g)
        {
            g.DrawLine(new Pen(Color.Red, 5), A,B);
            g.DrawLine(new Pen(Color.Red, 5), A, C);
            g.DrawLine(new Pen(Color.Red, 5), B, C);
        }
    }
    public class ChuNhat : TamGiac
    {
        Point _D;
        public Point D
        {
            get { return _D; }
            set{_D=value;}
        }
        public ChuNhat(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public ChuNhat(Point d)
        {
            D = d;
        }
        public override void Ve(Graphics g)
        {
            g.DrawLine(new Pen(Color.Blue, 5), A, B);
            g.DrawLine(new Pen(Color.Blue, 5), A, D);
            g.DrawLine(new Pen(Color.Blue, 5), B, C);
            g.DrawLine(new Pen(Color.Blue, 5), D, C);
        }
    }
}
