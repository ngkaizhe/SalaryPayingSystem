using System;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.TimeCards;
using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.Transactions.AddEmp;
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
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();

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