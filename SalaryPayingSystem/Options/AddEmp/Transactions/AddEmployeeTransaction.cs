using SalaryPayingSystem.Databases;
using SalaryPayingSystem.Employees;
using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentMethods;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Options.AddEmp.Transactions;

public abstract class AddEmployeeTransaction(string empId, string name, string address) : ITransaction
{
    public void Execute()
    {
        Employee employee = new Employee(
            empId, 
            name, 
            address, 
            MakePayClassification(), 
            MakePaySchedule(), 
            new HoldMethod());
        
        PayrollDatabase.AddEmployee(empId, employee);
    }
    
    protected abstract IPayClassification MakePayClassification();
    
    protected abstract IPaymentSchedule MakePaySchedule();
}