using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Params
{
    class Program
    {
        static void Main(string[] args)
        {
            Program  t = new Program ();
          
          t.DisplayVals(5, 6, 7, 8); // Truyền trực tiếp
           int[] explicitArray = new int[5] { 1, 2, 3, 4, 5 }; // hay thông qua một mang khác
            t.DisplayVals(explicitArray);
        }
        public void DisplayVals(params  int[] intVals)
        {
              foreach (int i in intVals)
        {
       Console.WriteLine("DisplayVals {0}", i);
        }
}
    }
}
