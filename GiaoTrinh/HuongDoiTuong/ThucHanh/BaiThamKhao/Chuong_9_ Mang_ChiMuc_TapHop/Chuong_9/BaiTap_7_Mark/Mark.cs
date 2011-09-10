using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_7_Mark
{
    class Mark
    {
        #region Mark properties
        private float[] _ListMark;
        private int _Index = 0;

        public float[] ListMark
        {
            get { return _ListMark; }
            set { _ListMark = value; }
        }

        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        #endregion

        #region Indexer of list mark
        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= this.ListMark.Length)
                    Console.WriteLine("Index was outside the bounds of array.");

                return this.ListMark[index];
            }
            set
            {
                if (index < 0 || index >= this.ListMark.Length)
                    Console.WriteLine("Index was outside the bounds of array");

                this.ListMark[index] = value;
            }

        }
        #endregion

        #region Create constructor
        public Mark()
        {
            this.ListMark = new float[30];
            bool flag = true;

            Console.WriteLine("Create list mark of student");
            do
            {
                try
                {
                    Console.Write("\tAdd mark: ");
                    this.ListMark[this.Index] = float.Parse(Console.ReadLine());
                    this.Index++;

                    //Do you want to continue
                    Console.Write("Do you want to continue? (Y/N): ");
                    string key = Console.ReadLine();
                    if (key == "n" || key == "N")
                        flag = false;

                }
                catch (FormatException fEx)
                {
                    Console.WriteLine("Error: " + fEx.Message);
                }
            } while (flag);
        }
        #endregion

        #region Print list mark of student
        public void PrintList()
        {
            if (this.Index < this.ListMark.Length)
            {
                Console.WriteLine("List mark of students are: ");
                for (int i = 0; i < this.Index; i++)
                {
                    Console.WriteLine("\t{0}.\t{1}", i + 1, this.ListMark[i]);
                }
            }
            else
                Console.WriteLine("List mark of student is full");

        } 
        #endregion

        #region Add mark of student to list
        public float[] AddToList(float x)
        {
            if (this.Index < this.ListMark.Length)
            {
                this.ListMark[this.Index] = x;

                return this.ListMark;
            }

            return null;
        } 
        #endregion

        #region Average of list mark
        public float AverageOfList()
        {
            float sum = 0;
            for (int i = 0; i < this.Index; i++)
            {
                sum += this.ListMark[i];
            }
            return sum / this.Index;

        } 
        #endregion
    }
}
