
-- =============================================
-- Author:		Sai Sidharth
-- Create date: 7/7/2015
-- Description:	Update Daily Attendance with new TotalOTValue
-- =============================================

CREATE PROCEDURE Checkroll.DailyAttendanceUpdateOTValue
	-- Add the parameters for the stored procedure here
	@Id bigint,
	@TotalOT numeric(18,2)
AS
BEGIN
	
    UPDATE Checkroll.DailyAttendance SET TotalOTValue = @TotalOT where id = @Id

END
GO
