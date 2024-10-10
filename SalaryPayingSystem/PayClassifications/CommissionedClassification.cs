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
        if (IsLastDayOfMonth(payCheck.PayDay))
        {
            totalPay += salary;
        }

        // for sales receipt
        if (payCheck.PayDay.DayOfWeek == DayOfWeek.Friday)
        {
            foreach (var salesReceipt in _salesReceipts)
            {
                var previousWeekStart = payCheck.PayDay.AddDays(-7-5);
                var previousWeekEnd = payCheck.PayDay.AddDays(-7);
                if(salesReceipt.Date >= previousWeekStart && salesReceipt.Date <= previousWeekEnd)
                {
                    totalPay += salesReceipt.Amount * commissionRate;
                }
            }
        }

        return totalPay;
    }
    
    private bool IsLastDayOfMonth(DateTime date)
    {
        return date.AddDays(1).Month != date.Month;
    }
}