using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.TimeCards;

namespace SalaryPayingSystem.PayClassifications;

public class HourlyClassification(double hourlyPay) : IPayClassification
{
    public double HourlyPay { get; } = hourlyPay;
    private readonly List<TimeCard> _timeCards = [];

    public double CalculatePay(PayCheck payCheck)
    {
        var totalPay = 0.0;
        foreach (var timeCard in _timeCards)
        {
            if (IsInPayPeriod(timeCard.Date, payCheck.PayDay))
            {
                totalPay += CalculatePayForTimeCard(timeCard);
            }
        }

        return totalPay;
    }
    
    private bool IsInPayPeriod(DateTime timeCardDate, DateTime payCheckPayDay)
    {
        var payPeriodEndDate = payCheckPayDay.Date;
        var payPeriodStartDate = payCheckPayDay.Date.AddDays(-5);
        return timeCardDate >= payPeriodStartDate && timeCardDate <= payPeriodEndDate;
    }

    private double CalculatePayForTimeCard(TimeCard timeCard)
    {
        var overTimeHours = Math.Max(0, timeCard.Hours - 8);
        var normalHours = timeCard.Hours - overTimeHours;
        return overTimeHours * HourlyPay * 1.5 + normalHours * HourlyPay;
    }

    public TimeCard? GetTimeCard(DateTime date)
    {
        return _timeCards.FirstOrDefault(tc => tc.Date == date);
    }

    public void AddTimeCard(DateTime date, int hours)
    {
        _timeCards.Add(new TimeCard(date, hours));
    }
}