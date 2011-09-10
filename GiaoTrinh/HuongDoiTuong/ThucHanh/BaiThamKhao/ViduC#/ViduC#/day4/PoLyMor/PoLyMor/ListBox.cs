using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoLyMor
{
  public  class ListBox:Window
    {
        private string listBoxContents;
        // hàm Constructor thêm thông số contents
        public ListBox(int top,int left,string contents) :base(top,left)
    {
        listBoxContents = contents;
    }
        // tính đa hình với cách viết lại hàm DrawWindow
        public override void DrawWindow()
        {
            base.DrawWindow();
            Console.WriteLine("Thuoc ve ListBox {0}",listBoxContents);
        }
    }
}
