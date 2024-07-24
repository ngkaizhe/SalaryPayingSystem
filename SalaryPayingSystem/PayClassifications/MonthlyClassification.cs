namespace SalaryPayingSystem.PayClassifications;

public class MonthlyClassification(double monthlyPay) : IPayClassification
{
    private double _monthlyPay = monthlyPay;

    public double CalculatePay()
    {
        throw new NotImplementedException();
    }
}