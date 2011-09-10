using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapSo4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            float x1, x2, delta;
            Console.Write("+ Nhap vao he so a = ");
            a = int.Parse(System.Console.ReadLine());
            Console.Write("+ Nhap vao he so b = ");
            b = int.Parse(Console.ReadLine());
            Console.Write("+ Nhap vao he so c = ");
            c = int.Parse(Console.ReadLine());
            delta = b * b - 4 * a * c;
            if (delta == 0)
            {
                x1 = -b / (2 * a);
                Console.WriteLine(".:.Phuong trinh co nghiem kep x = {0}",x1);
            }
            if (delta > 0)
            {
                x1 = (-b + (float)Math.Sqrt(delta)) / (2 * a);
                x2 = (-b - (float)Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine(".:.Phuong trinh co hai nghiem phan biet x1 = {0} va x2 = {1}", Math.Round(x1, 2), Math.Round(x2));
            }
            if (delta < 0)
            {
                x1 = -b / (2 * a);
                x2 = (float)Math.Sqrt(-delta) / (2 * a);
                Console.WriteLine(".:.Phuong trinh co hai nghiem thuc x1 = {0}+{1}i va x2 = {0}-{1}i", Math.Round(x1,2), Math.Round(Math.Abs(x2), 2));
            }
            
        }
    }
}
