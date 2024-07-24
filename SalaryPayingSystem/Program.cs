﻿// See https://aka.ms/new-console-template for more information
using CommandLine;
using SalaryPayingSystem.AddEmp;
using SalaryPayingSystem.ChgEmp;
using SalaryPayingSystem.DelEmp;
using SalaryPayingSystem.Options.AddEmp;
using SalaryPayingSystem.Payday;
using SalaryPayingSystem.SalesReceipt;
using SalaryPayingSystem.ServiceCharge;
using SalaryPayingSystem.TimeCard;


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