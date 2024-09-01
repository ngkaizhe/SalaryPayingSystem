using SalaryPayingSystem.Databases;
using SalaryPayingSystem.PayClassifications;

namespace SalaryPayingSystem.Transactions.SalesReceipts;

public class SalesReceiptTransaction(string empId, DateTime dateTime, double amount) : ITransaction
{
    public void Execute()
    {
        var employee = PayrollDatabase.GetEmployee(empId);

        if (employee != null)
        {
            if (employee.PayClassification is CommissionedClassification commissionedClassification)
            {
                commissionedClassification.AddSalesReceipt(dateTime, amount);
            }
            else
            {
                throw new InvalidOperationException("Tried to add sales receipt to non-commissioned employee");
            }
        }
        else
        {
            throw new InvalidOperationException("No such employee.");
        }
    }
}