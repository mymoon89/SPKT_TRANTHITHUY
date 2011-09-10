using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Throw will be implemented inside Try block, and catch block will show the exception
namespace ThrowTryCatch01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In Main");
            Program pg = new Program();
            pg.F1();
            Console.WriteLine("Ouf of Main");

        }
        public void F1() {
            Console.WriteLine("In F1");
            F2();
            Console.WriteLine("Out of F1");

        }
        public void F2() {
            Console.WriteLine(" In F2");
            try
            {
                Console.WriteLine("In Try Block");
                throw new Exception();
                // Khi exception duoc "throw" ra, thi no se nhay den phan Catch
                // do do, khong cho ra "Out of try"
                Console.WriteLine("Out of Try");
            }
            catch {
                // khoi lenh chi la thong bao "exception" da duoc khac phuc
                // co the chua cac thanh phan fix "exception"
                Console.WriteLine("Exception be catched and solved");
            }
            Console.WriteLine(" out of F2");
        }
    }
}
