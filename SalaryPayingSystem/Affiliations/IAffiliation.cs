using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Affiliations;

public interface IAffiliation
{
    double CalculateDeductions(PayCheck payCheck);
}