
Update Checkroll.DailyAttendanceMandor
Set Checkroll.DailyAttendanceMandor.EmpID =  Checkroll.CREmployee.EmpID
from Checkroll.DailyAttendanceMandor 
left join Checkroll.CREmployee on Checkroll.DailyAttendanceMandor.EmpID =  Checkroll.CREmployee.EmpCode