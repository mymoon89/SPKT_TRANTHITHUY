using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace thuake_console
{
    public abstract class HinhHoc
    {
        public Point Tam;
        public abstract void Ve();
        public abstract Double DienTich();
        public abstract Double ChuVi();
    }
    public class DoanThang : HinhHoc
    {
        private Point _A, _B;
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
        public DoanThang(Point a, Point b)
        {
            A = a;
            B = b;
        }
        public override double ChuVi()
        {
            throw new Exception("KHONG TINH DUOC");
        }
        public override double DienTich()
        {
            throw new Exception("KHONG TINH DUOC");
        }
        public override void Ve()
        {
            Console.Write("*****************");
        }
        public double dodai()
        {
            double ddai;
            ddai = Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
            return ddai;
        }

    }
    public class TamGiac : HinhHoc
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
        public TamGiac(Point a, Point b,Point c)
        {
            _A = a;
            _B = b;
            _C = c;
        }
        /*public double canh1()
        {
            DoanThang d = new DoanThang(this._A, this._B);
            return d.dodai();
        }
        public double canh2()
        {
            DoanThang d = new DoanThang(this._A, this._C);
            return d.dodai();
        }
        public double canh3()
        {
            DoanThang d = new DoanThang(this._B, this._C);
            return d.dodai();
        }*/
        public override double ChuVi()
        {
            Double canh1 = Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
            Double canh2 = Math.Sqrt(Math.Pow((A.X - C.X), 2) + Math.Pow((A.Y - C.Y), 2));
            Double canh3 = Math.Sqrt(Math.Pow((C.X - B.X), 2) + Math.Pow((C.Y - B.Y), 2));
            return canh3 + canh2 + canh1;
        }
        public override double DienTich()
        {
            Double a = Math.Sqrt(Math.Pow((A.X - B.X), 2) + Math.Pow((A.Y - B.Y), 2));
            Double b= Math.Sqrt(Math.Pow((A.X - C.X), 2) + Math.Pow((A.Y - C.Y), 2));
            Double c = Math.Sqrt(Math.Pow((C.X - B.X), 2) + Math.Pow((C.Y - B.Y), 2));
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public override void Ve()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    
}
