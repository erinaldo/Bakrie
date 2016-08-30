
GO

/****** Object:  StoredProcedure [Checkroll].[EmployeeIsExistDailyAttendance]    Script Date: 20/01/2015 8:22:56 ******/
DROP PROCEDURE [Checkroll].[EmployeeIsExistDailyAttendance]
GO

/****** Object:  StoredProcedure [Checkroll].[EmployeeIsExistDailyAttendance]    Script Date: 20/01/2015 8:22:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[EmployeeIsExistDailyAttendance]
	@EstateID as varchar(50),
	@EmpID as varchar(50),
	@RDate as datetime
AS
BEGIN 
	select * from Checkroll.DailyAttendance where EmpID = @EmpID and RDate = @RDate and EstateID = @EstateID
END

GO


