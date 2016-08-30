
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorBeforeInsert]    Script Date: 04/12/2014 10:23:34 ******/
DROP PROCEDURE [Checkroll].[DailyAttendanceMandorBeforeInsert]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorBeforeInsert]    Script Date: 04/12/2014 10:23:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyAttendanceMandorBeforeInsert]
	@EstateID as nvarchar(50),
	@RDate as datetime
AS
BEGIN
	Declare @Check as integer
	select @Check = count(Distinct Convert(Date,RDate))  from Checkroll.DailyAttendanceMandor where EstateID = @EstateID and Convert(DATE,RDate) = @RDate
	if @Check <> 0
	Begin
		Delete From Checkroll.DailyAttendanceMandor where Convert(DATE,RDate) = @RDate
	END
END

GO


