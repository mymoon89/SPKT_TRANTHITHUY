using System;
using System.Collections.Generic;
using System.Text;

namespace ViduSGK
{
   abstract  public class Window
    {
       protected     int top;
       protected     int left;

        public Window() { }
        public Window(int top, int left)
        {
            this.top = top;
            this.left = left;
        }

        abstract public void DrawWindow();
         
    }
}
