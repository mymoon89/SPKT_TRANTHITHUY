using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayString
{
    class Program
    {
         static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Working with System.Array.");

            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
            // Print out names in declared order.
            Console.WriteLine(" -> Here is the array:");
            for (int i = 0; i <= gothicBands.GetUpperBound(0); i++)
            {
                // Print a name
                Console.Write(gothicBands[i] + " ");
            }
        Console.WriteLine("\n");
            
            Array.Reverse(gothicBands); // dao chuoi
            Console.WriteLine(" -> The reversed array");
            // ... and print them.
            for (int i = 0; i <= gothicBands.GetUpperBound(0); i++)
            {
                // Print a name
                Console.Write(gothicBands[i] + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine(" -> Cleared out all but one...");

            Array.Clear(gothicBands, 1, 2); // thiết lập về Null, thành phân thứ 2, 3, giu lai 1
            for (int i = 0; i <= gothicBands.GetUpperBound(0); i++)// tra ve giá trị cận trên trong mảng
            {
                // Print a name
                Console.Write(gothicBands[i] + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            SystemArrayFunctionality();
            Console.ReadLine();

        }
    }
}
