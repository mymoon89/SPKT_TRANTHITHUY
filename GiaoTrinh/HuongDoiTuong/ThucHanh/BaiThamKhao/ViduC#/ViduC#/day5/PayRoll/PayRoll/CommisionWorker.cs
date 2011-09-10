using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayRoll{
  public class CommisionWorker:Employee
    {
      private decimal salary;
      private decimal commission;
      private int quantity;
      public CommisionWorker(string firstNameValue,
         string lastNameValue, decimal salaryValue,
         decimal commissionValue, int quantityValue)
          : base(firstNameValue, lastNameValue)
      {
          WeeklySalary = salaryValue;
          Commission = commissionValue;
          Quantity = quantityValue;
      }
      public decimal WeeklySalary
      {
          get
          {
              return salary;
          }
          set
          {
              // ensure non-negative salary value
              if (value > 0)
                  salary = value;
          }
      }
      public decimal Commission
      {
          get
          {
              return commission;
          }

          set
          {
              // ensure non-negative commission value
              if (value > 0)
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
              if (value > 0)
                  quantity = value;
          }
      }

      // override base-class method to calculate 
      // CommissionWorker's earnings
      public override decimal Earnings()
      {
          return WeeklySalary + Commission * Quantity;
      }

      // return string representation of CommissionWorker
      public override string ToString()
      {
          return "CommissionWorker: " + base.ToString();
      }

 
    }

}