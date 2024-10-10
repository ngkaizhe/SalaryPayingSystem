namespace SalaryPayingSystem.PaymentMethods;

public interface IPaymentMethod
{
    void Pay(double netPay);
}