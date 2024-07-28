using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.AddEmp;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.AddEmp;
using SalaryPayingSystem.Options.DelEmp;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.DelEmp;

[TestSubject(typeof(DelEmpService))]
public class DelEmpServiceTest
{

    [Fact]
    public void Execute_Always_DeleteEmpCorrectly()
    {
        const string empId = "4";
        new AddEmpService().Execute(new AddEmpOptions
        {
            EmpId = empId,
            Name = "John",
            Address = "1234",
            EmployeeType = EmployeeType.H,
            Params = new[] { "1000" }
        });
        var service = new DelEmpService();
        
        service.Execute(new DelEmpOptions { EmpId = empId });
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Should().BeNull();
    }
}