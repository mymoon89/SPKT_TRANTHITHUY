using System;
using System.Collections.Generic;
using System.Text;

namespace SinhVien
{
    struct SinhVien
    {
        public string name;
        // hàm constructor
        public SinhVien(string name)
        {
            this.name = name;
        }
        public void Hoc()
        {
            Console.WriteLine(" Đang học C#");
        }
        public bool Nghi() {
            return false;
        }
        public bool Choi() {
            return false;
        }
        static void Main(string[] args)
        {
           SinhVien svNam = new SinhVien("Le Van A");
             Console.WriteLine(svNam.name.ToString());
            Console.WriteLine(" đi chơi chưa: {0}", svNam.Choi().ToString());
            Console.WriteLine("nghỉ chưa:{0}",svNam.Nghi().ToString());
            // truy xuat hàm
            for (int i=0; i<2;i++)
                svNam.Hoc();
            Console.ReadLine();
        }
    }
}
