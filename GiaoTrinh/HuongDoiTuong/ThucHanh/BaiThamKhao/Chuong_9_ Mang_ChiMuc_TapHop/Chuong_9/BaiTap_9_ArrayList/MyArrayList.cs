using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BaiTap_9_ArrayList
{
    class MyArrayList
    {
        #region MyArrayList properties
        private ArrayList myAL;

        public ArrayList MyAL
        {
            get { return myAL; }
            set { myAL = value; }
        } 
        #endregion

        #region Create constructor
        public MyArrayList()        
        {
            this.myAL = new ArrayList();
            int count = 0;
            bool flag = true;

            Console.WriteLine("Moi ban nhap gia tri cac phan tu cua mang so nguyen:");            
            do
            {                
                try
                {
                    Console.Write("A[{0}] = ", count++);
                    myAL.Add(int.Parse(Console.ReadLine()));

                    Console.Write("Ban co muon nhap tiep khong ? (Y/N)");
                    string key = Console.ReadLine();
                    if (key == "n" || key == "N") 
                        flag = false;

                }
                catch(FormatException fEx)
                {
                    Console.WriteLine("Error: " + fEx.Message);
                    count--;
                }

            }while (flag);        
        } 
        #endregion

        #region Print array list
        public void Print()
        {
            foreach (int x in this.myAL)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine();
        } 
        #endregion

    }
}
