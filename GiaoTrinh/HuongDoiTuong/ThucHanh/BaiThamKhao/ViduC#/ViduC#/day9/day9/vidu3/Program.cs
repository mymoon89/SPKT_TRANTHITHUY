using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// liên quan đến Static method
namespace vidu3
{
    delegate void Del();

    class SampleClass
    {
        public void InstanceMethod()
        {
            System.Console.WriteLine("A message from the instance method.");
        }

        static public void StaticMethod()
        {
            System.Console.WriteLine("A message from the static method.");
        }
    }

    class TestSampleClass
    {
        static void Main()
        {
            SampleClass sc = new SampleClass();

            // Map the delegate to the instance method:
            Del d = sc.InstanceMethod;
            d();

            // Map to the static method:
            d = SampleClass.StaticMethod;
            d();
        }
    }

}
