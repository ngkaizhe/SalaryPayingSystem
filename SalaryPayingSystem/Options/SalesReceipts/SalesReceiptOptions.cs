using CommandLine;

namespace SalaryPayingSystem.Options.SalesReceipts;

[Verb("SalesReceipt", HelpText = "Register for sales receipt")]
public class SalesReceiptOptions
{
    [Value(0, MetaName = "EmpID", Required = true, HelpText = "Employee ID")]
    public string EmpId { get; set; }
    
    [Value(1, MetaName = "date", Required = true, HelpText = "Date")]
    public DateTime Date { get; set; }
    
    [Value(2, MetaName = "amount", Required = true, HelpText = "Amount")]
    public double Amount { get; set; }
}