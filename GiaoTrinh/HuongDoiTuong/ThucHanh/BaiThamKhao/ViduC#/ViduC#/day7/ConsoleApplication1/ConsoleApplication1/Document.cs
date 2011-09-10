using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    public class Document : IStore, IExtend 
    {
        private int status = 0;
        public Document(string s)
        {
            Console.WriteLine("Tao Class :{0}",s);
        }

        #region IStore Members

        public void Read()
        {
            Console.WriteLine("Trien khai read");
            //throw new NotImplementedException();
        }

        public void Write(object obj)
        {
            Console.WriteLine("trien khai Write");
        //    throw new NotImplementedException();
        }

        public int Status
        {
            get
            {
                return status;
            //    throw new NotImplementedException();
            }
            set
            {
                status = value;
           //     throw new NotImplementedException();
            }
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
