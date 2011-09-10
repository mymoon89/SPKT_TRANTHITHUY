using System;
using System.Threading;
namespace vidu3
{
    public class Fibonacci
    {
        public Fibonacci(int n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }
        public void ThreadPoolCallback(Object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine("thread {0} started...", threadIndex);
            _fibOfN = Calculate(_n);
            Console.WriteLine("thread {0} result calculated...", threadIndex);
            _doneEvent.Set();
        }
        public int Calculate(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return Calculate(n - 1) + Calculate(n - 2);
        }
        public int N { get { return _n; } }
        private int _n;
        public int FibOfN { get { return _fibOfN; } }
        private int _fibOfN;
        private ManualResetEvent _doneEvent;
    }

}