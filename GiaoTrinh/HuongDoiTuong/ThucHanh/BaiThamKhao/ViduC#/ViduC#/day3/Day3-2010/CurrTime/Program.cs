using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrTime
{
     public class ThoiGian
{
    public void PresentTime()
{
    Console.WriteLine("Bieu dien thoi gian bang {0}",Name);
    Console.WriteLine("Display Curent Time: {0}/{1}/{2}{3}:{4}:{5}", Ngay, Thang, Nam, Gio, Phut, Giay);
}
   static ThoiGian() 
    {
         Name= "C#";
     } 
         public ThoiGian(System.DateTime dt)//Constructor khoi tao Lop, Bien thanh vien Lop
    {
        Nam = dt.Year; Thang = dt.Month; Ngay = dt.Day;
        Gio = dt.Hour; Phut = dt.Minute; Giay = dt.Second;    }

// Các biến thành viên cua Lop ThoiGian
   private static string Name;
    int Nam;
int Thang; int Ngay; int Gio;
int Phut;
int Giay;
}
 
    public class Tester
{
        static void Main()
        {
            System.DateTime currentTime = System.DateTime.Now;
            ThoiGian t = new ThoiGian(currentTime);
            t.PresentTime() ;
        }
    }
 
}
