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
            Console.WriteLine("{0}/{1}", _TuSo, _MauSo);
        }
        public PhanSo()
        {
            _MauSo = 1;
        }
        public PhanSo(int tu, int mau)
        {
            _TuSo = tu;
            _MauSo = mau;
        }
        //1
        public PhanSo(int tu)
        {
            _TuSo = tu;
            _MauSo = 1;
        }

    }
}
namespace ToanHoc.HinhHoc
{
    public class TamGiac
    {
        public Double a;
        public Double b;
        public Double c;
        public Double s ;
        public Double cv;

        public TamGiac(int x)
        {
            a = b = c = x;
        }
        public Double DienTich
        {
            get
            {
                s = ((a * a) / 2) * 1.0;
                return s;
            }
        }
        public Double ChuVi
        {
            get
            {
                cv = 3 * a;
                return cv;
            }
        }
    }
    public class HinhChuNhat
    {
        public int rong;
        public int cao;
        public HinhChuNhat(int wide, int high)
        {
            rong = wide;
            cao = high;
        }
        public Double ChuVi
        {
            get
            {
                return ((rong + cao) / 2);
            }
        }
        public Double DienTich
        {
            get
            {
                return (rong * cao);
            }
        }
    }
    public class HinhVuong
    {
        public int canh;
        public HinhVuong(int c)
        {
            canh= c;
        }
        public int ChuVi
        {
            get
            {
                return (canh * 4);
            }
        }
        public int DienTich
        {
            get
            {
                return (canh * canh);
            }
        }
    }
    public class HinhTron
    {
        public int bankinh;
        public HinhTron(int r)
        {
            bankinh = r;
        }
        public Double ChuVi
        {
            get
            {
                return (2 * Math.PI * bankinh);
            }
        }
        public Double DienTich
        {
            get
            {
                return (Math.PI * bankinh * bankinh);
            }
        }
    }
}
namespace ToanHoc.DaiSo
{
    public class SoPhuc
    {
        public Double PhanThuc;
        public Double PhanAo;
        public  SoPhuc(Double thuc, Double ao)
        {
            PhanThuc = thuc;
            PhanAo = ao;
        }
        public String Cong(SoPhuc p1,SoPhuc p2)
        {           
            String pt,pa;
            pt=(p1.PhanThuc+p2.PhanThuc).ToString();
            pa=(p1.PhanAo+p2.PhanAo).ToString();
            return (pt +"+"+"i"+pa);
        }
        public String Tru(SoPhuc p1, SoPhuc p2)
        {
            String pt, pa;
            pt = (p1.PhanThuc - p2.PhanThuc).ToString();
            pa = (p1.PhanAo - p2.PhanAo).ToString();
            return (pt + "-" + "i" + pa);
        }
    }
}
    