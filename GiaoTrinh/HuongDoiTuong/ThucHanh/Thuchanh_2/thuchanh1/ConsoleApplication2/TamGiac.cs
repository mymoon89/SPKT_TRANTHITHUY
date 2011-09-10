using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ConsoleApplication2
{
    public class TamGiac
    {

        private Point _A, _B, _C;
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
        public TamGiac(Point a, Point b, Point c)
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
        public void ChuViTG()
        {
            double a = Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }
    }
}
