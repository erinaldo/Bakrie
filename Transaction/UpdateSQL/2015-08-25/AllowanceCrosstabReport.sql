
/****** Object:  StoredProcedure [Checkroll].[CREstateMonthlyProductionReport]    Script Date: 1/9/2015 5:01:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [Checkroll].[AllowanceCrosstabReport]
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
	
	
AS

SET NOCOUNT ON

Declare @Amonth int
Declare @Ayear Int

Select @Amonth =AMonth ,@Ayear =AYear 
From General.ActiveMonthYear 
where EstateID =@EstateID 
AND ActiveMonthYearID =@ActiveMonthYearID 
AND ModID = 1

select EA.EmpId, CRE.EmpCode  + ' ' +  CRE.EmpName as EmpName, Amount, EA.[Type] as AllDedType, StartDate, EndDates, ad.AllowDedCode, ad.AllowDedCode + ' ' + AD.Remarks as Remarks from Checkroll.EmpAllowanceDeduction EA
inner join Checkroll.AllowanceDeductionSetup AD on EA.AllowDedID = AD.AllowDedID
inner join Checkroll.CREmployee CRE on EA.EmpID = CRE.EmpID
where Month(StartDate) = @Amonth and Year(StartDate) = @Ayear


