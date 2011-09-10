using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiVeNhaSo1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("+ Nhap vao chieu cao cua hinh tam giac n = ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if ((j > 0) && (j < i))
                        Console.Write(" ");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int k = 0; k < n; k++)
                Console.Write("*");
            Console.WriteLine();

        }
    }
}
