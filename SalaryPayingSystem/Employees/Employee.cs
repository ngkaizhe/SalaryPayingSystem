using SalaryPayingSystem.Options.ServiceCharges;
using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentMethods;
using SalaryPayingSystem.PaymentSchedules;

namespace SalaryPayingSystem.Employees;

public class Employee(
    string empId,
    string name,
    string address,
    IPayClassification payClassification,
    IPaymentSchedule paymentSchedule,
    IPaymentMethod paymentMethod)
{
    private string _empId = empId;
    public string Name { get; } = name;
    private string _address = address;
    public IAffiliation? Affiliation { get; set; } = null;
    
    public IPayClassification PayClassification { get; } = payClassification;
    public IPaymentSchedule PaymentSchedule { get; } = paymentSchedule;
    public IPaymentMethod PaymentMethod { get; } = paymentMethod;
}