namespace SalaryPayingSystem.PaymentMethods;

public class MailMethod(string address) : IPaymentMethod
{
    public string Address { get; } = address;
}