using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication2
{
    public class Document01 : IExtendStore_01
    {
        #region IStore Members

        public int Status
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IExtend Members

        public void Compress()
        {
            throw new NotImplementedException();
        }

        public void Depress()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
