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
                        ham.NhapMangMotChieu();
                        Console.WriteLine("Mang vua nhap la:");
                        ham.InMang();
                        //Console.WriteLine("sap xep tang dan:");
                        //ham.SapXep();
                        //ham.InMang();                                    
                        //Console.WriteLine("sap xep Giam dan:");
                        //ham.SapXepGiam();
                        //ham.InMang();
                        ////Console.WriteLine("Mang Tu tao:");
                        ////int[] a = new int[] { 1, 2, 5 };
                        ////HamMang ham1 = new HamMang(new int[] { 1, 2, 5 });
                        //ham1.InMang();
                        //Console.WriteLine("sap xep tang dan:");
                        //ham1.SapXep();
                        //ham1.InMang();
                        //Console.WriteLine("sap xep Giam dan:");                  
                        //ham1.SapXepGiam();
                        //ham1.InMang();
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
                case 3:
                    {
                        HamMang ham2 = new HamMang(4, 4);

                        ham2.InMangHaiChieu();
                        int [,] A= ham2.MANG2;
                        Console.WriteLine();
                        HamMang ham22 = new HamMang(4, 4);
                        int[,] B = ham22.MANG2;
                        ham22.InMangHaiChieu();
                        Console.WriteLine();
                        ham2.CongHaiMaTran(A, B);
                        ham2.InMangHaiChieu();
                        ham2.NhapMangHaiChieu();
                        ham2.InMangHaiChieu();
                        HamMang ham3=new HamMang(new int[,] {{1,2,3},{3,4,6}});
                        ham3.InMangHaiChieu();
                       break;

                    }
                case 4:
                    {
                        Console.WriteLine("LOP DANH SACH SINH VIEN");
                        Console.WriteLine("Nhap Siso:");
                        int siso = int.Parse(Console.ReadLine());
                        
                        LOPHOC lop=new LOPHOC(siso);
                        lop.NhapDSSV();
                        lop.XUAT(lop.DSSV);

                        LOPHOC l = new LOPHOC(5);
                        l.XUAT(l.DSSV);
                       
                        l.sapxep();
                        l.XUAT(l.DSSV);
                        
                        l.TimTen();

                        //l.SapXep();
                        SinhVien[] A;
                        A=new SinhVien[2];
                        A[0]=new SinhVien("0","th");
                        A[1]=new SinhVien("2","jh");

                        LOPHOC L = new LOPHOC(A);
                        L.XUAT(L.DSSV);
                        break;
                    }
            }
        }
    }
}
