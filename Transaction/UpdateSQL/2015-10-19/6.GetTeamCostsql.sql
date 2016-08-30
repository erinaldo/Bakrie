

/****** Object:  UserDefinedFunction [Checkroll].[GetEmployeeDailyRate]    Script Date: 19/10/2015 11:36:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [Checkroll].[GetTeamActualDailyRate] (
	@GangMasterId nvarchar(50),@DDate as date)
RETURNS numeric(18,4)
AS
BEGIN
	DECLARE @Rate as numeric(18,4)
	select @Rate = Sum(IsNull(Checkroll.GetEmployeeDailyRate(a.EmpID),0))/ Count(a.empid) from checkroll.DailyGangEmployeeSetup a
inner join Checkroll.DailyAttendance b on a.DailyTeamActivityID = b.DailyTeamActivityID and a.EmpID = b.EmpID
inner join Checkroll.AttendanceSetup c on b.AttendanceSetupID = c.AttendanceSetupID
where BasicPay = 'Y' and a.GangMasterID = @GangMasterId and a.DDAte = @DDate
			
	RETURN (@Rate);	
END;



GO


