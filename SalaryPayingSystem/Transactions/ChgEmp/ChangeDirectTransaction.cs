using SalaryPayingSystem.PaymentMethods;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public class ChangeDirectTransaction(string empId, string bank, string account) : ChangeMethodTransaction(empId)
{
    protected override IPaymentMethod PaymentMethod { get; } = new DirectMethod(bank, account);
}