using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            Console.WriteLine(" gia tri ban dau: a= {0}, b={1}",a,b);
           // Swap<int>(ref a, ref b);
            SwapIfGreater<int>(ref a, ref b);
             Console.WriteLine(a + " " + b);
        }
        
       /*  static void Swap<T>(ref T lhs, ref T rhs)
                   {
                     T temp;
                      temp = lhs;
                     lhs = rhs;
                     rhs = temp;
                     }  */
     static  void SwapIfGreater<T>(ref T lhs, ref T rhs)  where T : IComparable<T>
        {
            T temp;
            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        } 

          
        }
     
}
