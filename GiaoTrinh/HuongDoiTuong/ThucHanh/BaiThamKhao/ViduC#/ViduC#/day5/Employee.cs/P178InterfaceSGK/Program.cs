using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P178InterfaceSGK
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document("Test Document");
            doc.Status = -1;
            doc.Read();
            Console.WriteLine("Document Status: {0}", doc.Status);
            
            // gán cho một giao diện và sử dụng giao diện
            IStorable isDoc = (IStorable) doc;
            isDoc.Status = 0;
            isDoc.Read();
            Console.WriteLine("IStorable Status: {0}", isDoc.Status);

        }
    }
}
