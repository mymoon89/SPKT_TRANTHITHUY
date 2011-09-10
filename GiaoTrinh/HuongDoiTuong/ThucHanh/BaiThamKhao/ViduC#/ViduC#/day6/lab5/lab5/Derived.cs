using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab5
{
    class Derived : Base
    {
        public Derived(){}
        public Derived(string var)
        {
            Console.WriteLine("In Derived constructor. Constructor parameter value:{0}", var);
        }

        public override void Method1()
        {
            base.Method1();
            Console.WriteLine("in the Derived class");
        }
        public new void Method2()
        {
            Console.WriteLine("In Derived.Method2");
        } 
    }
        class MoreDerived : Derived
        {
            //notice the use of the base keyword to chain the construction to the base 
            public MoreDerived()
                : base("DEFAULT")
            {
                Console.WriteLine("In MoreDerived Constructor!");
            }

        }
   

    }
