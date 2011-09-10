using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    public class Doc01 : IExtend01
    {
        #region IExtend01 Members

        public void AddMoreDoc()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IExtend Members

        public void Compress()
        {
            throw new NotImplementedException();
        }

        public void Decompress()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
