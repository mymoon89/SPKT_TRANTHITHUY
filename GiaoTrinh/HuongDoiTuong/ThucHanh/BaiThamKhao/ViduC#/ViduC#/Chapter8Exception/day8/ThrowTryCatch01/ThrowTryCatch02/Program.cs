using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowTryCatch02
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
            try
            {
                Console.WriteLine("In Try Block");
                F2();
                Console.WriteLine("Out of Try");}
            catch
            { Console.WriteLine("Exception be catched and solved"); }
            Console.WriteLine("Out of F1");
        }
        public void F2() {
            Console.WriteLine(" In F2");
            throw new Exception();     
            Console.WriteLine(" out of F2");
        }
        }
    }
 
