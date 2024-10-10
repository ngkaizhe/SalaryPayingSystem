using SalaryPayingSystem.Employees;
using SalaryPayingSystem.PaymentMethods;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public abstract class ChangeMethodTransaction(string empId) : ChangeEmployeeTransaction(empId)
{
    protected override void Change(Employee employee)
    {
        employee.PaymentMethod = PaymentMethod;
    }
    
    protected abstract IPaymentMethod PaymentMethod { get; }
}