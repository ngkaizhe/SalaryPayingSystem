using SalaryPayingSystem.Employees;
using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public abstract class ChangeClassificationTransaction(string empId) : ChangeEmployeeTransaction(empId)
{
    protected override void Change(Employee employee)
    {
        employee.PayClassification = PayClassification;
        employee.PaymentSchedule = PaySchedule;
    }

    protected abstract IPayClassification PayClassification { get; }
    protected abstract IPaymentSchedule PaySchedule { get; }
}