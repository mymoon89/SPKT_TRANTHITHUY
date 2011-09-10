using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_2_Queue
{
    class Queue
    {
        #region Queue Properties
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

        #region 2.a: Create queue have n element
        public Queue(int n)
        {
            this.N = n;
            this.Top = 0;
            this.Value = new int[this.N];

        } 
        #endregion

        #region 2.b: Check queue is empty
        public bool isEmpty()
        {
            if (this.Top == 0)
                return true;

            return false;
        } 
        #endregion

        #region 2.c: Check queue is full
        public bool isFull()
        {
            if (this.Top == this.N)
                return true;

            return false;
        }
        #endregion

        #region 2.d: Push element in to queue
        public Queue Push(int x)
        {
            if (!this.isFull())
            {
                this.Value[this.Top] = x;
                this.Top++;

            }

            return this;
        
        }
        #endregion

        #region 2.e: Pop element out to queue
        public int Pop()
        {
            if (!this.isEmpty())
            {
                //Get first element of queue
                int temp = this.Value[0];

                //Sort queue
                for (int i = 0; i < this.Top;)
                {
                    this.Value[i] = this.Value[++i];
                }

                this.Top--;

                return temp;
            }
            else
                Console.WriteLine("Queue is empty");
            return -1;
        }
        #endregion

        #region Print queue
        public void Print()
        {
            Console.Write("Value of queue is:\t");
            for (int i = 0; i < this.Top; i++)
            {
                Console.Write(this.Value[i] + "\t");
            }
            Console.WriteLine();

        }
        #endregion

    }
}
