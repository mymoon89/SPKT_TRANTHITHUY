using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommissionEmployee 

{
    class CommissionEmployee : Object
    {
        protected string firstName;
        protected string lastName;
        protected string socialSecurityNumber;
        protected decimal grossSales; // gross weekly sales
        protected decimal commissionRate; // commission percentage

        // five-parameter constructor
        public CommissionEmployee(string first, string last, string ssn,
           decimal sales, decimal rate)
        {
            // implicit call to object constructor occurs here
            firstName = first;
            lastName = last;
            socialSecurityNumber = ssn;
            GrossSales = sales; // validate gross sales via property
            CommissionRate = rate; // validate commission rate via property
        } // end five-parameter CommissionEmployee constructor

        // read-only property that gets commission employee's first name
       public string FirstName
        {
            get
            {
                return firstName;
            } // end get
        } // end property FirstName 
        public string LastName
        {
            get
            {
                return lastName;
            } // end get
        } // end property LastName

        // read-only property that gets 
        // commission employee's social security number
        public string SocialSecurityNumber
        {
            get
            {
                return socialSecurityNumber;
            } // end get
        } // end property SocialSecurityNumber

        // property that gets and sets commission employee's gross sales
        public decimal GrossSales
        {
            get
            {
                return grossSales;
            } // end get
            set
            {
                grossSales = (value < 0) ? 0 : value;
            } // end set
        } // end property GrossSales

        // property that gets and sets commission employee's commission rate
   public decimal CommissionRate
   {
      get
      {
         return commissionRate;
      } // end get
      set
      {
         commissionRate = ( value > 0 && value < 1 ) ? value : 0;
      } // end set
   } // end property CommissionRate

   // calculate commission employee's pay
   public  virtual decimal Earnings()
   {
      return commissionRate * grossSales;
   } // end method Earnings

   // return string representation of CommissionEmployee object
   public override string ToString()
   {
      return string.Format( 
         "{0}: {1} {2}\n{3}: {4}\n{5}: {6:C}\n{7}: {8:F2}",
         "commission employee", FirstName, LastName,
         "social security number", SocialSecurityNumber,
         "gross sales", GrossSales, "commission rate", CommissionRate );
   } // end method ToString 
        // file CommissiionEmloyee3.cs thay thế Earning() và ToString() bằng 
        // các Properties
        
         /*
         
          public virtual decimal Earnings()
    {
        return CommissionRate * GrossSales;
    } // end method Earnings

    // return string representation of CommissionEmployee object
    public override string ToString()
    {
        return string.Format(
           "{0}: {1} {2}\n{3}: {4}\n{5}: {6:C}\n{7}: {8:F2}",
           "commission employee", FirstName, LastName,
           "social security number", SocialSecurityNumber,
           "gross sales", GrossSales, "commission rate", CommissionRate);
    } // end method ToString 
         */
    } // end class CommissionEmployee
  }

