using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document("Kiem tra Interface Document");
            doc.Status = -1;
            doc.Read();
            Console.WriteLine("Status cua class Document:{0}",doc.Status);
            // ep kieu Document thanh kieu giao dien IStrore
            IStore epDoc = (IStore)doc;
            epDoc.Status = 0;
            epDoc.Read();
            epDoc.Write(doc);
            Console.WriteLine("trang thai cua Interface: {0}",epDoc.Status);
          
            Document01 doc1 = new Document01("Su dung phoi hop Interface");
            // ep qui chieu doc1 ve cac kieu Intefacce
            
            IStore isDoc1=(IStore)doc1;
            isDoc1.Read();

            IExtend ieDoc1 = (IExtend)doc1;
            ieDoc1.Compress();

            IExtend01 ie01Doc1 = (IExtend01)doc1;
            ie01Doc1.AddMoreDoc();
 
            IExtend01_Store iesDoc1 = doc1 as IExtend01_Store;
            iesDoc1.AddMoreDoc(); // lay tu IExtend01
            iesDoc1.Compress();// lay tu IExtend
            iesDoc1.Read();// lay tu IEStore
            iesDoc1.ResizeDoc();// lay tu Chinh no'
            
        }
    }
}
