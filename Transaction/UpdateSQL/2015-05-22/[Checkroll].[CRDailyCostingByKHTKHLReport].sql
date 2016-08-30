
GO

/****** Object:  StoredProcedure [Checkroll].[CRDailyCostingByKHTKHLReport]    Script Date: 5/17/2015 7:21:06 PM ******/
DROP PROCEDURE [Checkroll].[CRDailyCostingByKHTKHLReport]
GO

/****** Object:  StoredProcedure [Checkroll].[CRDailyCostingByKHTKHLReport]    Script Date: 5/17/2015 7:21:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--==============================================================      
-- Author   : SIVA       
-- Created on  : 30-11-2010      
-- Modified By  : Palani    
-- Modified On  : 25-June-2011    
-- Place   : Samarinda    
-- For reporting : Daily Costing Report     
--==============================================================      
    
CREATE procedure [Checkroll].[CRDailyCostingByKHTKHLReport]      
      
@EstateID nvarchar(50),      
@FromDate Date,      
@Todate Date,      
@ActiveMonthYearID nvarchar(50),      
@Amonth int,      
@AYear int,
@Category nvarchar(50)
  
AS      

BEGIN
	DECLARE @ActiveMonthYearIDST nvarchar(50)      
	SELECT @ActiveMonthYearIDST =ActiveMonthYearID  FROM  General .ActiveMonthYear G_AMY WHERE AMonth =@Amonth AND AYear =@AYear  AND ModID =2 AND EstateID =@EstateID      
	      
	IF @Category = 'KHT' 
		BEGIN
			SELECT       
			 C_DAD.DailyDistributionID ,      
			 (      
			  SELECT COADescp      
			  FROM       
			   Accounts.COA      
			  WHERE       
			   COACode = SUBSTRING(A_COA.COACode, 1, 4)      
			   AND EstateID = C_DAD.EstateID      
			 ) + ' - ' +
			 (      
			  SELECT COADescp      
			  FROM       
			   Accounts.COA      
			  WHERE       
			   COACode = SUBSTRING(A_COA.COACode, 1, 6)      
			   AND EstateID = C_DAD.EstateID      
			 ) AS Activity ,      
			       
			 SUBSTRING( A_COA.COACode, 1, 6) AccountCode,      
			 A_COA.COACode,      
			 G_YOP.YOP,      
			 C_DAD.DistbDate,      
			 G_BM.BlockName,      
			 CASE WHEN G_DIV .DivName IS NULL      
			   THEN 'NoDIV'      
			   ELSE      
			   G_DIV .DivName      
			 END AS DivName ,      
			       
			 ISNULL(C_DAD.Ha, 0) AS Ha,      
			 -- ISNULL(C_DAD.Mandays, 0) AS Mandays,       
			--  ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) as  Mandays,    
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) as  Mandays,    
			  
			 -- Palani, Note: CheckRoll.StandardRateSetup table screen (web) more than 1 record is not applicable (Tabbed Dialog KHL / KHT)    
			 -- ISNULL(C_DAD.Mandays, 0) * ISNULL(C_RS.BasicRate, 0) AS Salary ,      
			     
			-- commented on 25-June-2011     
			 --case when C_GM.Category = 'KHL' then   
			 --( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup)    
			 --else   
			 --( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) End as Salary,    
			 case when C_GM.Category = 'KHL' then   
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup)    
			 else   
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) End as Salary,    
			     
			     
			 S_MASTER.StockDesc AS MaterialDesc,      
			 ISNULL(C_AMU.UsageQty, 0)AS MaterialQty,      
			   
			     
			 (SELECT Checkroll.CRDailyCosting( @EstateID,C_AMU.StockID,@ActiveMonthYearIDST)) AS AvgPrice,      
			 CASE      
			  WHEN C_DAD.Ha IS NULL THEN 0      
			  ELSE      
			    
			-- commented on 25-June-2011     
			  --case when C_GM.Category = 'KHL' then     
			  --( ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha      
			  --else     
			  --( ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha End     
			  
			  case when C_GM.Category = 'KHL' then     
			  ( ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha      
			  else     
			  ( ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha End     
			     
			 END AS SalaryPerHa        
			      
			FROM      
			Checkroll.DailyActivityDistribution AS C_DAD      
			LEFT JOIN General.Division AS G_DIV ON C_DAD.DIVID = G_DIV.DivID      
			INNER JOIN Accounts.COA AS A_COA ON C_DAD.COAID = A_COA.COAID      
			LEFT JOIN General.YOP AS G_YOP ON C_DAD.YOPID = G_YOP.YOPID      
			LEFT JOIN General.BlockMaster AS G_BM ON C_DAD.BlockID = G_BM.BlockID      
			INNER JOIN Checkroll.GangMaster As C_GM ON C_DAD.GangMasterID = C_GM.GangMasterID      
			-- Palani (Not Required bcas Salary Formula is changed now taking the BAsicRate from "CheckRoll.StandardRateSetup" Table    
			-- INNER JOIN Checkroll.RateSetup AS C_RS ON C_GM.Category = C_RS.Category      
			LEFT JOIN Checkroll.ActivityMaterialUsage AS C_AMU ON C_DAD.DailyDistributionID = C_AMU.DailyDistributionID      
			LEFT JOIN Store.STMaster AS S_MASTER ON C_AMU.StockID = S_MASTER.StockID      
			      
			WHERE C_GM.Category ='KHT' and C_DAD.ActiveMonthYearID =@ActiveMonthYearID AND C_DAD .EstateID = @EstateID        
			      AND C_DAD.DistbDate BETWEEN @FromDate AND @Todate           
			ORDER BY DistbDate, Activity
		END
	ELSE IF @Category = 'KHL'-- KHL
		BEGIN
			SELECT       
			 C_DAD.DailyDistributionID ,      
			 (      
			  SELECT COADescp      
			  FROM       
			   Accounts.COA      
			  WHERE       
			   COACode = SUBSTRING(A_COA.COACode, 1, 4)      
			   AND EstateID = C_DAD.EstateID      
			 ) + ' - ' +
			 (      
			  SELECT COADescp      
			  FROM       
			   Accounts.COA      
			  WHERE       
			   COACode = SUBSTRING(A_COA.COACode, 1, 6)      
			   AND EstateID = C_DAD.EstateID      
			 ) AS Activity ,      
			       
			 SUBSTRING( A_COA.COACode, 1, 6) AccountCode,      
			 A_COA.COACode,      
			 G_YOP.YOP,      
			 C_DAD.DistbDate,      
			 G_BM.BlockName,      
			 CASE WHEN G_DIV .DivName IS NULL      
			   THEN 'NoDIV'      
			   ELSE      
			   G_DIV .DivName      
			 END AS DivName ,      
			       
			 ISNULL(C_DAD.Ha, 0) AS Ha,      
			 -- ISNULL(C_DAD.Mandays, 0) AS Mandays,       
			--  ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) as  Mandays,    
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) as  Mandays,    
			  
			 -- Palani, Note: CheckRoll.StandardRateSetup table screen (web) more than 1 record is not applicable (Tabbed Dialog KHL / KHT)    
			 -- ISNULL(C_DAD.Mandays, 0) * ISNULL(C_RS.BasicRate, 0) AS Salary ,      
			     
			-- commented on 25-June-2011     
			 --case when C_GM.Category = 'KHL' then   
			 --( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup)    
			 --else   
			 --( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) End as Salary,    
			 case when C_GM.Category = 'KHL' then   
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup)    
			 else   
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) End as Salary,    
			     
			     
			 S_MASTER.StockDesc AS MaterialDesc,      
			 ISNULL(C_AMU.UsageQty, 0)AS MaterialQty,      
			   
			     
			 (SELECT Checkroll.CRDailyCosting( @EstateID,C_AMU.StockID,@ActiveMonthYearIDST)) AS AvgPrice,      
			 CASE      
			  WHEN C_DAD.Ha IS NULL THEN 0      
			  ELSE      
			    
			-- commented on 25-June-2011     
			  --case when C_GM.Category = 'KHL' then     
			  --( ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha      
			  --else     
			  --( ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha End     
			  
			  case when C_GM.Category = 'KHL' then     
			  ( ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha      
			  else     
			  ( ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha End     
			     
			 END AS SalaryPerHa        
			      
			FROM      
			Checkroll.DailyActivityDistribution AS C_DAD      
			LEFT JOIN General.Division AS G_DIV ON C_DAD.DIVID = G_DIV.DivID      
			INNER JOIN Accounts.COA AS A_COA ON C_DAD.COAID = A_COA.COAID      
			LEFT JOIN General.YOP AS G_YOP ON C_DAD.YOPID = G_YOP.YOPID      
			LEFT JOIN General.BlockMaster AS G_BM ON C_DAD.BlockID = G_BM.BlockID      
			INNER JOIN Checkroll.GangMaster As C_GM ON C_DAD.GangMasterID = C_GM.GangMasterID      
			-- Palani (Not Required bcas Salary Formula is changed now taking the BAsicRate from "CheckRoll.StandardRateSetup" Table    
			-- INNER JOIN Checkroll.RateSetup AS C_RS ON C_GM.Category = C_RS.Category      
			LEFT JOIN Checkroll.ActivityMaterialUsage AS C_AMU ON C_DAD.DailyDistributionID = C_AMU.DailyDistributionID      
			LEFT JOIN Store.STMaster AS S_MASTER ON C_AMU.StockID = S_MASTER.StockID      
			      
			WHERE  C_GM.Category ='KHL' and C_DAD.ActiveMonthYearID =@ActiveMonthYearID AND C_DAD .EstateID = @EstateID        
			       AND C_DAD.DistbDate BETWEEN @FromDate AND @Todate           
			ORDER BY DistbDate, Activity
		END
	ELSE
	BEGIN
		SELECT       
			 C_DAD.DailyDistributionID ,      
			 (      
			  SELECT COADescp      
			  FROM       
			   Accounts.COA      
			  WHERE       
			   COACode = SUBSTRING(A_COA.COACode, 1, 4)      
			   AND EstateID = C_DAD.EstateID      
			 ) + ' - ' +
			 (      
			  SELECT COADescp      
			  FROM       
			   Accounts.COA      
			  WHERE       
			   COACode = SUBSTRING(A_COA.COACode, 1, 6)      
			   AND EstateID = C_DAD.EstateID      
			 ) AS Activity ,      
			       
			 SUBSTRING( A_COA.COACode, 1, 6) AccountCode,      
			 A_COA.COACode,      
			 G_YOP.YOP,      
			 C_DAD.DistbDate,      
			 G_BM.BlockName,      
			 CASE WHEN G_DIV .DivName IS NULL      
			   THEN 'NoDIV'      
			   ELSE      
			   G_DIV .DivName      
			 END AS DivName ,      
			       
			 ISNULL(C_DAD.Ha, 0) AS Ha,      
			 -- ISNULL(C_DAD.Mandays, 0) AS Mandays,       
			--  ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) as  Mandays,    
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) as  Mandays,    
			  
			 -- Palani, Note: CheckRoll.StandardRateSetup table screen (web) more than 1 record is not applicable (Tabbed Dialog KHL / KHT)    
			 -- ISNULL(C_DAD.Mandays, 0) * ISNULL(C_RS.BasicRate, 0) AS Salary ,      
			     
			-- commented on 25-June-2011     
			 --case when C_GM.Category = 'KHL' then   
			 --( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup)    
			 --else   
			 --( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) End as Salary,    
			 case when C_GM.Category = 'KHL' then   
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup)    
			 else   
			 ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) End as Salary,    
			     

			     
			 S_MASTER.StockDesc AS MaterialDesc,      
			 ISNULL(C_AMU.UsageQty, 0)AS MaterialQty,      
			   
			     
			 (SELECT Checkroll.CRDailyCosting( @EstateID,C_AMU.StockID,@ActiveMonthYearIDST)) AS AvgPrice,      
			 CASE      
			  WHEN C_DAD.Ha IS NULL THEN 0      
			  ELSE      
			    
			-- commented on 25-June-2011     
			  --case when C_GM.Category = 'KHL' then     
			  --( ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha      
			  --else     
			  --( ( ISNULL(C_DAD.Mandays, 0) + ISNULL(C_DAD.TotalOT, 0) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha End     
			  
			  case when C_GM.Category = 'KHL' then     
			  ( ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRate, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha      
			  else     
			  ( ( ISNULL(C_DAD.Mandays, 0) + (ISNULL(C_DAD.OT, 0)/7) ) * (select ISNULL(StandardRateKHT, 0) from CheckRoll.StandardRateSetup) ) / C_DAD.Ha End     
			     
			 END AS SalaryPerHa      
			      
			FROM      
			Checkroll.DailyActivityDistribution AS C_DAD      
			LEFT JOIN General.Division AS G_DIV ON C_DAD.DIVID = G_DIV.DivID      
			INNER JOIN Accounts.COA AS A_COA ON C_DAD.COAID = A_COA.COAID      
			LEFT JOIN General.YOP AS G_YOP ON C_DAD.YOPID = G_YOP.YOPID      
			LEFT JOIN General.BlockMaster AS G_BM ON C_DAD.BlockID = G_BM.BlockID      
			INNER JOIN Checkroll.GangMaster As C_GM ON C_DAD.GangMasterID = C_GM.GangMasterID      
			-- Palani (Not Required bcas Salary Formula is changed now taking the BAsicRate from "CheckRoll.StandardRateSetup" Table    
			-- INNER JOIN Checkroll.RateSetup AS C_RS ON C_GM.Category = C_RS.Category      
			LEFT JOIN Checkroll.ActivityMaterialUsage AS C_AMU ON C_DAD.DailyDistributionID = C_AMU.DailyDistributionID      
			LEFT JOIN Store.STMaster AS S_MASTER ON C_AMU.StockID = S_MASTER.StockID      
			      
			WHERE --C_GM.Category ='KHT' and 
			C_DAD.ActiveMonthYearID =@ActiveMonthYearID AND C_DAD .EstateID = @EstateID        
			      AND C_DAD.DistbDate BETWEEN @FromDate AND @Todate           
			ORDER BY DistbDate, Activity
		END
END

GO


