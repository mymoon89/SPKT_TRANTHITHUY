using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefExam
{
    class Program
    {// gán bằng hàm gọi
        public static void RefExam(ref int[] array)
        {
       // if (array == null)
         //       array = new int[10];
         array[0]=0;
        array[4]=444;}
        static void Main(string[] args)
        {
            int[] arrayInt = { 1, 2, 3, 4 ,5};
            RefExam(ref arrayInt);
            Console.WriteLine("In ra mang: ");
                for (int i=0;i<arrayInt.Length;i++)
                    Console.WriteLine(arrayInt[i]);
        }
    }
}
