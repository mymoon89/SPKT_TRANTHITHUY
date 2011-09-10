using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_2_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create queue
            Queue queue = new Queue(10);

            //Add 3 element to queue
            queue.Push(4);
            queue.Push(8);
            queue.Push(-5);

            //Print queue
            queue.Print();

            //Pop first element out to queue
            Console.WriteLine("First element of queue have value: " + queue.Pop());

            //Print queue
            queue.Print();

            //Stop monitor
            Console.ReadLine();

        }
    }
}
