using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Transactions.Payday;

public class PaydayTransaction(DateTime payDate) : ITransaction
{
    private readonly Dictionary<string, PayCheck> _payChecks = new ();
    public void Execute()
    {
        var employeeIds = PayrollDatabase.GetAllEmployeeIds();
        foreach (var id in employeeIds)
        {
            var employee = PayrollDatabase.GetEmployee(id);
            if (employee.IsPayDate(payDate))
            {
                var payCheck = new PayCheck(payDate);
                _payChecks[id] = payCheck;
                employee.Payday(payCheck);
            }
        }
    }
    
    public PayCheck? GetPayCheck(string empId)
    {
        return _payChecks.GetValueOrDefault(empId);
    }
}