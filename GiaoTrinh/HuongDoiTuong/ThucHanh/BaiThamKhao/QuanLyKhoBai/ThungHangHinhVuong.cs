using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoBai
{
    public class ThungHangHinhVuong : ThungHang
    {
        public ThungHangHinhVuong()
            : base(1)
        {
        }

        public override void NhapThungHang()
        {
            Console.Write("\nNhap thung hang hinh vuong:");
            base.NhapThungHang();
            Console.Write("Nhap vao canh hinh vuong: ");
            this[0] = double.Parse(Console.ReadLine());
            this.DienTichMatDay = this.TinhDienTichMatDay();
        }

        public override void XuatThungHang()
        {
            Console.WriteLine("\nXuat thung hang hinh vuong:");
            base.XuatThungHang();
            Console.WriteLine("Kich thuoc mat day: {0}", this.DienTichMatDay);
        }
        
        public override double TinhDienTichMatDay()
        {
            return Math.Pow(this[0], 2);
        }
    }
}
