using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Transactions.ChgEmp;

class ChangeCommissionTransaction(string empId, double salary, double commissionRate) : ChangeClassificationTransaction(empId)
{
    protected override IPayClassification PayClassification => new CommissionedClassification(commissionRate, salary);
    protected override IPaymentSchedule PaySchedule => new BiweeklySchedule();
}