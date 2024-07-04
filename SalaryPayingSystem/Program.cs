// See https://aka.ms/new-console-template for more information
using CommandLine;

Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(options =>
    {
        Console.WriteLine($"Employee ID: {options.EmployeeID}");
        Console.WriteLine($"Name: {options.Name}");
        Console.WriteLine($"Address: {options.Address}");
        Console.WriteLine($"Salary: {options.Salary}");
                
        // Here you can perform further operations, such as adding the employee to a database
        // or performing some other business logic.
    })
    .WithNotParsed(errors =>
    {
        // If there are any parsing errors, you can handle them here
        // For example, print error messages or help text.
        foreach (var error in errors)
        {
            Console.WriteLine(error.ToString());
        }
    });