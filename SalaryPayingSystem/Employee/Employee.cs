using SalaryPayingSystem.PayClassifications;

namespace SalaryPayingSystem.Employee;

public class Employee
{
    private IPayClassification _payClassification;
    private int _salary;
    private string _address;

    public Employee(int salary, string address, IPayClassification payClassification)
    {
        _salary = salary;
        _address = address;
        _payClassification = payClassification;
    }
}