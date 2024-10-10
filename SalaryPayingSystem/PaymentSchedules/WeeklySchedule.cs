namespace SalaryPayingSystem.PaymentSchedules;

public class WeeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday;
    }

    public DateTime GetPayPeriodStartDate(DateTime date)
    {
        return date.AddDays(-5);
    }

    public DateTime GetPayPeriodEndDate(DateTime date)
    {
        return date;
    }
}