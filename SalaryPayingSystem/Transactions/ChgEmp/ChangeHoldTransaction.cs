using SalaryPayingSystem.PaymentMethods;

namespace SalaryPayingSystem.Transactions.ChgEmp;

class ChangeHoldTransaction(string empId) : ChangeMethodTransaction(empId)
{
    protected override IPaymentMethod PaymentMethod { get; } = new HoldMethod();
}