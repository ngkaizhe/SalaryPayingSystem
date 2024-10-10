using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.SalesReceipts;
using SalaryPayingSystem.Utils;

namespace SalaryPayingSystem.PayClassifications;

public class CommissionedClassification(double commissionRate, double salary) : IPayClassification
{
    public double Salary { get; } = salary;
    public double CommissionRate { get; } = commissionRate;
    private readonly List<SalesReceipt> _salesReceipts = [];
    
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
        var totalPay = 0.0;
        // for monthly pay
        if (payCheck.PayPeriodEndDate.IsLastDayOfMonth())
        {
            totalPay += Salary;
        }

        // for sales receipt
        if (payCheck.PayPeriodEndDate.DayOfWeek == DayOfWeek.Friday)
        {
            foreach (var salesReceipt in _salesReceipts)
            {
                if(salesReceipt.Date.IsInBetween(payCheck.PayPeriodEndDate.AddDays(-7-5), payCheck.PayPeriodEndDate.AddDays(-7)))
                {
                    totalPay += salesReceipt.Amount * CommissionRate;
                }
            }
        }

        return totalPay;
    }
}