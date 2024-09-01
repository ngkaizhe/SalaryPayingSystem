using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Transactions.AddEmp;

public class AddCommissionedEmployee(string empId, string name, string address,  double salary, double commissionRate) : AddEmployeeTransaction(empId, name, address)
{
    protected override IPayClassification MakePayClassification()
    {
        return new CommissionedClassification(commissionRate, salary);
    }

    protected override IPaymentSchedule MakePaySchedule()
    {
        return new BiweeklySchedule();
    }
}