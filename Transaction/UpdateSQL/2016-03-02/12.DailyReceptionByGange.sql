
/****** Object:  StoredProcedure [Checkroll].[CRDailyReceiptionWithTeamByGangeReport]    Script Date: 4/3/2016 9:06:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--==============================================================
--
-- Author     : Ahmed Nazim
-- Created on : 16 April 2013
-- Place      : Kuala Lumpur
-- For reporting - DailyReceiptionWithTeamReport
--
--==============================================================
ALTER PROCEDURE [Checkroll].[CRDailyReceiptionWithTeamByGangeReport]
@EstateID nvarchar(50),
@ActiveMonthYearID nvarchar(50),
@RDate smalldatetime,
@Gang nvarchar(50),
@User nvarchar(50)
AS
SELECT 
	C_DA.RDate
	,G_ESTATE.EstateName
	,C_EMPMandor.EmpName AS MandorName
	,C_EMPKrani.EmpName AS KraniName
	,C_GM.GangName
	,C_EMP.EmpCode
	,C_EMP.EmpName
	,C_AS.AttendanceCode
	,G_BM.BlockName
	,G_TPH.TPH
	,Sum(C_DRWT.Ha) as Ha
	,SUM(C_DRWT.UnripeNormal) as N_MH
	,SUM(C_DRWT.UnderRipeNormal) as N_KM
	,SUM(C_DRWT.OverRipeNormal) as N_TM
	,SUM(C_DRWT.RipeNormal) as N_MTG
	,SUM(C_DRWT.LooseFruitNormal) as N_BRD
	,SUM(C_DRWT.DiscardedNormal) as N_BB
	,SUM(C_DRWT.UnripeBorongan) as B_MH
	,SUM(C_DRWT.UnderRipeBorongan) as B_KM
	,SUM(C_DRWT.OverRipeBorongan) as B_TM
	,SUM(C_DRWT.RipeBorongan) as B_MTG
	,SUM(C_DRWT.LooseFruitBorongan) as B_BRD
	,SUM(C_DRWT.DiscardedBorongan) as B_BB
FROM
Checkroll.DailyAttendance AS C_DA 
LEFT JOIN Checkroll.DailyReceiption AS C_DR ON C_DA.DailyReceiptionID = C_DR.DailyReceiptionID
INNER JOIN Checkroll.DailyReceptionWithTeam AS C_DRWT ON C_DRWT.DailyReceiptionDetID=C_DR.DailyReceiptionDetID
INNER JOIN Checkroll.DailyTeamActivity AS C_DTA ON C_DA.DailyTeamActivityID = C_DTA.DailyTeamActivityID
INNER JOIN Checkroll.GangMaster AS C_GM ON C_DTA.GangMasterID = C_GM.GangMasterID
INNER JOIN Checkroll.CREmployee AS C_EMPMandor ON C_DTA.MandoreID = C_EMPMandor.EmpID
INNER JOIN Checkroll.CREmployee AS C_EMPKrani ON C_DTA.KraniID = C_EMPKrani.EmpID
INNER JOIN Checkroll.CREmployee AS C_EMP ON C_DA.EmpID = C_EMP.EmpID
LEFT JOIN General.BlockMaster AS G_BM ON C_DR.BlockID = G_BM.BlockID
LEFT JOIN Production.Station AS P_STATION ON C_DR.StationID = P_STATION.StationID
INNER JOIN General.Estate AS G_ESTATE ON C_DA.EstateID = G_ESTATE.EstateID
INNER JOIN Checkroll.AttendanceSetup AS C_AS ON C_DA.AttendanceSetupID = C_AS.AttendanceSetupID
INNER JOIN General.TPHMaster AS G_TPH ON (C_DRWT.TphNormal = G_TPH.TPH OR C_DRWT.TphBorongan = G_TPH.TPH) AND C_DR.BlockID = G_TPH.BlockID
WHERE C_DA.EstateID = @EstateID AND ActiveMonthYearID = @ActiveMonthYearID AND RDate = @RDate AND C_GM.GangName = @Gang
GROUP BY C_DA.RDate
	,G_ESTATE.EstateName
	,C_EMPMandor.EmpName
	,C_EMPKrani.EmpName 
	,C_GM.GangName
	,C_EMP.EmpCode
	,C_EMP.EmpName
	,C_AS.AttendanceCode
	,G_BM.BlockName
	,G_TPH.TPH
ORDER BY C_EMP.EmpName
