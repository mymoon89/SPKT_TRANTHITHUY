using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayListsEx
{
    class Employee
    {
        public Employee(int empID)
{
        this.empID = empID;
}
        public override string ToString()
{
        return empID.ToString();
}
    public int EmpID
{
    get
    {
        return empID;
    }
    set
    {
        empID = value;
    }
}
    private int empID;
    }
}
