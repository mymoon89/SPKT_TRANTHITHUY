using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    class Program
    {  static short x = 32767;
        static short y = 32767;
        public static int myFunc() {
            int z=0;
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
            float d = 3.01234f;
            Console.WriteLine(" gia tri in ra la : {1}\n gia tri cua f la : {0:2}", myFunc(),d);
        }
    }
}
