use payroll_service


create procedure spGetAllEmployeePayroll
As 
Begin try
select * from employee_payroll
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

exec spGetAllEmployeePayroll


Create procedure spAddEmployeePayroll
(@Name varchar(250), @Salary int, @StartDate date)
As 
Begin try
insert into employee_payroll(Name,Salary,StartDate)values(@Name,@Salary,@StartDate)
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  



exec spAddEmployeePayroll
'roja',20000,'2018-04-15'

Alter procedure spUpdateEmployeePayroll
(@Name varchar(20), @BasicPay money)
As 
Begin try
update employee_payroll set BasicPay = @BasicPay where Name=@Name
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  

exec spUpdateEmployeePayroll
@BasicPay=50000, @Name='Yuva'

select * from employee_payroll

create procedure spRetrieveAllEmployeeInARange
As 
Begin try
select * from employee_payroll where id between 1 and 6
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

exec spRetrieveAllEmployeeInARange

Alter procedure spSumOfSalaryOfMaleEmployee
As 
Begin try
select SUM(Salary) As Salary from employee_payroll where Gender='M' group by Gender;
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spSumOfSalaryOfMaleEmployee


Alter procedure spGetAllemployeeAndPayroll
As 
Begin try
select * from Employee AS emp join Payroll AS payroll on emp.EmpId = payroll.EmpId where NetPay<10000
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

exec spGetAllemployeeAndPayroll