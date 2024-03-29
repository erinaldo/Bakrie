
/****** Object:  StoredProcedure [Checkroll].[CRTHRPaymentReport]    Script Date: 19/1/2016 3:19:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================
--
-- Author      : Dadang Adi Hendradi     
-- Create date : Selasa, 29 Dec 2009, 10:13
--
-- Description :  THRPaymentReport
--
--Modified     : Sabtu, 13 Feb 2010, 00:24
--               Penambahan field
--               - Netto
--               - RoundUP
-- Modified By : Kumar
--	Modified Date : 09/07/2010
--  Descp: Adding EstateID and ActiveMonthYearID
-- Modified By : Stanley
--	Modified Date : 22/07/2011
-- ==============================================
ALTER PROCEDURE [Checkroll].[CRTHRPaymentReport]

	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
	
AS

SELECT 
	
	DISTINCT C_EMP.EmpCode
	,C_EMP.EmpName
	,C_THR.ProcessingDate
	,C_GM.GangName
	,C_GM.Category
	,C_EMP.MaritalStatus
	,C_EMP.DOJ
	,DATEDIFF(Year, C_EMP.DOJ, C_THR.ProcessingDate) AS MasaKerjaDalamTahun
	,Ceiling(Convert(numeric(18,3),DATEDIFF(Day, C_EMP.DOJ, C_THR.ProcessingDate))/30)  AS MasaKerjaDalamBulan
	,C_THR.Bruto
	,ISNULL(C_THR.DedIncomeTax, 0) AS DedIncomeTax
	,ISNULL(C_THR.DedCooper, 0) AS DedCooper
	,ISNULL(C_THR.DedOthers, 0) AS DedOthers
	,Netto
	,RoundUP
	,C_EMP.Category
	,G_ESTATE.EstateName
	,C_THR.EstateID
	,C_EMP.Gender
	,C_THR.ActiveMonthYearID
	,C_THR.YearPeriod
	,G_AMY.AMonth
	,C_THR.DagingNatura
	,C_THR.berasNatura
	,C_EMP.BankID
	,C_EMP.BankAccountNo
FROM
Checkroll.THR AS C_THR
INNER JOIN Checkroll.CREmployee AS C_EMP ON C_THR.EmpID = C_EMP.EmpID
INNER JOIN Checkroll.Salary AS C_SAL ON C_THR.EmpID = C_SAL.EmpID AND C_THR.ActiveMonthYearID = C_SAL.ActiveMonthYearID
LEFT JOIN Checkroll.DailyTeamActivity AS C_DTA ON C_SAL.GangMasterID = C_DTA.GangMasterID
LEFT JOIN Checkroll.GangMaster AS C_GM ON C_SAL.GangMasterID = C_GM.GangMasterID

INNER JOIN General.Estate AS G_ESTATE ON C_THR.EstateID = G_ESTATE.EstateID
INNER JOIN General.ActiveMonthYear AS G_AMY ON C_THR.ActiveMonthYearID = G_AMY.ActiveMonthYearID
where C_THR.EstateID = @EstateID 
	AND C_THR.ActiveMonthYearID = @ActiveMonthYearID
