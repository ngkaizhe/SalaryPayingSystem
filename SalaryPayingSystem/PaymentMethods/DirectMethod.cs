namespace SalaryPayingSystem.PaymentMethods;

public class DirectMethod(string bank, string account) : IPaymentMethod
{
    public string Bank { get; }= bank;
    public string Account { get; } = account;
    public void Pay(double netPay)
    {
        throw new NotImplementedException();
    }
}