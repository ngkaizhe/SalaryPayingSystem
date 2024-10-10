using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Databases;

public abstract class PayrollDatabase
{
    private static readonly Dictionary<string, Employee> Employees = new ();
    private static readonly Dictionary<int, Employee> UnionMembers = new ();
    
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
    
    public static void AddUnionMember(int memberId, Employee employee)
    {
        UnionMembers.Add(memberId, employee);
    }
    
    public static Employee? GetUnionMember(int memberId)
    {
        UnionMembers.TryGetValue(memberId, out var employee);
        return employee;
    }
    
    public static void Clear()
    {
        Employees.Clear();
        UnionMembers.Clear();
    }

    public static void RemoveUnionMember(int memberId)
    {
        UnionMembers.Remove(memberId);
    }
}