/****** Object:  StoredProcedure [Checkroll].[DailyActivityDistributionWithTeamSelect]    Script Date: 11/10/2015 10:39:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
--
-- Author        : Dadang Adi Hendradi
-- Create date   : <9 Oct 2009,,>
-- Modifed date  : Sunday, 18 Oct 2009, 16:33>
-- Modified date : Senin, 26 Oct 2009, 21:09
-- Modified      : Selasa, 27 Oct 2009, 22:09
-- Modified      : Kamis, 19 Nov 2009, 16:39
-- Description   :
--
-- =============================================

ALTER PROCEDURE [Checkroll].[DailyActivityDistributionWithTeamSelect]
@EstateID nvarchar(50),
@TeamName nvarchar(50),
@DistbDate nvarchar(50)
AS
BEGIN
	SELECT DISTINCT
		CR_DAD.DistbDate,
		CR_DTA.GangName, 
		TotalHK = ISNULL(CR_DAD.TotalHK, 0), 
		TotalOT = ISNULL(CR_DAD.TotalOT, 0), 
		G_CM.ContractNo,
		A_COA.COACode, 
		--A_COA.COADescp, 
		Checkroll.ConcatenateActivityCOA(A_CoA.COAID) as COADescp,
		A_COA.OldCOACode ,
		
		
		A_COAOvertime.COACode AS [OvertimeCOACode],
		A_COAOvertime.OldCOACode AS [OTOldCOACode],
		
		A_COAOvertime.COADescp AS [OvertimeCOADescp],
	--	Checkroll.ConcatenateActivityCOA(A_COAOvertime.COAID) as OvertimeCOADescp,
		G_BM.BlockName,
		G_DIV.DivName, 
		G_YOP.YOP, 
		P_ST.StationDescp,
		P_ST.StationCode,
		CR_DAD.Mandays, 
		CR_DAD.OT, 
		CR_DAD.Ha, 

		G_TA0.TValue As TAnalysisCode_T0,
		G_TA1.TValue AS TAnalysisCode_T1,
		G_TA2.TAnalysisCode AS TAnalysisCode_T2,
		G_TA3.TValue AS TAnalysisCode_T3,
		G_TA4.TValue AS TAnalysisCode_T4,

		CR_DAD.DailyDistributionID, 
		CR_DAD.EstateID, 
		CR_DAD.DailyReceiptionID,
		CR_DAD.ActiveMonthYearID, 
		CR_DAD.GangMasterID,
		CR_DAD.ContractID, 
		CR_DAD.COAID, 
		CR_DAD.OvertimeCOAID, -- 19 Nov 2009, 16:46
		CR_DAD.StationID,
		CR_DAD.DivID, 
		CR_DAD.YOPID, 
		CR_DAD.BlockID,
		CR_DAD.T0, -- Ini adalah TAnalysisID
		CR_DAD.T1, 
		CR_DAD.T2, 
		CR_DAD.T3, 
		CR_DAD.T4,
		--CR_DAD.UOMID, 
		CR_DAD.CreatedBy,
		CR_DAD.CreatedOn,
		CR_DAD.ModifiedBy,
		CR_DAD.ModifiedOn ,
		G_ESTATE.EstateCode, 
		--G_UOM.UOM,
		G_TA0.TAnalysisDescp AS TAnalysisDescp_T0,
		G_TA1.TAnalysisDescp AS TAnalysisDescp_T1,
		G_TA2.TAnalysisDescp AS TAnalysisDescp_T2,
		G_TA3.TAnalysisDescp AS TAnalysisDescp_T3,
		G_TA4.TAnalysisDescp AS TAnalysisDescp_T4,
	    CR_DAD.Brondolan,
	    P_MM.MachineID,
	    P_MM.MachineCode,
	    P_MM.MachineName,
		CR_DAD.VHID as VehicleId,VH.VHWSCode as VehicleCode ,VH.VHDescp as VehicleDesc, 
		VHD.VHDetailCostCodeID as DetailCostId,VHD.VHDetailCostCode as DetailCostCode, VHD.VHDescp as DetailCostDesc
	FROM
		Checkroll.DailyActivityDistribution AS CR_DAD
		INNER JOIN Checkroll.DailyTeamActivity AS CR_DTA on CR_DAD.GangMasterID = CR_DTA.GangMasterID
		LEFT JOIN General.ContractMaster AS G_CM on CR_DAD.ContractID = G_CM.ContractID
		INNER JOIN Accounts.COA AS A_COA on CR_DAD.COAID = A_COA.COAID
		LEFT JOIN Accounts.COA AS A_COAOvertime ON CR_DAD.OvertimeCOAID = A_COAOvertime.COAID
		
		LEFT JOIN General.Division AS G_DIV on CR_DAD.DivID = G_DIV.DivID
		INNER JOIN General.Estate AS G_ESTATE on CR_DAD.EstateID = G_ESTATE.EstateID
		LEFT JOIN General.YOP AS G_YOP on CR_DAD.YOPID = G_YOP.YOPID
		LEFT JOIN General.BlockMaster AS G_BM on CR_DAD.BlockID = G_BM.BlockID
		LEFT JOIN Production.Station AS P_ST on CR_DAD.StationID = P_ST.StationID
		LEFT JOIN General.UOM AS G_UOM on CR_DAD.UOMID = G_UOM.UOMID

		LEFT JOIN General.TAnalysis AS G_TA0 on CR_DAD.T0 = G_TA0.TAnalysisID
		LEFT JOIN General.TAnalysis AS G_TA1 on	CR_DAD.T1 = G_TA1.TAnalysisID
		LEFT JOIN General.TAnalysis AS G_TA2 on	CR_DAD.T2 = G_TA2.TAnalysisID
		LEFT JOIN General.TAnalysis AS G_TA3 on CR_DAD.T3 = G_TA3.TAnalysisID
		LEFT JOIN General.TAnalysis AS G_TA4 on CR_DAD.T4 = G_TA4.TAnalysisID
		LEFT JOIN Production.MachineryMaster AS P_MM on CR_DAD.MachineID = P_MM.MachineID
		LEft join Vehicle.VHMaster as VH on CR_DAD.VHID = VH.VHID 
		LEft Join Vehicle.VHDetailCostCode as VHD on CR_DAD.VHDetailCostCodeID = VHD.VHDetailCostCodeID

		--INNER JOIN Checkroll.DailyAttendance AS CR_DA on CR_DAD.GangMasterID = CR_DA.GangMasterID
	
	WHERE
		CR_DAD.EstateID = @EstateID AND
		CONVERT(DATE, CR_DAD.DistbDate) = @DistbDate AND
		CR_DTA.GangName = @TeamName
END
