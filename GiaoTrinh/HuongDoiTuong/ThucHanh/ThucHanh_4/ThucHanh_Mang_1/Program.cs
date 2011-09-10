using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Array121
{
    class Program
    {        
         static void Main(string[] args)
        {
            int[] myArray;
            myArray = new int[10];
            Random rand=new Random();
            for (int i = 0; i < 10;i++ )
            {
               myArray[i] = rand.Next(100);
            }
                         
            foreach (int i in myArray)
            {
                Console.WriteLine(i);
            }
            List<int> mylist= myArray.ToList<int>();
            mylist.Sort();
            Console.WriteLine("sau khi sort");
             foreach (int j in mylist)
                Console.WriteLine(j);

             Console.WriteLine("xep giam");
             mylist.Sort(sortint);
             foreach (int j in mylist)
                 Console.WriteLine(j);
            
        }

         static int sortint(int i, int j)
         {
             if (i > j)
                 return -1;
             else if (i == j)
                 return 0;
             return 1;
         }
    }
}
