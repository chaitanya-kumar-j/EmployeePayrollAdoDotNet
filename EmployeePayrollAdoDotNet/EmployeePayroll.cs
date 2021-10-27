using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayrollAdoDotNet
{
    public class EmployeePayroll
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool DataBaseConnection()
        {
            try
            {
                connection.Open();
                using (connection)
                {
                    Console.WriteLine($"Connection is created Successful");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        public DataSet GetAllEmployee()
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("spGetAllEmployeePayroll", this.connection);
                    adapter.Fill(dataSet, "employee_payroll");
                    Console.WriteLine($"EmpId   Name    Salary  StartDate   Gender  PhoneNumber Address Department  BasicPay    Deduction   TaxablePay  Tax NetPay");
                    foreach (DataRow row in dataSet.Tables["employee_payroll"].Rows)
                    {
                        Console.WriteLine($"{row["EmpId"]}   {row["Name"]}    {row["Salary"]}  {row["StartDate"]}   {row["Gender"]}  " +
                            $"{row["PhoneNumber"]} {row["Address"]} {row["Department"]}  {row["BasicPay"]}    " +
                            $"{row["Deduction"]}   {row["TaxablePay"]}  {row["Tax"]} {row["NetPay"]}");
                    }
                    this.connection.Close();
                }
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool AddEmployee(EmployeeModel obj)
        {
            try
            {
                using (connection)
                {
                    SqlCommand com = new SqlCommand("spAddEmployeePayroll", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Name", obj.Name);
                    com.Parameters.AddWithValue("@Salary", obj.Salary);
                    com.Parameters.AddWithValue("@StartDate", obj.StartDate);
                    connection.Open();
                    var result = com.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool UpdateEmployee(double BasicPay, string Name)
        {
            try
            {
                using (connection)
                {
                    SqlCommand com = new SqlCommand("spUpdateEmployeePayroll", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Name", Name);
                    com.Parameters.AddWithValue("@BasicPay", BasicPay);
                    connection.Open();
                    var result = com.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataSet RetrieveAllEmployeeInARange()
        {
            try
            {
                DataSet dataSet = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("RetrieveAllEmployeeInARange", this.connection);
                    adapter.Fill(dataSet, "employee_payroll");
                    foreach (DataRow row in dataSet.Tables["employee_payroll"].Rows)
                    {
                        Console.WriteLine($"{row["EmpId"]}   {row["Name"]}    {row["Salary"]}  {row["StartDate"]}   {row["Gender"]}  " +
                            $"{row["PhoneNumber"]} {row["Address"]} {row["Department"]}  {row["BasicPay"]}    " +
                            $"{row["Deduction"]}   {row["TaxablePay"]}  {row["Tax"]} {row["NetPay"]}");
                    }
                    this.connection.Close();
                }
                return dataSet;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public DataSet RetrieveAllEmployeeDeatilsUsingJoins()
        {
            try
            {
                DataSet dataSets = new DataSet();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("spGetAllemployeeAndPayroll", this.connection);
                    adapter.Fill(dataSets, "Employee");
                    foreach (DataRow row in dataSets.Tables["Employee"].Rows)
                    {
                        Console.WriteLine($"{row["EmpId"]}   {row["Name"]}    {row["Salary"]}  {row["StartDate"]}   {row["Gender"]}  " +
                             $"{row["PhoneNumber"]} {row["Address"]} {row["Department"]}  {row["BasicPay"]}    " +
                             $"{row["Deduction"]}   {row["TaxablePay"]}  {row["Tax"]} {row["NetPay"]}");
                    }
                    this.connection.Close();
                }
                return dataSets;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
