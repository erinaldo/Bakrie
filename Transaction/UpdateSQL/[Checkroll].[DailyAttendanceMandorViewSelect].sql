
/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorViewSelect]    Script Date: 28/11/2014 15:47:52 ******/
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
	select Distinct Convert(Date,RDate)  as RDate from Checkroll.DailyAttendanceMandor where EstateID = @EstateID and Convert(DATE,RDate) = @RDate
END

GO


