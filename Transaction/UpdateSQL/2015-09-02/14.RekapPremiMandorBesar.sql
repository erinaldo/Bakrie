
/****** Object:  StoredProcedure [Checkroll].[TransferSalaryToAllowance]    Script Date: 26/8/2015 10:50:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [Checkroll].[RekapPremiMandorBesar]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50) 
AS     

declare @until datetime
declare @tanggal datetime
declare @from datetime

select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where am.ActiveMonthYearID = @ActiveMonthYearId

  
BEGIN  
	Select MB.*,CR.EmpCode, CR.EmpName  from Checkroll.MandorBesarPremi MB
	inner join Checkroll.CREmployee CR on MB.EmpId = CR.EmpID 
	Where Mb.DDate between @from and @until
	order by MB.DDate, CR.EmpCode

END
