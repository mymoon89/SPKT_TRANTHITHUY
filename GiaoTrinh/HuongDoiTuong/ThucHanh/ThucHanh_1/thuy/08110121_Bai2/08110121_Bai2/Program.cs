using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToanHoc;
using ToanHoc.HinhHoc;

namespace _08110121_Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            PhanSo p1 = new ToanHoc.PhanSo(3,4);
            //p1._TuSo = 3;
            //p1._MauSo = 4;
            p1.Xuat();
            PhanSo p2 = new ToanHoc.PhanSo(3);
            p2.Xuat();
            TamGiac t1 = new TamGiac(3);
            Double g = t1.DienTich;
            Console.WriteLine(g);            
            Console.WriteLine();            
        }
    }
}
