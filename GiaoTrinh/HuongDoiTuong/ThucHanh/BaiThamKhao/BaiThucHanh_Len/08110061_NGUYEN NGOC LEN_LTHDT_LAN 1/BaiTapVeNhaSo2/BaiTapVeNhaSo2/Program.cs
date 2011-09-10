using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapVeNhaSo2
{
    class Program
    {
        static void Main(string[] args)
        {
            int h, n;
            Console.Write("Nhap vao chieu cao h = ");
            h = int.Parse(Console.ReadLine());
            n = h - 2;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= 2 * n - 2; j++)
                {
                    if ((j < 2 * n - 2 - 2 * i) || (j > 2 * n - 2 - 2 * i) && (j < 2 * n - 2))
                        Console.Write(" ");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int k = n - 2; k >= 0; k--)
            {
                for (int l = 0; l <= 2 * n - 2; l++)
                {
                    if ((l < 2 * n - 2 - 2 * k) || (l > 2 * n - 2 - 2 * k) && (l < 2 * n - 2))
                        Console.Write(" ");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
