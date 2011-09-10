using System;
using System.Collections.Generic;
using System.Text;

namespace Vidu2
{
    public class Class1 : IB, IC
    {
        #region IB Members

        public void SelectText()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IA Members

        public void Paint()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IC Members

        public void ShowList()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
