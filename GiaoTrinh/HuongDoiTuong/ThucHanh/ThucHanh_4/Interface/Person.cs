using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    class Person
    {
        private string _MaritalStatus;

        public Person ()
        {
            string name, adr, bir,marry;
            int year;
            Console.Write("Please Enter Name:");
            name=Console.ReadLine();
            Console.Write("Please Enter Addrsee:");
            adr = Console.ReadLine();
            Console.Write("Please Enter Marital Status <Single,Married,Divorced or Widowed>");
            _MaritalStatus=Console.ReadLine();
            Console.Write("Please Enter Date of Birth <dd/mm/yyyy>:");
            bir = Console.ReadLine();
            year = 2010 -int.Parse( bir.Substring(6, 4));
            marry = CanMarry();            
            Console.WriteLine(name + " lives at "+ adr + ", born on "+ bir + ", "+_MaritalStatus + ","+year.ToString()+" years old and "+marry);
            
        }
        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }

        public string CanMarry()
        {
            if (_MaritalStatus == "Single")
                return "can marry";
            else
                return "can't marry";
        }
             

    }
}
