namespace SalaryPayingSystem.Employees;

public class PayCheck(DateTime payDay)
{
    public DateTime PayDay { get; } = payDay;
    public double GrossPay;
    public double Deductions;
    public double NetPay;
}