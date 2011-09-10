using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Arraylist
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            list.Add(3);
            list.Add(4);
           // list.Add(5.0);

            int total = 0;
            foreach (int val in list)
            {
                total = total + val;
            }

            Console.WriteLine("Total is {0}", total);
            Console.ReadLine();
        }
    }
}
