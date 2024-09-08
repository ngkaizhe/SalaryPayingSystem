using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Transactions.ChgEmp;

class ChangeHourlyTransaction(string empId, double hourlyRate) : ChangeClassificationTransaction(empId)
{
    protected override IPayClassification PayClassification => new HourlyClassification(hourlyRate);
    protected override IPaymentSchedule PaySchedule => new WeeklySchedule();
}