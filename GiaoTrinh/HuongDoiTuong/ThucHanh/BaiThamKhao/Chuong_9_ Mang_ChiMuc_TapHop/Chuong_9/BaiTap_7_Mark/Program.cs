using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_7_Mark
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create list mark of student
            Mark listMark = new Mark();

            //Print list
            listMark.PrintList();

            //Average of list marks
            Console.WriteLine("Average of list mark is: " + listMark.AverageOfList());

            //Stop monitor
            Console.ReadLine();

        }
    }
}
