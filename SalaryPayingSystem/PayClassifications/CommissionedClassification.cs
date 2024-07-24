namespace SalaryPayingSystem.PayClassifications;

public class CommissionedClassification(double commissionRate, double basePay) : IPayClassification
{
    private double _basePay = basePay;
    private double _commissionRate = commissionRate;
    private List<SalesReceipt> _salesReceipts = [];

    public double CalculatePay()
    {
        throw new NotImplementedException();
    }
}