using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenInheritance
{
    public class MyBaseClass<U>
    {
        private U _parentData;
        public MyBaseClass() { }
        public MyBaseClass(U val)
        {
            this._parentData = val;
        }
    }

}
