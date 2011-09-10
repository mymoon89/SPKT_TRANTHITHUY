using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OutEx
{// out khởi tạo bằng hàm hành sự,sử dụng trong Main
    class Program
    {
        public static void OutEx(out int[] arrayInt)
        { arrayInt = new int[5] { 1, 2, 3, 4, 5 }; }
        static void Main(string[] args)
        {
            int[] arrayInt;
            OutEx(out arrayInt);
            Console.WriteLine("In ra phan tu:");
            for (int i = 0; i < arrayInt.Length; i++)
                Console.WriteLine(arrayInt[i]);
        }
    }
}
