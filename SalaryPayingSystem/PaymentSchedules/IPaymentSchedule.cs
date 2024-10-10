namespace SalaryPayingSystem.PaymentSchedules;

public interface IPaymentSchedule
{
    bool IsPayDate(DateTime date);
}