using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_1_PhanSo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Khoi tao phan so A
            PhanSo phanSoA = new PhanSo(5, 7);

            //Rut gon phan so A
            phanSoA.RutGon();

            //Khoi tao phan so B
            PhanSo phanSoB = new PhanSo(2, 7);

            //Rut gon phan so B
            phanSoB.RutGon();

            //Cong hai phan so A va B. Ket qua cat vao A            
            Console.WriteLine(phanSoA.Xuat() + " + " + phanSoB.Xuat() + " = " + phanSoA.Cong(phanSoB).Xuat());

            //Dung mang hinh de xem ket qua
            Console.ReadLine();

        }
    }
}
