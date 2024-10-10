namespace SalaryPayingSystem.PaymentSchedules;

public class BiweeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        // sales receipt pay check and monthly pay check
        return date.DayOfWeek == DayOfWeek.Friday || IsLastDayOfMonth(date);;
    }
    
    public DateTime GetPayPeriodStartDate(DateTime date)
    {
        return date.AddDays(-5);
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