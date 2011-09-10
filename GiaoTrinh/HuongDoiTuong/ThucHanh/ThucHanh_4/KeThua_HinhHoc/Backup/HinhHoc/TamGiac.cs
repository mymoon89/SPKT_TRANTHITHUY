using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HinhHoc
{
    public class TamGiac:ClassHinhHoc
    {
        private Point _A, _B, _C;

        public Point A
        {
            get { return _A; }
            set { _A = value; }
        }
        public Point B
        {
            get { return _B; }
            set { _B = value; }
        }
        public Point C
        {
            get { return _C; }
            set { _C = value; }
        }

        public Point  Tam
        {
            get { return new Point((_A.X + _B.X + _C.X) / 3, (_A.Y + _B.Y + _C.Y) / 3); }
        }
        public TamGiac() 
        {
            
        }
        public TamGiac(Point a, Point b, Point c)
        {
            _A = a; _B = b; _C = c;
        }

        public override double Chuvi()
        {
            double canhAB,canhBC,canhAC;
            canhAB = Math.Sqrt((_A.X - _B.X) * (_A.X - _B.X) + (_A.Y - _B.Y) * (_A.Y - _B.Y));
            canhAC = Math.Sqrt((_A.X - _C.X) * (_A.X - _C.X) + (_A.Y - _C.Y) * (_A.Y - _C.Y));
            canhBC = Math.Sqrt((_C.X - _B.X) * (_C.X - _B.X) + (_C.Y - _B.Y) * (_C.Y - _B.Y));
            return canhAB+canhAC+canhBC;        

        }
        public override double DienTich()
        {
            double canhAB, canhBC, canhAC;
            canhAB = Math.Sqrt((_A.X - _B.X) * (_A.X - _B.X) + (_A.Y - _B.Y) * (_A.Y - _B.Y));
            canhAC = Math.Sqrt((_A.X - _C.X) * (_A.X - _C.X) + (_A.Y - _C.Y) * (_A.Y - _C.Y));
            canhBC = Math.Sqrt((_C.X - _B.X) * (_C.X - _B.X) + (_C.Y - _B.Y) * (_C.Y - _B.Y));
            double p;
            p =Chuvi()/2;
            return Math.Sqrt(p * (p - canhAB) * (p - canhAC) * (p - canhBC));
        }
        public override void Ve(Graphics g)
        {
            Console.WriteLine("Tam giac:..............");
            g.DrawLine(new Pen(Color.Red, 5), _A, _B);
            g.DrawLine(new Pen(Color.Red, 5), _B, _C);
            g.DrawLine(new Pen(Color.Red, 5), _C, _A);
        }

    }
}
