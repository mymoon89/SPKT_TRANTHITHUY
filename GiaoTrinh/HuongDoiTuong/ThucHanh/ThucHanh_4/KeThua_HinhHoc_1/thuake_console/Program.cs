using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace thuake_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point(4, 100);
            Point b = new Point(98, 200);
            Point c = new Point(89, 300);
            // HinhHoc H= new HinhHoc();
            DoanThang dt = new DoanThang(a, b);
            TamGiac tg = new TamGiac(a, b, c);
            try
            {
               // dt.ChuVi();
            }
            catch
            {
                Console.Write("kjni");
            }
            Console.WriteLine(dt.A);
            Console.WriteLine(tg.ChuVi());
            Console.WriteLine(tg.DienTich());
        }
    }
}
