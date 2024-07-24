# SalaryPayingSystem
## 初略的 spec
- 時薪工的員工一天工作超過 8 小時，超過時間的部分就會按照原本的實薪 * 1.5
- 月薪員工會在每個月的最後一個工作日支付薪水
- 月薪的員工會根據他們的銷售狀況支付他們一定的佣金
  - 員工需要提交銷售單據，其中記錄了銷售的日期 & 數量
  - 每隔一周的`周五`對他們進行支付
- 員工可以選擇支付方式，支票郵寄到他們指定的郵政地址/把支票保存在`出納人員`那邊/直接存入他們的銀行帳戶
- 一些員工加入了工會，工會每`每周`會收取固定的會費，會費會從薪水裏面扣除
  - 工會每周會提交這些服務費用，費用會從下個月的薪水總額扣除
- 薪水支付系統每個工作日執行一次，每次執行時會支付當天需要支付的員工薪水

## Input Cases
### Case 1：增加新員工
``` bash
AddEmp <EmpID> "<name>" "<address>" H <hrly-rate>
AddEmp <EmpID> "<name>" "<address>" S <mtly-slry>
AddEmp <EmpID> "<name>" "<address>" C <mtly-slry> <comm-rate>
```

### Case 2: 刪除員工
``` bash
DelEmp <EmpId>
```

### Case 3: 登記出缺勤卡
``` bash
TimeCard <empid> <date> <hours>
```

### Case 4: 登記銷售單據
``` bash
SalesReceipt <EmpId> <date> <amount>
```

### Case 5: 登記工會服務費
``` bash
ServiceCharge <memberId> <amount>
```

### Case 6: 更改員工明細
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

### Case 7: 在今日執行薪水支付系統
``` bash
Payday <date>
```