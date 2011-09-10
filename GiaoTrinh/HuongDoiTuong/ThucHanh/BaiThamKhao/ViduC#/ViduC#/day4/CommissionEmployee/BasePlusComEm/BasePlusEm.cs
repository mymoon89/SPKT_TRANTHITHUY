using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasePlusComEm
{
    class BasePlusEm
    {
        private string firstName;
    private string lastName;
    private string socialSecurityNumber;
    private decimal grossSales; // gross weekly sales
    private decimal commissionRate; // commission percentage
    private decimal baseSalary; // base salary per week

    // six-parameter constructor
    public BasePlusEm(string first, string last,
       string ssn, decimal sales, decimal rate, decimal salary)
    {
        // implicit call to object constructor occurs here
        firstName = first;
        lastName = last;
        socialSecurityNumber = ssn;
        GrossSales = sales; // validate gross sales via property
        CommissionRate = rate; // validate commission rate via property
        BaseSalary = salary; // validate base salary via property
    } // end six-parameter BasePlusCommissionEmployee constructor

    // read-only property that gets 
    // base-salaried commission employee's first name
    public string FirstName
    {
        get
        {
            return firstName;
        } // end get
    } // end property FirstName
    // read-only property that gets 
    // base-salaried commission employee's last name
    public string LastName
    {
        get
        {
            return lastName;
        } // end get
    } // end property LastName

    // read-only property that gets 
    // base-salaried commission employee's social security number
    public string SocialSecurityNumber
    {
        get
        {
            return socialSecurityNumber;
        } // end get
    } // end property SocialSecurityNumber

    // property that gets and sets 
    // base-salaried commission employee's gross sales
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
    // property that gets and sets 
    // base-salaried commission employee's commission rate
    public decimal CommissionRate
    {
        get
        {
            return commissionRate;
        } // end get
        set
        {
            commissionRate = (value > 0 && value < 1) ? value : 0;
        } // end set
    } // end property CommissionRate

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
        // calculate earnings
    public decimal Earnings()
    {
        return BaseSalary + (CommissionRate * GrossSales);
    } // end method earnings

    // return string representation of BasePlusCommissionEmployee
    public override string ToString()
    {
        return string.Format(
           "{0}: {1} {2}\n{3}: {4}\n{5}: {6:C}\n{7}: {8:F2}\n{9}: {10:C}",
           "base-salaried commission employee", FirstName, LastName,
           "social security number", SocialSecurityNumber,
           "gross sales", GrossSales, "commission rate", CommissionRate,
           "base salary", BaseSalary);
    } // end method ToString
} // end class BasePlusCommissionEmployee
    }
