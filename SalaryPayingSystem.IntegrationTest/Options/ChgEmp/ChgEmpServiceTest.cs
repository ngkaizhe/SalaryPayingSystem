﻿using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Affiliations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.ChgEmp;
using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentMethods;
using SalaryPayingSystem.PaymentSchedules;
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
    
    [Fact]
    public void ChangeHourly_Always_ChangeEmployeeTypeToHourly()
    {
        const string empId = "1";
        new AddMonthlyEmployee(empId, "John", "1234", 1000).Execute();

        var newHourlyPay = 2000;
        new ChgEmpService().Execute(new ChgEmpOptions { EmpId = empId, Hourly = newHourlyPay});
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.PayClassification.Should().BeOfType<HourlyClassification>();
        var hourlyClassification = (HourlyClassification) employee.PayClassification;
        hourlyClassification.HourlyPay.Should().Be(newHourlyPay);

        var schedule = employee.PaymentSchedule;
        schedule.Should().BeOfType<WeeklySchedule>();
    }
    
    [Fact]
    public void ChangeMonthly_Always_ChangeEmployeeTypeToMonthly()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();

        var newMonthlyPay = 2000;
        new ChgEmpService().Execute(new ChgEmpOptions { EmpId = empId, Monthly = newMonthlyPay});
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.PayClassification.Should().BeOfType<MonthlyClassification>();
        var monthlyClassification = (MonthlyClassification) employee.PayClassification;
        monthlyClassification.Salary.Should().Be(newMonthlyPay);

        var schedule = employee.PaymentSchedule;
        schedule.Should().BeOfType<MonthlySchedule>();
    }
    
    [Fact]
    public void ChangeCommissioned_Always_ChangeEmployeeToCommissioned()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();

        var newMonthlyPay = 2000;
        var newCommissionedRate = 1.05;
        new ChgEmpService().Execute(new ChgEmpOptions
        {
            EmpId = empId, 
            Commissioned = new[]{ $"{newMonthlyPay}", $"{newCommissionedRate}" }
        });
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.PayClassification.Should().BeOfType<CommissionedClassification>();
        var commissionedClassification = (CommissionedClassification) employee.PayClassification;
        commissionedClassification.Salary.Should().Be(newMonthlyPay);
        commissionedClassification.CommissionRate.Should().Be(newCommissionedRate);

        var schedule = employee.PaymentSchedule;
        schedule.Should().BeOfType<BiweeklySchedule>();
    }
    
    [Fact]
    public void ChangePaymentMethod_Hold_ChangeToHoldMethod()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.PaymentMethod = new DirectMethod("bank1", "account1");

        new ChgEmpService().Execute(new ChgEmpOptions
        {
            EmpId = empId, 
            Hold = true
        });
        
        employee.PaymentMethod.Should().BeOfType<HoldMethod>();
    }
    
    [Fact]
    public void ChangePaymentMethod_Direct_ChangeToDirectMethod()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();

        var bankName = "bank1";
        var accountName = "account1";
        new ChgEmpService().Execute(new ChgEmpOptions
        {
            EmpId = empId, 
            Direct = new []{ bankName, accountName }
        });
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.PaymentMethod.Should().BeOfType<DirectMethod>();
        var method = employee.PaymentMethod as DirectMethod;
        method.Bank.Should().Be(bankName);
        method.Account.Should().Be(accountName);
    }
    
    [Fact]
    public void ChangePaymentMethod_Mail_ChangeToMailMethod()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();

        var address = "address1";
        new ChgEmpService().Execute(new ChgEmpOptions
        {
            EmpId = empId, 
            Mail = address
        });
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.PaymentMethod.Should().BeOfType<MailMethod>();
        var method = employee.PaymentMethod as MailMethod;
        method.Address.Should().Be(address);
    }
    
    [Fact]
    public void ChangeAffiliation_UnionMember_ChangeToUnionMember()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();
        
        const int memberId = 7743;
        var dues = 100;
        new ChgEmpService().Execute(new ChgEmpOptions
        {
            EmpId = empId, 
            Member = memberId,
            Dues = dues
        });
        
        var employee = PayrollDatabase.GetEmployee(empId);
        employee.Affiliation.Should().BeOfType<UnionAffiliation>();
        var affiliation = employee.Affiliation as UnionAffiliation;
        affiliation.MemberId.Should().Be(memberId);
        affiliation.Dues.Should().Be(dues);
    }
    
    [Fact]
    public void ChangeAffiliation_NoMember_ChangeToNoMember()
    {
        const string empId = "1";
        new AddHourlyEmployee(empId, "John", "1234", 1000).Execute();
        var employee = PayrollDatabase.GetEmployee(empId);
        const int memberId = 7743;
        PayrollDatabase.AddUnionMember(memberId, employee);
        
        new ChgEmpService().Execute(new ChgEmpOptions
        {
            EmpId = empId, 
            NoMember = true
        });
        
        employee.Affiliation.Should().BeOfType<NoAffiliation>();
    }
}