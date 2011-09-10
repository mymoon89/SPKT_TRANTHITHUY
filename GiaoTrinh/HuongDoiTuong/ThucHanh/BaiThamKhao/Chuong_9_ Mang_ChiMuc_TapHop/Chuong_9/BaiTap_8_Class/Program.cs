using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_8_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create list student
            MyClass listStudent = new MyClass();

            //Print list student
            listStudent.PrintList();

            //Stop monitor
            Console.ReadLine();
        }
    }
}
