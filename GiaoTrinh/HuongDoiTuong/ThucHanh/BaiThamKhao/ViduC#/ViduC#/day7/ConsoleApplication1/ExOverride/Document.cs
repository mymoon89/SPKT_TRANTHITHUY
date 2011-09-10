using System;
using System.Collections.Generic;
using System.Text;

namespace ExOverride
{
    public class Document : IStore
    {
        public Document(string s)
        {
            Console.WriteLine("Tao Class :{0}", s);
        }
        #region IStore Members

        public virtual void Read()
        {
            Console.WriteLine("Trien khai Read cho IStore");
        }

        public void Write()
        {
            Console.WriteLine("Trien khai Write cua IStore");
        }

        #endregion
    }
}
