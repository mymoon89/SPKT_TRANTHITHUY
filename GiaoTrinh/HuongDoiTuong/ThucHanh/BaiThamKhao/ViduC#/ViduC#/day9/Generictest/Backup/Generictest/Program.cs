using System;
using System.Collections;
using System.Text;

namespace Generictest
{
     public class List<T>
    {
       public  void Add(T input) { }
    }  
    
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            List<string > list2 =new List<string>() ; 
            // No boxing, no casting:
            list1.Add(3); 

            // Compile-time error:
            list2.Add("It is raining in Redmond.");
            ArrayList list = new ArrayList();
              list.Add(1);
              list.Add(2);
            //list.Add("wrong No");
           //  list.Add(3.14);
            int total = 0;
            foreach(int val in list)
            {
                total = total + val;
            }

            Console.WriteLine( "Total is {0}", total);
        }
    }
}

