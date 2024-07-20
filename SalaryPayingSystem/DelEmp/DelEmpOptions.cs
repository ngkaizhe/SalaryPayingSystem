using CommandLine;

namespace SalaryPayingSystem.DelEmp;

[Verb("DelEmp", HelpText = "Delete a employee")]
public class DelEmpOptions
{
    [Value(0, MetaName = "EmpID", Required = true, HelpText = "Employee ID")]
    public string EmpId { get; set; }
}