using CommandLine;

namespace SalaryPayingSystem.CommandLineOption;

[Verb("ServiceCharge", HelpText = "Register for guild service fee")]
public class ServiceChargeOptions
{
    [Value(0, MetaName = "memberId", Required = true, HelpText = "Member ID")]
    public string MemberId { get; set; }

    [Value(1, MetaName = "amount", Required = true, HelpText = "Service charge amount")]
    public decimal Amount { get; set; }
}