using CommandLine;
using SalaryPayingSystem.Employee;

namespace SalaryPayingSystem.AddEmp;

[Verb("AddEmp", HelpText = "Add a new employee")]
public class AddEmpOptions
{
    [Value(0, MetaName = "EmpID", Required = true, HelpText = "Employee ID")]
    public string EmpId { get; set; }

    [Value(1, MetaName = "name", Required = true, HelpText = "Employee name")]
    public string Name { get; set; }

    [Value(2, MetaName = "address", Required = true, HelpText = "Employee address")]
    public string Address { get; set; }

    [Value(3, MetaName = "employee-type", Required = true, HelpText = "Employee type")]
    public EmployeeType EmployeeType { get; set; }

    [Value(4, MetaName = "params", Required = true, HelpText = "Different params depends on employee type")]
    public IEnumerable<string> Params { get; set; }
}