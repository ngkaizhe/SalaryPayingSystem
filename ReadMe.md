# SalaryPayingSystem
## Case 1：增加新員工
``` bash
AddEmp <EmpID> "<name>" "<address>" H <hrly-rate>
AddEmp <EmpID> "<name>" "<address>" S <mtly-slry>
AddEmp <EmpID> "<name>" "<address>" C <mtly-slry> <comm-rate>
```

## Case 2: 刪除員工
``` bash
DelEmp <EmpId>
```

## Case 3: 登記出缺勤卡
``` bash
TimeCard <empid> <date> <hours>
```

## Case 4: 登記銷售單據
``` bash
SalesReceipt <EmpId> <date> <amount>
```

## Case 5: 登記工會服務費
``` bash
ServiceCharge <memberId> <amount>
```

## Case 6: 更改員工明細
```  bash
ChgEmp <EmpId> -Name <name>
ChgEmp <EmpId> -Address <address>
ChgEmp <EmpId> -Hourly <hourly>
ChgEmp <EmpId> -Salaried <salary>
ChgEmp <EmpId> -Commissioned <salary> <rate>
ChgEmp <EmpId> -Hold
ChgEmp <EmpId> -Direct <bank> <account>
ChgEmp <EmpId> -Mail <address>
ChgEmp <EmpId> -Member <memberId> -Dues <rate>
ChgEmp <EmpId> -NoMember
```

## Case 7: 在今日執行薪水支付系統
``` bash
Payday <date>
```