using SalaryPayingSystem.Affiliations;
using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public class ChangeMemberTransaction(string empId, int memberId, double dues) : ChangeAffiliationTransaction(empId)
{
    protected override IAffiliation Affiliation { get; } = new UnionAffiliation(memberId, dues);
    protected override void RecordMembership(Employee employee)
    {
        PayrollDatabase.AddUnionMember(memberId, employee);
    }
}