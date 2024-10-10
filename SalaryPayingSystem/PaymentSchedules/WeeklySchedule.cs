namespace SalaryPayingSystem.PaymentSchedules;

public class WeeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday;
    }
}