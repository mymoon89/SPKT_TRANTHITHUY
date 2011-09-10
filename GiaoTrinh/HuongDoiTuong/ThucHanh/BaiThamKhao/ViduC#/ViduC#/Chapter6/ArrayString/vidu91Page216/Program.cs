using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vidu91Page216
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray;
            Employee[] empArray;
            intArray = new int[5];
            empArray = new Employee[3];
// tạo đối tượng đưa vào mảng
            for( int i = 0; i < empArray.Length; i++)
                {
                    empArray[i] = new Employee(i+5);// giá trị i+5 đưa vào đối tượng boi Constructor
                }
// xuất mảng nguyên voi gia tri default la 0
            foreach (int i in intArray)
            {
                Console .WriteLine (i.ToString());
            }
           for( int i = 0; i < intArray.Length; i++)
                {
                    Console.Write(intArray[i].ToString()+"\t");
                 } 
// xuất mảng Employee
            Console.WriteLine();
            for( int i = 0; i < empArray.Length; i++)
                {
                    empArray[i].Display();
            Console.WriteLine(empArray[i].ToString()+"\t");
                }

        }
    }
}
