using CommandLine;

namespace SalaryPayingSystem;

class CommandLineOptions
{
    [Value(0, MetaName = "Action", Required = true, HelpText = "Action to perform (AddEmp, etc.)")]
    public ActionType Action { get; set; }

    [Value(1, MetaName = "EmpID", Required = true, HelpText = "Employee ID")]
    public int EmployeeId { get; set; }

    [Value(2, MetaName = "Name", Required = true, HelpText = "Employee name")]
    public string Name { get; set; }

    [Value(3, MetaName = "Address", Required = true, HelpText = "Employee address")]
    public string Address { get; set; }

    [Value(4, MetaName = "Salary", Required = true, HelpText = "Employee salary")]
    public decimal Salary { get; set; }
}