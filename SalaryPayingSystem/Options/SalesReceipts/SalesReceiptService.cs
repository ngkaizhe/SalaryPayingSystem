using SalaryPayingSystem.Transactions.SalesReceipts;

namespace SalaryPayingSystem.Options.SalesReceipts;

public class SalesReceiptService
{
    public int Execute(SalesReceiptOptions salesReceiptOptions)
    {
        var timeCardTransaction = new SalesReceiptTransaction(salesReceiptOptions.EmpId, salesReceiptOptions.Date, salesReceiptOptions.Amount);
        timeCardTransaction.Execute();
        return 0;
    }
}