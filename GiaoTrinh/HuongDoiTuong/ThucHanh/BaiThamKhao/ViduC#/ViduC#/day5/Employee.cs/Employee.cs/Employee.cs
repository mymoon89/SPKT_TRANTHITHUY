using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.cs
{
    public abstract class Employee
    {
       private string firstName;
        private string lastName;

        public Employee(string firstNameValue, string lastNameValue)
        {
            FirstName = firstNameValue;
            LastName = lastNameValue;

        }
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
               return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public override  string  ToString()
        {
            return FirstName + " " + LastName;
        }

        public abstract  decimal Earnings();
         
    }
}
