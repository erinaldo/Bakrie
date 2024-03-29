SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[CRDailyAttendanceWithTeamSumHK]
@TeamName nvarchar(50),
@RDate date
AS
BEGIN

	SELECT SUM(CR_AS.TimesBasic ) AS SumTimesBasicHK
	FROM 
		Checkroll.DailyAttendance AS CR_DA
		INNER JOIN Checkroll.AttendanceSetup AS CR_AS ON CR_DA.AttendanceSetupID = CR_AS.AttendanceSetupID
		INNER JOIN Checkroll.DailyTeamActivity AS CR_DTA ON CR_DA.DailyTeamActivityID = CR_DTA.DailyTeamActivityID
	WHERE
		CR_DTA.GangName = @TeamName AND
		CONVERT(DATE, RDate) = @RDate AND
		--CR_AS.TimesBasic > 0
		CR_AS.AttendanceCode IN ('11', '51', 'J1','52','53','54','55','56', 'M1')

END









