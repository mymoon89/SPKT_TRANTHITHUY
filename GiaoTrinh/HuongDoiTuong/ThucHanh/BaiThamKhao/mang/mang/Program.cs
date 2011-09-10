using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mang
{
     public class Tester
    {
        static void Main(string[] args)
        {
           //BAI1.MANG
            Console.WriteLine("Nhap s:");
            int s = int.Parse(Console.ReadLine());
            
            switch (s)
            {
                case 1:
                    {
                        Console.WriteLine("Mang BAI1:");
                        HamMang ham = new HamMang(10);
                        ham.InMang();
                        Console.WriteLine("sap xep tang dan:");
                        ham.SapXep();
                        ham.InMang();                                    
                        Console.WriteLine("sap xep Giam dan:");
                        ham.SapXepGiam();
                        ham.InMang();
                        Console.WriteLine("Mang Tu tao:");
                        int[] a = new int[] { 1, 2, 5 };
                        HamMang ham1 = new HamMang(new int[] { 1, 2, 5 });
                        ham1.InMang();
                        Console.WriteLine("sap xep tang dan:");
                        ham1.SapXep();
                        ham1.InMang();
                        Console.WriteLine("sap xep Giam dan:");                  
                        ham1.SapXepGiam();
                        ham1.InMang();
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("Mang BAI 2:");
                        HamMang ham = new HamMang(10);
                        ham.InMang();
                        Console.WriteLine("sap xep Tang neu Am Va Giam dan neu Duong:");    
                        ham.SapTangAmSapGiamAM();
                        ham.InMang();
                        break;
                    }

            }
        }
    }
}
