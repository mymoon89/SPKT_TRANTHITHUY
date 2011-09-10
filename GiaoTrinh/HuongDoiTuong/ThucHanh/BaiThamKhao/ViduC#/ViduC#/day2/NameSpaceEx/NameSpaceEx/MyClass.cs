using System;
using System.Collections.Generic;
using System.Text;

namespace NameSpaceEx
{
    public class MyClass
    {
        static void Main()
        {
            Console.WriteLine("Dong cua Main()");
            B.LopCuaB.Display();
        }
    }

    // Qua 1 namespace khac
    namespace B 
    {
        public class LopCuaB
        {
            public static void Display()
            {
                Console.WriteLine("Dong cua B");
                Console.ReadLine();
            }
        }
    }

}
