using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3 phần của biểu thức LINQ:
            // 1. Dữ liệu nguồn.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            // 2. Tạo truy vấn.
            // numQuery là 1 IEnumerable<int>
            var numQuery = from num in numbers
                           where (num % 2) == 0
                           select num;// cách sắp đặt các mệnh đề khác với trong SQL

            // 3. Thực thi truy vấn.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }
            Console.ReadLine();
        }
    }
}
