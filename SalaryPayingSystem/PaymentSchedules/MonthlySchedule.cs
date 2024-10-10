namespace SalaryPayingSystem.PaymentSchedules;

public class MonthlySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return IsLastDayOfMonth(date);
    }

    private bool IsLastDayOfMonth(DateTime date)
    {
        return date.AddDays(1).Month != date.Month;
    }
}