using SalaryPayingSystem.PayClassifications;
using SalaryPayingSystem.PaymentMethod;
using SalaryPayingSystem.PaymentSchedule;

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
    private string _name = name;
    private string _address = address;
    private IPayClassification _payClassification = payClassification;
    private IPaymentSchedule _paymentSchedule = paymentSchedule;
    private IPaymentMethod _paymentMethod = paymentMethod;
}