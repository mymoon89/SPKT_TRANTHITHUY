using System;
using System.Collections.Generic;
using System.Text;

namespace P182InterfaceSGK
{
    public class Document : I5, I413
    {
        public Document( string s)
        {
        Console.WriteLine("Creating document with: {0}", s);
        }
        private int status = 0;
        #region I5 Members

        public void Encrypt()
        {
            Console.WriteLine("Implementing Encrypt");
        }

        public void Decrypt()
        {
            Console.WriteLine("Implementing Decrypt");
        }

        #endregion

        #region I413 Members

        public void LogOriginalSize()
        {
             Console.WriteLine("Implementing LogOriginalSize");
        }

        #endregion

        #region I1 Members

        public void Read()
        {
             Console.WriteLine("Implementing the Read Method for IStorable");
        }

        public void Write(object obj)
        {
             Console.WriteLine("Implementing the Write Method for IStorable");
        }

        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        #endregion

        #region I32 Members

        public void LogSavedBytes()
        {
             Console.WriteLine("Implementing LogSavedBytes");
        }

        #endregion

        #region I2 Members

        public void Compress()
        {
            Console.WriteLine("Implementing Compress");
        }

        public void Decompress()
        {
             Console.WriteLine("Implementing Decompress");
        }

        #endregion
    }
}
