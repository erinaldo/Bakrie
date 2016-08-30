

/****** Object:  StoredProcedure [Checkroll].[DailyTeamActivityEditTeam]    Script Date: 20/03/2015 16:04:35 ******/
DROP PROCEDURE [Checkroll].[DailyTeamActivityEditTeam]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyTeamActivityEditTeam]    Script Date: 20/03/2015 16:04:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyTeamActivityEditTeam]
	@GangMasterID as varchar(50),
	@EstateID as varchar(50),
	@DailyTeamActivityID as varchar(50),
	@DDate as datetime
AS
BEGIN
		SELECT      distinct  Checkroll.DailyTeamActivity.Id, Checkroll.DailyTeamActivity.DDate, Checkroll.DailyTeamActivity.DailyTeamActivityID, Checkroll.DailyTeamActivity.GangMasterID, 
                         Checkroll.DailyTeamActivity.EstateID, Checkroll.DailyTeamActivity.GangName, Checkroll.DailyTeamActivity.Activity, Checkroll.DailyTeamActivity.MandoreID, 
                         Checkroll.DailyTeamActivity.KraniID, Checkroll.DailyTeamActivity.MandorPremi, Checkroll.DailyTeamActivity.KraniPremi, Checkroll.DailyTeamActivity.ConcurrencyId, 
                         Checkroll.DailyTeamActivity.CreatedBy, Checkroll.DailyTeamActivity.CreatedOn, Checkroll.DailyTeamActivity.ModifiedBy, Checkroll.DailyTeamActivity.ModifiedOn, 
                         Checkroll.GangMasterBesar.GangMasterBesarID, Checkroll.GangMaster.Category, Checkroll.GangMaster.Descp, Checkroll.DailyGangEmployeeSetup.EmpID, 
                         Checkroll.CREmployee.EmpName AS MandorBesar, CREmployee_1.EmpName AS Mandor, CREmployee_3.EmpName AS Krani, CREmployee_2.EmpName
FROM            Checkroll.CREmployee AS CREmployee_1 RIGHT OUTER JOIN
                         Checkroll.CREmployee AS CREmployee_3 RIGHT OUTER JOIN
                         Checkroll.DailyTeamActivity ON CREmployee_3.EmpID = Checkroll.DailyTeamActivity.KraniID ON 
                         CREmployee_1.EmpID = Checkroll.DailyTeamActivity.MandoreID LEFT OUTER JOIN
                         Checkroll.DailyGangEmployeeSetup LEFT OUTER JOIN
                         Checkroll.CREmployee AS CREmployee_2 ON Checkroll.DailyGangEmployeeSetup.EmpID = CREmployee_2.EmpID ON 
                         Checkroll.DailyTeamActivity.GangMasterID = Checkroll.DailyGangEmployeeSetup.GangMasterID LEFT OUTER JOIN
                         Checkroll.GangMaster ON Checkroll.DailyTeamActivity.GangMasterID = Checkroll.GangMaster.GangMasterID LEFT OUTER JOIN
                         Checkroll.GangMasterBesar LEFT OUTER JOIN
                         Checkroll.CREmployee ON Checkroll.GangMasterBesar.GangMasterBesarID = Checkroll.CREmployee.EmpID ON 
                         Checkroll.DailyTeamActivity.GangMasterID = Checkroll.GangMasterBesar.GangMasterID
WHERE        (Checkroll.DailyTeamActivity.GangMasterID = @GangMasterID 
AND Checkroll.DailyTeamActivity.EstateID = @EstateID 
AND Checkroll.DailyTeamActivity.DailyTeamActivityID = @DailyTeamActivityID
AND Checkroll.DailyTeamActivity.DDate = @DDate)
END



GO


