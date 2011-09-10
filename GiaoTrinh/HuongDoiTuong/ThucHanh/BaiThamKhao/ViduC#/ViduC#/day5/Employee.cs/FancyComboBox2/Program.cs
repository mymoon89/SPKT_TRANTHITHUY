using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FancyComboBox2
{
    class Program
    {
        static void Main(string[] args)
        {
            FancyComboBox cb = new FancyComboBox();

            cb.Paint(); //Paint cua chinh no
            cb.ShowList();
            ((IUIControl)cb).Paint();
            ((IEditBox)cb).Paint(); //Paint tu IUIControl
            

        }
    }
}
