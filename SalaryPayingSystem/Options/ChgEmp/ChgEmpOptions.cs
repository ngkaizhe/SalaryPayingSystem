using CommandLine;

namespace SalaryPayingSystem.Options.ChgEmp;

[Verb("ChgEmp", HelpText = "Register for guild service fee")]
public class ChgEmpOptions
{
    [Value(0, MetaName = "EmpId", Required = true, HelpText = "Employee ID")]
    public string EmpId { get; set; }

    [Option("Name", HelpText = "New name for the employee")]
    public string Name { get; set; }

    [Option("Address", HelpText = "New address for the employee")]
    public string Address { get; set; }

    [Option("Hourly", HelpText = "Hourly rate for the employee")]
    public double? Hourly { get; set; }

    [Option("Salaried", HelpText = "Monthly salary for the employee")]
    public double? Monthly { get; set; }

    [Option("Commissioned", HelpText = "Monthly salary and commission rate for commissioned employee")]
    public IEnumerable<string> Commissioned { get; set; }

    [Option("Hold", HelpText = "Set payment method to hold")]
    public bool Hold { get; set; }

    [Option("Direct", HelpText = "Set payment method to direct deposit")]
    public bool Direct { get; set; }

    [Option("Mail", HelpText = "Set payment method to mail")]
    public bool Mail { get; set; }

    [Option("Member", HelpText = "Assign employee as union member")]
    public string MemberId { get; set; }

    [Option("Dues", HelpText = "Union dues rate for the employee")]
    public decimal? DuesRate { get; set; }

    [Option("NoMember", HelpText = "Remove employee from union membership")]
    public bool NoMember { get; set; }
}