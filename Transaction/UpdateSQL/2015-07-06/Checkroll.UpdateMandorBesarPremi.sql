
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sai Sidharth
-- Create date: 6/7/2015
-- Description:	Updates Premi For Mandor Besar, Based on  200% of Avg of Mandor Premi supervised by them
-- =============================================


CREATE PROCEDURE [Checkroll.UpdateMandorBesarPremi] 
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Gets mandor premi records into temporary table.
	Select ActiveMonthYearID, EstateID, EstateName, AMonth, AYear, RDate, Count(RDate) as FaktorPembahagi,Sum(MandorPremi) as TotalPremiMandor, 
Sum(MandorPremi)/ Count(RDate) * 2 as MandorBesarPremi , MandorBesarName 	into #tempPremiMandorBesar
from 
(
SELECT 
	ActiveMonthYearID, EstateID, EstateName, AMonth, AYear, GangName, RDate, MandorName,
	SUM(MandorPremi) as MandorPremi,  SUM(SUMPREMI) as SUMPREMI, FaktorPembagi, MandorBesarName
	FROM 
	(
	SELECT 
	a.ActiveMonthYearID, a.EstateID, EstateName, c.AMonth, c.AYear, d.GangName, RDate, e.EmpName as MandorName, 
	(((TValue1+TValue2+TValue3+TotalBoronganValue+TLooseFruitsValue)/z.FaktorPembagi)*1.5) as MandorPremi,
	(TValue1+TValue2+TValue3+TotalBoronganValue+TLooseFruitsValue) as SUMPREMI, z.FaktorPembagi, dta.MandorBesarID, g.EmpName as MandorBesarName
	FROM [Checkroll].[ReceptionTargetDetail] a
	INNER JOIN [General].[Estate] b on a.EstateID = b.EstateID
	INNER JOIN [General].[ActiveMonthYear] c on a.ActiveMonthYearID = c.ActiveMonthYearID
	INNER JOIN [Checkroll].[GangMaster] d on a.GangMasterID = d.GangMasterID
	INNER JOIN [Checkroll].[CREmployee] e on a.MandoreID = e.EmpID
	INNER JOIN [Checkroll].[CREmployee] f on a.KraniID = f.EmpID
	inner join Checkroll.DailyTeamActivity DTA on a.GangMasterID = dta.GangMasterID and a.RDate = dta.DDate 
	inner Join Checkroll.CREmployee g on dta.MandorBesarID = g.EmpID
	inner Join (Select Count(*) as FaktorPembagi, GangMasterID,DDAte from Checkroll.DailyAttendance inner join Checkroll.AttendanceSetup on 
	Checkroll.DailyAttendance.AttendanceSetupID = Checkroll.AttendanceSetup.AttendanceSetupID
	inner join Checkroll.DailyTeamActivity on Checkroll.DailyAttendance.DailyTeamActivityID = Checkroll.DailyTeamActivity.DailyTeamActivityID
	Where AttendanceCode = '11' And Checkroll.DailyAttendance.ActiveMonthYearID  = '02R1688'  Group By Gangmasterid,DDate) Z on a.GangMasterID = z.gangmasterid and a.RDate = z.DDAte
	WHERE a.ActiveMonthYearID = '02R1688' AND a.EstateID = 'M5'
	) as tbl
	
	GROUP BY ActiveMonthYearID, EstateID, EstateName, AMonth, AYear, GangName, RDate, MandorName,FaktorPembagi,MandorBesarName
	--ORDER BY GangName, RDate
) as tbl2
	group by ActiveMonthYearID, EstateID, EstateName, AMonth, AYear, RDate, MandorBesarName


	Drop table #tempPremiMandorBesar
END


GO
