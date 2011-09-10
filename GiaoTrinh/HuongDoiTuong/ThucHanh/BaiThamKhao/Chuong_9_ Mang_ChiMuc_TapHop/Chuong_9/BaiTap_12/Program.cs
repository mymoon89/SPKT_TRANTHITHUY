using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_12
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create list student
            LopHoc lopHoc = new LopHoc();

            //Add 3 student to list
            lopHoc.DSHocVien.Add("1", "Nguyen Van A");
            lopHoc.DSHocVien.Add("2", "Le Van Teo");
            lopHoc.DSHocVien.Add("3", "Phan Van Ty");

            //Print list student
            Console.WriteLine("List student:");
            lopHoc.PrintListStudent();

            //Search student has name is 'Mu Ga'
            HocVien hocVien1 = lopHoc.SearchStudent("Mu Ga");
            if (hocVien1 == null)
                Console.WriteLine("Mu Ga is not found !");
            else
            {
                Console.WriteLine("Search success !");
                Console.WriteLine("\tStudent ID is: " + hocVien1.MaSoSV);
                Console.WriteLine("\tStudent name is: " + hocVien1.TenSV);

            }

            //Search student has name is 'Nguyen Van A'
            HocVien hocVien2 = lopHoc.SearchStudent("Nguyen Van A");
            if (hocVien2 == null)
                Console.WriteLine("Not found !");
            else
            {
                Console.WriteLine("Search success !");
                Console.WriteLine("\tStudent ID is: " + hocVien2.MaSoSV);
                Console.WriteLine("\tStudent name is: " + hocVien2.TenSV);

            }

            //Stop monitor
            Console.ReadLine();

        }
    }
}
