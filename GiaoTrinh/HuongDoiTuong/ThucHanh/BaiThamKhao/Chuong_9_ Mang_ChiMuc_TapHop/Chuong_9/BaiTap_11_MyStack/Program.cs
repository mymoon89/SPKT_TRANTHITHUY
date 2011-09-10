using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_11_MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create stack have 5 element
            MyStack myStack = new MyStack();

            //Print stack
            Console.Write("Value of stack is:\t");
            myStack.PrintStack();

            //Pop 1 element out to stack
            Console.WriteLine("Pop 1 element out to stack. Value is: " + myStack.Pop());

            //Print stack
            Console.Write("Value of stack is:\t");
            myStack.PrintStack();

            //Pop 1 element out to stack
            int[] listPop = myStack.PopTwoElement();
            Console.WriteLine("Pop 2 element out to stack.");
            foreach (int element in listPop)
            {
                Console.WriteLine("\tValue is: " + element);
            }

            //Print stack
            Console.Write("Value of stack is:\t");
            myStack.PrintStack();

            //Display first element of stack
            Console.WriteLine("The first element of stack is: " + myStack.DisplayFirstElement());

            //Print stack
            Console.Write("Value of stack is:\t");
            myStack.PrintStack();

            //Push element has value is 29 to stack
            Console.WriteLine("Push element has value is 29 to stack");
            myStack.Push(29);

            //Print stack
            Console.Write("Value of stack is:\t");
            myStack.PrintStack();

            //Stop monitor
            Console.ReadLine();
        }
    }
}
