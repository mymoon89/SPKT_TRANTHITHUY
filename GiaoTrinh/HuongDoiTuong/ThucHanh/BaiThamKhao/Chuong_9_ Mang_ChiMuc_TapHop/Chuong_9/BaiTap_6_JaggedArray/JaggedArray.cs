using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_6_JaggedArray
{
    class JaggedArray
    {
        #region JaggedArray properties
        private int[][] _MyArray;

        public int[][] MyArray
        {
            get { return _MyArray; }
            set { _MyArray = value; }
        }
        #endregion

        #region Create constructor
        public JaggedArray()
        {
            this.MyArray = new int[5][];
            Random rd = new Random();

            for (int i = 0, j = this.MyArray.Length; i < j; i++)
            {
                this.MyArray[i] = new int[i + 1];
                for (int k = 0, l = this.MyArray[i].Length; k < l; k++)
                {
                    this.MyArray[i][k] = rd.Next(0, 10);

                }
            }
        }
        #endregion

        #region Print array
        public void Print()
        {
            Console.WriteLine("Print array by for loop");
            for (int i = 0, j = this.MyArray.Length; i < j; i++)
            {
                for (int k = 0, l = this.MyArray[i].Length; k < l; k++)
                {
                    Console.Write("A[{0}][{1}] = {2}\t", i, k, this.MyArray[i][k]);

                }
                Console.WriteLine();
            }

            Console.WriteLine("Print array by foreach loop");
            foreach (int[] row in this.MyArray)
            {
                foreach (int value in row)
                {
                    Console.Write(value + "\t");
                }
                Console.WriteLine();
            }

        } 
        #endregion
    }
}
