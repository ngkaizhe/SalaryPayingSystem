using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.PayClassifications;

public interface IPayClassification
{
    double CalculatePay(PayCheck payCheck);
}