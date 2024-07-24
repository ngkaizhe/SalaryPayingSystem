namespace SalaryPayingSystem.Employee;

public class HourlyEmployee
{
    private int _salary;
    private string _address;

    public HourlyEmployee(int salary, string address)
    {
        _salary = salary;
        _address = address;
    }

    public int GetTotalPay()
    {
        return _salary;
    }
}