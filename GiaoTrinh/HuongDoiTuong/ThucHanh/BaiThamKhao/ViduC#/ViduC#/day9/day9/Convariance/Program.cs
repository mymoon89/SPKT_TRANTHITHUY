using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Convariance
{
    class Mammals
    {
    }

    class Dogs : Mammals
    {
    }

    class Program
    {
        // Define the delegate.
        public delegate Mammals HandlerMethod();

        public static Mammals FirstHandler()
        {
            return null;
        }

        public static Dogs SecondHandler()
        {
            return null;
        }

        static void Main()
        {
            HandlerMethod handler1 = FirstHandler;

            // Covariance allows this delegate.
            HandlerMethod handler2 = SecondHandler;
        }
    }

}
