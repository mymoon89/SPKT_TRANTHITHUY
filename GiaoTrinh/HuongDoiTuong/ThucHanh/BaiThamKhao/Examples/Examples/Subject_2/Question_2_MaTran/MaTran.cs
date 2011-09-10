using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_2_MaTran
{
    class MaTran
    {
        #region MaTran properties
        private int _SoHang;
        private int _SoCot;
        private int[,] _GiaTri;

        public int SoHang
        {
            get { return _SoHang; }
            set { _SoHang = value; }
        }

        public int SoCot
        {
            get { return _SoCot; }
            set { _SoCot = value; }
        }

        public int[,] GiaTri
        {
            get { return _GiaTri; }
            set { _GiaTri = value; }
        } 
        #endregion

        #region 2.a: Create constructor
        public MaTran(int soHang, int soCot)
        {
            this.SoHang = soHang;
            this.SoCot = soCot;
            this.GiaTri = new int[this.SoHang, this.SoCot];

        } 
        #endregion

        #region 2.b: Nhap ma tran
        public MaTran nhapMaTran()
        {
            for (int i = 0; i < this.SoHang; i++)
                for (int j = 0; j < this.SoCot; j++)
                {
                    Console.Write("A[{0}, {1}] = ", i, j);
                    try 
                    {
                        this.GiaTri[i, j] = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException fEx) 
                    {
                        Console.WriteLine("Error: " + fEx.Message);
                    }

                    
                }

            return this;
        } 
        #endregion

        #region 2.c: Xuat ma tran
        public void xuatMaTran()
        {
            for (int i = 0; i < this.SoHang; i++)
                for (int j = 0; j < this.SoCot; j++)
                    Console.WriteLine("A[{0}, {1}] = {2}", i, j, this.GiaTri[i, j]);

        } 
        #endregion

        #region 2.d: Cong hai ma tran
        public MaTran congMaTran(MaTran maTranB)
        {
            if (this.SoHang == maTranB.SoHang && this.SoCot == maTranB.SoCot)
            {
                for (int i = 0; i < this.SoHang; i++)
                    for (int j = 0; j < this.SoCot; j++)
                        this.GiaTri[i, j] = this.GiaTri[i, j] + maTranB.GiaTri[i, j];

            }
            else
            {
                Console.WriteLine("Khong the cong hai ma tran khac kich thuoc");
            }

            return this;
        } 
        #endregion

        #region 2.e: Tru hai ma tran
        public MaTran truMaTran(MaTran maTranB)
        {
            if (this.SoHang == maTranB.SoHang && this.SoCot == maTranB.SoCot)
            {
                for (int i = 0; i < this.SoHang; i++)
                    for (int j = 0; j < this.SoCot; j++)
                        this.GiaTri[i, j] = this.GiaTri[i, j] - maTranB.GiaTri[i, j];

            }
            else
            {
                Console.WriteLine("Khong the tru hai ma tran khac kich thuoc");
            }
            return this;

        }
        #endregion

        #region 2.f: Doi dau cac phan tu cua ma tran
        public MaTran doiDauMaTran()
        {
            for (int i = 0; i < this.SoHang; i++)
                for (int j = 0; j < this.SoCot; j++)
                    this.GiaTri[i, j] *= -1;

            return this;

        } 
        #endregion
    }
}
