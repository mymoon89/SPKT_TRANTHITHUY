using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication3
{
    public class Document : IStore
    {
        private int status;

        public Document(string s)
        {
            Console.WriteLine("Goi constructor Document");
        }
        #region IStore Members

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

        public void Read()
        {
            Console.WriteLine("la read cua IStore");
        }

        public void Write()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
