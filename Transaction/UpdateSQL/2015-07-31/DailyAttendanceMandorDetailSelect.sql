
GO
/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorDetailSelect]    Script Date: 31/7/2015 11:41:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Checkroll].[DailyAttendanceMandorDetailSelect]
	-- Add the parameters for the stored procedure here
	@EstateId as nvarchar(50),
	@RDate as nvarchar(50)
AS
BEGIN
SELECT        Checkroll.DailyAttendanceMandor.ID, Checkroll.DailyAttendanceMandor.EstateID, Checkroll.DailyAttendanceMandor.ActiveMonthYearID, CONVERT(Date, 
                         Checkroll.DailyAttendanceMandor.RDate) AS RDate, Checkroll.DailyAttendanceMandor.EmpID, Checkroll.DailyAttendanceMandor.AttendanceSetupID, 
                         Checkroll.DailyAttendanceMandor.ConcurrencyId, Checkroll.DailyAttendanceMandor.CreatedBy, Checkroll.DailyAttendanceMandor.CreatedOn, 
                         Checkroll.DailyAttendanceMandor.ModifiedBy, Checkroll.DailyAttendanceMandor.ModifiedOn, Checkroll.CREmployee.EmpName, 
                         Checkroll.AttendanceSetup.AttendanceCode, Checkroll.DailyAttendanceMandor.DailyOt, General.EmpJobDescription.Description, ISNull(Checkroll.DailyAttendanceMandor.KraniPremiKg,0) as KraniPremiKg
FROM            General.EmpJobDescription INNER JOIN
                         Checkroll.CREmployee ON General.EmpJobDescription.Id = Checkroll.CREmployee.EmpJobDescriptionId RIGHT OUTER JOIN
                         Checkroll.DailyAttendanceMandor LEFT OUTER JOIN
                         Checkroll.AttendanceSetup ON Checkroll.DailyAttendanceMandor.AttendanceSetupID = Checkroll.AttendanceSetup.AttendanceSetupID ON 
                         Checkroll.CREmployee.EmpID = Checkroll.DailyAttendanceMandor.EmpID
WHERE        (Checkroll.DailyAttendanceMandor.EstateID = @EstateId) AND (CONVERT(DATE, Checkroll.DailyAttendanceMandor.RDate) = @RDate)
END



