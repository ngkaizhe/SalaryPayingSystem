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
        throw new NotImplementedException();
    }
}