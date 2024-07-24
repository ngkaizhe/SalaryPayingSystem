namespace SalaryPayingSystem.PayClassifications;

public class CommissionedClassification(double commissionRate, double salary) : IPayClassification
{
    public double Salary { get; } = salary;
    public double CommissionRate { get; } = commissionRate;
    private List<SalesReceipt> _salesReceipts = [];

    public double CalculatePay()
    {
        throw new NotImplementedException();
    }
}