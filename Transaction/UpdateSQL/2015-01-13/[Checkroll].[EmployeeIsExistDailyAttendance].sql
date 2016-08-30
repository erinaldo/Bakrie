
GO

/****** Object:  StoredProcedure [Checkroll].[EmployeeIsExistDailyAttendance]    Script Date: 13/01/2015 11:52:28 ******/

/****** Object:  StoredProcedure [Checkroll].[EmployeeIsExistDailyAttendance]    Script Date: 13/01/2015 11:52:28 ******/
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
	@EmpID as varchar(50)
AS
BEGIN
	select * from Checkroll.DailyAttendance where EmpID = @EmpID and EstateID = @EstateID
END

GO


