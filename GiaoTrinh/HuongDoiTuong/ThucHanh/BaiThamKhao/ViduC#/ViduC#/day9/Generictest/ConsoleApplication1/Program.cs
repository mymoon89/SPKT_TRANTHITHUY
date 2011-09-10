using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class List<T>
    {
        public void Add(T input) { }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            List<string >list2=new List<string>() ; 
            list1.Add(3);
            // aList.Add(5.0);
            list2 .Add ("This is string");
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            //list.Add("wrong No");
            //  list.Add(3.14);
            int total = 0;
            foreach (int val in list)
            {
                total = total + val;
            }

            Console.WriteLine("Total is {0}", total);

            
            

           
        }
    }
}