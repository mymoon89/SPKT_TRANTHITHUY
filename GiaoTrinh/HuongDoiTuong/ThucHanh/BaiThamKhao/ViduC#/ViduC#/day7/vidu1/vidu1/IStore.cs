using System;
using System.Collections.Generic;
using System.Text;

namespace vidu1
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
