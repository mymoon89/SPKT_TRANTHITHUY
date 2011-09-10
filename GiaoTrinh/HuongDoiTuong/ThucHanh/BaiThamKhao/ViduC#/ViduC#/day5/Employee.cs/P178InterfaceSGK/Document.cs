using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P178InterfaceSGK
{
    public class Document : IStorable  
    {
        public Document(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }
        public void Read()
        {
            Console.WriteLine("Implement the Read Method for IStorable");
        }
        // thực thi phương thức Write
        public void Write(object o)
        {
            Console.WriteLine("Impleting the Write Method for IStorable");
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
        private int status = 0;
    }
}