using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayRec
{
    class Program
    {
        static void Main(string[] args)
        {
            // khai báo số dòng và số cột của mảng
            const int rows = 4;
            const int columns = 3;
// khai báo mảng 4x3 số nguyên
            int [,] rectangularArray = new int[rows, columns];
            
// khởi tạo các thành phần trong mảng
            for(int i = 0; i < rows; i++)
{
            for(int j = 0; j < columns; j++)
{
            rectangularArray[i,j] = i+j; // dua giá trị vào thành phần mang
}
}
// xuất nội dung ra màn hình
            for(int i = 0; i < rows; i++)
                {
            for(int j = 0; j < columns; j++)
                {
            Console.WriteLine("rectangularArray[{0},{1}] = {2}",i, j, rectangularArray[i, j]);
                }
                }
        }
    }
}
