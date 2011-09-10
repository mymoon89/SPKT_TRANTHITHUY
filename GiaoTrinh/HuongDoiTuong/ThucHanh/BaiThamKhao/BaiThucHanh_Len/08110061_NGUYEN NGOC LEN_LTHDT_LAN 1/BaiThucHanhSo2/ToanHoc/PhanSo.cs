using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToanHoc
{
    public class PhanSo
    {
        public int _TuSo;
        public int _MauSo;
        public void Xuat()
        {
            Console.WriteLine("{0}/{1}",_TuSo,_MauSo);
        }
        public PhanSo()
        {
            _MauSo = 1;
        }
        public PhanSo(int Tu, int Mau)
        {
            _TuSo  = Tu;
            _MauSo = Mau;
        }
        public PhanSo(int SoNguyen)
        {
            _TuSo  = SoNguyen;
            _MauSo = 1;
        }
    }
}
