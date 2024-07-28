using SalaryPayingSystem.Transactions.DelEmp;

namespace SalaryPayingSystem.Options.DelEmp;

public class DelEmpService
{
    public int Execute(DelEmpOptions options)
    {
        var transaction = new DeleteEmployee(options.EmpId);
        transaction.Execute();
        return 0;
    }   
}