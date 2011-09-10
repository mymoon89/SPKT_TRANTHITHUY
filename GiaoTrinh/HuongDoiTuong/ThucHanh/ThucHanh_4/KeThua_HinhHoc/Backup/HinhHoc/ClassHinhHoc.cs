using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace HinhHoc
{     
    abstract public class ClassHinhHoc
    {
        protected Point _Tam;
        public Point Tam
        {
            get { return _Tam; }
            set { _Tam = value; }
        }
        public abstract double Chuvi();
        public abstract double DienTich();
        public abstract void Ve(Graphics g);
    }

}


