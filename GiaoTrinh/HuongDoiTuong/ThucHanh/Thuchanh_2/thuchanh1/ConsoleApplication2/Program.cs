using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("nhap so menu:");
            Console.WriteLine("2:Ho ten:");
            Console.WriteLine("3:Ma ASCII cua ki tu:");
            Console.WriteLine("4:Giai phuong trinh bac hai:");
            Console.WriteLine("5:ve hinh chu nhat *:");
            Console.WriteLine("6:Kiem tra nguyen to:");
            Console.WriteLine("7:Ma ASCII cua chuoi ki tu:");
            
         ll:   int s=int.Parse(Console.ReadLine());;
            
            switch(s)
            {
                    case 2:
                Console.WriteLine("Nhap ho ten:");
                    break;
                    case 3:
                Console.WriteLine("Xuat ma ASCII cua ky tu:");
                    break;
                    case 4:
                Console.WriteLine("giai phuong trinh bac 2:");
                    break;
                    case 5:
                Console.WriteLine("Ve hinh chu nhat:");
                    break;
                    case 6:
                Console.WriteLine("kiem tra nguyen to:");
                    break;
                    case 7:
                Console.WriteLine("xuat ma ASCII cua chuoi:");
                    break;
                   
            }
            if (s == 2)
            {
                //2.xuat ra ten ho:
                string myname;
                Console.Write("hello! What your name:");
                myname = Console.ReadLine();
                Console.WriteLine("myname is {0}", myname);
                goto ll;
            }
            if (s == 3)
            {
                int code;
                code = Console.Read();
                Console.WriteLine("{0}", code);
                goto ll;
            }
            if (s == 4)
            {
                //4. giai phuong trinh bac hai:
                double denta, x1, x2;
                Console.WriteLine("nhap he so a,b,c:");
                float a = float.Parse(Console.ReadLine());
                float b = float.Parse(Console.ReadLine());
                float c = float.Parse(Console.ReadLine());
                Console.WriteLine("{0} {1} {2}", a, b, c);
                denta = b * b - 4 * a * c;
                x1 = (-1) * b + (float)Math.Sqrt(denta) / 2 * a;
                x2 = (-1) * b - (float)Math.Sqrt(denta) / 2 * a;
                if (denta < 0)
                    Console.WriteLine("phuong trinh vo nghiem!");
                else
                    Console.WriteLine("nghiem la:{0}{1}", x1, x2);
                goto ll;
            }
            if (s == 5)
            {
                //5.Ve hinh chu nhat bang *
                int cd = int.Parse(Console.ReadLine());
                int cc = int.Parse(Console.ReadLine());
                Console.WriteLine("{0} {1}", cd, cc);
                for (int i = 0; i < cc; i++)
                {
                    for (int j = 0; j < cd; j++)
                        Console.Write("*");
                    Console.Write("\n");
                }
                goto ll;
            }
            if (s == 6)
            {
                //6. Kiem tra mot so co phai la nguyen to hay khong
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("{0}", n);
                int OK = 1;
                for (int i = 2; i < Math.Sqrt(n); i++)
                    if (n % i == 0)
                    {
                        OK = 0;
                        break;
                    }
                if (OK == 1)
                    Console.WriteLine("la nguyen to!");
                else
                    Console.WriteLine(" khong la nguyen to!");
                goto ll;
            }
            if (s == 7)
            {
                char c;

                do
                {
                    c = Console.ReadKey().KeyChar;

                    Console.WriteLine(" co ma ascii la : {0}", (int)c);
                } while (c != 13);
                goto ll;
            }
            Console.ReadKey();
        }
    }
}
