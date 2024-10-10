using SalaryPayingSystem.Affiliations;
using SalaryPayingSystem.Employees;

namespace SalaryPayingSystem.Transactions.ChgEmp;

public abstract class ChangeAffiliationTransaction(string empId) : ChangeEmployeeTransaction(empId)
{
    protected override void Change(Employee employee)
    {
        RecordMembership(employee);
        employee.Affiliation = Affiliation;
    }

    protected abstract IAffiliation Affiliation { get; }
    protected abstract void RecordMembership(Employee employee);
}