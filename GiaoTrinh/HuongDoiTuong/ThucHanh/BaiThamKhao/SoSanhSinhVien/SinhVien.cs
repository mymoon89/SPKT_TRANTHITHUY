using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoSanhSinhVien
{
    public class SinhVien
    {
        private string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }

        private int _Tuoi;
        public int Tuoi
        {
            get { return _Tuoi; }
            set { _Tuoi = value; }
        }

        private int _MSSV;
        public int MSSV
        {
            get { return _MSSV; }
            set { _MSSV = value; }
        }
        
        public SinhVien()
        {
        }

        public SinhVien(string ten, int tuoi, int mssv)
        {
            this.Ten = ten;
            this.Tuoi = tuoi;
            this.MSSV = mssv;
        }

        public static int SoSanhTen(SinhVien x, SinhVien y)
        {
            return x.Ten.CompareTo(y.Ten);
        }

        public static int SoSanhTuoi(SinhVien x, SinhVien y)
        {
            return x.Tuoi.CompareTo(y.Tuoi);
        }

        public static int SoSanhMSSV(SinhVien x, SinhVien y)
        {
            return x.MSSV.CompareTo(y.MSSV);
        }
    }
}
