using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToanHoc.HinhHoc
{
    class TamGiac
    {
        public int _DoDaiCanh1;
        public int _DoDaiCanh2;
        public int _DoDaiCanh3;
        public int c;
        public float s;
        public TamGiac(int SoNguyen)
        {
            _DoDaiCanh1 = SoNguyen;
            _DoDaiCanh2 = SoNguyen;
            _DoDaiCanh3 = SoNguyen;
        }
        public TamGiac(int SoNguyen1,int SoNguyen2,int SoNguyen3)
        {
            _DoDaiCanh1 = SoNguyen1;
            _DoDaiCanh2 = SoNguyen2;
            _DoDaiCanh3 = SoNguyen3;
        }
        public void TinhDienTich()
        {
            int p;
            p = (_DoDaiCanh1 + _DoDaiCanh2 + _DoDaiCanh3) / 2;
            s = (float)Math.Sqrt(p * (p - _DoDaiCanh1) * (p - _DoDaiCanh2) * (p - _DoDaiCanh3));
        }
        public void TinhChuVi()
        {
            c = _DoDaiCanh1 + _DoDaiCanh2 + _DoDaiCanh3;
        }

    }
}
