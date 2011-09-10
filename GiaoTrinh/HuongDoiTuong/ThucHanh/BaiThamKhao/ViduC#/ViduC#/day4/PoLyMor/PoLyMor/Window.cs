using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoLyMor
{
   public class Window
    {
        private int top,left;
        public Window(int top, int left) {
            this.top = top;
            this.left = left;
        }
        //hàm vẽ mô Window
        public virtual void DrawWindow() {
            Console.WriteLine(" Ve Window tai top {0} left{1}", top, left);
        }
    }
}
