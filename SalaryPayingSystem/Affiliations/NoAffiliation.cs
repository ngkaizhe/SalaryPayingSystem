using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.ServiceCharges;

namespace SalaryPayingSystem.Affiliations;

public class NoAffiliation : IAffiliation
{
    public double CalculateDeductions(PayCheck payCheck)
    {
        return 0;
    }
}