using SalaryPayingSystem.Databases;

namespace SalaryPayingSystem.Transactions.DelEmp;

public class DeleteEmployee(string empId) : ITransaction
{
    public void Execute()
    {
        PayrollDatabase.DeleteEmployee(empId);
    }
}