using System;
using System.Collections.Generic;
using System.Text;

namespace FancyComboBox2
{
    public class ComboBox : IDropList, IEditBox
    {
        #region IDropList Members

        public void ShowList()
        {
            Console.WriteLine("Day la showlist cua IDropList");
        }

        #endregion

        #region IUIControl Members

        public  virtual   void Paint()
        {
            Console.WriteLine("ComboBox.Paint()"); 
        }

        public void Show()
        {
           
        }

        #endregion

        #region IEditBox Members

        public void SelectText()
        {
             
        }

        #endregion
    }
}
