using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using HinhHoc;


namespace ThuaKe_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point(100, 100);
            Point b = new Point(200, 200);

            DoanThang dt = new DoanThang(a,b);
            try
            {
                dt.Chuvi();
            }
            catch
            {
                Console.WriteLine("Doan thang ko co chu vi, chi co chieu dai");
                Console.ReadKey();
            }
            try
            {
                dt.DienTich();
            }
            catch
            {
                Console.WriteLine("Doan thang ko co dien tich, chi co chieu dai");
                Console.ReadKey();
            }
            
            

            
        }
    }
}
