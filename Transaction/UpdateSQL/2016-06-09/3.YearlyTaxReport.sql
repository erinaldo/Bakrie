
/****** Object:  StoredProcedure [Checkroll].[MonthlyTaxProcess]    Script Date: 9/6/2016 8:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Checkroll].[YearlyTaxReport]    
@Ayear int,
@EstateId nvarchar (50)
AS     
  
BEGIN  
declare @EmpId nvarchar(50)
declare @until datetime
declare @from datetime
declare @id varchar(15)
DECLARE @AllowDecCode nvarchar(50)
declare @EstateCode varchar(10)
declare @tanggal datetime


set @tanggal= getDate()



select a.EmpID,EmpName,EmpCode,HaveNPWP,Gender,NPWP,HomeAdd1,MaritalStatus,NoOfChildrenforTax,OEEmpLocation,Status,'' as KodePajak,
Jumlah1,Jumlah2,Jumlah3,Jumlah4,Jumlah5,Jumlah6,Jumlah7,Jumlah8,Jumlah9,Jumlah10,Jumlah11,Jumlah12
 from 
(Select HaveNPWP,MaritalStatus,NPWP,EmpName,EmpID,EmpCode,HomeAdd1,NoOfChildrenforTax,OEEmpLocation,Status,Gender from Checkroll.CREmployee where MaritalStatus <> '' and MaritalStatus is not null) as CEmp
LEFt JOiN  
(select Sum(Round(Amount,0)) as Jumlah1,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 1 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as a
on CEmp.EmpID = a.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah2,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 2 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as b
on CEmp.EmpID = b.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah3,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 3 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as c
on CEmp.EmpID = c.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah4,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 4 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as d
on CEmp.EmpID = d.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah5,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 5 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as e
on CEmp.EmpID = e.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah6,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 6 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as f
on CEmp.EmpID = f.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah7,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 7 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as g
on CEmp.EmpID = g.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah8,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 8 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as h
on CEmp.EmpID = h.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah9,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 9 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as i
on CEmp.EmpID = i.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah10,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 10 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as j
on CEmp.EmpID = j.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah11,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 11 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as k
on CEmp.EmpID = k.EmpID
LEFT join 
(select Sum(Round(Amount,0)) as Jumlah12,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = 12 and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID = 'BSP04R50' group by empid) as l
on CEmp.EmpID = l.EmpID
-- where a.empid = 'C00203531'

END
