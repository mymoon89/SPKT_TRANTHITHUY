using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_1_PhanSo
{
    class PhanSo
    {
        #region PhanSo properties
        private int _TuSo;
        private int _MauSo;

        public int TuSo
        {
            get { return _TuSo; }
            set { _TuSo = value; }
        }

        public int MauSo
        {
            get { return _MauSo; }
            set { _MauSo = value; }
        }
        #endregion

        #region 1.a: Tao phan so khong co tham so
        public PhanSo()
        {
            this.TuSo = 0;
        }
        #endregion

        #region 1.b: Tao phan so nhan 2 so nguyen lam tham so
        public PhanSo(int tuSo, int mauSo)
        {
            try
            {
                this.TuSo = tuSo;
                this.MauSo = mauSo;

                if (this.TuSo / this.MauSo != 0) ;                
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        #endregion

        #region 1.c: Tao phan so nhan doi tuong PhanSo lam tham so
        public PhanSo(PhanSo phanSo)
        {
            this.TuSo = phanSo.TuSo;
            this.MauSo = phanSo.MauSo;

        }
        #endregion

        #region 1.d: Rut gon phan so
        public PhanSo RutGon()
        {
            for (int j = this.MauSo / 2, i = j; i > 1; i--)
            {
                if (this.TuSo % i == 0 && this.MauSo % i == 0)
                {
                    this.TuSo = this.TuSo / i;
                    this.MauSo = this.MauSo / i;

                    return this;
                }
            }
            return this;

        } 
        #endregion

        #region 1.e.1: Cong 2 phan so
        public PhanSo Cong(PhanSo phanSo)
        {
            this.TuSo = this.TuSo * phanSo.MauSo + this.MauSo * phanSo.TuSo;
            this.MauSo = this.MauSo * phanSo.MauSo;

            //Rut gon phan so
            this.RutGon();

            return this;

        } 
        #endregion

        #region 1.e.2: Tru 2 phan so
        public PhanSo Tru(PhanSo phanSo)
        {
            this.TuSo = this.TuSo * phanSo.MauSo - this.MauSo * phanSo.TuSo;
            this.MauSo = this.MauSo * phanSo.MauSo;

            //Rut gon phan so
            this.RutGon();

            return this;
        } 
        #endregion

        #region 1.e.3: Nhan 2 phan so
        public PhanSo Nhan(PhanSo phanSo)
        {
            this.TuSo = this.TuSo * phanSo.TuSo;
            this.MauSo = this.MauSo * phanSo.MauSo;

            //Rut gon phan so
            this.RutGon();

            return this;

        } 
        #endregion

        #region 1.e.4: Chia 2 phan so
        public PhanSo Chia(PhanSo phanSo)
        {
            if (phanSo.TuSo != 0)
            {
                this.TuSo = this.TuSo * phanSo.MauSo;
                this.MauSo = this.MauSo * phanSo.TuSo;

                //Rut gon phan so
                this.RutGon();

            }
            else
                Console.WriteLine("Khong the chia mot phan so voi 0");

            return this;

        } 
        #endregion

        #region 1.f: In phan so
        public string Xuat()
        {
            if (this.MauSo == 1)
                return this.TuSo + "";
            else if (this.TuSo == this.MauSo)
                return "1";
            else
                return this.TuSo + "/" + this.MauSo;

        } 
        #endregion
    }
}
