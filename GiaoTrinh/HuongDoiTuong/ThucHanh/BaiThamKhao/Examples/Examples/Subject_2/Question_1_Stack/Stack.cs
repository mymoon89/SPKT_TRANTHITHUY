using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_1_Stack
{
    class Stack
    {
        #region Stack properties
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

        #region 1.a: Create constructor have parameter
        public Stack(int n)
        {
            this.N = n;
            this.Top = 0;
            this.Value = new int[n];

        }
        #endregion

        #region 1.b: The method checks stack is empty
        public bool isEmpty()
        {
            if (this.Top == 0)
                return true;

            return false;

        }
        #endregion

        #region 1.c: The method checks stack is full
        public bool isFull()
        {
            if (this.Top == N)
                return true;

            return false;
        }
        #endregion

        #region 1.d: The method pushes element to stack
        public Stack push(int x)
        {
            if (!this.isFull())
            {
                this.Value[this.Top] = x;
                this.Top++;
            }
            else
            {
                Console.WriteLine("The stack is full");
            }
            return this;
        }
        #endregion

        #region 1.e: The method pops first element of stack
        public int pop()
        {
            if (!this.isEmpty())
            {                
                this.Top--;
                return this.Value[this.Top];
            }   
            else
                Console.WriteLine("The stack is empty");

            return -1;
        }
        #endregion

        #region The method prints value of stack
        public void printStack()
        {
            if (!this.isEmpty())
            {
                for (int i = 0; i < this.Top; i++)
                    Console.Write(this.Value[i] + "\t");
                Console.WriteLine();
            }                
            else
                Console.WriteLine("The stack is empty");
        }
        #endregion
    }
}
