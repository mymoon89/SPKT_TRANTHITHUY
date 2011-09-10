using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_12
{
    class HocVien
    {
        #region HocVien properties
        private string _MaSoSV;
        private string _TenSV;

        public string MaSoSV
        {
            get { return _MaSoSV; }
            set { _MaSoSV = value; }
        }

        public string TenSV
        {
            get { return _TenSV; }
            set { _TenSV = value; }
        } 
        #endregion
        
        #region Create constructor HocVien have 2 parameter
        public HocVien(string maSoSV, string tenSV)
        {
            this.MaSoSV = maSoSV;
            this.TenSV = tenSV;

        } 
        #endregion
        
    }
}
