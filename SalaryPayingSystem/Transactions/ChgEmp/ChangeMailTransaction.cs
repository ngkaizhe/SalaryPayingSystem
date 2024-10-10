using SalaryPayingSystem.PaymentMethods;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public class ChangeMailTransaction(string empId, string address) : ChangeMethodTransaction(empId)
{
    protected override IPaymentMethod PaymentMethod { get; } = new MailMethod(address);
}