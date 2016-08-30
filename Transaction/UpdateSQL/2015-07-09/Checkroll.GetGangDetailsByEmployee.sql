SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Retrieves GangDetails for Mandor, Krani or Mandor Besar so that it can be saved in the OT table.

CREATE PROCEDURE Checkroll.GetGangDetailsByEmployee
	@EstateID nvarchar(50),
    @EmpID nvarchar(50),
	@DDate datetime
AS
BEGIN
	
	SELECT TOP 1 DTA.GangMasterID,DTA.Activity,DTA.DDate,DTA.MandoreID,DTA.KraniID,DTA.MandorBesarID from DailyTeamActivity DTA WHere MandoreID = @EmpID OR KraniID = @EmpID OR MandorBesarID = @EmpID
	
END
GO
