using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollAdoDotNet
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string StartDate { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public int Department { get; set; }
        public string Address { get; set; }
        public double BasicPay { get; set; }
        public double Deduction { get; set; }
        public double TaxablePay { get; set; }
        public double Tax { get; set; }
        public double NetPay { get; set; }
    }
}
