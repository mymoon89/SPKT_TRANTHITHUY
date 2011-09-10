using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vidu1
{
    delegate double MathAction(double num);
     
    class DelegateTest
    {
        // Regular method that matches signature:
        static double Double(double input)
        {
            return input * 2;
        }

        static void Main()
        {
            // Instantiate delegate with named method:
            MathAction math = Double;

            // Invoke delegate math:
            double multByTwo = math(4.5);
            Console.WriteLine(multByTwo);

            // Instantiate delegate with anonymous method:
            MathAction math2 = delegate(double input)
            {
                return input * input;
            };

            double square = math2(5);
            Console.WriteLine(square);

            // Instantiate delegate with lambda expression
            MathAction math3 = s => s * s * s;
            double cube = math3(4.375);

            Console.WriteLine(cube);
        }
    }

}
