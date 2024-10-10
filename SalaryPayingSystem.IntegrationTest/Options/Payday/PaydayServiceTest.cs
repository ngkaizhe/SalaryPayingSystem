using System;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.Payday;
using SalaryPayingSystem.Options.SalesReceipts;
using SalaryPayingSystem.Options.TimeCards;
using SalaryPayingSystem.Transactions.AddEmp;
using SalaryPayingSystem.Transactions.Payday;
using Xunit;

namespace SalaryPayingSystem.IntegrationTest.Options.Payday;

[TestSubject(typeof(PaydayService))]
[Collection("Sequential")]
public class PaydayServiceTest
{

    public PaydayServiceTest()
    {
        PayrollDatabase.Clear();
    }
    
    [Fact]
    public void PaySingleMonthlyEmployee_NotLastDateOfMonth_PayCheckIsNull()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const int monthlySalary = 1000;
        new AddMonthlyEmployee(empId, name , address, monthlySalary).Execute();

        var payDate = new DateTime(2001, 11, 15);
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = payDate
        });

        var payCheck = paydayService.GetPayCheck(empId);
        payCheck.Should().BeNull();
    }

    [Fact]
    public void PaySingleMonthlyEmployee_LastDateOfMonth_PayCheckWithCorrectInformation()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const int monthlySalary = 1000;
        new AddMonthlyEmployee(empId, name , address, monthlySalary).Execute();

        var payDate = new DateTime(2001, 11, 30);
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = payDate
        });

        var payCheck = paydayService.GetPayCheck(empId);
        payCheck.PayDay.Should().Be(payDate);
        payCheck.GrossPay.Should().Be(monthlySalary);
        payCheck.Deductions.Should().Be(0);
        payCheck.NetPay.Should().Be(monthlySalary);
    }
    
    [Fact]
    public void PaySingleMonthlyEmployee_NotFriday_PayCheckIsNull()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double hourlyPay = 15.25;
        new AddHourlyEmployee(empId, name , address, hourlyPay).Execute();

        var thursday = new DateTime(2001, 11, 8);
        new TimeCardService().Execute(new TimeCardOptions()
        {
            EmpId = empId,
            Date = thursday,
            Hour = 9
        });
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = thursday
        });

        var payCheck = paydayService.GetPayCheck(empId);
        payCheck.Should().BeNull();
    }
    
    [Fact]
    public void PaySingleHourlyEmployee_NoTimeCard_PayCheckIsNull()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const int hourlyPay = 100;
        new AddHourlyEmployee(empId, name , address, hourlyPay).Execute();

        var payDate = new DateTime(2001, 11, 9);
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = payDate
        });

        ValidatePayCheck(paydayService, empId, payDate, 0);
    }
    
    [Fact]
    public void PaySingleHourlyEmployee_OneTimeCardAndFriday_PayCheckHasCorrectInformation()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double hourlyPay = 15.25;
        new AddHourlyEmployee(empId, name , address, hourlyPay).Execute();

        var friday = new DateTime(2001, 11, 9);
        var totalHourInWork = 2;
        new TimeCardService().Execute(new TimeCardOptions()
        {
            EmpId = empId,
            Date = friday,
            Hour = totalHourInWork
        });
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = friday
        });

        ValidatePayCheck(paydayService, empId, friday, totalHourInWork * hourlyPay);
    }
    
    [Fact]
    public void PaySingleHourlyEmployee_OneTimeCardWithOvertime_PayCheckHasCorrectInformation()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double hourlyPay = 15.25;
        new AddHourlyEmployee(empId, name , address, hourlyPay).Execute();

        var friday = new DateTime(2001, 11, 9);
        new TimeCardService().Execute(new TimeCardOptions()
        {
            EmpId = empId,
            Date = friday,
            Hour = 9
        });
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = friday
        });

        ValidatePayCheck(paydayService, empId, friday, (8 + 1.5) * hourlyPay);
    }
    
    [Fact]
    public void PaySingleHourlyEmployee_MultipleTimeCard_PayCheckHasCorrectInformation()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double hourlyPay = 15.25;
        new AddHourlyEmployee(empId, name , address, hourlyPay).Execute();

        var friday = new DateTime(2001, 11, 9);
        new TimeCardService().Execute(new TimeCardOptions()
        {
            EmpId = empId,
            Date = friday,
            Hour = 2
        });
        new TimeCardService().Execute(new TimeCardOptions()
        {
            EmpId = empId,
            Date = friday.AddDays(-1),
            Hour = 5
        });
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = friday
        });

        ValidatePayCheck(paydayService, empId, friday, 7 * hourlyPay);
    }
    
    [Fact]
    public void PaySingleHourlyEmployee_TimeCardsSpanningTwoDayPeriod_PayCheckOnlyPayCurrentDayPeriod()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double hourlyPay = 15.25;
        new AddHourlyEmployee(empId, name , address, hourlyPay).Execute();

        var friday = new DateTime(2001, 11, 9);
        new TimeCardService().Execute(new TimeCardOptions()
        {
            EmpId = empId,
            Date = friday,
            Hour = 2
        });
        var previousDayPeriod = friday.AddDays(-7);
        new TimeCardService().Execute(new TimeCardOptions()
        {
            EmpId = empId,
            Date = previousDayPeriod,
            Hour = 5
        });
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = friday
        });

        ValidatePayCheck(paydayService, empId, friday, 2 * hourlyPay);
    }
    
    [Fact]
    public void PayCommissionedEmployee_NotLastDayOfMonth_PayCheckIsNull()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double monthlyPay = 1500.25;
        const double commissionRate = 0.1;
        new AddCommissionedEmployee(empId, name , address, monthlyPay, commissionRate).Execute();

        var notLastDayOfMonth = new DateTime(2001, 11, 15);
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = notLastDayOfMonth
        });

        var payCheck = paydayService.GetPayCheck(empId);
        payCheck.Should().BeNull();
    }
    
    [Fact]
    public void PayCommissionedEmployee_LastDayOfMonth_PayCheckHasCorrectInformation()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double monthlyPay = 1500.25;
        const double commissionRate = 0.1;
        new AddCommissionedEmployee(empId, name , address, monthlyPay, commissionRate).Execute();

        var payDate = new DateTime(2001, 11, 30);
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = payDate
        });

        ValidatePayCheck(paydayService, empId, payDate, monthlyPay);
    }
    
    [Fact]
    public void PayCommissionedEmployee_MultipleSalesReceiptsAndFriday_PayCheckHasCorrectInformation()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double monthlyPay = 1500.25;
        const double commissionRate = 0.1;
        new AddCommissionedEmployee(empId, name , address, monthlyPay, commissionRate).Execute();

        var friday = new DateTime(2001, 11, 9);
        const int salesReceiptAmount1 = 100;
        new SalesReceiptService().Execute(new SalesReceiptOptions()
        {
            EmpId = empId,
            Date = friday.AddDays(-7),
            Amount = salesReceiptAmount1
        });
        const int salesReceiptAmount2 = 200;
        new SalesReceiptService().Execute(new SalesReceiptOptions()
        {
            EmpId = empId,
            Date = friday.AddDays(-7),
            Amount = salesReceiptAmount2
        });
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = friday
        });

        ValidatePayCheck(paydayService, empId, friday,
            salesReceiptAmount1 * commissionRate + salesReceiptAmount2 * commissionRate);
    }
    
    [Fact]
    public void PayCommissionedEmployee_SalesReceiptsTwoWeekPeriod_PayCheckOnlyPayPastWeekPeriod()
    {
        const string empId = "1";
        const string name = "John";
        const string address = "address1";
        const double monthlyPay = 1500.25;
        const double commissionRate = 0.1;
        new AddCommissionedEmployee(empId, name , address, monthlyPay, commissionRate).Execute();

        var payDate = new DateTime(2001, 11, 9);
        const int salesReceiptAmount1 = 100;
        var previousWeek = payDate.AddDays(-7);
        new SalesReceiptService().Execute(new SalesReceiptOptions()
        {
            EmpId = empId,
            Date = previousWeek,
            Amount = salesReceiptAmount1
        });
        new SalesReceiptService().Execute(new SalesReceiptOptions()
        {
            EmpId = empId,
            Date = payDate,
            Amount = 200
        });
        var paydayService = new PaydayService();
        paydayService.Execute(new PaydayOptions()
        {
            Date = payDate
        });

        ValidatePayCheck(paydayService, empId, payDate,  salesReceiptAmount1 * commissionRate);
    }

    private static void ValidatePayCheck(PaydayService paydayService, string empId, DateTime payDate, double pay)
    {
        var payCheck = paydayService.GetPayCheck(empId);
        payCheck.PayDay.Should().Be(payDate);
        payCheck.GrossPay.Should().Be(pay);
        payCheck.Deductions.Should().Be(0);
        payCheck.NetPay.Should().Be(pay);
    }
}