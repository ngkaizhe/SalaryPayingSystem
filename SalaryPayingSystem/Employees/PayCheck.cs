namespace SalaryPayingSystem.Employees;

public class PayCheck(DateTime payPeriodStartDate, DateTime payPeriodEndDate)
{
    public DateTime PayPeriodStartDate { get; } = payPeriodStartDate;
    public DateTime PayPeriodEndDate { get; } = payPeriodEndDate;
    public double GrossPay;
    public double Deductions;
    public double NetPay;
}