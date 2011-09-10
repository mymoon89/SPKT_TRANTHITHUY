using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTapVector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector u, v;
            Vector x = new Vector();
            Vector y = new Vector();
            int i, j;
            Console.Write("Nhap vao so chieu vector u: ");
            i = int.Parse(Console.ReadLine());
            u = new Vector(i);
            u.NhapVector();
            Console.Write("\nNhap vao so chieu vector v: ");
            j = int.Parse(Console.ReadLine());
            v = new Vector(j);
            v.NhapVector();

            Console.WriteLine("\nXuat 2 vector u va v:");
            u.XuatVector();
            v.XuatVector();

            x = u.Cong(v);
            y = u.Tru(v);
            x.XuatVector();
            y.XuatVector();

            x = u + v;
            y = u - v;
            x.XuatVector();
            y.XuatVector();
        }
    }
}
