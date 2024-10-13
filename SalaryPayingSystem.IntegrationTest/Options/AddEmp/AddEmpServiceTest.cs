using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.AddEmp;
using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentMethods;
using SalaryPayingSystem.PaymentSchedules;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.AddEmp;

[TestSubject(typeof(AddEmpService))]
[Collection("Sequential")]
public class AddEmpServiceTest
{
    public AddEmpServiceTest()
    {
        PayrollDatabase.Clear();
    }
    
    [Fact]
    public void AddEmployee_Hourly_DatabaseHaveHourlyEmployee()
    {
        const string empId = "1";
        const string name = "John";
        const int salary = 1000;
        var service = new AddEmpService();
        var options = new AddEmpOptions
        {
            EmpId = empId,
            Name = name,
            Address = "1234",
            EmployeeType = EmployeeType.H,
            Params = new List<string> { salary.ToString() }
        };
        
        service.Execute(options);
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Should().NotBeNull();
        employee.Name.Should().Be(name);

        var classification = employee.PayClassification;
        classification.Should().BeOfType<HourlyClassification>();
        var hourlyClassification = (HourlyClassification) classification;
        hourlyClassification.HourlyPay.Should().Be(salary);

        var schedule = employee.PaymentSchedule;
        schedule.Should().BeOfType<WeeklySchedule>();
        
        var method = employee.PaymentMethod;
        method.Should().BeOfType<HoldMethod>();
    }

    [Fact]
    public void AddEmployee_Monthly_DatabaseHaveMonthlyEmployee()
    {
        const string empId = "1";
        const string name = "John";
        const int salary = 1000;
        var service = new AddEmpService();
        var options = new AddEmpOptions
        {
            EmpId = empId,
            Name = name,
            Address = "1234",
            EmployeeType = EmployeeType.S,
            Params = new List<string> { salary.ToString() }
        };
        
        service.Execute(options);
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Should().NotBeNull();
        employee.Name.Should().Be(name);

        var classification = employee.PayClassification;
        classification.Should().BeOfType<MonthlyClassification>();
        var monthlyClassification = (MonthlyClassification) classification;
        monthlyClassification.Salary.Should().Be(salary);

        var schedule = employee.PaymentSchedule;
        schedule.Should().BeOfType<MonthlySchedule>();
        
        var method = employee.PaymentMethod;
        method.Should().BeOfType<HoldMethod>();
    }
    
    [Fact]
    public void AddEmployee_Commissioned_DatabaseHaveCommissionedEmployee()
    {
        const string empId = "1";
        const string name = "John";
        const int salary = 1000;
        const double commissionRate = 0.3;
        var service = new AddEmpService();
        var options = new AddEmpOptions
        {
            EmpId = empId,
            Name = name,
            Address = "1234",
            EmployeeType = EmployeeType.C,
            Params = new List<string> { salary.ToString(), commissionRate.ToString(CultureInfo.CurrentCulture) }
        };
        
        service.Execute(options);
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Should().NotBeNull();
        employee.Name.Should().Be(name);

        var classification = employee.PayClassification;
        classification.Should().BeOfType<CommissionedClassification>();
        var commissionedClassification = (CommissionedClassification) classification;
        commissionedClassification.Salary.Should().Be(salary);
        commissionedClassification.CommissionRate.Should().Be(commissionRate);

        var schedule = employee.PaymentSchedule;
        schedule.Should().BeOfType<BiweeklySchedule>();
        
        var method = employee.PaymentMethod;
        method.Should().BeOfType<HoldMethod>();
    }
}