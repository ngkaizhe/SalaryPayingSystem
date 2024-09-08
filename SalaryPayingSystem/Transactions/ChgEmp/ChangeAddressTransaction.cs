using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public class ChangeAddressTransaction(string empId, string address) : ChangeEmployeeTransaction(empId)
{
    protected override void Change(Employee employee)
    {
        employee.Address = address;
    }
}