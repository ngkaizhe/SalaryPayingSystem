namespace SalaryPayingSystem.Employee;

public sealed class MonthlyEmployee : Employee
{
    private int _salary;
    private int _commissionRate;

    public MonthlyEmployee(int salary, int commissionRate, string address): base(address)
    {
        _salary = salary;
        _commissionRate = commissionRate;
    }

    public override int GetTotalPay()
    {
        return _salary + GetTotalCommission();
    }

    private int GetTotalCommission()
    {
        return 0;
    }
}