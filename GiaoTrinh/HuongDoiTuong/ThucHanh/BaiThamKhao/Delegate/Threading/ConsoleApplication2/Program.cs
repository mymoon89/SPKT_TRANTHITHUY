using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main()
        {
            DateTime t = DateTime.Now;
            int n = 10001;
            string s = "";
            for (int i = 1; i < n; i++)
                s += i.ToString();
            Console.WriteLine("ThoiGian String: {0}", (DateTime.Now - t).Ticks);

            StringBuilder strBuilder = new StringBuilder();
            t = DateTime.Now;
            for (int i = 1; i < n; i++)
                strBuilder.Append(i.ToString());
            Console.WriteLine("ThoiGian StringBuilder: {0}", (DateTime.Now - t).Ticks);
        }
    }
    #region Thu 2
    //class Program
    //{
    //    public static List<int> lst = new List<int>();
    //    static Thread Th1;
    //    static Thread Th2;

    //    static void Main()
    //    {            
    //        lst.Add(10);
    //        lst.Add(20);
    //        Th1= new Thread(Them);
    //        Th2 = new Thread(Xuat);

    //        Th1.Start();
    //        Th2.Start();                        
    //    }
    //    public static void Them()
    //    {
    //        Console.WriteLine("Bat dau them");
    //        for (int i = 0; i < 20; i++)
    //        {
    //            lst.Add(i);
    //            Console.WriteLine("Them " + i.ToString());
    //            Thread.Sleep(1000);
    //        }

    //        Console.WriteLine("Them Xong");
    //    }
    //    public static void Xuat()
    //    {
    //        Console.WriteLine("Bat dau xuat");
    //        int tong = 0;
    //        bool kq = Th1.Join(100000);

    //        Console.WriteLine("Join = " + kq.ToString());

    //        for (int i = 0; i < lst.Count; i++)
    //        {
    //            tong += lst[i];
    //            Console.WriteLine("Cong phan tu thu " + i.ToString());
    //            Thread.Sleep(500);
    //        }
    //        Console.WriteLine("Tong =" + tong.ToString());
    //        Console.WriteLine("Ket thuc Xuat");
    //    }

    //} 
    #endregion
    #region Create Thread, and Using CallBack Function
    //public delegate void LoadFinish(CayHoa hoa);

    //public class CayHoa
    //{
    //    public LoadFinish OnLoadFinish;

    //    public string Name;        
    //    public CayHoa(string name) { Name = name; }
    //    public void Load()
    //    {
    //        for (int i = 0; i < 100; i++)
    //            Console.WriteLine( Name+" \t "+ i.ToString());
    //        Console.WriteLine("Load Finished: \t"+Name );
    //        if (OnLoadFinish != null)
    //            OnLoadFinish(this);
    //    }
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        CayHoa hoa1 = new CayHoa("Hoa Hong");
    //        CayHoa hoa2 = new CayHoa("Huong Duong");
    //        Thread thread1;
    //        Thread thread2;
    //        hoa1.OnLoadFinish += new LoadFinish(VePhucTap);
    //        hoa2.OnLoadFinish += new LoadFinish(VePhucTap);

    //        thread1 = new Thread(new ThreadStart(hoa1.Load));
    //        thread2=new Thread(new ThreadStart(hoa2.Load));
    //        thread1.Start();
    //        thread2.Start();            
    //        Console.WriteLine("Tai cac Hoa1, hoa 2 ban nhe!");
    //        VeDonGian(hoa1);
    //        VeDonGian(hoa2);            
    //        Console.WriteLine("Lam gi do");
    //    }
    //    public static void VeDonGian(CayHoa hoa)
    //    {
    //        Console.WriteLine("Day la giao dien don gian cua " + hoa.Name);
    //    }
    //    public static void VePhucTap(CayHoa hoa)
    //    {
    //        Console.WriteLine("Day la giao dien PHUC TAP cua " + hoa.Name);
    //    }
    //    public static void RunThread1()
    //    {
    //        for (int i = 0; i < 100; i++)
    //            Console.WriteLine("Thread 1 \t" + i.ToString());
    //        Console.WriteLine("End thread 1");
    //    }
    //    public static void RunThread2()
    //    {
    //        for (int i = 0; i < 100; i++)
    //            Console.WriteLine("Thread 2 \t" + i.ToString());
    //        Console.WriteLine("End thread 2");
    //    }
    //} 
    #endregion
}
