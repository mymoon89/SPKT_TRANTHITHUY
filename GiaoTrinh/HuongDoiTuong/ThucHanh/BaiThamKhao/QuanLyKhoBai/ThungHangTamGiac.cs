using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoBai
{
    public class ThungHangTamGiac : ThungHang
    {
        public ThungHangTamGiac() : base(3)
        {
        }

        public override void NhapThungHang()
        {
            // bước nhập cạnh tam giác đã bỏ qua việc kiểm tra tính hợp lệ của 
            // 3 cạnh tam giác. Do đó, các bạn nên nhập độ dài 3 cạnh tam giác
            // hợp lệ để có thể tính được diện tích tam giác.
            Console.Write("\nNhap thung hang hinh tam giac:");
            base.NhapThungHang();
            for (int i = 0; i < this.SoCanh; i++)
            {
                Console.Write("Nhap vao canh thu {0}: ", i);
                this[i] = double.Parse(Console.ReadLine());
            }
            this.DienTichMatDay = TinhDienTichMatDay();
        }

        public override void XuatThungHang()
        {
            Console.WriteLine("\nXuat thung hang hinh tam giac:");
            base.XuatThungHang();
            Console.WriteLine("Kich thuoc mat day: {0}", this.DienTichMatDay);
        }
        
        public override double TinhDienTichMatDay()
        {
            double chuvi = (this[0] + this[1] + this[2]) / 2;
            return Math.Sqrt((chuvi - this[0]) * (chuvi - this[1]) * (chuvi - this[2]));
        }
    }
}
