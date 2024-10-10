// See https://aka.ms/new-console-template for more information
using CommandLine;
using SalaryPayingSystem.Options.AddEmp;
using SalaryPayingSystem.Options.ChgEmp;
using SalaryPayingSystem.Options.DelEmp;
using SalaryPayingSystem.Options.Payday;
using SalaryPayingSystem.Options.SalesReceipts;
using SalaryPayingSystem.Options.ServiceCharges;
using SalaryPayingSystem.Options.TimeCards;


var addEmpService = new AddEmpService();
var delEmpService = new DelEmpService();
var timeCardService = new TimeCardService();
var salesReceiptService = new SalesReceiptService();
var serviceChargeService = new ServiceChargeService();
var chgEmpService = new ChgEmpService();
var paydayService = new PaydayService();

Parser.Default.ParseArguments<
        AddEmpOptions, 
        DelEmpOptions,
        TimeCardOptions,
        SalesReceiptOptions,
        ServiceChargeOptions,
        ChgEmpOptions,
        PaydayOptions>(args)
    .MapResult(
        (AddEmpOptions options) => addEmpService.Execute(options),
        (DelEmpOptions options) => delEmpService.Execute(options),
        (TimeCardOptions options) => timeCardService.Execute(options),
        (SalesReceiptOptions options) => salesReceiptService.Execute(options),
        (ServiceChargeOptions options) => serviceChargeService.Execute(options),
        (ChgEmpOptions options) => chgEmpService.Execute(options),
        (PaydayOptions options) => paydayService.Execute(options),
        errors =>
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.ToString());
            }

            return 1;
        });