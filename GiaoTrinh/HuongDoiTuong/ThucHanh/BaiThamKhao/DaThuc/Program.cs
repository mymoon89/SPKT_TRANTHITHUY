using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class dathuc
    {
        private int bac;
        private string x;
        private int[] heso;
        public int BAC
        {
            get { return bac; }
            set { bac = value; }

        }
        public string X
        {
            get { return x; }
            set { x = value; }
        }
        public int[] HESO
        {
            get { return heso; }
            set { heso = value; }
        }
        public int this[int i]
        {
            get
            {
                if (i < 0 || i > this.heso.Length)
                    throw new Exception("vuot qua so bac :");
                return this.heso[i];
            }
            set
            {
                if (i < 0 || i > this.heso.Length)
                    throw new Exception("vuot qua so bac :");
                this.heso[i] = value;
            }



        }
        public dathuc()
        {
        }
        public dathuc(int _bac, string bien, int[] _Hs)
        {
            bac = _bac;
            x = bien;
            heso = _Hs;
        }
        public void nhap(dathuc d)
        {
            heso = new int[20];

            Console.WriteLine(" Moi ban nhap bac ");
            d.bac = int.Parse(Console.ReadLine());
            Console.WriteLine(" Moi Ban Nhap ten bien x hay y hay bat ky ky tu");
            d.x = Console.ReadLine();
            Console.WriteLine(" Moi ban nhap he so ");
            for (int i = 0; i <= d.bac; i++)
            {
                Console.Write(" A[{0}]= ", i);
                d.heso[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(" Cac he so ma ban vua nhap la :");
            for (int i = 0; i <= d.bac; i++)
                Console.WriteLine(" A[{0}]={1} ", i, heso[i]);

           }
        public dathuc cong(dathuc d1, dathuc d2)
        {
            string kq = " ";
            string kq1 = " ";
            string kq2 = "";
            string kq3 = "";

            Console.WriteLine(" Moi Ban Nhap du lieu cho da thuc thu Nhat:");
            d1.nhap(d1);
            Console.WriteLine(" Moi Ban Nhap du lieu cho da thuc thu Hai:");
            d2.nhap(d2);
            if (d1.bac == d2.bac)
            {
                for (int i = d1.bac; i >= 0; i--)
                {
                    kq += "+" + (d1.heso[i] + d2.heso[i]).ToString() + d1.x + "^" + i.ToString();

                }
                Console.WriteLine(" Ket Qua la F(x)= {0}", kq.Remove(0, 2));
             


            }

            if (d1.bac < d2.bac)
            {

                for (int i = d2.bac; i > d1.bac; i--)
                    kq1 += "+" + d2.heso[i].ToString() + d1.x + "^" + i.ToString();
                for (int j = d1.bac; j >= 0; j--)
                {
                    kq2 += "+" + (d1.heso[j] + d2.heso[j]).ToString() + d1.x + "^" + j.ToString();
                }
                kq3 = kq1 + kq2;
                Console.WriteLine(" Ket Qua la F(x)= {0}", kq3.Remove(0, 2));
                
            }
            if (d1.bac > d2.bac)
            {
                for (int i = d1.bac; i > d2.bac; i--)

                    kq1 += "+" + d1.heso[i].ToString() + d1.x + "^" + i.ToString();
                for (int j = d2.bac; j >= 0; j--)
                {
                    kq2 += "+" + (d1.heso[j] + d2.heso[j]).ToString() + d1.x + "^" + j.ToString();
                }
                kq3 = kq1 + kq2;
                Console.WriteLine(" Ket Qua la F(x)= {0}", kq3.Remove(0, 2));
              

            }

            return d1; 


        }

        public dathuc tru(dathuc d1, dathuc d2)
        {
            string kq = " ";
            string kq1 = " ";
            string kq2 = "";
            string kq3 = "";
            Console.WriteLine(" Moi Ban Nhap du lieu cho da thuc thu Nhat:");
            d1.nhap(d1);
            Console.WriteLine(" Moi Ban Nhap du lieu cho da thuc thu Hai:");
            d2.nhap(d2);
            if (d1.bac == d2.bac)
            {
                for (int i = d1.bac; i >= 0; i--)
                {
                    kq += "+" + "(" + (d1.heso[i] - d2.heso[i]).ToString() + ")" + d1.x + "^" + i.ToString();

                }
                Console.WriteLine(" Ket Qua la F(x)= {0}",kq.Remove(0, 2));
             


            }

            if (d1.bac < d2.bac)
            {

                for (int i = d2.bac; i > d1.bac; i--)
                    kq1 += "-" + d2.heso[i].ToString() + d1.x + "^" + i.ToString();
                for (int j = d1.bac; j >= 0; j--)
                {
                    kq2 += "+" + "(" + (d1.heso[j] - d2.heso[j]).ToString() + ")" + d1.x + "^" + j.ToString();
                }
                kq3 = kq1 + kq2;
                Console.WriteLine(" Ket Qua la F(x)= {0}", kq3.Remove(0, 1));
              

            }
            if (d1.bac > d2.bac)
            {
                for (int i = d1.bac; i > d2.bac; i--)
                    kq1 += "+" + d1.heso[i].ToString() + d1.x + "^" + i.ToString();
                for (int j = d2.bac; j >= 0; j--)
                {
                    kq2 += "+" + "(" + (d1.heso[j] - d2.heso[j]).ToString() + ")" + d1.x + "^" + j.ToString();
                }

                kq3 = kq1 + kq2;
                Console.WriteLine(" Ket Qua la F(x)= {0}", kq3.Remove(0, 2));
               
            }
            return d1;
        }
        public static dathuc operator -(dathuc d1, dathuc d2)
        {
            return d1.tru(d1, d2);
        }
        public static dathuc operator +(dathuc d1, dathuc d2)
        {
            return d1.cong(d1, d2);
        }
        class Program
        {
            static void Main(string[] args)
            {
                int[] a = new int[30];
                dathuc d1 = new dathuc();
                dathuc d2 = new dathuc();
                dathuc d = new dathuc();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t.....:: Chuong Trinh Thuc Hien Phep Cong va Tru Da Thuc .....");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Ban chon 1: Thuc hien Phep cong da thuc");
                Console.WriteLine(" Ban chon 2: Thuc hien phep tru da thuc");

              int k;
              do{
            
                Console.Write("\nNhap phep toan muon thuc hien(1 or 2 )? ");
                k = int.Parse(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine(" Bat dau thuc hien phep cong nhe :");
                        d = d1 + d2;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(" Bat dau thuc hien phep tru (d1-d2) nhe :");
                        d = d1 - d2;
                        break;
                    default:
                        Console.WriteLine(" Moi ban chon lai");
                        break;
                }

                Console.WriteLine(" Tiep tuc y/n?");
                Console.WriteLine(" Ban Co Met khong , Neu ban Met thi Nhan Phim N de thoat nhe!hjhjhj");
                Console.WriteLine(" Cam on ban da chay chuong trinh nay:");
                if (Console.ReadLine().ToUpper ()== "N")
                     break;

            }
            while (true);
                   
          
                
     Console.ReadLine();
           
        }
        }
    }
}