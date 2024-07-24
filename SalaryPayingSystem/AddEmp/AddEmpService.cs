using SalaryPayingSystem.Employee;

namespace SalaryPayingSystem.AddEmp;

public class AddEmpService
{
    public int Execute(AddEmpOptions options)
    {
        var parameters = options.Params.ToList();
        switch (options.EmployeeType)
        {
            case EmployeeType.H:
            {
                int.TryParse(parameters[0], out var salary);
                var employee = new HourlyEmployee(salary, options.Address);
                break;
            }
            case EmployeeType.S:
            {
                int.TryParse(parameters[0], out var salary);
                var employee = new MonthlyEmployee(salary, 0, options.Address);
                break;
            }
            default:
            {
                if (options.EmployeeType is EmployeeType.S)
                {
                    int.TryParse(parameters[0], out var salary);
                    int.TryParse(parameters[1], out var commissionRate);
                    var employee = new MonthlyEmployee(salary, commissionRate, options.Address);
                }
                else
                {
                    Console.WriteLine("Invalid employee type");
                }

                break;
            }
        }

        return 0;
    }
}