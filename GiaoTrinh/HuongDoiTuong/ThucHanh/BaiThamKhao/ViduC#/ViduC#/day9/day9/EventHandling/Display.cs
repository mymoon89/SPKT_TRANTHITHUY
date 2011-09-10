using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace EventHandling
{// lop này se dua tình huong với Clock, vì có su thay doi
  public   class Display
    {
       
        public void SubCri(Clock theClock)
        {        
            theClock.OnChange += new Clock.ChangeHander(TimeChange);           
        }
        public void TimeChange(object theClock, TimeInforEvent time)
        {
            Console.WriteLine("thoi gian hien hanh: {0}: {1}: {2}",
                time.hour.ToString(),
                time.minute.ToString(),
                time.second.ToString()
                );
        }
    }
}
