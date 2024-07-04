using CommandLine;

class CommandLineOptions
{
    [Value(0, MetaName = "EmpID", Required = true, HelpText = "Employee ID")]
    public int EmployeeID { get; set; }

    [Value(1, MetaName = "Name", Required = true, HelpText = "Employee name")]
    public string Name { get; set; }

    [Value(2, MetaName = "Address", Required = true, HelpText = "Employee address")]
    public string Address { get; set; }

    [Value(3, MetaName = "Salary", Required = true, HelpText = "Employee salary")]
    public decimal Salary { get; set; }
}