DECLARE @ESTATEID  nvarchar(50)
DECLARE @ActiveMonthYearID nvarchar(50)

Select @ActiveMonthYearID = ActiveMonthYearID from General.ActiveMonthYear where modid = 1 and AMonth = 2 and AYear =2016

select @ESTATEID = estateid from General.Estate
execute checkroll.AnalyRubberCostInsert @ESTATEID,@ActiveMonthYearID,'sai'


--select * from checkroll.AnalyHarvestingCost where ActiveMonthYearID