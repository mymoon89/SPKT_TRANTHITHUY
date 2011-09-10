using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventHandling
{   // lưu trữ thông tin liên quan đến events
   public  class TimeInforEvent: EventArgs 
    {
        public TimeInforEvent(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public readonly int hour;
        public readonly int minute;
        public readonly int second;

    }
}
