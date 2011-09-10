using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
// lớp tạo tình huống OnChange
namespace EventHandling
{
   public  class Clock
    {
        public delegate void ChangeHander(object clock, TimeInforEvent timeInfor);
        // tình huống
        public event ChangeHander OnChange;
        private int hour;
        private int minute;
        private int second;
        public void Run()
        {
            for (; ; )
            {
                Thread.Sleep(10);
                System.DateTime dt = System.DateTime.Now;// lay time hiện hành
                if (dt.Second != second)// nến giây thay đổi sẽ báo cho hàm xử lý
                {// tao doi tuong de chuyen cho hàm xu lý
                    TimeInforEvent timeInformation = new TimeInforEvent(dt.Hour, dt.Minute, dt.Second);
                    if (OnChange != null) {
                        OnChange(this, timeInformation);
                    }
                }
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }
}
