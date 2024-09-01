using CommandLine;

namespace SalaryPayingSystem.Options.ServiceCharges;

[Verb("ServiceCharge", HelpText = "Register for guild service fee")]
public class ServiceChargeOptions
{
    [Value(0, MetaName = "memberId", Required = true, HelpText = "Member ID")]
    public string MemberId { get; set; }
    
    [Value(1, MetaName = "date", Required = true, HelpText = "Date")]
    public DateTime Date { get; set; }

    [Value(2, MetaName = "amount", Required = true, HelpText = "Service charge amount")]
    public double Amount { get; set; }
}