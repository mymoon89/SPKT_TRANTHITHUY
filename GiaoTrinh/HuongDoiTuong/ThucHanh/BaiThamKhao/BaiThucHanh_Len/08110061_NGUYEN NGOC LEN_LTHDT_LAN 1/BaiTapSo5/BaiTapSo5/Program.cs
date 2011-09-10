using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapSo5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.Write("+ Nhap vao chieu rong a = ");
            a = int.Parse(Console.ReadLine());
            Console.Write("+ Nhap vao chieu dai  b = ");
            b = int.Parse(Console.ReadLine()); ;
            for (int k = 0; k < b; k++)
                Console.Write("*");
            Console.WriteLine();
            for (int i = 1; i < a - 1; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if ((j > 0) && (j < b - 1))
                        Console.Write(" ");
                    else
                        Console.Write("*");   
                }
                Console.WriteLine();
            }
            for (int l = 0; l < b; l++)
                Console.Write("*");
            Console.WriteLine();

        



            
        }
    }
}
