namespace SalaryPayingSystem.PaymentSchedules;

public class MonthlySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return IsLastDayOfMonth(date);
    }
    
    public DateTime GetPayPeriodStartDate(DateTime date)
    {
        return date.AddMonths(-1).AddDays(1);
    }

    public DateTime GetPayPeriodEndDate(DateTime date)
    {
        return date;
    }

    private bool IsLastDayOfMonth(DateTime date)
    {
        return date.AddDays(1).Month != date.Month;
    }
}