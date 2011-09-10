using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverflowException1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = Int32.MaxValue;  // 2,147,483,647
            int number2 = Int32.MaxValue;  // 2,147,483,647
            int sum = 0;

            Console.WriteLine(
               "number1: {0}\nnumber2: {1}", number1, number2);

            // calculate sum of number1 and number2
            try
            {
                Console.WriteLine(
                   "\nSum integers in checked context:");

                sum = checked(number1 + number2);
            }

            // catch overflow exception
            catch (OverflowException overflowException)
            {
                Console.WriteLine(overflowException.ToString());
            }

            Console.WriteLine(
               "\nsum after checked operation: {0}", sum);
         Console.WriteLine( 
            "\nSum integers in unchecked context:" );
   
         sum = unchecked( number1 + number2 );
   
         Console.WriteLine( "sum after unchecked operation: {0}", sum );
   
      }  
   
   }  

        }
    
