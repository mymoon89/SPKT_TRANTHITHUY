using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParamOutRef
{
    class Program
    {
        // param cho phép khai báo thông số hàm hành sự mà ko quan tâm đến số lượng parameter
        public void Example(params int[] intValue)
        {
            foreach (int i in intValue)
            {
                Console.WriteLine("In ra {0}",i);
            }
 
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Example(1, 2, 3);
            int[] arrayTemp = new int[5] { 4, 5, 6, 7, 8 };
            p.Example(arrayTemp);
        }
    }
}
