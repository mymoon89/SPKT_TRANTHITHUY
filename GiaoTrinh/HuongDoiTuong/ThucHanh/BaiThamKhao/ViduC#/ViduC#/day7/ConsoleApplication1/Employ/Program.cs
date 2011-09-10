using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employ
{
  public  class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap tong so sinh vien hien co:");
            string s = Console.ReadLine();
            // chuyen kieu de gan cho kieu int
            Employee.total = int.Parse(s);
            Employee emp = new Employee();
            Console.WriteLine("Them sinh vien moi:");
            emp.Name = Console.ReadLine();
            Console.WriteLine("Thong tin sinh vien:");
            Console.WriteLine("So sv hien co:{0}",emp.Counter);
            Console.WriteLine("Ten sv moi nhap hoc: {0}",emp.Name);

        }
    }
}
