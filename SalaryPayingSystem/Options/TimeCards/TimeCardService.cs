using SalaryPayingSystem.Transactions.TimeCard;

namespace SalaryPayingSystem.Options.TimeCards;

public class TimeCardService
{
    public int Execute(TimeCardOptions timeCardOptions)
    {
        var timeCardTransaction = new TimeCardTransaction(timeCardOptions.EmpId, timeCardOptions.Date, timeCardOptions.Hour);
        timeCardTransaction.Execute();
        return 0;
    }
}