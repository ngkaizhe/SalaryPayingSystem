using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.SalesReceipts;

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
        if (IsLastDayOfMonth(payCheck.PayPeriodEndDate))
        {
            totalPay += salary;
        }

        // for sales receipt
        if (payCheck.PayPeriodEndDate.DayOfWeek == DayOfWeek.Friday)
        {
            foreach (var salesReceipt in _salesReceipts)
            {
                if(SalesReceiptIsInPayPeriod(salesReceipt.Date, payCheck.PayPeriodEndDate.AddDays(-7-5), payCheck.PayPeriodEndDate.AddDays(-7)))
                {
                    totalPay += salesReceipt.Amount * commissionRate;
                }
            }
        }

        return totalPay;
    }

    private bool SalesReceiptIsInPayPeriod(DateTime payDateTime, DateTime startDateTime, DateTime endDateTime)
    {
        return payDateTime >= startDateTime && payDateTime <= endDateTime;
    }


    private bool IsLastDayOfMonth(DateTime date)
    {
        return date.AddDays(1).Month != date.Month;
    }
}