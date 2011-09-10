using System;
using System.Collections.Generic;
using System.Text;

namespace GenInheritance
{
    public class MySubClass<T, U> : MyBaseClass<U>
    {
        private T _myData;
        public MySubClass() { }
        public MySubClass(T val1, U val2)
            : base(val2)
        {
            this._myData = val1;
        }
    }

}
