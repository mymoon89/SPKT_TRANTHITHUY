using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommissionEmployee
{
    class BasePlusCommissionEmployee2:CommissionEmployee
    {
        private decimal baseSalary; // base salary per week

        // six-parameter derived class constructor
        // with call to base class CommissionEmployee constructor
        public BasePlusCommissionEmployee2(string first, string last,
           string ssn, decimal sales, decimal rate, decimal salary)
            : base(first, last, ssn, sales, rate)
        {
            BaseSalary = salary; // validate base salary via property
        } // end six-parameter BasePlusCommissionEmployee2 constructor

        // property that gets and sets 
        // base-salaried commission employee's base salary
        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            } // end get
            set
            {
                baseSalary = (value < 0) ? 0 : value;
            } // end set
        } // end property BaseSalary
      public override  decimal Earnings()
        {
            // not allowed: commissionRate and grossSales private in base class
            return baseSalary + (commissionRate * grossSales);
        } // end method Earnings

        // return string representation of BasePlusCommissionEmployee2
        public override string ToString()
        {
            // not allowed: attempts to access private base class members   
            return string.Format(
               "{0}: {1} {2}\n{3}: {4}\n{5}: {6:C}\n{7}: {8:F2}\n{9}: {10:C}",
               "base-salaried commission employee", firstName, lastName,
               "social security number", socialSecurityNumber,
               "gross sales", grossSales, "commission rate", commissionRate,
               "base salary", baseSalary);
        } // end method ToString 
      //   file số 3 
       /*   public override decimal Earnings()
    {
        return BaseSalary + base.Earnings();
    } // end method Earnings

    // return string representation of BasePlusCommissionEmployee4
    public override string ToString()
    {
        return string.Format("{0} {1}\n{2}: {3:C}",
           "base-salaried", base.ToString(), "base salary", BaseSalary);
    } // end method ToString
  */
         

    }
}
