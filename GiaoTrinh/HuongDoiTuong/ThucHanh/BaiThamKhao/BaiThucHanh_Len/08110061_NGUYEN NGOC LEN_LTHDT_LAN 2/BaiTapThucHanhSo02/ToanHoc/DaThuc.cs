using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToanHoc
{
    class DaThuc
    {
        private PhanSo[] _HeSo;
        private int      _X;
        //-----------------------KHAI BAO PROPERTY---------------------------
        public int X
        {
            get { return _X; }
            set { _X = value; }
        }
        public PhanSo[] HeSo
        {
            get { return _HeSo[_X];}
            set { _HeSo[_X] = value; }
 
        }
        //--------------------------------------------------------------------

    }
}
