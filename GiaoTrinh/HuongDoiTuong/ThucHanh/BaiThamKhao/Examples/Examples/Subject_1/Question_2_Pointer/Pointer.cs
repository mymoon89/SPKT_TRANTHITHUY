using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question_2_Pointer
{
    class Pointer
    {
        #region Pointer Properties
        private float _HoangDo;
        private float _TungDo;
        private float _CaoDo;

        public float HoangDo
        {
            get { return _HoangDo; }
            set { _HoangDo = value; }
        }

        public float TungDo
        {
            get { return _TungDo; }
            set { _TungDo = value; }
        }

        public float CaoDo
        {
            get { return _CaoDo; }
            set { _CaoDo = value; }
        } 
        #endregion

        #region 2.b.1: Create constructor non parameter
        public Pointer() { } 
        #endregion

        #region 2.b.2: Create constructor have 3 parameter
        public Pointer(float hoangDo, float tungDo, float caoDo)
        {
            this.HoangDo = hoangDo;
            this.TungDo = tungDo;
            this.CaoDo = caoDo;

        } 
        #endregion

        #region 2.b.3: Input pointer from keyboard
        public Pointer InputPointer()
        {
            try
            {
                Console.WriteLine("Please input pointer: ");
                Console.Write("\tInput hoanh do: ");
                this.HoangDo = float.Parse(Console.ReadLine());
                Console.Write("\tInput tung do: ");
                this.TungDo = float.Parse(Console.ReadLine());
                Console.Write("\tInput cao do: ");
                this.CaoDo = float.Parse(Console.ReadLine());
                return this;
            }
            catch (FormatException fEx)
            {
                Console.WriteLine("Error: " + fEx.Message);
            }

            return null;
        } 
        #endregion

        #region 2.b.4: Display pointer into monitor
        public void DisplayPointer(Pointer pointer)
        {
            Console.WriteLine("Pointer information is:");
            Console.WriteLine("\tHoang do: " + pointer.HoangDo); 
            Console.WriteLine("\tTung do: " + pointer.TungDo);            
            Console.WriteLine("\tCao do: " + pointer.CaoDo);

        } 
        #endregion
    }
}
