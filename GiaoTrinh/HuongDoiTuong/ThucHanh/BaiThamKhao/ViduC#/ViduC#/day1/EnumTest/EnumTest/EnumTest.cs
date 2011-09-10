using System;
using System.Collections.Generic;
using System.Text;

namespace EnumTest
{
    enum LuongNhanVien
    {
        NV1 = 100,
        NV2 = 150,
        NV3 = 200
    };
    class EnumTest 
    {
        public static void ThuongNhanVien(LuongNhanVien lnv)
        {
            switch (lnv)
            {
                case LuongNhanVien.NV1:
                    Console.WriteLine(" thuong cho nv 1 ...");
                    break;
                case LuongNhanVien.NV2:
                    Console.WriteLine("thuong cho nv 2....");
                    break;
                case LuongNhanVien.NV3:
                    Console.WriteLine(" thuong nv 3....");
                    break;
                default: break;
            }
        }
        static void Main(string[] args)
        {
            int x =  (int)LuongNhanVien.NV1;
         
            LuongNhanVien cal;
            cal = LuongNhanVien.NV2;
            ThuongNhanVien(cal);
            Console.WriteLine("Hello C#\n");
            Console.WriteLine(" luong nhan vien 1 la :{0}\n, luong nhan vien 2: {1} ",x,cal);
            Console.ReadLine();
        } 
    }
}
