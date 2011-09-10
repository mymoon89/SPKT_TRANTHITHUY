using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.cs
{
    public class Boss : Employee
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
        public override string ToString()
        {
            return "Boss: " + base.ToString();
        }

        public override decimal Earnings()
        {
            return WeeklySalary;
        }
    }
}
