using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_10_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create queue
            MyQueue myQueue = new MyQueue();

            //Print queue
            Console.Write("Values of queue is:\t");
            myQueue.Print();

            //Pop element out to queue
            Console.WriteLine("Pop queue! Value of this element is: " + myQueue.Pop());

            //Print queue
            Console.Write("Values of queue is:\t");
            myQueue.Print();

            //Pop 2 elements out to queue
            int[] listPop = new int[2];
            listPop = myQueue.PopTwoElement();
            if (listPop != null)
            {
                Console.Write("Pop 2 elements ! Values of 2 element are:\t");
                foreach (int element in listPop)
                {
                    Console.Write(element + "\t");
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("Queue is empty");

            //Print queue
            Console.Write("Values of queue is:\t");
            myQueue.Print();

            //Display first element of queue
            Console.WriteLine("The first element of queue is: " + myQueue.DisplayFirstElement());

            //Push element to queue
            Console.WriteLine("Push 29 to queue");
            myQueue.Push(29);

            //Print queue
            Console.Write("Values of queue is:\t");
            myQueue.Print();

            //Stop monitor
            Console.ReadLine();

        }
    }
}
