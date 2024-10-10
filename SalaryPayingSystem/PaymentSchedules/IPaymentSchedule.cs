namespace SalaryPayingSystem.PaymentSchedules;

public interface IPaymentSchedule
{
    bool IsPayDate(DateTime date);
    
    DateTime GetPayPeriodStartDate(DateTime date);
    DateTime GetPayPeriodEndDate(DateTime date);
}