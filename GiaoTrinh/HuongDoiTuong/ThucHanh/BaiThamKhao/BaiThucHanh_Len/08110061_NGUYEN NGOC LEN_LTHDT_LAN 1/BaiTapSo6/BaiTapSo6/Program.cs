using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapSo6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            bool kt;
            kt = true;
            Console.Write("+ Nhap vao mot so n = ");
            n = int.Parse(Console.ReadLine());
            if (n == 0 || n == 1)
                kt = false;
            if(n>=2)
                for(int i = 2; i<n; i++)
                    if (n % i == 0)
                    {
                        kt = false;
                        break;
                    }
            if (kt)
                Console.WriteLine(".:.So {0} la so nguyen to!", n);
            else
                Console.WriteLine(".:.So {0} KHONG la so nguyen to!", n);
        }
    }
}
