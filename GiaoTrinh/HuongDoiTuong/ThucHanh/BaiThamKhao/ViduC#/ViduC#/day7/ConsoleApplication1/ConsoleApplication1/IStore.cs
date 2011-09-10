using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public interface IStore
    {
        void Read();
        void Write(object obj);
        int Status { get; set; }
    }

   

    
}
