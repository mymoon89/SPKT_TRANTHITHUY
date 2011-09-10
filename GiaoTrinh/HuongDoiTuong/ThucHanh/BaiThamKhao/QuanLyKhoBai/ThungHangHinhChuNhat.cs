using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoBai
{
    public class ThungHangHinhChuNhat : ThungHang
    {
        public ThungHangHinhChuNhat()
            : base(4)
        {
        }

        public override void NhapThungHang()
        {
            Console.Write("\nNhap thung hang hinh chu nhat:");
            base.NhapThungHang();
            Console.Write("Nhap vao chieu dai: ");
            this[0] = this[2] = double.Parse(Console.ReadLine());
            Console.Write("Nhap vao chieu rong: ");
            this[1] = this[3] = double.Parse(Console.ReadLine());
            this.DienTichMatDay = this.TinhDienTichMatDay();
        }

        public override void XuatThungHang()
        {
            Console.WriteLine("\nXuat thung hang hinh chu nhat:");
            base.XuatThungHang();
            Console.WriteLine("Kich thuoc mat day: {0}", this.DienTichMatDay);
        }
        
        public override double TinhDienTichMatDay()
        {
            return this[0] * this[1];
        }
    }
}
