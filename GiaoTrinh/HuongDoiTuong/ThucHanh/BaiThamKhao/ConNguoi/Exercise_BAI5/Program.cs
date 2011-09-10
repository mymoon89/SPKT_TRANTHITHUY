using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_BAI5
{
    class Program
    {
        static void Main(string[] args)
        {
            LopNguoi Nguoi = new LopNguoi();
            Console.WriteLine("Nhap Ten:");
            Nguoi.Name = Console.ReadLine();
            Console.WriteLine("Nhap Dia Chi:");
            Nguoi.Address = Console.ReadLine();
            Console.WriteLine("Nhap Tinh Trang Hon Nhan:<yes/No>");
            Nguoi.MaritalStatus = Console.ReadLine();
            Console.WriteLine("Nhap Ngay Sinh:");
            Nguoi.Birthday = Console.ReadLine();
            string nam= Nguoi.Birthday.Substring(6);
            int tuoi = 2010 - int.Parse(nam);
            //string n;
            if (Nguoi.MaritalStatus == "yes" || Nguoi.MaritalStatus == "Yes" || Nguoi.MaritalStatus == "YES")
                Console.WriteLine("Ten: {0},Dia Chi: {1},Tinh Tang Hon Nhan: {2},Sinh Ngay: {3},Can Mary,{4}", Nguoi.Name, Nguoi.Address, Nguoi.MaritalStatus, Nguoi.Birthday,tuoi);
            else
                Console.WriteLine("Ten: {0},Dia Chi: {1},Tinh Tang Hon Nhan: {2},Sinh Ngay: {3},Can't Mary,Tuoi: {4}", Nguoi.Name, Nguoi.Address, Nguoi.MaritalStatus, Nguoi.Birthday, tuoi);

        }
    }
}
