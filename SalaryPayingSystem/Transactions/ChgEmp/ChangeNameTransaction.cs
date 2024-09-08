using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public class ChangeNameTransaction(string empId, string newName): ChangeEmployeeTransaction(empId)
{
    protected override void Change(Employee employee)
    {
        employee.Name = newName;
    }
}