namespace SalaryPayingSystem.PayClassifications;

public class SalesReceipt(DateTime date, double amount)
{
    public DateTime Date = date;
    public readonly double Amount = amount;
}