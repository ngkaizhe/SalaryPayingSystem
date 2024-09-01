using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.AddEmp;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.AddEmp;
using SalaryPayingSystem.Options.TimeCards;
using SalaryPayingSystem.PayClassifications;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.TimeCards;

[TestSubject(typeof(TimeCardService))]
[Collection("Sequential")]
public class TimeCardServiceTest
{
    public TimeCardServiceTest()
    {
        PayrollDatabase.Clear();
    }

    [Fact]
    public void Execute_Always_AddTimeCardToClassification()
    {
        const string empId = "1";
        new AddEmpService().Execute(new AddEmpOptions
        {
            EmpId = empId,
            Name = "Name",
            Address = "1234",
            EmployeeType = EmployeeType.H,
            Params = new List<string> { "1000" }
        });

        var dateTime = new DateTime(2021, 1, 1);
        const int hour = 8;
        new TimeCardService().Execute(new TimeCardOptions
        {
            EmpId = empId,
            Date = dateTime,
            Hour = hour
        });
        
        var employee = PayrollDatabase.GetEmployee(empId);
        var hourlyClassification = employee.PayClassification as HourlyClassification;
        var timeCard = hourlyClassification.GetTimeCard(dateTime);
        timeCard.Should().BeEquivalentTo(new TimeCard(dateTime, hour));
    }
}