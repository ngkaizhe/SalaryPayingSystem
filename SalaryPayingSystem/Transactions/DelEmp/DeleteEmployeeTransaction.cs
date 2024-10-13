using SalaryPayingSystem.Databases;

namespace SalaryPayingSystem.Transactions.DelEmp;

public class DeleteEmployeeTransaction(string empId) : ITransaction
{
    public void Execute()
    {
        PayrollDatabase.DeleteEmployee(empId);
    }
}