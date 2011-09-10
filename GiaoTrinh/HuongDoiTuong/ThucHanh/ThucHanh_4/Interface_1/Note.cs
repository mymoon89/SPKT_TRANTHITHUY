using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface_08110121
{
    class Note:Document
    {
        public Note(string s)
            : base(s)
        {
            Console.WriteLine("Creating note with: {0}", s);
        }

        // phủ quyết phương thức Read()
        public override void Read()
        {
            Console.WriteLine("Viet lai phuong thuc Read cho Note!");
        }

        // thực thi một phương thức Write riêng của lớp 
        public void Write()
        {
            Console.WriteLine("Viet lai phuong thuc Write cho Note!");
        }

    }
}
