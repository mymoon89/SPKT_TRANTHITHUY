using System;
using System.Collections.Generic;
using System.Text;

namespace XinChao
{
    class XinChao
    {
        enum LuongNhanVien
        {
            NV1=100,
            NV2=150,
            NV3=200
        }
   
        static void Main()
        {
            Console.WriteLine("Hello C#\n");
            int x = (int)LuongNhanVien.NV1;
            Console.WriteLine(" luong nhan vien 1 la :{0}\n luong nhan vien 3 la :{1}",x, LuongNhanVien.NV3);
            Console.ReadLine();
        }
    }
}
