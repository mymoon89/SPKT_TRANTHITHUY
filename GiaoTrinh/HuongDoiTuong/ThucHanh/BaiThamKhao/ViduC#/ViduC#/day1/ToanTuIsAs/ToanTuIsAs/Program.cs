using System;
using System.Collections.Generic;
using System.Text;

namespace ToanTuIsAs
{
    class Program
    {
        static void Main(string[] args)
        {   // toán tử is
            int i = 1;
            if (i is object)
                Console.WriteLine(" I la mot doi tuong");
            else
                Console.WriteLine("I khong la doi tuong");
            Console.ReadLine();
        }
    }
}
