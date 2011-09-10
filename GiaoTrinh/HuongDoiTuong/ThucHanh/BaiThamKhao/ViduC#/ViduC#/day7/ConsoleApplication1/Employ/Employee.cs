using System;
using System.Collections.Generic;
using System.Text;

namespace Employ
{
    public class Employee : IEmployee
    {
        private string name;
        private int counter;
        public static int total;

        public Employee()
        {
            counter = ++counter + total;
            //   throw new System.NotImplementedException();
        }
        #region IEmployee Members

        public string Name
        {
            get
            {
                return name;
                //  throw new NotImplementedException();
            }
            set
            {
                name = value;
                //    throw new NotImplementedException();
            }
        }

        public int Counter
        {

            get
            {
                return counter;
                //   throw new NotImplementedException(); }
            }

        #endregion
        }
    }
}