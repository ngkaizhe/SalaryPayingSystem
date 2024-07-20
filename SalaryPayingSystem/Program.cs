// See https://aka.ms/new-console-template for more information
using CommandLine;
using SalaryPayingSystem.AddEmp;
using SalaryPayingSystem.ChgEmp;
using SalaryPayingSystem.CommandLineOption;
using SalaryPayingSystem.DelEmp;
using SalaryPayingSystem.SalesReceipt;
using SalaryPayingSystem.ServiceCharge;
using SalaryPayingSystem.TimeCard;


var addEmpService = new AddEmpService();
var delEmpService = new DelEmpService();

Parser.Default.ParseArguments<
        AddEmpOptions, 
        DelEmpOptions,
        TimeCardOptions,
        SalesReceiptOptions,
        ServiceChargeOptions,
        ChgEmpOptions,
        PaydayOptions>(args)
    .MapResult(
        (AddEmpOptions options) => 0,
        (DelEmpOptions options) => 0,
        (TimeCardOptions options) => 0,
        (SalesReceiptOptions options) => 0,
        (ServiceChargeOptions options) => 0,
        (ChgEmpOptions options) => 0,
        (PaydayOptions options) => 0,
        errors =>
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }

            return 1;
        });