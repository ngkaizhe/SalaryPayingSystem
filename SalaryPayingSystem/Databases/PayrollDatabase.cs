using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Databases;

public abstract class PayrollDatabase
{
    private static readonly Dictionary<string, Employee> Employees = new ();
    private static readonly Dictionary<string, Employee> UnionMembers = new ();
    
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
    
    public static void AddUnionMember(string memberId, Employee employee)
    {
        UnionMembers.Add(memberId, employee);
    }
    
    public static Employee? GetUnionMember(string memberId)
    {
        UnionMembers.TryGetValue(memberId, out var employee);
        return employee;
    }
    
    public static void Clear()
    {
        Employees.Clear();
        UnionMembers.Clear();
    }
}