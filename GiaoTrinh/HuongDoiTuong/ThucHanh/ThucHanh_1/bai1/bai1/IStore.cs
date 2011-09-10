using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bai1
{
    public interface IStore
    {
        void Read();
        void Write(object Obj);
        int Status
        {
            get;
            set;
        }
    }
    public interface IComp
    {
        void Comp();
        void DeComp();
    }
    //thuc thi giao dien interface
    public class Document : IStore,IComp
    {
        public Document(string str)
        {
            Console.WriteLine("Ban co the luu nhung gi ban muon");
        }
        
        // lưu trữ giá trị thuộc tính 
        public Document()
        {
            Console.WriteLine("Ban co the luu nhung gi ban muon");
        }

        
        public void Read()
        {
            Console.WriteLine("Ban co the doc duoc");
        }
        public void Write(object O)
        {
            Console.WriteLine("Ban co the ghi duoc");
        }
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                Status = value;
            }
        }
        public void Comp()
        {
            Console.WriteLine("SEE YOU");
        }
        public void DeComp()
        {
            Console.WriteLine("GOOD BYE");
        }
        // lưu trữ giá trị thuộc tính 
        private int status = 0;

    }
}
