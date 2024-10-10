namespace SalaryPayingSystem.PaymentSchedules;

public class BiweeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday || IsLastDayOfMonth(date);;
    }

    private bool IsLastDayOfMonth(DateTime date)
    {
        return date.AddDays(1).Month != date.Month;
    }
}