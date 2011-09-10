using System;
using System.Collections.Generic;
using System.Text;

namespace ConStrucTest
{
   class Time
    {
        int Year;
        int Month;
        int Date;
        int Hour;
        int Minute;
        int Second;
        public Time(System.DateTime dt)
        {
            Year = dt.Year;
            Month = dt.Month;
            Date = dt.Day;
            Hour = dt.Hour;
            Minute = dt.Minute;
            Second = dt.Second;
        
        }
        public  void DisplayTime() {
            Console.WriteLine("Ngay {0} /{1}/{2}/  Gio {3}:{4}:{5}", Month, Date, Year, Hour, Minute, Second);
        }
        static void Main(string[] args)
        {
            System.DateTime gioHienTai= System.DateTime.Now;
            Time t= new Time(gioHienTai);
            t.DisplayTime();
        }
    }
}
