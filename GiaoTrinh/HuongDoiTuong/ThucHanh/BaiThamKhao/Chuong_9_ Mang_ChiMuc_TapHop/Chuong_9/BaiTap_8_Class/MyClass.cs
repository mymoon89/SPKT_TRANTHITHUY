using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_8_Class
{
    class MyClass
    {
        #region MyClass properties
        private string[] _ListStudent;
        private int _Index = 0;

        public string[] ListStudent
        {
            get { return _ListStudent; }
            set { _ListStudent = value; }
        }

        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }
        #endregion

        #region Indexer of list student
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= this.ListStudent.Length)
                    Console.WriteLine("Index was outside the bounds of array.");

                return this.ListStudent[index];
            }
            set
            {
                if (index < 0 || index >= this.ListStudent.Length)
                    Console.WriteLine("Index was outside the bounds of array.");

                this.ListStudent[index] = value;
            }
        } 
        #endregion
        
        #region Create constructor
        public MyClass()
        {
            this.ListStudent = new string[30];
            bool flag = true;
   
            Console.WriteLine("Insert list student:");
            Console.WriteLine(this.Index);

            do
            {
                if (this.Index < this.ListStudent.Length)
                {
                    Console.Write("\tAdd student to list. Student name: ");
                    this.ListStudent[this.Index] = Console.ReadLine();
                    this.Index++;

                    //Do you want to continue ?
                    Console.Write("Do you want to continue ? (Y/N)");
                    string key = Console.ReadLine();
                    if (key == "n" || key == "N")
                        flag = false;

                }
                else
                    Console.WriteLine("List student is full !");

            } while (flag);
        }
        #endregion

        #region Print list student
        public void PrintList()
        {
            if (this.Index < this.ListStudent.Length)
            {
                Console.WriteLine("List student is: ");
                for (int i = 0; i < this.Index; i++)
                {
                    Console.WriteLine("\t{0}.\t{1}", i + 1, this.ListStudent[i]);
                }

            }
            else
                Console.WriteLine("List is empty");

        }
        #endregion

        #region Add student to list
        public string[] AddToList(string studentName)
        {
            //Check list is full
            if (this.Index < this.ListStudent.Length)
            {
                //Add student to list
                this.ListStudent[this.ListStudent.Count() - 1] = studentName;

                return this.ListStudent;
            }

            return null;
        }
        #endregion
    }
}
