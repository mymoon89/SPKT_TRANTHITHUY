using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.cs
{
    public class CommisionWorker : Employee
    {
        private decimal salary;     // base weekly salary
       private decimal commission; // amount paid per item sold
       private int quantity;       // total items sold
   
      // constructor
         public CommisionWorker(string firstNameValue,
         string lastNameValue, decimal salaryValue,
         decimal commissionValue, int quantityValue ) 
         : base( firstNameValue, lastNameValue )
      {
         WeeklySalary = salaryValue;
         Commission = commissionValue;
         Quantity = quantityValue;
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
            // ensure non-negative salary value
            if ( value > 0 )
               salary = value;
         }
      }
   
      // property Commission
      public decimal Commission
      {
         get
         {
            return commission;
         }
   
         set
         {
            // ensure non-negative commission value
            if ( value > 0 )
               commission = value;
         }
      }
   
      // property Quantity
      public int Quantity
      {
         get
         {
            return quantity;
         }
         set
         {
            // ensure non-negative quantity value
            if ( value > 0 )
               quantity = value;
         }
      }
   
      // override base-class method to calculate 
      // CommissionWorker's earnings
      public override decimal Earnings()
      {
         return WeeklySalary + Commission * Quantity;
      }

               public override string ToString()
      {
         return "CommissionWorker: " + base.ToString();
      }

    }
}
