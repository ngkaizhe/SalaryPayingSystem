using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Options.ServiceCharges;

namespace SalaryPayingSystem.Transactions.ServiceCharges;

public class ServiceChargeTransaction(string memberId, DateTime dateTime, double amount): ITransaction
{
    public void Execute()
    {
        var employee = PayrollDatabase.GetUnionMember(memberId);
        
        if(employee != null)
        {
            UnionAffiliation? unionAffiliation = null;
            if (employee.Affiliation is UnionAffiliation affiliation)
            {
                unionAffiliation = affiliation;
            }

            if (unionAffiliation != null)
            {
                unionAffiliation.AddServiceCharge(new ServiceCharge(dateTime, amount));
            }
            else
            {
                throw new InvalidOperationException(
                    "Tried to add service charge to union member without a union affiliation");
            }
        }
        else
        {
            throw new InvalidOperationException("No such union member.");
        }
    }
}