namespace SalaryPayingSystem.Employee;

public sealed class MonthlyEmployee
{
    private int _salary;
    private int _commissionRate;
    private string _address;

    public MonthlyEmployee(int salary, int commissionRate, string address)
    {
        _salary = salary;
        _commissionRate = commissionRate;
        _address = address;
    }

    public int GetTotalPay()
    {
        return _salary + GetTotalCommission();
    }

    private int GetTotalCommission()
    {
        return 0;
    }
}