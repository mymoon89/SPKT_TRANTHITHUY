using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab5
{
    class Client
    {
        static void Main(string[] args)
        {
            TestStaticBinding(); 
            /*
            Base b;
            b = new Derived();
            //call inherited implementation for method1 on Derived instance. 
            b.Method1();
            Base c = new MoreDerived();
            c.Method1(); 
            */

        }
        static void TestStaticBinding()
        {
            Base b;
            Derived d;
            //create an instance of Derived 
            d = new Derived("test");
            b = d;
            b.Method2();//does this go to Derived implementation or Base? 
            d.Method2();//what about this call? 
        } 

    }
}
