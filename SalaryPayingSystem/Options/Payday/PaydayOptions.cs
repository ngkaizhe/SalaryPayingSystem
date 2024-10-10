using CommandLine;

namespace SalaryPayingSystem.Options.Payday;

[Verb("Payday", HelpText = "Register for guild service fee")]
public class PaydayOptions
{
    [Value(0, MetaName = "date", Required = true, HelpText = "Date for payroll processing")]
    public DateTime Date { get; set; }
}