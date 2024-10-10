using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.SalesReceipts;

namespace SalaryPayingSystem.PayClassifications;

public class CommissionedClassification(double commissionRate, double salary) : IPayClassification
{
    public double Salary { get; } = salary;
    public double CommissionRate { get; } = commissionRate;
    private List<SalesReceipt> _salesReceipts = [];
    
    public SalesReceipt? GetSalesReceipt(DateTime date)
    {
        return _salesReceipts.FirstOrDefault(sr => sr.Date == date);
    }

    public void AddSalesReceipt(DateTime date, double amount)
    {
        _salesReceipts.Add(new SalesReceipt(date, amount));
    }

    public double CalculatePay(PayCheck payCheck)
    {
        throw new NotImplementedException();
    }
}