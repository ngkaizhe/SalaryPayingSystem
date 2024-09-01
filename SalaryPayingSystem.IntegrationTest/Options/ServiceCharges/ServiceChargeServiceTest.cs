using System;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.ServiceCharges;
using SalaryPayingSystem.Transactions.AddEmp;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.ServiceCharges;

[TestSubject(typeof(ServiceChargeService))]
[Collection("Sequential")]
public class ServiceChargeServiceTest
{
    public ServiceChargeServiceTest()
    {
        PayrollDatabase.Clear();
    }

    [Fact]
    public void Execute_Always_AddServiceChargeToEmployee()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();
        var employee = PayrollDatabase.GetEmployee(empId);
        var employeeAffiliation = new UnionAffiliation();
        employee.Affiliation = employeeAffiliation;
        const string memberId = "1_1";
        PayrollDatabase.AddUnionMember(memberId, employee);

        var dateTime = new DateTime(2021,1,1);
        var amount = 100;
        new ServiceChargeService().Execute(new ServiceChargeOptions
        {
            MemberId = memberId,
            Date = dateTime,
            Amount = amount
        });

        var serviceCharge = employeeAffiliation.GetServiceCharge(dateTime);
        serviceCharge.Should().BeEquivalentTo(new ServiceCharge(dateTime, amount));
    }
}