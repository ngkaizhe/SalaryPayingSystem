using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Transactions.AddEmp;

class AddMonthlyEmployee(string empId, string name, string address, double monthlyPay) : AddEmployeeTransaction(empId, name, address)
{
    protected override IPayClassification MakePayClassification()
    {
        return new MonthlyClassification(monthlyPay);
    }

    protected override IPaymentSchedule MakePaySchedule()
    {
        return new MonthlySchedule();
    }
}