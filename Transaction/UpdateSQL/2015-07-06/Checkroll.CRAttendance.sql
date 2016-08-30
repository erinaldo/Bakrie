
/****** Object:  StoredProcedure [Checkroll].[CRAttendanceHK]    Script Date: 6/7/2015 6:11:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [Checkroll].[CRAttendanceHK]
@EstateID nvarchar(50)

AS
BEGIN

	SELECT CR_AS.AttendanceSetupID  ,CR_AS.TimesBasic 
	FROM 
		 Checkroll.AttendanceSetup AS CR_AS 
		WHERE
		CR_AS.AttendanceCode IN ('11', '51', 'J1','52','53','54','55','56', 'M1')
		AND EstateID =@EstateID
END










