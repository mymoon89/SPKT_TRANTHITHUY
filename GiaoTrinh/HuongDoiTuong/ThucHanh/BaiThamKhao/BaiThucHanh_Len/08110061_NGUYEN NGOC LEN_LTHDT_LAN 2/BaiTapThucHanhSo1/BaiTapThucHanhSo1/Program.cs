using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapThucHanhSo1
{
    class Program
    {
            private String _HoTen;
            public string Hoten
            {
                get
                {
                    return _HoTen;
                }
                set
                {
                    if(value == " ")
                    {
                        throw new Exception("Gan ten la chuoi rong");
                    }
                    _HoTen = value;
                }

            }
        static void Main(string[] args)
        {
            Program p =  new Program();
            bool kt;
            do 
            {
                try
                {
                    Console.WriteLine("Nhap ho ten : ");
                    p._HoTen = Console.ReadLine();
                    kt = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Bi loi" + ex.Message);
                    kt = false;
                }
            }
            while (kt == false);
            
            int a, b,c;
            try
            {
                Console.Write("Nhap vao so A : ");
                a = int.Parse(Console.ReadLine());
                Console.Write("Nhap vao so B : ");
                b = int.Parse(Console.ReadLine());
                c = a / b;
                Console.Write("Ket qua       : ");
                Console.WriteLine("{0} / {1} = {2}", a, b, c);
            }
            catch (DivideByZeroException ex1)
            {
                Console.WriteLine("LOI CHIA CHO KHONG : " + ex1.Message);
            }
            catch (FormatException ex2)
            {
                Console.WriteLine("LOI FORMAT : "+ ex2.Message);
            }
            Console.WriteLine("Ket thuc");

        }
    }
}
