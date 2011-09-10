using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HinhHoc
{
    class HinhTron:ClassHinhHoc
    {

        private double _R;
        public double R
        {
            get{return _R;}
            set { _R = value; }
        }
        public HinhTron(double r)
        {
            _R = r;
        }

        public override double Chuvi()
        {
            return 2 * Math.PI * _R;
        }

        public override double DienTich()
        {
            return  Math.PI * _R*_R;
        }

        public override void Ve(Graphics g)
        {
            g.DrawEllipse(Pens.DarkGreen, (float)(_Tam.X - _R), (float)(_Tam.Y - _R), (float)(2 * _R), (float)(2 * _R));
        }


    }
}
