using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface2_08110121
{
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
    
}
