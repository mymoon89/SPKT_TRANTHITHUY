using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventHandling
{
    class WriteFile
    {
        public void GhiFile(object theClock,TimeInforEvent time) {
            Console.WriteLine("Ghi file : {0} : {1}: {2}",time .hour .ToString (),time .minute .ToString (),time .second .ToString ());
        }
        public void Subscri(Clock theClock) {
            theClock.OnChange += new Clock.ChangeHander(GhiFile);
        }

        void theClock_OnChange(object clock, TimeInforEvent timeInfor)
        {
            throw new NotImplementedException();
        }
    }
}
