namespace SalaryPayingSystem.Options.ServiceCharges;

public class ServiceCharge(DateTime date, double amount)
{
    public DateTime Date = date;
    public double Amount = amount;
}