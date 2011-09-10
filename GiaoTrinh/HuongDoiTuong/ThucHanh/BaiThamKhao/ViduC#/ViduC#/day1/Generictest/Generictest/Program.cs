using System;
using System.Collections;
using System.Text;

namespace Generictest
{
    public class List<T> { }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            
           // list1.Add(1);
            ArrayList list = new ArrayList();
              list.Add(3);
              list.Add(4);
            //list.Add("wrong No");
             list.Add(3.14);
            int total = 0;
            foreach(int val in list)
            {
                total = total + val;
            }

            Console.WriteLine( "Total is {0}", total);
        }
    }
}

