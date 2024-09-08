using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public abstract class ChangeEmployeeTransaction(string empId): ITransaction
{
    public void Execute()
    {
        var employee = PayrollDatabase.GetEmployee(empId);

        if (employee != null)
        {
            Change(employee);
        }
        else
        {
            throw new InvalidOperationException("No such employee.");
        }
    }

    protected abstract void Change(Employee employee);
}