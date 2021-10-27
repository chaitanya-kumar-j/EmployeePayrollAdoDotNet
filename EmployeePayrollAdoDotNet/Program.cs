using System;

namespace EmployeePayrollAdoDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRun = true;
            EmployeePayroll employeePayroll = new EmployeePayroll();
            while (isRun)
            {
                Console.WriteLine("Select and enter the query number:\n1.GetAllEmployeeDetails\n 2.AddEmployeeDetails\n" +
                    " 3.UpdateEmployeeDetails\n 4.RetrieveAllEmployeeForParticularRange\n" +
                    "5.Retrieve Sal from Employee and Payroll using joins");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        employeePayroll.GetAllEmployee();
                        break;
                    case 2:
                        EmployeeModel employee = new EmployeeModel();
                        employee.Name = "Ravi";
                        employee.Salary = 70000;
                        employee.StartDate = "2021-04-08";
                        employeePayroll.AddEmployee(employee);
                        break;
                    case 3:
                        employeePayroll.UpdateEmployee(50000, "Joe");
                        break;
                    case 4:
                        employeePayroll.RetrieveAllEmployeeInARange();
                        break;
                    case 5:
                        employeePayroll.RetrieveAllEmployeeDeatilsUsingJoins();
                        break;
                    default:
                        Console.WriteLine("enter valid option");
                        break;
                }
            }
        }
    }
}
