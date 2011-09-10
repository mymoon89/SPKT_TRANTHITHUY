using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HinhHoc
{
    public class DoanThang:ClassHinhHoc
    {
        private Point _A, _B;
        public Point B
        {
            get{return _B;}
            set { _B = value; }
        }
        public Point A
        {
            get { return _A; }
            set { _A = value; }
        }
        public DoanThang(Point a, Point b)
        {
            _A = a;
            _B = b;
        }

        public override double Chuvi()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override double DienTich()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Ve(Graphics g)
        {
            g.DrawLine(Pens.DarkGreen, _A, _B);
        }

    

    }
}
