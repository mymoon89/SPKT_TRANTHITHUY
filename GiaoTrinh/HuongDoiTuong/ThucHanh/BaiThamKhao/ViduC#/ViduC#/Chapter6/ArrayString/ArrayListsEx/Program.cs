using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ArrayListsEx
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ArrayList empArray = new ArrayList();
            ArrayList intArray = new ArrayList();
// đưa vào mảng
            for( int i = 0; i < 5; i++)
{
    Employee a = new Employee(i + 100);
    empArray.Add(a);
          //  empArray.Add( new Employee(i+100));
            intArray.Add( i*5 );
}
// in tất cả nội dung
            for(int i = 0; i < intArray.Count; i++)
{
            Console.Write("{0} ",intArray[i].ToString());
}
            Console.WriteLine("\n");
// in tất cả nội dung của mảng
            for(int i = 0; i < empArray.Count; i++)
{
            Console.Write("{0} ",empArray[i].ToString());
}
            Console.WriteLine("\n");
            Console.WriteLine("empArray.Count: {0}", empArray.Count);
            Console.WriteLine("empArray.Capacity: {0}", empArray.Capacity);
        }
    }
}
