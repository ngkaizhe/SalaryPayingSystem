using SalaryPayingSystem.Utils;

namespace SalaryPayingSystem.PaymentSchedules;

public class MonthlySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return date.IsLastDayOfMonth();
    }
    
    public DateTime GetPayPeriodStartDate(DateTime date)
    {
        return date.AddMonths(-1).AddDays(1);
    }

    public DateTime GetPayPeriodEndDate(DateTime date)
    {
        return date;
    }
}