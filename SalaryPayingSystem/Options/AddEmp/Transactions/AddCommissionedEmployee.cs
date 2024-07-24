using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedule;

namespace SalaryPayingSystem.Options.AddEmp.Transactions;

class AddCommissionedEmployee(string empId, string name, string address, double commissionRate, double basePay) : AddEmployeeTransaction(empId, name, address)
{
    protected override IPayClassification MakePayClassification()
    {
        return new CommissionedClassification(commissionRate, basePay);
    }

    protected override IPaymentSchedule MakePaySchedule()
    {
        return new BiweeklySchedule();
    }
}