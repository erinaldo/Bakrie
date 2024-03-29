
/****** Object:  StoredProcedure [Checkroll].[CRTHRPaymentReport]    Script Date: 19/1/2016 3:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Checkroll].[CRBonusPaymentReport]

	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
	
AS

SELECT 
	
	DISTINCT C_EMP.EmpCode
	,C_EMP.EmpName
	,C_BNS.ProcessingDate
	,C_GM.GangName
	,C_GM.Category
	,C_EMP.MaritalStatus
	,C_EMP.DOJ
	,DATEDIFF(Year, C_EMP.DOJ, C_BNS.ProcessingDate) AS MasaKerjaDalamTahun
	,Ceiling(Convert(numeric(18,3),DATEDIFF(Day, C_EMP.DOJ, C_BNS.ProcessingDate))/30)  AS MasaKerjaDalamBulan
	,C_BNS.Bruto
	,ISNULL(C_BNS.DedIncomeTax, 0) AS DedIncomeTax
	,ISNULL(C_BNS.DedCooper, 0) AS DedCooper
	,ISNULL(C_BNS.DedOthers, 0) AS DedOthers
	,Netto
	,RoundUP
	,C_EMP.Category
	,G_ESTATE.EstateName
	,C_BNS.EstateID
	,C_EMP.Gender
	,C_BNS.ActiveMonthYearID
	,C_BNS.YearPeriod
	,G_AMY.AMonth
	,C_BNS.DagingNatura
	,C_BNS.berasNatura
	,C_EMP.BankID
	,C_EMP.BankAccountNo
FROM
Checkroll.Bonus AS C_BNS
INNER JOIN Checkroll.CREmployee AS C_EMP ON C_BNS.EmpID = C_EMP.EmpID
INNER JOIN Checkroll.Salary AS C_SAL ON C_BNS.EmpID = C_SAL.EmpID AND C_BNS.ActiveMonthYearID = C_SAL.ActiveMonthYearID
LEFT JOIN Checkroll.DailyTeamActivity AS C_DTA ON C_SAL.GangMasterID = C_DTA.GangMasterID
LEFT JOIN Checkroll.GangMaster AS C_GM ON C_SAL.GangMasterID = C_GM.GangMasterID

INNER JOIN General.Estate AS G_ESTATE ON C_BNS.EstateID = G_ESTATE.EstateID
INNER JOIN General.ActiveMonthYear AS G_AMY ON C_BNS.ActiveMonthYearID = G_AMY.ActiveMonthYearID
where C_BNS.EstateID = @EstateID 
	AND C_BNS.ActiveMonthYearID = @ActiveMonthYearID
