using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.ChgEmp;
using SalaryPayingSystem.Transactions.AddEmp;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.ChgEmp;

[TestSubject(typeof(ChgEmpService))]
[Collection("Sequential")]
public class ChgEmpServiceTest
{
    public ChgEmpServiceTest()
    {
        PayrollDatabase.Clear();
    }

    [Fact]
    public void ChangeName_Always_ChangeEmployeeName()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();

        var newName = "JohnNewName";
        new ChgEmpService().Execute(new ChgEmpOptions { EmpId = empId, Name = newName});
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Name.Should().Be(newName);
    }
    
    [Fact]
    public void ChangeAddress_Always_ChangeEmployeeAddress()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();

        var newAddress = "taipei123";
        new ChgEmpService().Execute(new ChgEmpOptions { EmpId = empId, Address = newAddress});
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Address.Should().Be(newAddress);
    }
}