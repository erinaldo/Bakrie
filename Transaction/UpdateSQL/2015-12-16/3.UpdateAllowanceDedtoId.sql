UPDate Checkroll.EmpAllowanceDeduction
	set Checkroll.EmpAllowanceDeduction.EmpID  = Checkroll.CREmployee.empid
from Checkroll.EmpAllowanceDeduction 
inner join Checkroll.CREmployee on Checkroll.EmpAllowanceDeduction.EmpID = Checkroll.CREmployee.EmpCode
where Checkroll.EmpAllowanceDeduction.EmpID <> Checkroll.CREmployee.EmpID



select a.EmpID,b.EmpID,b.EmpCode from Checkroll.EmpAllowanceDeduction a
inner join Checkroll.CREmployee b on a.EmpID = b.EmpCode
where b.EmpID <> a.EmpID