namespace SalaryPayingSystem.Employee;

public class HourlyEmployee: Employee
{
    private int _salary;

    public HourlyEmployee(int salary, string address): base(address)
    {
        _salary = salary;
    }

    public override int GetTotalPay()
    {
        return _salary;
    }
}