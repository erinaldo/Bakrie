
/****** Object:  StoredProcedure [Checkroll].[DailyTeamActivityEditTeam]    Script Date: 9/9/2015 10:33:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[DailyTeamActivityEditTeam]
	@GangMasterID as varchar(50),
	@EstateID as varchar(50),
	@DailyTeamActivityID as varchar(50),
	@DDate as datetime
AS
BEGIN
		SELECT DISTINCT 
                         Checkroll.DailyTeamActivity.Id, Checkroll.DailyTeamActivity.DDate, Checkroll.DailyTeamActivity.DailyTeamActivityID, Checkroll.DailyTeamActivity.GangMasterID, Checkroll.DailyTeamActivity.EstateID, 
                         Checkroll.DailyTeamActivity.GangName, Checkroll.DailyTeamActivity.Activity, Checkroll.DailyTeamActivity.MandoreID, Checkroll.DailyTeamActivity.KraniID, Checkroll.DailyTeamActivity.MandorPremi, 
                         Checkroll.DailyTeamActivity.KraniPremi, Checkroll.DailyTeamActivity.ConcurrencyId, Checkroll.DailyTeamActivity.CreatedBy, Checkroll.DailyTeamActivity.CreatedOn, Checkroll.DailyTeamActivity.ModifiedBy, 
                         Checkroll.DailyTeamActivity.ModifiedOn, Checkroll.DailyGangEmployeeSetup.EmpID, Checkroll.GangMaster.Category, Checkroll.GangMaster.Descp, Checkroll.GangMasterBesar.GangMasterBesarID, 
                         Checkroll.CREmployee.EmpName, CREmployee_1.EmpName AS Mandor, CREmployee_2.EmpName AS Krani, CREmployee_3.EmpName AS MandorBesar, Checkroll.CREmployee.EmpCode, 
                         CREmployee_1.EmpCode AS MandorCode, CREmployee_2.EmpCode AS KraniCode, CREmployee_3.EmpCode AS MandorBesarCode
FROM            Checkroll.CREmployee AS CREmployee_3 RIGHT OUTER JOIN
                         Checkroll.GangMasterBesar ON CREmployee_3.EmpID = Checkroll.GangMasterBesar.GangMasterBesarID RIGHT OUTER JOIN
                         Checkroll.CREmployee INNER JOIN
                         Checkroll.DailyGangEmployeeSetup INNER JOIN
                         Checkroll.DailyTeamActivity ON Checkroll.DailyGangEmployeeSetup.DailyTeamActivityID = Checkroll.DailyTeamActivity.DailyTeamActivityID INNER JOIN
                         Checkroll.GangMaster ON Checkroll.DailyTeamActivity.GangMasterID = Checkroll.GangMaster.GangMasterID ON Checkroll.CREmployee.EmpID = Checkroll.DailyGangEmployeeSetup.EmpID LEFT OUTER JOIN
                         Checkroll.CREmployee AS CREmployee_1 ON Checkroll.DailyTeamActivity.MandoreID = CREmployee_1.EmpID LEFT OUTER JOIN
                         Checkroll.CREmployee AS CREmployee_2 ON Checkroll.DailyTeamActivity.KraniID = CREmployee_2.EmpID ON Checkroll.GangMasterBesar.GangMasterID = Checkroll.GangMaster.GangMasterID
WHERE        (Checkroll.DailyTeamActivity.GangMasterID = @GangMasterID 
AND Checkroll.DailyTeamActivity.EstateID = @EstateID 
AND Checkroll.DailyTeamActivity.DailyTeamActivityID = @DailyTeamActivityID
AND Checkroll.DailyTeamActivity.DDate = @DDate)
END



