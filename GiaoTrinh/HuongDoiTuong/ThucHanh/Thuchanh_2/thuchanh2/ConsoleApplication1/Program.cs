using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Toanhoc.phanso
            Console.WriteLine("Nhap Tuso:");
            int t = int.Parse(Console.ReadLine());
            Toanhoc.Phanso p1 = new Toanhoc.Phanso(t);
            p1.Xuat();
            Console.WriteLine("Tuso mauso");
            int tu = int.Parse(Console.ReadLine());
            int mau = int.Parse(Console.ReadLine());
            Toanhoc.Phanso p2 = new Toanhoc.Phanso(tu,mau);
            p2.Xuat();


            //Toanhoc.hinhhoc.tamgiac
            Console.WriteLine("Nhap chieu dai canh:");
            int c = int.Parse(Console.ReadLine());
            Toanhoc.HinhHoc.Tamgiac t1 = new Toanhoc.HinhHoc.Tamgiac(c);
            t1.ChuVi();
            t1.DienTich();
            Console.WriteLine("Nhap chieu 3 dai canh:");
            int c1 = int.Parse(Console.ReadLine());
            int c2= int.Parse(Console.ReadLine());
            int c3 = int.Parse(Console.ReadLine());
            Toanhoc.HinhHoc.Tamgiac t2 = new Toanhoc.HinhHoc.Tamgiac(c1,c2,c3);
            t2.ChuVi();
            t2.DienTich();

            //Toanhoc.hinhhoc.HinhChuNhat
            Console.WriteLine("Nhap chieu 2 dai canh:");
            int cd = int.Parse(Console.ReadLine());
            int cr = int.Parse(Console.ReadLine());
            Toanhoc.HinhHoc.HinhChuNhat cn = new Toanhoc.HinhHoc.HinhChuNhat(cd,cr);
            cn.ChuVi();
            cn.DienTich();

            //Toanhoc.hinhhoc.HinhVuong
            Console.WriteLine("Nhap chieu dai canh:");
            int canh = int.Parse(Console.ReadLine());
            Toanhoc.HinhHoc.HinhVuong v = new Toanhoc.HinhHoc.HinhVuong(canh);
            v.ChuVi();
            v.DienTich();

            //Toanhoc.hinhhoc.HinhTron
            Console.WriteLine("Nhap Ban Kinh:");
            int bk = int.Parse(Console.ReadLine());
            Toanhoc.HinhHoc.HinhTron tron = new Toanhoc.HinhHoc.HinhTron(bk);
            tron.ChuVi();
            tron.DienTich();
            
            Console.ReadKey();

        }
    }
}
