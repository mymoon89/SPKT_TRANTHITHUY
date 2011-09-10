using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication2
{
    public interface IStore
    {
        int Status
        {
            get;
            set;
        }
    
        void Read();

        void Write();
    }
}
