using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Transactions.ChgEmp;

class ChangeMonthlyTransaction(string empId, double monthlyPay) : ChangeClassificationTransaction(empId)
{
    protected override IPayClassification PayClassification => new MonthlyClassification(monthlyPay);
    protected override IPaymentSchedule PaySchedule => new MonthlySchedule();
}