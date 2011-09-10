using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vidu91Page216
{
     class Employee
    {
        // bộ khởi tạo lấy một tham số
        public Employee(int empID)
        {
            this.empID = empID;
        }
        public void Display() { }
        public override string ToString()
        {
            return empID.ToString();
        }
        // biến thành viên private
        private int empID;
        private int size;
    }
}
