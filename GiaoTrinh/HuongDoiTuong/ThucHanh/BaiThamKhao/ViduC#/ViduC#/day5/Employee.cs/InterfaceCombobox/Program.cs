using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceCombobox
{
    class Program
    {
        static void Main(string[] args)
        {
            ComboBox cb = new ComboBox();
            cb.Paint();
            ((IEditBox)cb).Paint(); // Paint nay la cua IEditBox
            ((IDropList)cb).Paint();// Paint cua IUIControl
            ((IUIControl)cb).Paint();

        }
    }
}
