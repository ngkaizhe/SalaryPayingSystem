using System;
using FluentAssertions;
using JetBrains.Annotations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.Payday;
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

        ValidateHourlyPayCheck(paydayService, empId, payDate, 0);
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

        ValidateHourlyPayCheck(paydayService, empId, friday, totalHourInWork * hourlyPay);
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

        ValidateHourlyPayCheck(paydayService, empId, friday, (8 + 1.5) * hourlyPay);
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

        ValidateHourlyPayCheck(paydayService, empId, friday, 7 * hourlyPay);
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

        ValidateHourlyPayCheck(paydayService, empId, friday, 2 * hourlyPay);
    }

    private static void ValidateHourlyPayCheck(PaydayService paydayService, string empId, DateTime payDate, double pay)
    {
        var payCheck = paydayService.GetPayCheck(empId);
        payCheck.PayDay.Should().Be(payDate);
        payCheck.GrossPay.Should().Be(pay);
        payCheck.Deductions.Should().Be(0);
        payCheck.NetPay.Should().Be(pay);
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
}