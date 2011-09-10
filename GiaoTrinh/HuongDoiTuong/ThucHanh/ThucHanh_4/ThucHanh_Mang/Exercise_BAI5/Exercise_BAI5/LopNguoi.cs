using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise_BAI5
{
    public class LopNguoi
    {
        private string _Name;
        private string _Address;
        private string _MaritalStatus;
        private string _Birthday;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }
        public string Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }
       
    }
}
