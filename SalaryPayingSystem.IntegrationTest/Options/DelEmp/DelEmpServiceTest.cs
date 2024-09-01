using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.DelEmp;
using SalaryPayingSystem.Transactions.AddEmp;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.DelEmp;

[TestSubject(typeof(DelEmpService))]
[Collection("Sequential")]
public class DelEmpServiceTest
{
    public DelEmpServiceTest()
    {
        PayrollDatabase.Clear();
    }

    [Fact]
    public void Execute_Always_DeleteEmpCorrectly()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();
        
        new DelEmpService().Execute(new DelEmpOptions { EmpId = empId });
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Should().BeNull();
    }
}