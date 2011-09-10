using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_11_MyStack
{
    class MyStack
    {
        #region MyStack properties
        private int _N;
        private int _Top;
        private int[] _Value;

        public int N
        {
            get { return _N; }
            set { _N = value; }
        }

        public int Top
        {
            get { return _Top; }
            set { _Top = value; }
        }

        public int[] Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        #endregion

        #region Create stack have 5 element
        public MyStack()
        {
            this.N = 10;
            this.Top = 0;
            this.Value = new int[this.N];
            Random rd = new Random();
            //Create value for stack
            for (int i = 0; i < 5; i++)
            {                   
                this.Value[i] = rd.Next(-10, 10);
                this.Top++;

            }
        }
        #endregion

        #region Check stack is empty
        public bool IsEmpty()
        {
            if (this.Top == 0)
                return true;

            return false;

        }
        #endregion

        #region Check stack is full
        public bool IsFull()
        {
            if (this.Top == this.N)
                return true;

            return false;

        }
        #endregion

        #region Print stack
        public void PrintStack()
        {
            for (int i = 0; i < this.Top; i++)
                Console.Write(this.Value[i] + "\t");

            Console.WriteLine();

        }
        #endregion

        #region 1: Pop 1 element out to stack
        /// <summary>
        /// Pop 1 element out to stack. If stack is empty then show message and return -99
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (!this.IsEmpty())
            {
                this.Top--;
                return this.Value[this.Top];
            }
            else
            {
                Console.WriteLine("The stack is empty");
            }
            return -99;

        }
        #endregion

        #region 2: Pop 2 elements out to stack
        /// <summary>
        /// Pop 2 element out to stack. If stack is empty then show messeage and return null, else return array integer have elements
        /// </summary>
        /// <returns></returns>
        public int[] PopTwoElement()
        {
            if (!this.IsEmpty())
            {
                //Create array list have type integer store 2 element
                int[] listPop = new int[2];

                //Pop first element
                this.Top--;
                listPop[0] = this.Value[this.Top];                

                //Check stack is empty, if stack isn't empty then pop last element
                if (!this.IsEmpty())
                {
                    //Pop last element
                    this.Top--;
                    listPop[1] = this.Value[this.Top];                    

                }
                return listPop;

            }
            else
            {
                Console.WriteLine("Stack is empty");
            }
            return null;

        } 
        #endregion

        #region 3: Display first element of stack
        /// <summary>
        /// Display first element of stack. If stack is empty then show meseage and return -99
        /// </summary>
        /// <returns></returns>
        public int DisplayFirstElement()
        {
            if (!this.IsEmpty())
                return this.Value[this.Top - 1];
            else
                Console.WriteLine("Stack is empty");

            return -99;

        } 
        #endregion

        #region 4: Push 1 element to stack
        public MyStack Push(int x)
        {
            if (!this.IsFull())
            {
                this.Value[this.Top] = x;
                this.Top++;

                return this;

            }
            return this;

        } 
        #endregion
    }
}
