using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_2_Pointer
{
    class Test
    {
        static void Main(string[] args)
        {
            //Create pointer
            Pointer pointer = new Pointer();
            
            //Input pointer from keyboard
            pointer.InputPointer();

            //Display pointer into monitor
            pointer.DisplayPointer(pointer);

            //Stop monitor
            Console.ReadLine();


        }
    }
}
