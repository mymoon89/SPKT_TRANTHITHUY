using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverLoadingCurrentTime
{
    public class ThoiGian
    {
        public void InputTime() {
            Console.WriteLine("The hien ngay nhap tu keyboard:{0}/{1}/{2}{3}:{4}:{5} ", Ngay, Thang, Nam, Gio, Phut, Giay);
        }
        public void PresentTime()
        {
           Console.WriteLine("Display Curent Time: {0}/{1}/{2}{3}:{4}:{5}", Ngay, Thang, Nam, Gio, Phut, Giay);
        }
          public ThoiGian(System.DateTime dt)//Constructor khoi tao Lop, Bien thanh vien Lop
        {
            Nam = dt.Year; Thang = dt.Month; Ngay = dt.Day;
            Gio = dt.Hour; Phut = dt.Minute; Giay = dt.Second;
        }
        public ThoiGian(int Nam, int Thang, int Ngay, int Gio, int Phut, int Giay)
        {
           this.Nam= Nam ; this.Thang= Thang ;this.Ngay = Ngay;this.Gio = Gio;this.Phut = Phut;this.Giay = Giay ;
        }



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
            t.PresentTime();
            ThoiGian t2 = new ThoiGian(2010, 9, 9, 9, 15, 20);
           // t2.PresentTime();
            t2.InputTime();
        }
    }
}
