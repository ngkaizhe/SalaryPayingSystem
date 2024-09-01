namespace SalaryPayingSystem.Options.SalesReceipts;

public class SalesReceipt(DateTime date, double amount)
{
    public DateTime Date = date;
    public double Amount = amount;
}