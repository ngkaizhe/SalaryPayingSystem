// See https://aka.ms/new-console-template for more information
using CommandLine;
using SalaryPayingSystem;

Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(options =>
    {
        switch (options.Action)
        {
            case ActionType.AddEmp:
                Console.WriteLine("Performing AddEmp action:");
                Console.WriteLine($"Employee ID: {options.EmployeeId}");
                Console.WriteLine($"Name: {options.Name}");
                Console.WriteLine($"Address: {options.Address}");
                // Here you can implement logic specific to AddEmp action
                break;
            // Add cases for other actions if needed

            default:
                Console.WriteLine($"Unknown action: {options.Action}");
                break;
        }
                
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