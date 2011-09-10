using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface_08110121
{
    //Lop phu quyet:

    public class Document : IStoreable
    {
        // bộ khởi dựng
        public Document(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }
        // đánh dấu phương thức Read ảo 
        public virtual void Read()
        {
            Console.WriteLine("Document Read Method for IStorable");
        }
        // không phải phương thức ảo 
        public void Write()
        {
            Console.WriteLine("Document Write Method for IStorable");
        }
    }

    /*public class Document :IStorableCompressible,IEncryptable
    {
        public Document(string s)
        {
            Console.WriteLine("Creating document with: {0}", s);
        }
        // thực thi phương thức Read()
        public void Read()
        {
            Console.WriteLine("Phuong thuc Read() cho IStoreable");
        }
        // thực thi phương thức Write 
        public void Write(object o)
        {
            Console.WriteLine("Phuong thuc Write() cho IStoreable");
        }
        // thực thi thuộc tính 
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
        // thực thi ICompressible 
        public void Compress()
        {
            Console.WriteLine("Implementing Compress");
        }
        public void DeCompress()
        {
            Console.WriteLine("Implementing Decompress");
        }

        // thực thi giao diện ILoggedCompressible 
        public void LogSavedBytes()
        {
            Console.WriteLine("Implementing LogSavedBytes");
        }
        // thực thi giao diện IStorableCompressible 
        public void LogOriginalSize()
        {
            Console.WriteLine("Implementing LogOriginalSize");
        }
        // thực thi giao diện 
        public void Encrypt()
        {
            Console.WriteLine("Implementing Encrypt");
        }
        public void Decrypt()
        {
            Console.WriteLine("Implementing Decrypt");
        }
        // biến thành viên lưu dữ liệu cho thuộc tính 
        private int status = 0;
    }*/

}
