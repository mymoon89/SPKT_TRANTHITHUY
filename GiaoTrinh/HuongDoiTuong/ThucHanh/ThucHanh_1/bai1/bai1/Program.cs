using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bai1
{
    class Program
    {

        /* Document DOC = new Document();
        // DOC.Status = -1;
         //DOC.Read();
         Console.WriteLine("Ban se luu ten:{0}", DOC.Status);
         //gan cho giao dien va su dung giao dien
         IStore ISDOC = (IStore)DOC;
         ISDOC.Read();
         ISDOC.Status = 0;
         Console.WriteLine("Ban se luu gi tiep:{0}", ISDOC.Status);
         IComp COM = DOC;
         COM.Comp();*/
        interface IStorable
        {
            void Read();
            void Write();
        }
        interface ITalk
        {
            void Talk();
            void Read();
        }
        // lớp Document thực thi hai giao diện 
        public class Document : IStorable, ITalk
        {
            // bộ khởi dựng
            public Document(string s)
            {
                Console.WriteLine("Creating document with: {0}", s);
            }
            // tạo phương thức ảo 
            public virtual void Read()
            {
                Console.WriteLine("Implementing IStorable.Read");
            }
            // thực thi bình thường 
            public void Write()
            {
                Console.WriteLine("Implementing IStorable.Write");
            }
            // thực thi tường minh 
            void ITalk.Read()
            {
                Console.WriteLine("Implementing ITalk.Read");
            }
            public void Talk()
            {
                Console.WriteLine("Implementing ITalk.Talk");
            }
        }

        static void Main(string[] args)
        {
            // tạo đối tượng Document
            Document theDoc = new Document("Test Document");
            IStorable isDoc = theDoc as IStorable;
            if (isDoc != null)
            {
                isDoc.Read();
            }
            ITalk itDoc = theDoc as ITalk;
            if (itDoc != null)
            {
                itDoc.Read();
            }
            theDoc.Read();
            theDoc.Talk();
        }
    }
}
