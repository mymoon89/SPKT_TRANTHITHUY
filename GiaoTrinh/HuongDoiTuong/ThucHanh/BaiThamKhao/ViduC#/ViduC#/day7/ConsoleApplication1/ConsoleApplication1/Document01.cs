using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    public class Document01 : IExtend01_Store
    {
        private int status=0;
    
        public Document01(string s)
        {
            Console.WriteLine("Tao Doccument su dung :{0}",s);
        }

        
        #region IExtend01_Store Members

        public void ResizeDoc()
        {
            Console.WriteLine("Su dung Resize cua IEtend01_Store");
           // throw new NotImplementedException();
        }

        #endregion

        #region IExtend01 Members

        public void AddMoreDoc()
        {
            Console.WriteLine(" Su dung AddMoreDoc cua Extend01");
            //throw new NotImplementedException();
        }

        #endregion

        #region IExtend Members

        public void Compress()
        {
            Console.WriteLine("su dung Compress cua IExtend");
            //throw new NotImplementedException();
        }

        public void Decompress()
        {
            Console.WriteLine(" Su dung Ddecompress cua EXtend");
            //throw new NotImplementedException();
        }

        #endregion

        #region IStore Members

        public void Read()
        {
            Console.WriteLine("su dung read cua IStore");
            //throw new NotImplementedException();
        }

        public void Write(object obj)
        {
            Console.WriteLine(" Su dung Write cua IStore");
            //throw new NotImplementedException();
        }

        public int Status
        {
            get
            {
                return status;
    //            throw new NotImplementedException();
            }
            set
            {
                status = value;
                //throw new NotImplementedException();
            }
        }

        #endregion
    }
}
