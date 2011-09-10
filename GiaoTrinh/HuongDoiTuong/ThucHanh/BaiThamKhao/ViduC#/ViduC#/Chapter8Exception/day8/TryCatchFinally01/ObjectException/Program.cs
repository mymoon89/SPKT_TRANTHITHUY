using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// vi du 12-6
namespace ThrowTryCatch03
{
    class Program
    {
        public double Chia(double a, double b)
        {
            if (b == 0) {
                DivideByZeroException e = new DivideByZeroException();
                e.HelpLink = "http://www.yahoo.com";
                throw e;
            }
            if (a == 0)
            { ArithmeticException ab = new ArithmeticException();
            throw ab;
            }//throw new ArithmeticException();
            return a / b;
        }
        public void KiemTra()
        {
            try
            {
                Console.WriteLine("Open file");
                double a = 0;
                double b = 4;
                Console.WriteLine("{0} /{1}={2}", a, b, Chia(a, b));
            }
            // thu tu cua khoi Catch, phai de Exception co nguy co xay ra cao len uu tien
            // mot doi tuong Exception
            catch (DivideByZeroException e)
            {   //dua ra thong tin ve Exception
                Console.WriteLine(" \nDay la DivideByZezoException! Msg: {0}", e.Message);
                // set 1 link ve file help cho biet le
                Console.WriteLine("\n HelpLink: {0}", e.HelpLink);
                // bieu dien 1 chuoi goi tren stack khi Exception duoc Throw
                Console.WriteLine("\nVi du  stack trace: {0}", e.StackTrace);
            }
            catch (ArithmeticException ab)
            {
                Console.WriteLine("Day la Arithmetic Exception:{0} ",ab.StackTrace  );
            }
            catch
            {
                Console.WriteLine("Cac Exception khac");
            }
            finally { Console.WriteLine("Close File"); }
        }
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.KiemTra();
        }
    }
}

