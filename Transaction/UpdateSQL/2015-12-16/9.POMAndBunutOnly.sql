
update Checkroll.AllowanceDeductionSetup set AllowDedID = 'BSP04' + SUBSTRING(AllowDedID,6,Len(AllowDedId)) 
update Checkroll.EmpAllowanceDeduction set AllowDedID = 'BSP04' + SUBSTRING(AllowDedID,6,Len(AllowDedId)) 