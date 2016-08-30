
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorViewSelect]    Script Date: 3/22/2015 2:51:24 PM ******/
DROP PROCEDURE [Checkroll].[DailyAttendanceMandorViewSelect]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorViewSelect]    Script Date: 3/22/2015 2:51:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyAttendanceMandorViewSelect]
	-- Add the parameters for the stored procedure here
	@EstateID as nvarchar(50),
	@RDate as nvarchar(50)
AS
BEGIN
	IF @RDate is null
	select Distinct Convert(Date,RDate) as RDate from Checkroll.DailyAttendanceMandor where EstateID = @EstateID
	Else
	select Distinct Convert(Date,RDate)  as RDate from Checkroll.DailyAttendanceMandor where EstateID = 'M2' and DATEADD(MONTH, DATEDIFF(MONTH, 0, RDate), 0)  = DATEADD(MONTH, DATEDIFF(MONTH, 0, @RDate), 0) 
END


GO


