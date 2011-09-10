using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication2
{
    public class Document : IStore, IExtend
    {
        private int status;
        #region IStore Members

        public int Status
        {
            get
            {
                return status;
                throw new NotImplementedException();
            }
            set
            {
                status = value;
                throw new NotImplementedException();
            }
        }

        public void Read()
        {
            Console.WriteLine("");
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
