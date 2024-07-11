namespace SalaryPayingSystem.Employee;

public abstract class Employee
{
    protected Employee(string address)
    {
        _address = address;
    }

    private string _address;
    public abstract int GetTotalPay();

    public string GetAddress()
    {
        return _address;
    }
}