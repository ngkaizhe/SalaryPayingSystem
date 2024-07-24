using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentSchedule;

namespace SalaryPayingSystem.Options.AddEmp.Transactions;

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