using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    public interface IExtend01_Store :  IStore,IExtend01
    {
        void ResizeDoc();
    }
}
