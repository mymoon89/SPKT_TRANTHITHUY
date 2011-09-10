using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLinQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var evenNumQuery = from num in numbers
                               where (num % 2) == 0
                               select num;
            int evenNumCount = evenNumQuery.Count();           
            Console.WriteLine("So Luong So Chan: " +evenNumCount);

            /* List<int> numQuery2 = (from num in numbers
                                   where (num % 2) == 0
                                   select num).ToList();
             Console.WriteLine("So Luong So Chan:"+numQuery2.Count);*/
           
            //numQuery3 vẫn là int[]
             /*var numQuery3 = (from num in numbers
                             where (num % 2) == 0
                             select num).ToArray();
             Console.WriteLine("So Luong So Chan: " +numQuery3.LongLength);*/
             Console.ReadLine();
        }
    }
}
