using SalaryPayingSystem.Affiliations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public class ChangeUnaffiliatedTransaction(string empId) : ChangeAffiliationTransaction(empId)
{
    protected override IAffiliation Affiliation { get; } = new NoAffiliation();
    protected override void RecordMembership(Employee employee)
    {
        var affiliation = employee.Affiliation;
        if (affiliation is UnionAffiliation)
        {
            var unionAffiliation = affiliation as UnionAffiliation;
            var memberId = unionAffiliation.MemberId;
            PayrollDatabase.RemoveUnionMember(memberId);
        }
    }
}