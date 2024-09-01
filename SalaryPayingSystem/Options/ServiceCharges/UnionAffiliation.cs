namespace SalaryPayingSystem.Options.ServiceCharges;


public interface IAffiliation
{
}

public class UnionAffiliation: IAffiliation
{
    private readonly List<ServiceCharge> _serviceCharges = new ();
    
    public void AddServiceCharge(ServiceCharge serviceCharge)
    {
        _serviceCharges.Add(serviceCharge);
    }
    
    public ServiceCharge? GetServiceCharge(DateTime date)
    {
        return _serviceCharges.FirstOrDefault(sc => sc.Date == date);
    }
}