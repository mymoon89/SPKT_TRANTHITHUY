using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mang
{
    public class HamMang
    {
        public int[] MANG;
        int col=0;
        int row=0;
        //public int col
        //{
        //    get { return _col; }
        //    set { _col = value; }
        //}
        //public int row
        //{
        //    get { return _row; }
        //    set { _row = value; }
        //}
     //________________________________________________________________________//
     //------------------HAM MANG MOT CHIEU------------------------------------//
        public HamMang(int n)
        {
            MANG = new int[n];
            
            Random rand = new Random();
           // System.Collections.IEnumerator e = MANG.GetEnumerator();
            for (int i = 0; i < MANG.Length; i++)
            {
                MANG[i] = rand.Next(-20,50);
            }
           
        }
        public HamMang(int[] A)
        {
            MANG = A;
        }
        public void InMang()
        {
            
            foreach (int x in MANG)
            {
                Console.WriteLine("{0}",x);
            }
        }
        public void SapXep()
        {
            Array.Sort(MANG);
        }
        public void SapXepGiam()
        {
            int tam;
            for(int i=0;i<MANG.Length;i++)
                for(int j=0;j<MANG.Length;j++)
                {
                    if (MANG[j] < MANG[i])
                    {
                        tam = MANG[j];
                        MANG[j] = MANG[i];
                        MANG[i] = tam;
                    }
                        
                }
        }
        public void SapTangAmSapGiamAM()
        {
            for (int i = 0; i < MANG.Length; i++)
            {
                if (MANG[i] < 0)
                    SapXep();
                else
                    SapXepGiam();
            }
        }
        public void NhapMangMotChieu()
        {
            Console.WriteLine("Nhap so phan tu cua mang:");
            int n = int.Parse(Console.ReadLine());
            MANG = new int[n];
            Console.WriteLine("Nhap phan tu:\n");
            for (int i = 0; i<MANG.Length;i++)
            {

                
                MANG[i] = int.Parse(Console.ReadLine());
            }
        }
        //____________________________________________________________________//
        //--------------------HAM MANG HAI CHIEU------------------------------//
        public int[,] MANG2;
        public HamMang(int m,int n)
        {
            col=m;
            row=n;
            MANG2=new int[m,n];
            
            Random rand = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    MANG2[i, j] = rand.Next(-10, 20);
                }
            }
        }
        public HamMang(int[,] A)
        {
            MANG2 = A;
        }
        public void NhapMangHaiChieu()
        {
            Console.WriteLine("Nhap so dong va so cot cua mang: \n");
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            MANG2=new int[m,n];
            //Console.WriteLine("Nhap phan cac phan tu cua mang:\t");
            //int k = 0;
            for(int i=0;i<m;i++)
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Thu [{0}{1}]=",i,j);
                    MANG2[i, j] = int.Parse(Console.ReadLine());
                    
                }
        }
        public void InMangHaiChieu()
        {
           
            System.Collections.IEnumerator myEnumerator = MANG2.GetEnumerator();
            int i = 0;
            int cols = MANG2.GetLength(MANG2.Rank - 1);
            while (myEnumerator.MoveNext())
            {
                if (i < cols)
                {
                    i++;
                }
                else
                {
                    Console.WriteLine();
                    i = 1;
                }
                Console.Write("\t{0}", myEnumerator.Current);
            }
            Console.WriteLine();

        }
        public void CongHaiMaTran(int[,] A,int[,] B)
        {
            int c = col;
            int r = row;
            //int [,] C;
            for (int i = 0; i < c; i++)
                for (int j = 0; j < row; j++)
                    A[i, j] = A[i, j] + B[i, j];
        }

    }
}
 