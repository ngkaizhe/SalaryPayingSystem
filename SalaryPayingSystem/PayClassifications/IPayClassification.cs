using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.PayClassifications;

public interface IPayClassification
{
    public double CalculatePay(PayCheck payCheck);
}