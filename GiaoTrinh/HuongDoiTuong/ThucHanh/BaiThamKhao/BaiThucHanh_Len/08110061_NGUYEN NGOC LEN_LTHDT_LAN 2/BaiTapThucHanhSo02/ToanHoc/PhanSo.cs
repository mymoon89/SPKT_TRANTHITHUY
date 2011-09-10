using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToanHoc
{
    public class PhanSo
    {
        #region Members
        private int _TuSo;
        private int _MauSo;
        #endregion Members
        #region Properties
        public int TuSo
        {
            get { return _TuSo; }
            set { _TuSo = value; }
        }
        public int MauSo
        {
            get { return _MauSo; }
            set { _MauSo = value; }
        }
        #endregion Properties
        #region Contructors
        public PhanSo()
        {
            _MauSo = 1;
        }
        public PhanSo(PhanSo p)
        {
            _TuSo = p.TuSo;
            _MauSo = p._MauSo;
        }
        public PhanSo(int a, int b)
        {
            _TuSo = a;
            _MauSo = b;
        }
        #endregion Contructors
        #region Methods
        public void NhapPhanSo()
        {
            _TuSo = int.Parse(Console.ReadLine());
            _MauSo = int.Parse(Console.ReadLine());
        }
        public void XuatPhanSo()
        {
            Console.WriteLine("{0}/{1}", _TuSo, _MauSo);
        }
        #endregion Methods

        public static PhanSo Cong(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p._TuSo = p1._TuSo * p2._MauSo + p2._TuSo * p1._MauSo;
            p._MauSo = p1._MauSo * p2._MauSo;
            return p;
        }
        public static PhanSo Cong(int a, PhanSo p1)
        {
            PhanSo p = new PhanSo();
            p._TuSo = a * p1._MauSo + p1._TuSo;
            p._MauSo = p1._MauSo;
            return p;
        }
        public void Cong(PhanSo p)
        {
            _TuSo = _TuSo * p._MauSo + _MauSo * p._TuSo;
            _MauSo = _MauSo * p._MauSo;
        }
        public void Cong(int a, int b)
        {
            _TuSo = _TuSo * b + _MauSo * a;
            _MauSo = _MauSo * b;
        }
        public void Cong(int a)
        {
            _TuSo = _TuSo + _MauSo * a;
        }
        public static PhanSo operator +(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo * p2.MauSo + p2.TuSo * p1.MauSo;
            p.MauSo = p1.MauSo * p2.MauSo;
            return p;
        }
        public static PhanSo operator -(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo * p2.MauSo - p2.TuSo * p1.MauSo;
            p.MauSo = p1.MauSo * p2.MauSo;
            return p;
        }
        public static PhanSo operator *(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo * p2.TuSo;
            p.MauSo = p1.MauSo * p2.MauSo;
            return p;
        }
        public static PhanSo operator /(PhanSo p1, PhanSo p2)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo * p2.MauSo;
            p.MauSo = p1.MauSo * p2.TuSo;
            return p;
        }
        public static PhanSo operator ++(PhanSo p1)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo + p1.MauSo;
            p.MauSo = p1.MauSo;
            return p;
        }
        public static PhanSo operator --(PhanSo p1)
        {
            PhanSo p = new PhanSo();
            p.TuSo = p1.TuSo - p1.MauSo;
            p.MauSo = p1.MauSo;
            return p;
        }
        public static explicit operator PhanSo(int i)
        {
            


        }
        public static explicit operator PhanSo(double i)
        {
            


        }
        public static implicit operator int(PhanSo i)
        {
            


        }
    }
}
