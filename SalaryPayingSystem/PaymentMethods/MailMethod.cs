namespace SalaryPayingSystem.PaymentMethods;

public class MailMethod(string address) : IPaymentMethod
{
    public string Address { get; } = address;
    public void Pay(double netPay)
    {
        throw new NotImplementedException();
    }
}