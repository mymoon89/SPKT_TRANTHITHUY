using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    class Program
    {   static short   x = 4; // Vung muc tin (field) cap Lop
        static short   y = 5;
        public  static  int   myFunc() {
            int   z=0;
           try
          {
                 z = checked((short)(x + y));
               
          }
          catch (System.OverflowException e) {
              Console.WriteLine(e.ToString());
           }
            return z;
        }
        static void Main(string[] args)
        {
            float d = 3.01234f;  // Bien cuc bo
            Console.WriteLine(" gia tri in ra la : {1}\n gia tri cua function la : {0}", myFunc(),d);
            Console.ReadLine();
        }
    }
}
