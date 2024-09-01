﻿using System;
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
    public void Execute_Always_AddSalesReceiptsToClassification()
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