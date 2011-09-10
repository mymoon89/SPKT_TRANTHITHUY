using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mang
{
    public class SinhVien
    {
        string _MSSV;
        string _HOTEN;
        public string MSSV
        {
            get { return _MSSV; }
            set { _MSSV = value; }
        }
        public string HOTEN
        {
            get { return _HOTEN; }
            set { _HOTEN = value; }
        }
        public SinhVien(string MS, string HT)
        {
            MSSV = MS;
            HOTEN = HT;
        }
        public override string ToString()
        {
            return (MSSV + "\t-" + HOTEN);
        }
        public void NhapSV(SinhVien i)
        {
            Console.WriteLine("Nhap MSSV:\n\t");
            i.MSSV=Console.ReadLine();
            Console.WriteLine("Nhap HOTEN:\n\t");
            i.HOTEN=Console.ReadLine();
        }
    }
    public class LOPHOC
    {
        public SinhVien[] DSSV;
        public LOPHOC(int SiSo)
        {
             DSSV = new SinhVien[SiSo];
            //DSSV[0] = new SinhVien("0123", "thuy");
            //DSSV[1] = new SinhVien("231", "Van");
            Random rand = new Random();
            for(int i=0;i<DSSV.Length;i++)
            {
                int n = rand.Next(52) + 56;
                DSSV[i] = new SinhVien( "MSSV:\t"+rand.Next(200).ToString(),"HoTen\t"+n.ToString());
            }
        }
        public void XUAT(object[] a)
        {
            
            string kq = "";
            foreach(object i in a)
                kq += i.ToString() + "\n";
            Console.WriteLine("{0} \t",kq);
        }
        public LOPHOC( SinhVien[] A)
        {
            DSSV =A;
        }
        public void NhapDSSV()
        {
            
            //SinhVien sv;
            foreach (SinhVien i in DSSV)
                i.NhapSV(i);
        }
        public int sosanhsv(SinhVien sv1, SinhVien sv2)
        {
            return sv1.HOTEN.CompareTo(sv2.HOTEN);
        }
        public int sosanhMS(SinhVien sv1, SinhVien sv2)
        {
            if (sv1.HOTEN.CompareTo(sv2.HOTEN) == 0)
                return sv1.MSSV.CompareTo(sv2.MSSV);
            else
                return sv1.HOTEN.CompareTo(sv2.HOTEN);
        }
        public void sapxep()
        {
            Array.Sort<SinhVien>(DSSV, this.sosanhsv);
            Array.Sort<SinhVien>(DSSV, this.sosanhMS);
        }
        public void TimTen()
        {

            Console.WriteLine("Nhap ma so can tim:\n");

            string s = Console.ReadLine();
            foreach(SinhVien i in DSSV)
            {
                if (s == i.HOTEN)
                    Console.WriteLine("tim thay");
                else
                    Console.WriteLine("ko tim thay");
            }
        }
    }
    

}
