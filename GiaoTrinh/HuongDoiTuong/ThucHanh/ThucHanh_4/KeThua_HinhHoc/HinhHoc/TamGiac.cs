using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HinhHoc
{
    public class TamGiac:ClassHinhHoc,ILuaChon,IDiChuyen
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
           /* Console.WriteLine("Tam giac:..............");
            g.DrawLine(new Pen(Color.Red, 5), _A, _B);
            g.DrawLine(new Pen(Color.Red, 5), _B, _C);
            g.DrawLine(new Pen(Color.Red, 5), _C, _A);
            */
            Brush brush;
            if (Chon)
                brush = Brushes.ForestGreen;
            else
                brush = Brushes.Brown;
            Pen pen = new Pen(brush, 5);
            if (g != null)
            {
                g.DrawLine(pen, _A, _B);
                g.DrawLine(pen, _B, _C);
                g.DrawLine(pen, _C, _A);
            }
        }

        public override void Nhap()
        {
            FormNhapTamGiac form = new FormNhapTamGiac();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TamGiac tg = form.Data;
                this.A = tg.A;
                this.B = tg.B;
                this.C = tg.C;
            }
        }

        //private bool _DuocChon;
        private bool _DuocChon=false;//
        #region ILuaChon Members  
        public bool KiemTraDuocChon(Point p)
        {
            Point tamTamGiac = Tam;
            double KhoangCachDiem2Tam = TienIch.KhoangCach(p, tamTamGiac);
            double KhoangCachTam2DinhA = TienIch.KhoangCach(_A, tamTamGiac);
            double KhoangCachTam2DinhB = TienIch.KhoangCach(_B, tamTamGiac);
            double KhoangCachTam2DinhC = TienIch.KhoangCach(_C, tamTamGiac);
            if (KhoangCachDiem2Tam < KhoangCachTam2DinhA &&
                KhoangCachDiem2Tam < KhoangCachTam2DinhB &&
                KhoangCachDiem2Tam < KhoangCachTam2DinhC)
                return true;
            return false;
        }

        public bool Chon
        {
            get
            {
                return _DuocChon;
            }
            set
            {
                _DuocChon = value;
            }
        }

        #endregion

        #region IDiChuyen Members

        public void DiChuyenToi(Point p)
        {
            Point tamTG = Tam;
            int dx = p.X - tamTG.X;
            int dy = p.Y - tamTG.Y;
            _A.X += dx;
            _A.Y += dy;
            _B.X += dx;
            _B.Y += dy;
            _C.X += dx;
            _C.Y += dy;
        }
        #endregion
    }
}
