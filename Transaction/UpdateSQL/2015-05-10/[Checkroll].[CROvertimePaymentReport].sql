
GO

/****** Object:  StoredProcedure [Checkroll].[CROvertimePaymentReport]    Script Date: 5/10/2015 4:35:36 PM ******/
DROP PROCEDURE [Checkroll].[CROvertimePaymentReport]
GO

/****** Object:  StoredProcedure [Checkroll].[CROvertimePaymentReport]    Script Date: 5/10/2015 4:35:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











--==============================================================
--
-- Author     : Dadang Adi Hendradi
-- Created on : Rabu, 23 Dec 2009, 13:52
-- Place      : Kuala Lumpur
--
-- update     : Kamis, 11 Feb 2010, 23:38
-- place      : Kebun Perdana
--              OT Payment dijadikan ROUNDUP(OTValue1 + OTValue2 + OTValue3 + OTValue4)
-- For reporting - OvertimePaymentReport
--
-- update     : Rabu, 17 Mar 2010, 23:45
--              report ini dijakian rekap overtime utk masing2 orang
--
-- Modified By : Kumar
--	Modified Date : 15/07/2010
--  Descp: Adding EstateID and ActiveMonthYearID
--==============================================================
CREATE PROCEDURE [Checkroll].[CROvertimePaymentReport]
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)


AS
SELECT DISTINCT
	C_OTD.EstateID
	,G_ESTATE.EstateName
	--,C_DA.ActiveMonthYearID
	,C_GM.GangName
	,C_EMP.EmpCode
	,C_EMP.EmpName
	,OT1 = SUM(ISNULL(C_OTD.OT1,0))
	,OT2 = SUM(ISNULL(C_OTD.OT2,0))
	,OT3 = SUM(ISNULL(C_OTD.OT3,0))
	,OT4 = SUM(ISNULL(C_OTD.OT4,0))
	---Modified by kumar
	--,TotalOTHours = (C_DA.TotalOT)
	,TotalOTHours = SUM(ISNULL(C_OTD.OT1,0)) +SUM(ISNULL(C_OTD.OT2,0))+SUM(ISNULL(C_OTD.OT3,0))+SUM(ISNULL(C_OTD.OT4,0))
	,TotalOTPayment = SUM(ISNULL(C_OTD.OTValue1,0)) +SUM(ISNULL(C_OTD.OTValue2 ,0))+SUM(ISNULL(C_OTD.OTValue3 ,0))+SUM(ISNULL(C_OTD.OTValue4 ,0))
	,TotalOTP = SUM(ISNULL(C_OTD.OTValue1,0)) +SUM(ISNULL(C_OTD.OTValue2 ,0))+SUM(ISNULL(C_OTD.OTValue3 ,0))+SUM(ISNULL(C_OTD.OTValue4 ,0))	

FROM
	Checkroll.OTDetail AS C_OTD
	INNER JOIN Checkroll.CREmployee AS C_EMP ON C_OTD.EmpID = C_EMP.EmpID
		--AND C_DA.RDate = C_OTD.ADate
	INNER JOIN Checkroll.GangMaster AS C_GM ON C_OTD.GangMasterID = C_GM.GangMasterID
	INNER JOIN General.Estate AS G_ESTATE ON C_OTD.EstateID = G_ESTATE.EstateID
	--INNER JOIN General.ActiveMonthYear AS G_AMY ON C_DA.ActiveMonthYearID = G_AMY.ActiveMonthYearID
WHERE C_OTD.EstateID= @EstateID 
	AND C_OTD.ActiveMonthYearID = @ActiveMonthYearID 
GROUP BY
	C_OTD.EstateID
	,G_ESTATE.EstateName
	,C_GM.GangName
	,C_EMP.EmpCode
	,C_EMP.EmpName
	--HAVING SUM(ISNULL(C_OTD.OTValue1,0)) +SUM(ISNULL(C_OTD.OTValue2 ,0))+SUM(ISNULL(C_OTD.OTValue3 ,0))+SUM(ISNULL(C_OTD.OTValue4 ,0))<>0 
	HAVING SUM(ISNULL(OT1,0)+ISNULL(OT2 ,0)+ISNULL(OT3 ,0)+ISNULL(OT4 ,0)) <>0 






GO


