using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Transactions.Payday;

namespace SalaryPayingSystem.Options.Payday;

public class PaydayService
{
    private PaydayTransaction? _tmpPaydayTransaction;
    public int Execute(PaydayOptions paydayOptions)
    {
        _tmpPaydayTransaction = new PaydayTransaction(paydayOptions.Date);
        _tmpPaydayTransaction.Execute();
        return 0;
    }
    
    public PayCheck? GetPayCheck(string empId)
    {
        return _tmpPaydayTransaction?.GetPayCheck(empId);
    }
}