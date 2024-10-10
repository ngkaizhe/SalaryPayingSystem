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
        else if (options.Hourly.HasValue)
        {
            new ChangeHourlyTransaction(options.EmpId, options.Hourly.Value).Execute();
        }
        else if (options.Monthly.HasValue)
        {
            new ChangeMonthlyTransaction(options.EmpId, options.Monthly.Value).Execute();
        }
        else if (options.Commissioned != null && options.Commissioned.Any())
        {
            var parameters = options.Commissioned.ToList();
            
            new ChangeCommissionTransaction(options.EmpId, double.Parse(parameters[0]), double.Parse(parameters[1])).Execute();        
        }
        else if (options.Hold)
        {
            new ChangeHoldTransaction(options.EmpId).Execute();        
        }
        else if (options.Direct != null && options.Direct.Any())
        {
            var parameters = options.Direct.ToList();
            
            new ChangeDirectTransaction(options.EmpId, parameters[0], parameters[1]).Execute();        
        }
        else if (!string.IsNullOrEmpty(options.Mail))
        {
            new ChangeMailTransaction(options.EmpId, options.Mail).Execute();        
        }
        else
        {
            return 1;
        }
        return 0;
    }
}