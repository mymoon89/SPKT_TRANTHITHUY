using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toanhoc.HinhHoc
{
    public class Tamgiac
    {
        //public int c;
        public int c1, c2, c3;
        public Tamgiac(int ca)
        {
            c1=ca;
            c2=ca;
            c3=ca;
        }
        
        public Tamgiac(int a, int b, int c)
        {
            c1 = a;
            c2 = b;
            c3 = c;
        }
        public void DienTich()
        {
            double S;
            float k=(c1*c2*c3)/2;
            S = Math.Sqrt(k * (k - c1) * (k - c2) * (k - c3));
            Console.WriteLine("Dien tich:{0}", S);

        }
        public void ChuVi()
        {
            int P;
            P=c1+c2+c3;
            Console.WriteLine("Chu vi:{0}", P);
        }

    }
    public class HinhChuNhat
    {
        public int cd, cr;
        public HinhChuNhat(int d, int r)
        {
            cd = d;
            cr = r;
        }
        public void ChuVi()
        {
            int P = (cd + cr) * 2;
            Console.WriteLine("Chu vi:{0}", P);
        }
        public void DienTich()
        {
            int S = cd*cr;
            Console.WriteLine("DienTich:{0}", S);
        }
    }
    public class HinhVuong
    {
        public int canh;
        public HinhVuong(int c)
        {
            canh = c;
        }
        public void ChuVi()
        {
            int P = canh*4;
            Console.WriteLine("Chu vi:{0}", P);
        }
        public void DienTich()
        {
            int S = canh*canh;
            Console.WriteLine("DienTich:{0}", S);
        }
    }
    public class HinhTron
    {
        public int bk;
        public HinhTron(int b)
        {
            bk = b;
        }
        public void ChuVi()
        {
            double P = 2 * 3.14 * bk;
            Console.WriteLine("Chu vi:{0}", P);
        }
        public void DienTich()
        {
            double S = 3.14 * bk * bk;
            Console.WriteLine("DienTich:{0}", S);
        }
    }



}
