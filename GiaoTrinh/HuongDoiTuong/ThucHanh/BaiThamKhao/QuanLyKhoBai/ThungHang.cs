using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhoBai
{
    public abstract class ThungHang : IComparable
    {
        #region Variables, properties and Indexer
        private int _MaThungHang;
        public int MaThungHang
        {
            get { return _MaThungHang; }
            set { _MaThungHang = value; }
        }

        private double _DienTichMatDay;
        public double DienTichMatDay
        {
            get { return _DienTichMatDay; }
            set { _DienTichMatDay = value; }
        }

        private int _SoCanh;
        public int SoCanh
        {
            get { return _SoCanh; }
        }

        // mảng độ dài cạnh này dùng để lưu các cạnh của hình. Nếu là hình tròn
        // thì chỉ cần khởi tạo mảng này 1 phần tử, phần tử này dùng để lưu bán kính
        // hình tròn.
        private double[] _DoDaiCanh;

        public double this[int i]
        {
            get
            {
                if (i < 0 || i > _DoDaiCanh.Length)
                    throw new Exception("Vuot qua so canh cua hinh");
                return _DoDaiCanh[i];
            }
            set
            {
                if (i < 0 || i > _DoDaiCanh.Length)
                    throw new Exception("Vuot qua so canh cua hinh");
                _DoDaiCanh[i] = value;
            }
        } 
        #endregion

        #region Constructors
        public ThungHang()
        {
        }

        public ThungHang(int socanh)
        {
            this._SoCanh = socanh;
            this._DoDaiCanh = new double[this.SoCanh];
        } 
        #endregion

        public virtual void NhapThungHang()
        {
            Console.Write("\nNhap vao ma thung hang <int>: ");
            this._MaThungHang = int.Parse(Console.ReadLine());
        }

        public virtual void XuatThungHang()
        {
            Console.WriteLine("Ma thung hang: {0}", this.MaThungHang);
        }

        public abstract double TinhDienTichMatDay();

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is ThungHang)
            {
                ThungHang th = (ThungHang)obj;
                // so sánh theo diện tích mặt đáy.
                return this.DienTichMatDay.CompareTo(th.DienTichMatDay);
            }
            else
            {
                throw new Exception("Khong phai doi tuong thung hang!!!");
            }
        }

        #endregion
    }
}
