using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// dùng HÀM như là các tham số
namespace vidu2
{
    delegate void Del(int i, double j);

    class MathClass
    {
        // Declare the associated method.
        void MultiplyNumbers(int m, double n)
        {
            System.Console.Write(m * n + " ");
        }
        static void Main()
        {
            MathClass m = new MathClass();

            // Delegate instantiation using "MultiplyNumbers"
            Del d = m.MultiplyNumbers;

            // Invoke the delegate object.
            System.Console.WriteLine("Invoking the delegate using 'MultiplyNumbers':");
            for (int i = 1; i <= 5; i++)
            {
                d(i, 2);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        
    }

}
