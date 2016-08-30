
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorDetailSelect]    Script Date: 23/12/2014 16:02:43 ******/
DROP PROCEDURE [Checkroll].[DailyAttendanceMandorDetailSelect]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorDetailSelect]    Script Date: 23/12/2014 16:02:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyAttendanceMandorDetailSelect]
	-- Add the parameters for the stored procedure here
	@EstateId as nvarchar(50),
	@RDate as nvarchar(50)
AS
BEGIN
SELECT        Checkroll.DailyAttendanceMandor.ID, Checkroll.DailyAttendanceMandor.EstateID, Checkroll.DailyAttendanceMandor.ActiveMonthYearID, CONVERT(Date, 
                         Checkroll.DailyAttendanceMandor.RDate) AS RDate, Checkroll.DailyAttendanceMandor.EmpID, Checkroll.DailyAttendanceMandor.AttendanceSetupID, 
                         Checkroll.DailyAttendanceMandor.ConcurrencyId, Checkroll.DailyAttendanceMandor.CreatedBy, Checkroll.DailyAttendanceMandor.CreatedOn, 
                         Checkroll.DailyAttendanceMandor.ModifiedBy, Checkroll.DailyAttendanceMandor.ModifiedOn, Checkroll.CREmployee.EmpName, 
                         Checkroll.AttendanceSetup.AttendanceCode, Checkroll.DailyAttendanceMandor.DailyOt
FROM            Checkroll.DailyAttendanceMandor LEFT OUTER JOIN
                         Checkroll.AttendanceSetup ON Checkroll.DailyAttendanceMandor.AttendanceSetupID = Checkroll.AttendanceSetup.AttendanceSetupID LEFT OUTER JOIN
                         Checkroll.CREmployee ON Checkroll.DailyAttendanceMandor.EmpID = Checkroll.CREmployee.EmpID
WHERE        (Checkroll.DailyAttendanceMandor.EstateID = @EstateId) AND (CONVERT(DATE, Checkroll.DailyAttendanceMandor.RDate) = @RDate)
END


GO


