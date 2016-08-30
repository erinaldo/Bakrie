SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Checkroll].[CRRecapitulationPremiMandorAndKraniDeresReport]
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
AS
BEGIN
	SELECT 
	ActiveMonthYearID, EstateID, GangName, DDate, MandorName,
	SUM(PremiMandor) as MandorPremi, KeraniName, SUM(PremiKerani) as KraniPremi, FaktorPembagi, Sum(TotalPremi) as TotalPremi
	FROM 
	(
	Select b.ActiveMonthYearID,b.EstateID,f.GangName, e.DDate, g.EmpName as MandorName,FaktorPembagi, SUm(PremiDasar + PremiBonus + PremiTreeLace + PremiProgresif + PremiBonus + PremiMinggu) / FaktorPembagi * 1.5 as PremiMandor,
	h.EmpName as KeraniName,SUm(PremiDasar + PremiBonus + PremiTreeLace + PremiProgresif + PremiBonus + PremiMinggu) / FaktorPembagi * 1.25 as PremiKerani,SUm(PremiDasar + PremiBonus + PremiTreeLace + PremiProgresif + PremiBonus + PremiMinggu) as TotalPremi
	from (Select Sum(a.PremiDasarLatex + a.PremiDasarLump) as PremiDasar, Sum(a.PremiProgresifLatex + a.PremiProgresifLump) as PremiProgresif,
	Sum(a.PremiBonusLatex + a.PremiBonusLump) as PremiBonus, Sum(a.PremiTreelace) as PremiTreeLace, Sum(a.PremiMinggu) as PremiMinggu,DailyReceiptionID from Checkroll.DailyReceptionForRubber a
	Group BY DailyReceiptionID) a
	inner Join Checkroll.DailyAttendance b On a.DailyReceiptionID = b.DailyReceiptionID
	INNER JOIN Checkroll.DailyTeamActivity e on b.DailyTeamActivityID = e.DailyTeamActivityID
	INNER JOIN [Checkroll].[GangMaster] f on e.GangMasterID = f.GangMasterID
	INNER JOIN [Checkroll].[CREmployee] g on e.MandoreID = g.EmpID
	INNER JOIN [Checkroll].[CREmployee] h on e.KraniID = h.EmpID
	inner Join (Select Count(*) as FaktorPembagi, GangMasterID,DDAte from Checkroll.DailyAttendance inner join Checkroll.AttendanceSetup on 
	Checkroll.DailyAttendance.AttendanceSetupID = Checkroll.AttendanceSetup.AttendanceSetupID
	inner join Checkroll.DailyTeamActivity on Checkroll.DailyAttendance.DailyTeamActivityID = Checkroll.DailyTeamActivity.DailyTeamActivityID
	Where AttendanceCode = '11' And Checkroll.DailyTeamActivity.Activity = 'Deres' Group By Gangmasterid,DDate) Z on e.GangMasterID = z.gangmasterid and e.DDate = z.DDAte
	WHERE b.ActiveMonthYearID = @ActiveMonthYearID AND b.EstateID = @EstateID
	Group by b.ActiveMonthYearID,b.EstateID,f.GangName, e.DDate, g.EmpName,FaktorPembagi,h.EmpName
	) as tbl
	GROUP BY ActiveMonthYearID, EstateID, GangName, DDate, MandorName,KeraniName,FaktorPembagi
	ORDER BY GangName, DDate
END
