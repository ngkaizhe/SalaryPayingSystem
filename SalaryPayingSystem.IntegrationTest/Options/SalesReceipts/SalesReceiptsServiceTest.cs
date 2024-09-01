using System;
using System.Collections.Generic;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.AddEmp;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.AddEmp;
using SalaryPayingSystem.Options.SalesReceipts;
using SalaryPayingSystem.Options.TimeCards;
using SalaryPayingSystem.PayClassifications;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.SalesReceipts;

[TestSubject(typeof(SalesReceiptService))]
[Collection("Sequential")]
public class SalesReceiptsServiceTest
{
    public SalesReceiptsServiceTest()
    {
        PayrollDatabase.Clear();
    }
    
    [Fact]
    public void Execute_Always_AddSalesReceiptsToClassification()
    {
        const string empId = "1";
        new AddEmpService().Execute(new AddEmpOptions
        {
            EmpId = empId,
            Name = "Name",
            Address = "1234",
            EmployeeType = EmployeeType.C,
            Params = new List<string> { "1000", "1.5" }
        });

        var dateTime = new DateTime(2021, 1, 1);
        var amount = 1000.0;
        new SalesReceiptService().Execute(new SalesReceiptOptions
        {
            EmpId = empId,
            Amount = amount,
            Date = dateTime,
        });
        
        
        var employee = PayrollDatabase.GetEmployee(empId);
        var commissionedClassification = employee.PayClassification as CommissionedClassification;
        var salesReceipt = commissionedClassification.GetSalesReceipt(dateTime);
        salesReceipt.Should().BeEquivalentTo(new SalesReceipt(dateTime, amount));
    }
}