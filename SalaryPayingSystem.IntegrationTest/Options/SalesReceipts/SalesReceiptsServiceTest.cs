using System;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.SalesReceipts;
using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.Transactions.AddEmp;
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
    public void AddSalesReceipts_Always_AddSalesReceiptsToClassification()
    {
        const string empId = "1";
        new AddCommissionedEmployee(empId, "John", "1234", 1000, 1.5).Execute();;

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