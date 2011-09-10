using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// tung lai biet le
namespace CustomException
{
    public class MyCusTomException : ApplicationException {
        public MyCusTomException(string message)
            : base(message)
        { }
    }
    class Program
    { 
            public double Chia(double a, double b)
        {
            if (b == 0) {
                DivideByZeroException e = new DivideByZeroException();
                e.HelpLink = "http://www.yahoo.com";
                throw e;
            }
                //tạo một đối tượng xử lý biệt lệ riêng.
            if (a == 0) {
                MyCusTomException e = new MyCusTomException("Test ve CustomException: khong the chia cho 0");
                e.HelpLink = "http://goole.com.vn";
                throw e;
            }
            return a / b;
        }
        public void KiemTra()
        {
            try
            {
                Console.WriteLine("Open file");
                double a = 0;
                double b = 3;
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
            catch (ArithmeticException)
            {
                Console.WriteLine("Day la Arithmetic Exception");
            }
            catch
            {
                MyCusTomException e = new MyCusTomException("Test ve CustomException: khong the chia cho 0");
                e.HelpLink = "http://goole.com.vn";
                Console.WriteLine("{0}" ,e.Message  );
                Console.WriteLine("Cac Exception khac  {0}  " ,e.HelpLink  );
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
 
