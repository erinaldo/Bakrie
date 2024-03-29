
/****** Object:  StoredProcedure [Checkroll].[CRAnalysisRubberCostReport]    Script Date: 9/6/2016 12:43:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Checkroll].[CRAnalysisRubberCostReportOverall]
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
AS
BEGIN

select MainDescription,SubDescription,MainOrderCounter,SubOrderCounterMain,1 as SubOrderCounterSub,Sum(PayrollBunches) as PayrollBunches,Sum(FactoryKG) as FactoryKG,
CASe SuM(PayrollBunches)
when 0 then 0
else Sum(FactoryKG)/Sum(PayrollBunches) end as KgPerBunches,
Sum(Mandays) as Mandays,
Case Sum(Mandays) 
when 0 then 0
else Sum(FactoryKG)/Sum(Mandays) 
end as KgPerMandays,
Sum(Cost) as Cost,
Case Sum(FactoryKG)
when 0 then 0
else Sum(Cost)/Sum(FactoryKG) end as CostPerKg,
CASe SuM(PayrollBunches)
when 0 then 0
else Sum(Cost)/Sum(PayrollBunches) end as CostPerBunches ,
Sum(FactoryBunches) as FactoryBunches,
Sum(DifferenceBunches) as DifferenceBunches
from Checkroll.AnalyLatexCost
where ActiveMonthYearID = @ActiveMonthYearID
group by MainDescription,SubDescription,MainOrderCounter,SubOrderCounterMain

END

