using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P182InterfaceSGK
{
    public interface I1
    {
        void Read();
        void Write(object obj);
        int Status
        {
            get;
            set;
        }
    }
}
