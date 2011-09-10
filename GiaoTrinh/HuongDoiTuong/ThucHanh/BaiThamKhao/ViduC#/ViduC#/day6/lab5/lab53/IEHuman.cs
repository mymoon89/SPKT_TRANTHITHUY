using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab53
{
   public interface IEHuman
    {
      // event EventHandler Event;
   
        void Speak(string Message);
        string Name { get; set; } 

    }
}
