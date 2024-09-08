using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Transactions;
using SalaryPayingSystem.Transactions.AddEmp;

namespace SalaryPayingSystem.Options.AddEmp;

public class AddEmpService
{
    public int Execute(AddEmpOptions options)
    {
        var parameters = options.Params.ToList();
        ITransaction transaction;
        switch (options.EmployeeType)
        {
            case EmployeeType.H:
            {
                transaction = new AddHourlyEmployee(options.EmpId, options.Name, options.Address, double.Parse(parameters[0]));
                transaction.Execute();
                break;
            }
            case EmployeeType.S:
            {
                transaction = new AddMonthlyEmployee(options.EmpId, options.Name, options.Address, double.Parse(parameters[0]));
                transaction.Execute();
                break;
            }
            case EmployeeType.C:
            {
                transaction = new AddCommissionedEmployee(options.EmpId, options.Name, options.Address, double.Parse(parameters[0]), double.Parse(parameters[1]));
                transaction.Execute();
                break;
            }
            default:
            { 
                Console.WriteLine("Invalid employee type");
                break;
            }
        }

        return 0;
    }
}