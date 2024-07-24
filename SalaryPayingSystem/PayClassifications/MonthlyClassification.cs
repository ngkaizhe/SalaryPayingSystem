namespace SalaryPayingSystem.PayClassifications;

public class MonthlyClassification(double salary) : IPayClassification
{
    public double Salary { get; } = salary;

    public double CalculatePay()
    {
        throw new NotImplementedException();
    }
}