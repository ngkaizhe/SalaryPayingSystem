using SalaryPayingSystem.Transactions.ChgEmp;

namespace SalaryPayingSystem.Options.ChgEmp;

public class ChgEmpService
{
    public int Execute(ChgEmpOptions options)
    {
        if(!string.IsNullOrEmpty(options.Name))
        {
            new ChangeNameTransaction(options.EmpId, options.Name).Execute();
        }
        else if (!string.IsNullOrEmpty(options.Address))
        {
            new ChangeAddressTransaction(options.EmpId, options.Address).Execute();
        }
        return 0;
    }
}