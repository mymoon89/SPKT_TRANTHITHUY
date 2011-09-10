#define DEBUG
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoSanhSinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            List<SinhVien> ListSinhVien = new List<SinhVien>();
            Comparison<SinhVien> SapXepSinhVien;

            ListSinhVien.Add(new SinhVien("Thuy Van", 25, 154));
            ListSinhVien.Add(new SinhVien("Oanh", 35, 756));
            ListSinhVien.Add(new SinhVien("Thu Van", 45, 136));
            ListSinhVien.Add(new SinhVien("Khoa", 21, 123));
            ListSinhVien.Add(new SinhVien("Nam", 50, 789));
            ListSinhVien.Add(new SinhVien("Quyen", 49, 675));
            ListSinhVien.Add(new SinhVien("Trung", 65, 223));
            ListSinhVien.Add(new SinhVien("Len", 27, 279));
            ListSinhVien.Add(new SinhVien("Quoc Dat", 30, 213));

            Console.WriteLine("TRUOC KHI SAP XEP:");
            XuatSV(ListSinhVien);           

            Console.WriteLine("\n\nSAU KHI SAP XEP:");
            SapXepSinhVien = new Comparison<SinhVien>(SinhVien.SoSanhTen);
            //SapXepSinhVien = new Comparison<SinhVien>(SinhVien.SoSanhTuoi);
            //SapXepSinhVien = new Comparison<SinhVien>(SinhVien.SoSanhMSSV);
            ListSinhVien.Sort(SapXepSinhVien);
            XuatSV(ListSinhVien);

            TimSinhVienGiaDauNhat(ListSinhVien);
        }

        static void XuatSV(List<SinhVien> ListSinhVien)
        {
            foreach (SinhVien x in ListSinhVien)
            {
                Console.WriteLine("Ho ten: {0}", x.Ten);
                Console.WriteLine("Tuoi: {0}", x.Tuoi);
                Console.WriteLine("MSSV: {0}", x.MSSV);
            }
        }

        // ví dụ vui về việc tìm kiếm trên List (^_^)
        static void TimSinhVienGiaDauNhat(List<SinhVien> ListSinhVien)
        {
            SinhVien LonTuoiNhat = ListSinhVien[0];
            SinhVien XuanKhoa = new SinhVien();
            foreach (SinhVien x in ListSinhVien)
            {
                if (x.Tuoi > LonTuoiNhat.Tuoi)
                    LonTuoiNhat = x;
                if (x.Ten == "Khoa")
                    XuanKhoa = x;
            }
#else

            Console.WriteLine("\nSINH VIEN GIA DAU NHAT LOP LA: {0} co tuoi la {1}", LonTuoiNhat.Ten, LonTuoiNhat.Tuoi);
            Console.WriteLine("\n\n==================");
            Console.WriteLine("SINH VIEN TRE VA DEP TRAI NHAT LOP LA (^_^) : {0} co tuoi la {1}", XuanKhoa.Ten, XuanKhoa.Tuoi);
            Console.WriteLine("CHUC ANH CHI EM THI TOT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
#endif
        }
    }
}
