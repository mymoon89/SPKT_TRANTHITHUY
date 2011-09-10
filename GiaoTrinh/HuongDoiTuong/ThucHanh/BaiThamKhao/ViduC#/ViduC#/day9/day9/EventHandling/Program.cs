using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace EventHandling
{
  public   class Program
    {
        static void Main( )
        {
            Clock theClock = new Clock();
            Display dis = new Display();
            dis.SubCri(theClock);
            WriteFile wf = new WriteFile();
            wf.Subscri(theClock );
            theClock.Run(); 
        }
    }
}
