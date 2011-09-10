using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace vidu3
{
    class ThreadPoolExample
    {
        static void Main()
        {
            const int FibonacciCalculations = 10;
            // One event is used for each Fibonacci object
            ManualResetEvent[] doneEvents = new ManualResetEvent[FibonacciCalculations];
            Fibonacci[] fibArray = new Fibonacci[FibonacciCalculations];
            Random r = new Random();

            Console.WriteLine("launching {0} tasks...", FibonacciCalculations);
            for (int i = 0; i < FibonacciCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                 Fibonacci  f = new Fibonacci(r.Next(20, 40), doneEvents[i]);
                fibArray[i] = f;
                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
            }
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete.");
            // Display the results...
            for (int i = 0; i < FibonacciCalculations; i++)
            {
                Fibonacci f = fibArray[i];
                Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
            }
        }

    }
}
