using SalaryPayingSystem.Databases;
using SalaryPayingSystem.PayClassifications;

namespace SalaryPayingSystem.Transactions.TimeCard;

public class TimeCardTransaction(string empId, DateTime date, int hours) : ITransaction
{
    public void Execute()
    {
        var employee = PayrollDatabase.GetEmployee(empId);

        if (employee != null)
        {
            if (employee.PayClassification is HourlyClassification hourlyClassification)
            {
                hourlyClassification.AddTimeCard(date, hours);
            }
            else
            {
                throw new InvalidOperationException("Tried to add time card to non-hourly employee");
            }
        }
        else
        {
            throw new InvalidOperationException("No such employee.");
        }
    }
}