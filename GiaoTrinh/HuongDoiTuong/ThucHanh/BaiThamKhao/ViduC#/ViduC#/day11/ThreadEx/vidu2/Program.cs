 using System;
using System.Threading;
namespace ThreadEx
{
    class Tester
    {
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;

        static void Main()
        {
            for (int i = 0; i < numThreads; i++)
            {
                Thread myThread = new Thread(new ThreadStart(MyThreadProc));
                myThread.Name = String.Format("Thread{0}", i + 1);
                myThread.Start();
            }

            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.
        }
    private static void MyThreadProc()
    {
        for (int i = 0; i < numIterations; i++)
        {
            UseResource();
        }
    }
private static void UseResource()
    {
        // Wait until it is safe to enter.
        mut.WaitOne();

 Console.WriteLine("{0} has entered the protected area",
        Thread.CurrentThread.Name);

        // Place code to access non-reentrant resources here.

        // Simulate some work.
        Thread.Sleep(500);

 Console.WriteLine("{0} is leaving the protected area\r\n",
        Thread.CurrentThread.Name);
        // Release the Mutex.
        mut.ReleaseMutex();
    }
}

    }

 