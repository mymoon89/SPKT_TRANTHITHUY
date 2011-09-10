using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowEx2
{
    class Program
    {
        static void Main(string[] args)
        {
         Console.WriteLine("In Main");
            Program pg = new Program();
            pg.F1();
            Console.WriteLine("Out of Main");
        }
      public void F1() { 
          Console.WriteLine("In F1");
          F2();
          Console.WriteLine("Out of F1");
      }
      public void F2() {
          Console.WriteLine("In F2");
          // dua ra một biệt lệ, chương trình dung o day va di tìm hàm xu ly "catch"
            throw new System.Exception();
          Console.WriteLine("Out of F2");
 
        }
    }
}
