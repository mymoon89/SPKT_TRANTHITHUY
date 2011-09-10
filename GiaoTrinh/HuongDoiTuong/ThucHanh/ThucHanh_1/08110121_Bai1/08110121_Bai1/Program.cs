using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08110121_Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            String Name;
            int  rong, cao,i,j;
            char KiTu,ch;
            Double a, b, c,N;
            Double delta;
            bool flag = false;         

             Console.WriteLine("Cau 1,2:");
             Console.WriteLine("Nhap vao Ho va Ten");
             Name = Console.ReadLine();
             Console.Write("Ten ban la: ");
             Console.WriteLine(Name);
              //-------------------------------------------------
             Console.WriteLine("Cau 3:");
             Console.Write("Nhap vao mot ki tu bat ki:");
             KiTu =Console.ReadKey().KeyChar;
             Console.WriteLine();
             Console.Write("Ma ASCII cua ki tu vua nhap la:{0} ",((int)KiTu).ToString());              
             Console.WriteLine();
             //-------------------------------------------------
             Console.WriteLine("Cau 4: Giai phuong trinh bac hai:");
             Console.WriteLine("Nhap cac chi so a,b,c:");
             Console.Write("a= ");
             a =Double.Parse( Console.ReadLine());
             Console.Write("b= ");
             b = Double.Parse(Console.ReadLine());
             Console.Write("c= ");
             c = Double.Parse(Console.ReadLine());
             delta = b * b - 4 * a * c;
             if (delta < 0)
                 Console.WriteLine("Phuong Trinh Vo Nghiem");
             else
             {
                 Console.WriteLine("Nghiem x1 cua phuong trinh la: x1={0}", (-b + Math.Sqrt(delta)) / (2 * a));
                 Console.WriteLine("Nghiem x1 cua phuong trinh la: x2={0}", (-b - Math.Sqrt(delta)) / (2 * a));
             }
              //-------------------------------------------------
             Console.WriteLine("Cau 5:Ve hinh chu nhat");
             Console.Write("Nhap chieu rong:");
             rong = int.Parse(Console.ReadLine());
             Console.Write("Nhap chieu cao:");
             cao = int.Parse(Console.ReadLine());
             Console.WriteLine("Ve hinh chu nhat");
             j = 0;
             while (j < cao)
             {
                 if (j == 0 || j == cao - 1)
                     for (i = 0; i < rong; i++)
                         Console.Write("*");
                 else
                     for (i = 0; i < rong; i++)
                         if (i == 0 || i == rong - 1)
                             Console.Write("*");
                         else
                             Console.Write(" ");
                 j++;
                 Console.WriteLine();
             }
             //-------------------------------------------------
             Console.WriteLine("Cau 6: Kiem tra so nguen to:");
             Console.Write("Nhap vao mot so nguyen:");
             N = Double.Parse(Console.ReadLine());
            i=2;            
            while (i <= Math.Sqrt(N))
            {
                if (N % i == 0)
                {
                    Console.WriteLine("{0} khong la so nguyen to.", N);
                    flag = true;
                    break;
                }
                i++;
            }
            if(flag==false)
                Console.WriteLine("{0} la so nguyen to.", N);
            // --------------------------------------------------
            //ConsoleKeyInfo ch;            
            Console.WriteLine("Cau 7: ");
            Console.WriteLine("Nhap ki tu:");
            do
            {
                ch = Console.ReadKey().KeyChar;
                Console.WriteLine("->{0}",((int)ch).ToString()); 
            } while (ch !=(char)ConsoleKey.Enter);
        }
    }
}
