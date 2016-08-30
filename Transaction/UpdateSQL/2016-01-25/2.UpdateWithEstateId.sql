DECLARE @ESTATEID  nvarchar(50)
DECLARE @ActiveMonthYearID nvarchar(50)

Select @ActiveMonthYearID = ActiveMonthYearID from General.ActiveMonthYear where modid = 1 and AMonth = 12 and AYear =2015

select @ESTATEID = estateid from General.Estate
execute checkroll.ProcessRiceValue @ESTATEID,@ActiveMonthYearID

Select @ActiveMonthYearID = ActiveMonthYearID from General.ActiveMonthYear where modid = 1 and AMonth = 1 and AYear =2016

select @ESTATEID = estateid from General.Estate
execute checkroll.ProcessRiceValue @ESTATEID,@ActiveMonthYearID


--select * from checkroll.AnalyHarvestingCost where ActiveMonthYearID