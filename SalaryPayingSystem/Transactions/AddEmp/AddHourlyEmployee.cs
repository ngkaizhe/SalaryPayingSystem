using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Transactions.AddEmp;

public class AddHourlyEmployee(string empId, string name, string address, double hourlyPay) : AddEmployeeTransaction(empId, name, address)
{
    protected override IPayClassification MakePayClassification()
    {
        return new HourlyClassification(hourlyPay);
    }

    protected override IPaymentSchedule MakePaySchedule()
    {
        return new WeeklySchedule();
    }
}