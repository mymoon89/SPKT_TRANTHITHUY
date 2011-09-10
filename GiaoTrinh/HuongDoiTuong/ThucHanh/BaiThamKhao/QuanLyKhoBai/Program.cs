using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoBai
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ThungHang> ListThungHang = new List<ThungHang>();

            Console.WriteLine("\t\t\t.....:: CHUONG TRINH QUAN LY KHO BAI ::.....");
            Console.Write("\n");
            NhapDanhSachThungHang(ListThungHang);
            Console.Write("\n\n");
            XuatDanhSachThungHang(ListThungHang);
            Console.Write("\nSAU KHI SAP XEP TANG DAN THEO DIEN TICH MAT DAY:");
            SapXepTangDanTheoDienTich(ListThungHang);
            Console.Write("\n");
            XuatDanhSachThungHang(ListThungHang);
            Console.ReadLine();
        }

        static void NhapDanhSachThungHang(List<ThungHang> ListThungHang)
        {
            int n, j;
            Console.WriteLine("NHAP VAO DANH SACH CAC THUNG HANG:");
            Console.WriteLine("KY HIEU:");
            Console.WriteLine("Thung hang hinh tam giac : 0");
            Console.WriteLine("Thung hang hinh tron     : 1");
            Console.WriteLine("Thung hang hinh HCN      : 2");
            Console.WriteLine("Thung hang hinh vuong    : 3\n");
            Console.Write("Nhap vao so luong cac thung hang: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("\nNhap loai thung hang muon them (0/1/2/3)?: ");
                j = int.Parse(Console.ReadLine());
                switch (j)
                {
                    case 0:
                        ListThungHang.Add(new ThungHangTamGiac());
                        ListThungHang[i].NhapThungHang();
                        break;
                    case 1:
                        ListThungHang.Add(new ThungHangHinhTron());
                        ListThungHang[i].NhapThungHang();
                        break;
                    case 2:
                        ListThungHang.Add(new ThungHangHinhChuNhat());
                        ListThungHang[i].NhapThungHang();
                        break;
                    case 3:
                        ListThungHang.Add(new ThungHangHinhVuong());
                        ListThungHang[i].NhapThungHang();
                        break;
                }
            }
        }

        static void XuatDanhSachThungHang(List<ThungHang> ListThungHang)
        {
            Console.WriteLine("XUAT DANH SACH THUNG HANG CO TRONG KHO:");
            foreach (ThungHang th in ListThungHang)
            {
                th.XuatThungHang();
            }
        }

        static void SapXepTangDanTheoDienTich(List<ThungHang> ListThungHang)
        {
            ListThungHang.Sort();
        }
    }
}
