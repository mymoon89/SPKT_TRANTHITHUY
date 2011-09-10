using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapVector
{
    public class Vector
    {
        private int _SoChieu;
        public int SoChieu
        {
            get { return _SoChieu; }
        }

        private int[] V;

        // đây là Indexer giúp cho việc truy xuất đến từng phần tử trong V
        // thuận tiện hơn. (^_^)
        public int this[int i]
        {
            get 
            {
                if (i < 0 || i > this.V.Length)
                    throw new Exception("Vuot qua so chieu cua vector");
                return this.V[i];
            }
            set 
            {
                if (i < 0 || i > this.V.Length)
                    throw new Exception("Vuot qua so chieu cua vector");
                this.V[i] = value;
            }
        }

        public Vector()
        {
        }

        public Vector(int sochieu)
        {
            this._SoChieu = sochieu;
            this.V = new int[this.SoChieu];
        }

        public void NhapVector()
        {
            for (int i = 0; i < this.SoChieu; i++)
            {
                //Console.Write("Nhap vao chieu thu {0} cua vector: ", i);
                Console.Write("A[{0}",i.ToString());
                Console.Write("]");
                Console.Write("=");


                this[i] = int.Parse(Console.ReadLine());
            }
        }

        public void XuatVector()
        {
            Console.WriteLine(this.ToString());
        }

        public Vector Cong(Vector x)
        {
            Vector y = new Vector(this.SoChieu);
            if (this.SoChieu != x.SoChieu)
                return null;
            for (int i = 0; i < this.SoChieu; i++)
            {
                y[i] = this[i] + x[i];
            }
            return y;
        }

        public Vector Tru(Vector x)
        {
            Vector y = new Vector(this.SoChieu);
            if (this.SoChieu != x.SoChieu)
                return null;
            for (int i = 0; i < this.SoChieu; i++)
            {
                y[i] = this[i] - x[i];
            }
            return y;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return a.Cong(b);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return a.Tru(b);
        }

        public override string ToString()
        {
            string strABC = "V = (";
            for (int i = 0; i < this.SoChieu; i++)
            {
                strABC = strABC + this[i].ToString();
                if (i < this.SoChieu - 1)
                    strABC = strABC + ",";
            }
            strABC = strABC + ")";
            return strABC;
        }
    }
}
