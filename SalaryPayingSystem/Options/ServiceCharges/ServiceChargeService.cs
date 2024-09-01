using SalaryPayingSystem.Transactions.ServiceCharges;

namespace SalaryPayingSystem.Options.ServiceCharges;

public class ServiceChargeService
{
    public int Execute(ServiceChargeOptions serviceChargeOptions)
    {
        var serviceChargeTransaction = new ServiceChargeTransaction(serviceChargeOptions.MemberId, serviceChargeOptions.Date, serviceChargeOptions.Amount);
        serviceChargeTransaction.Execute();
        return 0;
    }
}