using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayRoll
{
  public  class Boss: Employee
    {
        private decimal salary; // Boss's salary

        // constructor
        public Boss(string firstNameValue, string lastNameValue,
           decimal salaryValue)
            : base(firstNameValue, lastNameValue)
        {
            WeeklySalary = salaryValue;
        }

        // property WeeklySalary
        public decimal WeeklySalary
        {
            get
            {
                return salary;
            }

            set
            {
                // ensure positive salary value
                if (value > 0)
                    salary = value;
            }
        }
        // override base-class method to calculate Boss's earnings
        public override decimal Earnings()
        {
            return WeeklySalary;
        }

        // return string representation of Boss
        public override string ToString()
        {
            return "Boss: " + base.ToString();
        }

    }
}
