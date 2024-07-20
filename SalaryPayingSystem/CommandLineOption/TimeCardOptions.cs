using CommandLine;

namespace SalaryPayingSystem.CommandLineOption;

[Verb("TimeCard", HelpText = "Register for absents or presents")]
public class TimeCardOptions
{
    [Value(0, MetaName = "EmpID", Required = true, HelpText = "Employee ID")]
    public string EmpId { get; set; }
    
    [Value(1, MetaName = "date", Required = true, HelpText = "Date")]
    public DateTime Date { get; set; }
    
    [Value(2, MetaName = "hours", Required = true, HelpText = "Hour")]
    public string Hour { get; set; }
}