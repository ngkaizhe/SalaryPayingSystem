using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Options.AddEmp.Transactions;

class AddHourlyEmployee(string empId, string name, string address, double hourlyRate) : AddEmployeeTransaction(empId, name, address)
{
    protected override IPayClassification MakePayClassification()
    {
        return new HourlyClassification(hourlyRate);
    }

    protected override IPaymentSchedule MakePaySchedule()
    {
        return new WeeklySchedule();
    }
}