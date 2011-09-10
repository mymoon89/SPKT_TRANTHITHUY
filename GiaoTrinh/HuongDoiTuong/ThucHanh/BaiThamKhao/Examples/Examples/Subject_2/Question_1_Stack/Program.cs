using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_1_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Create stack have 10 element
                Stack stack = new Stack(10);

                //Push 2 element to stack
                stack.push(9);
                stack.push(-5);
                
                //Print stack
                Console.Write("Value of stack: ");
                stack.printStack();

                //Push element to stack
                Console.Write("Please input value need push: ");
                int x = int.Parse(Console.ReadLine());
                stack.push(x);

                //Print stack
                Console.Write("Value of stack: ");
                stack.printStack();

                //Push 3 element to stack
                Console.WriteLine("Push 3 element 5, 7, -2 to stack.");
                stack.push(5);
                stack.push(7);
                stack.push(-2);

                //Print stack
                Console.Write("Value of stack: ");
                stack.printStack();

                //Pop stack
                Console.WriteLine("Pop stack !The first element of stack is: " + stack.pop());                

                //Print stack
                Console.Write("Value of stack: ");
                stack.printStack();

                //Stop monitor
                Console.ReadLine();

            }
            catch (FormatException fEx)
            {
                Console.WriteLine("Error: " + fEx.Message);

            }
        }
    }
}
