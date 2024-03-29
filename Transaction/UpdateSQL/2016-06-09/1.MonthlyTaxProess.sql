
/****** Object:  StoredProcedure [Checkroll].[MonthlyTaxProcess]    Script Date: 9/6/2016 8:52:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [Checkroll].[MonthlyTaxReport]  
@AMonth int,  
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
select @estateCode =EstateCode from General.Estate  where EstateID=@EstateId




select a.EmpID,EmpName,AllowanceAmount as Bruto, isnull(deductionAmount,0) as Pajak,MaritalStatus,HaveNPWP,NPWP,'' as KodePajak,MONTH(@from), YEAR(@from)
 from 
(select Sum(Round(Amount,0)) as AllowanceAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = @AMonth and YEar(EndDates) = @Ayear and type = 'A' and AllowDedID Not IN ('BSP04R3') group by empid) as a
LEFT join 
(select Sum(Round(Amount,0)) as deductionAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = @AMonth and YEar(EndDates) = @Ayear and type = 'D' and AllowDedID = 'BSP04R50' group by empid)as b
on a.EmpID = b.EmpID
inner join 
(Select HaveNPWP,MaritalStatus,NPWP,EmpName,EmpID,Gender from Checkroll.CREmployee) as c
 on a.EmpID = c.EmpID  
-- where a.empid = 'C00203531'

END
