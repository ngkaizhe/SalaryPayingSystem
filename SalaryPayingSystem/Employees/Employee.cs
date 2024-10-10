using SalaryPayingSystem.Affiliations;
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
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;
    public IAffiliation? Affiliation { get; set; }
    
    public IPayClassification PayClassification { get; set; } = payClassification;
    public IPaymentSchedule PaymentSchedule { get; set; } = paymentSchedule;
    public IPaymentMethod PaymentMethod { get; set; } = paymentMethod;
}