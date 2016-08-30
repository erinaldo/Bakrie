GO
/****** Object:  StoredProcedure [Checkroll].[MonthlyTaxProcess]    Script Date: 19/1/2016 9:51:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Checkroll].[CRRekapPengajian]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50)   
AS  
BEGIN
declare @until datetime
declare @from datetime

select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where am.ActiveMonthYearID = @ActiveMonthYearId

Select MonthlySalary.*, CS.GangMasterID, CRE.EmpCode,CRE.EmpName,Gm.GangName from 
(select a.EmpID,AllowanceAmount as MonthSalary, isnull(deductionAmount,0) as Deduction, AllowanceAmount - isnull(deductionAmount,0) as NettSalary, @ActiveMonthYearId as ActiveMonthYearID
from 
(select Sum(Round(Amount,0)) as AllowanceAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = MONTH(@Until) and YEar(EndDates) = Year(@Until) and type = 'A'  group by empid) as a
LEFT join 
(select Sum(Round(Amount,0)) as deductionAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = Month(@Until) and YEar(EndDates) = Year(@Until) and type = 'D'  group by empid)as b
on a.EmpID = b.EmpID) as  MonthlySalary
inner Join checkroll.sAlary CS on MonthlySalary.EmpID = CS.EmpID and MonthlySalary.ActiveMonthYearID = CS.ActiveMonthYearID
inner join Checkroll.CREmployee CRE on MonthlySalary.EmpID = CRE.EmpID
left join Checkroll.GangMaster GM on CS.GangMasterID = GM.GangMasterID

END

