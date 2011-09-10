using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowTryCatch03
{
    class Program
    {
        public double Chia(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            if (a == 0) throw new ArithmeticException();
            return a / b;
        }
        public void KiemTra()
        {
            try
            {
                Console.WriteLine("Bat dau...");
                double a = 3;
                double b = 0;
                Console.WriteLine("{0} /{1}={2}", a, b, Chia(a, b));
                Console.WriteLine("Dong nay ko duoc in ra khi co biet le");
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
            catch
            {
                Console.WriteLine("Cac Exception khac");
            }
                // finally duoc bao dam la thi hanh bat chap co Exception hay khong
          finally {
                Console.WriteLine("Ket thuc tai day");
            }  
        }
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.KiemTra();
        }
    }
}
