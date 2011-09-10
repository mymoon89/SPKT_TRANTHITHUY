using System;
using System.Collections.Generic;
using System.Text;

namespace P178InterfaceSGK
{
    public interface IStorable
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
