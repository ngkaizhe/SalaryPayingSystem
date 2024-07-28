using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Databases;

public abstract class PayrollDatabase
{
    private static readonly Dictionary<string, Employee> Employees = new Dictionary<string, Employee>();

    public static void AddEmployee(string empId, Employee employee)
    {
        Employees.Add(empId, employee);
    }

    public static Employee? GetEmployee(string empId)
    {
        Employees.TryGetValue(empId, out var employee);
        return employee;
    }

    public static void DeleteEmployee(string empId)
    {
        Employees.Remove(empId);
    }

    public static List<string> GetAllEmployeeIds()
    {
        return Employees.Keys.ToList();
    }
    
    public static void Clear()
    {
        Employees.Clear();
    }
}