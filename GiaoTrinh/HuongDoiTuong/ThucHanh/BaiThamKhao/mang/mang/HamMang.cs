using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mang
{
    public class HamMang
    {
        public int[] MANG;
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
    }
}
