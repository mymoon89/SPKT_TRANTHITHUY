using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapSo7
{
    class Program
    {
        static void Main(string[] args)
        {
            int c;
            do
            {
                Console.Write(".:.Nhap mot ki tu bat ki tu ban phim : ");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                Console.Write(".:.Ma ASCII cua ki tu vua nhap la    : ");
                Console.WriteLine("{0} = {1}", (Char)c, c);
            } while (c != 13);
        }
    }
}
