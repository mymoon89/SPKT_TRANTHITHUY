using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapVeNhaSo3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.Write("+ Nhap vao chieu cao n = ");
            n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n + i - 1; j++)
                {
                    if ((j < n - i - 1) || (j > n - i - 1) && (j < n + i - 1))
                        Console.Write("  ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
               
            }
            for (int k = 0; k < n - 1; k++)
            {
                for (int l = 0; l <= 2 * n - k - 3; l++)
                {
                    if ((l < k + 1) || (l > k + 1) && (l < 2 * n - k - 3))
                        Console.Write("  ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine(); 
            }
        }
    }
}
