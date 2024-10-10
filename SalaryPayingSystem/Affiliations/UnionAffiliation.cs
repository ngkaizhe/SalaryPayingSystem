using System.Runtime.InteropServices.JavaScript;
using SalaryPayingSystem.Employees;
using SalaryPayingSystem.Options.ServiceCharges;

namespace SalaryPayingSystem.Affiliations;

public class UnionAffiliation(int memberId, double dues) : IAffiliation
{
    public int MemberId { get; } = memberId;
    public double Dues { get; } = dues;
    
    private readonly List<ServiceCharge> _serviceCharges = new ();
    
    public void AddServiceCharge(ServiceCharge serviceCharge)
    {
        _serviceCharges.Add(serviceCharge);
    }
    
    public ServiceCharge? GetServiceCharge(DateTime date)
    {
        return _serviceCharges.FirstOrDefault(sc => sc.Date == date);
    }

    public double CalculateDeductions(PayCheck payCheck)
    {
        var totalFridays = NumberOfFridaysInPayPeriod(payCheck.PayPeriodStartDate, payCheck.PayPeriodEndDate);
        return dues * totalFridays;
    }

    private int NumberOfFridaysInPayPeriod(DateTime startDate, DateTime endDate)
    {
        var totalFridays = 0;
        for(var day = startDate; day <= endDate; day = day.AddDays(1))
        {
            if (day.DayOfWeek == DayOfWeek.Friday)
            {
                totalFridays += 1;
            }
        }
        return totalFridays;
    }
}