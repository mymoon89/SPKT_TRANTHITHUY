using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowTryCatch03
{
    class Program
    {
        public double Chia(double a,double b) {
            if (b == 0) throw new DivideByZeroException();
            if (a == 0) throw new ArithmeticException();
            return a / b;
        }
        public void KiemTra() {
            try
            {
                double a =0;
                double b =6;
                Console.WriteLine("{0} /{1}={2}", a, b, Chia(a, b));
            }
           // thu tu cua khoi Catch, phai de Exception co nguy co xay ra cao len uu tien
           
            catch (DivideByZeroException)
            {
                Console.WriteLine(" Day la DivideByZezoException");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Day la Arithmetic Exception");
            }
            catch {
                Console.WriteLine("Cac Exception khac");
            }
        }
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.KiemTra();
        }
    }
}
