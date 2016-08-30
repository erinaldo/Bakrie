
GO

/****** Object:  StoredProcedure [Checkroll].[CREstateMonthlyProductionReport]    Script Date: 5/10/2015 4:36:12 PM ******/
DROP PROCEDURE [Checkroll].[CREstateMonthlyProductionReport]
GO

/****** Object:  StoredProcedure [Checkroll].[CREstateMonthlyProductionReport]    Script Date: 5/10/2015 4:36:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ==============================================
--
-- Author      : Dadang Adi Hendradi     
-- Create date : Selasa, 5 Jan 2010, 00:22
--
-- Description :  Estate Monthly Production Report (EMP Report)
-- Modified By : Kumar
--	Modified Date : 09/07/2010
--  Modified By : Stanley
--	Modified Date : 29/06/2011
--  Descp: Adding EstateID and ActiveMonthYearID

-- ==============================================

CREATE PROCEDURE [Checkroll].[CREstateMonthlyProductionReport]
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
	
	
AS

SET NOCOUNT ON

Declare @Amonth int
Declare @Ayear Int

Select @Amonth =AMonth ,@Ayear =AYear 
From General.ActiveMonthYear 
where EstateID =@EstateID 
AND ActiveMonthYearID =@ActiveMonthYearID 
AND ModID = 1

SELECT
	--G_ESTATE.EstateName
	--,C_DISTB_SUM.EstateID
	G_DIV.DivName
	,G_YOP.YOP
	,
	(	SELECT SUM(G_BM.PlantedHect) 
		FROM General.BlockMaster AS G_BM
		WHERE
		G_BM.YOPID = C_DISTB_SUM.YOPID
	 ) AS NoOfHaInYOP
	 
	 ,
	(
	SELECT COADescp
	FROM 
		Accounts.COA
	WHERE 
		COACode = SUBSTRING(A_COA.COACode, 1, 4)
		AND EstateID = C_DISTB_SUM.EstateID
	) AS Activity

	,	
	(
	SELECT COADescp
	FROM 
		Accounts.COA
	WHERE 
		COACode = SUBSTRING(A_COA.COACode, 1, 6)
		AND EstateID = C_DISTB_SUM.EstateID
	)
	AS SubActivity
	
	--,A_COA.COADescp
	--,SUBSTRING(A_COA.COACode, 1, 6) AS COACode -- Acc Code diambil 6 Digit saja
	,A_COA .COACode 
	--,Ha = SUM(ISNULL(Ha, 0))
	--,Man = SUM(ISNULL(Man, 0))
	-- Standard
	,MHaStd = 0	
	--,MManStd = 0

		
	--,G_AMY .AMonth	
	--,G_AMY .AYear
	,
	(
	SELECT 
	 ISNULL(SUM (C_DSUM.Ha) ,0)
	FROM 
		Checkroll.DailyActivityDistribution AS C_DSUM
		INNER JOIN General .ActiveMonthYear G_AMY ON G_AMY .ActiveMonthYearID = C_DSUM .ActiveMonthYearID 
	WHERE
		COAID = C_DISTB_SUM.COAID
		AND C_DSUM.DivID = C_DISTB_SUM.DivID
		AND C_DSUM.YOPID = C_DISTB_SUM.YOPID
		AND G_AMY.AYear = @Ayear 
		AND G_AMY.AMonth = @Amonth
	GROUP BY
		C_DSUM.COAID
		
	) 
	AS MHa
	,
	(
	SELECT 
	 ISNULL(SUM (C_DSUM.Ha) ,0)
	FROM 
		Checkroll.DailyActivityDistribution AS C_DSUM
		INNER JOIN General .ActiveMonthYear G_AMY ON G_AMY .ActiveMonthYearID = C_DSUM .ActiveMonthYearID 
	WHERE
		COAID = C_DISTB_SUM.COAID
		AND C_DSUM.DivID = C_DISTB_SUM.DivID
		AND C_DSUM.YOPID = C_DISTB_SUM.YOPID
		AND G_AMY.AYear = @Ayear 
		AND G_AMY.AMonth <= @Amonth
	GROUP BY
		C_DSUM.COAID
		
	) 
	AS MHaYearToDate
	,
	(
	SELECT 
		ISNULL(	SUM (C_DSUM2.Mandays) ,0)
	FROM 
		Checkroll.DailyActivityDistribution AS C_DSUM2
		INNER JOIN General .ActiveMonthYear G_AMY ON G_AMY .ActiveMonthYearID = C_DSUM2 .ActiveMonthYearID 
	WHERE
		COAID = C_DISTB_SUM.COAID
		AND C_DSUM2.DivID = C_DISTB_SUM.DivID
		AND C_DSUM2.YOPID = C_DISTB_SUM.YOPID
		AND G_AMY.AYear = @Ayear 
		AND G_AMY.AMonth = @Amonth
	GROUP BY
		C_DSUM2.COAID
		
	) 
	AS MMan

	,
	(
	SELECT 
		ISNULL(	SUM (C_DSUM2.Mandays) ,0)
	FROM 
		Checkroll.DailyActivityDistribution AS C_DSUM2
		INNER JOIN General .ActiveMonthYear As G_AMY ON G_AMY .ActiveMonthYearID = C_DSUM2 .ActiveMonthYearID 
	WHERE
		COAID = C_DISTB_SUM.COAID
		AND C_DSUM2.DivID = C_DISTB_SUM.DivID
		AND C_DSUM2.YOPID = C_DISTB_SUM.YOPID
		AND AYear = @Ayear 
		AND AMonth <= @Amonth
	GROUP BY
		C_DSUM2.COAID
		
	) 
	AS MManYearToDate

	--,
	--(
	--SELECT 
	--	HaStdYearToDate = SUM (ISNULL(C_DSUM2.HaStd, 0)) 
	--FROM 
	--	Checkroll.DailyActivityDistribution AS C_DSUM2
	--WHERE
	--	COAID = C_DISTB_SUM.COAID
	--	AND C_DSUM2.DivID = C_DISTB_SUM.DivID
	--	AND C_DSUM2.YOPID = C_DISTB_SUM.YOPID
	--	AND AYear = C_DISTB_SUM.AYear
	--	AND AMonth <= C_DISTB_SUM.AMonth
	--GROUP BY
	--	C_DSUM2.COAID
		
	--) 
	,0 AS MHaStdYearToDate

	--,
	--(
	--SELECT 
	--	ManStdYearToDate = SUM (ISNULL(C_DSUM2.ManStd, 0)) 
	--FROM 
	--	Checkroll.DailyActivityDistribution AS C_DSUM2
	--WHERE
	--	COAID = C_DISTB_SUM.COAID
	--	AND C_DSUM2.DivID = C_DISTB_SUM.DivID
	--	AND C_DSUM2.YOPID = C_DISTB_SUM.YOPID
	--	AND AYear = C_DISTB_SUM.AYear
	--	AND AMonth <= C_DISTB_SUM.AMonth
	--GROUP BY
	--	C_DSUM2.COAID
		
	--)
	--0 AS MManStdYearToDate
	
-- Added by Stanley - 29-06-2009.b	
	,ISNULL(C_EMPR.Mandays, 0) AS MManStd
 
	,ISNULL(C_EMPR.Mandays, 0) AS MManStdYearToDate
	
	,G_AMY.AMonth AS ActiveMonth
	
	,G_AMY.AYear AS ActiveYear
-- Added by Stanley - 29-06-2009.e

FROM
	Checkroll.DailyActivityDistribution AS C_DISTB_SUM
	INNER JOIN General.Estate			AS G_ESTATE ON C_DISTB_SUM.EstateID = G_ESTATE.EstateID
	INNER JOIN General .ActiveMonthYear As G_AMY ON G_AMY .ActiveMonthYearID = C_DISTB_SUM .ActiveMonthYearID 
	LEFT JOIN General.Division			AS G_DIV ON C_DISTB_SUM.DivID = G_DIV.DivID
	LEFT JOIN General.YOP				AS G_YOP ON C_DISTB_SUM.YOPID = G_YOP.YOPID
	INNER JOIN Accounts.COA				AS A_COA ON C_DISTB_SUM.COAID = A_COA.COAID
-- Added by Stanley - 29-06-2009.e
	LEFT JOIN Checkroll.EMPRStandardRateSetup AS C_EMPR ON C_DISTB_SUM.EstateID = C_DISTB_SUM.EstateID
			AND C_EMPR.COAID = C_DISTB_SUM.COAID
			AND C_EMPR.DivID = C_DISTB_SUM.DivID
			AND C_EMPR.YOPID = C_DISTB_SUM.YOPID
-- Added by Stanley - 29-06-2009.e
--GROUP BY 
WHERE
	--(Ha <> 0 OR Ha IS not NULL) AND
	C_DISTB_SUM.EstateID = @EstateID 
	AND AMonth =@Amonth 
	AND AYear =@Ayear 
	AND C_DISTB_SUM .DivID IS NOT NULL
	AND C_DISTB_SUM .YOPID IS NOT NULL	
--	AND C_DISTB_SUM.EstateID = 'M1'	

GROUP BY
	G_ESTATE.EstateName
	,C_DISTB_SUM.EstateID
	,G_DIV.DivName
	,G_YOP.YOP
	,C_DISTB_SUM.YOPID
	,A_COA.COACode
	,A_COA.COADescp
	,G_AMY .AMonth
	,G_AMY .AYear
	, C_DISTB_SUM.COAID
	, C_DISTB_SUM.DivID
	,C_EMPR.ManDays

--select * from Checkroll.DailyActivityDistribution where Checkroll.DailyActivityDistribution.DivID is not null and Checkroll.DailyActivityDistribution.YOPID is not null
--select * from General.ActiveMonthYear 

ORDER BY DivName

GO


