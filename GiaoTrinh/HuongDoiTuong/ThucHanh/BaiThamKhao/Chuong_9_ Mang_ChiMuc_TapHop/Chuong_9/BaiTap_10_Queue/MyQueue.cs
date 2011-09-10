using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiTap_10_Queue
{
    class MyQueue
    {
        #region Queue properties
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

        #region Create constructor MyQueue
        public MyQueue()
        {
            this.N = 10;
            this.Top = 0;
            this.Value = new int[this.N];

            //Create 5 element of queue            
            Random rd = new Random();
            for (int i = 0; i < 5; i++)
            {
                this.Value[i] = rd.Next(-10, 10);
                this.Top++;
            }
        } 
        #endregion

        #region Check queue is empty
        public bool IsEmpty()
        {
            if (this.Top == 0)
                return true;

            return false;
        } 
        #endregion

        #region Check queue is full
        public bool IsFull()
        {
            if (this.Top == this.N)
                return true;

            return false;
        } 
        #endregion

        #region Print queue
        public void Print()
        {
            for (int i = 0; i < this.Top; i++)
            {
                Console.Write(this.Value[i] + "\t");

            }
            Console.WriteLine();

        } 
        #endregion

        #region 1. Pop 1 element out to queue
        /// <summary>
        /// Pop 1 element out to queue. If queue is empty then return -99
        /// </summary>
        /// <returns></returns>
        public int Pop()
        {
            if (!this.IsEmpty())
            {
                int temp = this.Value[0];
                for (int i = 0; i < this.Top; i++)
                    this.Value[i] = this.Value[i+1];

                this.Top--;

                return temp;

            }
            else
                Console.WriteLine("Queue is empty");

            return -99;
        } 
        #endregion

        #region 2. Pop 2 elements out to queue
        public int[] PopTwoElement()
        {
            if (!this.IsEmpty())
            {
                //Pop first element
                int[] listPop = new int[2];
                listPop[0] = this.Value[0];

                for (int i = 0; i < this.Top; i++)
                {
                    this.Value[i] = this.Value[i + 1];
                }
                this.Top--;

                //Check queue is empty
                if (!this.IsEmpty())
                {
                    //Pop last element
                    listPop[1] = this.Value[0];
                    for (int i = 0; i < this.Top; i++)
                    {
                        this.Value[i] = this.Value[i + 1];
                    }
                    this.Top--;

                }
                return listPop;

            }
            else
                return null;
        } 
        #endregion

        #region 3. Display first element of queue
        public int DisplayFirstElement()
        {
            if (!this.IsEmpty())
            {
                return this.Value[0];

            }
            else
                Console.WriteLine("Queue is empty");

            return -99;
        } 
        #endregion

        #region 4. Push element to queue
        public MyQueue Push(int x)
        {
            if (!this.IsFull())
            {
                this.Value[this.Top] = x;
                this.Top++;

            }
            else
                Console.WriteLine("Queue is full");

            return this;
        } 
        #endregion
    }
}
