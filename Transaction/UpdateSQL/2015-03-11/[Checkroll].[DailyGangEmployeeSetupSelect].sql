
GO

/****** Object:  StoredProcedure [Checkroll].[DailyGangEmployeeSetupSelect]    Script Date: 11/03/2015 17:05:05 ******/
DROP PROCEDURE [Checkroll].[DailyGangEmployeeSetupSelect]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyGangEmployeeSetupSelect]    Script Date: 11/03/2015 17:05:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Muhamad Ramandani Si Ganteng Kalem>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyGangEmployeeSetupSelect]
	@GangMasterID as varchar(50),
	@EstateID as varchar(50)
AS
BEGIN
	Select * from Checkroll.DailyGangEmployeeSetup 
	where GangMasterID = @GangMasterID and EstateID = @EstateID
END

GO


