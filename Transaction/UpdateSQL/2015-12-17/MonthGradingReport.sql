USE [BSPMS_POM]
GO
/****** Object:  StoredProcedure [Production].[MonthGradingReport]    Script Date: 17/12/2015 12:00:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		siddhik-- KUMAR
-- Create date: <14/09/2010,,>  23/11202010
-- Description:	<get records to excel using joins by two tables,,>
-- Modified by: Stanley
-- Modified on: 18-06-2011
-- Modified by: Stanley
-- Modified on: 30-06-2011
-- Modified by: Stanley
-- Modified on: 02-07-2011
-- =============================================

ALTER PROCEDURE [Production].[MonthGradingReport]
 
@Estateid Nvarchar(50),
@Month Integer,
@Year Integer 
	
	AS
begin try

	SET NOCOUNT ON;

Declare @ActivemonthyearID nvarchar(50);

Set  @ActivemonthyearID =(Select  ActivemonthyearID From General.Activemonthyear Where Amonth=@Month and Ayear=@Year and Modid=4 AND EstateID =@Estateid )
--Select @AMYID-- as AMYID

Select   
 CONVERT(VARCHAR(11), FromDt ) AS FromDt,
 CONVERT(VARCHAR(11), ToDT ) AS ToDT  From general.FiscalYear  where Period=@Month and Fyear=@Year

-- @18-06-2011 by Stanley .b
DECLARE @WBT_YOP  TABLE 
		([Div] [nvarchar](50) NULL, 
		 [WeighingID] [nvarchar](50) NOT NULL,
         [YOP] [nvarchar](50) NULL,
         [YOP_Div] [nvarchar](50) NULL
        )                           	

INSERT INTO @WBT_YOP 
(Div, WeighingID, YOP, YOP_Div) 
SELECT W_WeighFBS.Div, WB_WeighBlkDet.WeighingID, W_WeighFBS.YOP, (MIN(W_WeighFBS.YOP)+'|'+MIN(W_WeighFBS.Div)) AS YOP_Div
FROM Weighbridge .WBWeighingBlockDetail AS WB_WeighBlkDet
LEFT JOIN Weighbridge .WBFieldBlockSetup W_WeighFBS ON W_WeighFBS .FieldBlockSetupID   =   WB_WeighBlkDet.FieldBlockSetupID
LEFT JOIN Production.GradingFFB  P_GFFB ON WB_WeighBlkDet.WeighingID = P_GFFB.WeighingID
WHERE WB_WeighBlkDet.WeighingID =  P_GFFB.WeighingID
		AND WB_WeighBlkDet.EstateID = @Estateid
		AND P_GFFB.ActivemonthyearID = @ActivemonthyearID
GROUP BY WB_WeighBlkDet.WeighingID, W_WeighFBS.YOP, W_WeighFBS.Div 

DECLARE @WBT_YOP1 TABLE 
		([Div] [nvarchar](50) NULL, 
		 [WeighingID] [nvarchar](50) NOT NULL,
         [YOP] [nvarchar](50) NULL
        ) 


INSERT INTO @WBT_YOP1 
(Div, WeighingID, YOP)                         
SELECT SUBSTRING(MIN(YOP_Div), CHARINDEX('|',MIN(YOP_Div))+1,LEN(MIN(YOP_Div))) As Div, WeighingID, SUBSTRING(MIN(YOP_Div), 1, CHARINDEX('|',MIN(YOP_Div))-1)
FROM @WBT_YOP 
GROUP BY WeighingID

DELETE @WBT_YOP

INSERT INTO @WBT_YOP 
(Div, WeighingID, YOP)                         
SELECT Div, WeighingID, MIN(YOP)
FROM @WBT_YOP1
GROUP BY WeighingID, Div
ORDER BY WeighingID, Div
-- @18-06-2011 by Stanley .e

-- @18-06-2011 by Stanley .b
select p3.GradingDate, p3.GradingDateForSorting
,p3.UnderripeT,p3.RipeFruitT,p3.UnripeFruitT,p3.OverRipeFruitT,p3.EmptyBunchFruitT,p3.PartheT,
p3.HardBunchT,p3.UnDamageT,p3.LightDamageT ,
(ISNULL(LightDamageP, 0) / ISNULL(P3.Recs,0)) AS LightDamageP,
(ISNULL(P3.TotalNormalFruitsJ, 0) / ISNULL(P3.Recs,0)) AS TotalNormalFruitsJ, 
(ISNULL(p3.UnripeFruitJ, 0) / ISNULL(P3.Recs,0)) AS UnripeFruitJ,
(ISNULL(p3.UnderripeJ, 0) / ISNULL(P3.Recs,0)) AS UnderripeJ,
(ISNULL(p3.EmptyBunchFruitJ, 0) / ISNULL(P3.Recs,0)) AS EmptyBunchFruitJ,
(ISNULL(P3.AB,0) / ISNULL(P3.Recs,0)) AS AB,P3.TotalAbnormalFruitsJ,p3.div,p3.Qty,p3.yop,
p3.FFBDeliveryOrderNo,(ISNULL(P3.NetWeight,0) / ISNULL(P3.Recs,0)) AS NetWeight,
(ISNULL(p3.UnripeFruitP, 0) / ISNULL(P3.Recs,0)) AS UnripeFruitP,
(ISNULL(p3.UnderripeP, 0) / ISNULL(P3.Recs,0)) AS UnderripeP,
(ISNULL(p3.RipeFruitP, 0) / ISNULL(P3.Recs,0)) AS RipeFruitP,
(ISNULL(p3.OverRipeFruitP, 0) / ISNULL(P3.Recs,0)) AS OverRipeFruitP,
(ISNULL(p3.EmptyBunchFruitP, 0) / ISNULL(P3.Recs,0)) AS EmptyBunchFruitP,
(ISNULL(p3.PartheP, 0) / ISNULL(P3.Recs,0)) AS PartheP,
(ISNULL(p3.HardBunchP, 0) / ISNULL(P3.Recs,0)) AS HardBunchP,
(ISNULL(p3.LooseFruitsP, 0) / ISNULL(P3.Recs,0)) AS LooseFruitsP,
(ISNULL(p3.UnDamageP, 0) / ISNULL(P3.Recs,0)) AS UnDamageP,
(ISNULL(p3.DamageP, 0) / ISNULL(P3.Recs,0)) AS DamageP,
P3.SupplierName, p3.WeighingID, P3.Recs
 
from

(
-- @18-06-2011 by Stanley .e
select distinct  p1.GradingDate
,p1.GradingDateForSorting
,p1.UnderripeT,p1.RipeFruitT,p1.UnripeFruitT,p1.OverRipeFruitT,p1.EmptyBunchFruitT,p1.PartheT
,p1.HardBunchT,p1.UnDamageT,p1.LightDamageT ,p1.LightDamageP,P1.TotalNormalFruitsJ, p1.UnripeFruitJ
,p1.UnderripeJ,p1.EmptyBunchFruitJ,p1.ab,P1.TotalAbnormalFruitsJ,p1.div
-- @30-06-2011 by Stanley	,P2.div
,p1.Qty,p1.yop,p1.FFBDeliveryOrderNo,p1.NetWeight,p1.UnripeFruitP,p1.UnderripeP,p1.RipeFruitP
,p1.OverRipeFruitP,p1.EmptyBunchFruitP,p1.PartheP,p1.HardBunchP,p1.LooseFruitsP,p1.UnDamageP
,p1.DamageP
-- @30-06-2011 by Stanley	,p1.UnripeFruitJ
-- @30-06-2011 by Stanley	,p1.UnderripeJ
-- @30-06-2011 by Stanley	,p1.EmptyBunchFruitJ
,P1.Name as SupplierName 
,p1.WeighingID
,P1.Recs	-- @30-06-2011 by Stanley

from


(select 
       CONVERT(VARCHAR(11), P_GFFB.GradingDate,7) AS GradingDate  ,
        P_GFFB.GradingDate AS GradingDateForSorting,
-- @18-06-2011 by Stanley		W_WeighFBS .Div AS Div,
-- @18-06-2011 by Stanley		W_WeighFBS.YOP AS YOP,
		WBT_YOP.Div AS Div,
		WBT_YOP.YOP AS YOP,
		W_WeighINOUT .FFBDeliveryOrderNo AS FFBDeliveryOrderNo,
		SUM(WB_WeighBlkDet .Qty) AS Qty ,
		SUM(W_WeighINOUT.NetWeight) AS NetWeight,
		SUM(P_GFFB.UnripeFruitP) AS UnripeFruitP,  
		SUM(P_GFFB.TotalNormalFruitsJ) AS TotalNormalFruitsJ,
		SUM(P_GFFB. TotalAbnormalFruitsJ) AS TotalAbnormalFruitsJ,
		SUM(P_GFFB.UnderripeP) AS UnderripeP,
		SUM(P_GFFB.RipeFruitP) AS RipeFruitP,
		SUM(P_GFFB.OverRipeFruitP) AS OverRipeFruitP,
		SUM(P_GFFB.EmptyBunchFruitP) AS EmptyBunchFruitP,
		SUM(P_GFFB.PartheP) AS PartheP ,
		SUM(P_GFFB.HardBunchP) AS HardBunchP,
		SUM(P_GFFB.LooseFruitsP) AS LooseFruitsP,
		SUM(P_GFFB.UnDamageP)  AS UnDamageP ,
		SUM(P_GFFB.DamageP) AS DamageP,
		P_GFFB.UnripeFruitT AS UnripeFruitT, 
		P_GFFB.UnderripeT AS UnderripeT, 
		P_GFFB.RipeFruitT AS RipeFruitT,
		P_GFFB.OverRipeFruitT AS OverRipeFruitT,
		P_GFFB.EmptyBunchFruitT AS EmptyBunchFruitT,
		P_GFFB.PartheT AS PartheT,
		P_GFFB.HardBunchT AS HardBunchT,
		P_GFFB.UnDamageT  AS UnDamageT ,
		P_GFFB.LightDamageT  AS LightDamageT ,
		SUM(P_GFFB.LightDamageP)  AS LightDamageP ,
		
		-- P_GFFB.UnripeFruitJ AS UnripeFruitJ,
		-- P_GFFB.UnderripeJ AS UnderripeJ,
		-- P_GFFB.EmptyBunchFruitJ AS EmptyBunchFruitJ,
		
		SUM((W_WeighINOUT.NetWeight * P_GFFB.UnripeFruitP / 100)) AS UnripeFruitJ,
		SUM(((W_WeighINOUT.NetWeight * P_GFFB.UnderripeP/100) * 20 / 100)) AS UnderripeJ,
		SUM((W_WeighINOUT.NetWeight * P_GFFB.EmptyBunchFruitP / 100)) AS EmptyBunchFruitJ,
		
		SUM((P_GFFB.UnripeFruitJ+ P_GFFB.UnderripeJ+P_GFFB.EmptyBunchFruitJ)) as TG,
		SUM(P_GFFB.TotalGradedBunches) as AB,
		SUM((WB_WeighBlkDet .Qty-(P_GFFB.TotalNormalFruitsJ + P_GFFB.TotalAbnormalFruitsJ))) as DIF,
		SUM((W_WeighINOUT. NetWeight/(P_GFFB.UnripeFruitJ+ P_GFFB.UnderripeJ+P_GFFB.EmptyBunchFruitJ))) as AVB,
		SUM((W_WeighINOUT. NetWeight/WB_WeighBlkDet .Qty)) as AVBFFB, 
		--SAI COmment
		--0 as AVBFFB,
		WB_Sup.Name,
		P_GFFB.WeighingID,
		Count(*) as Recs	-- @30-06-2011 by Stanley 
        
        from Production.GradingFFB  P_GFFB 
        -- inner join  Weighbridge .WBWeighingInOut WBIO  on  P_GFFB .WeighingID = WBIO.WeighingID 
        INNER JOIN Weighbridge .WBWeighingInOut W_WeighINOUT ON W_WeighINOUT .WeighingID = P_GFFB .WeighingID 
        LEFT Join Weighbridge .WBWeighingBlockDetail as  WB_WeighBlkDet on W_WeighINOUT.WeighingID = WB_WeighBlkDet.WeighingID
-- @18-06-2011        LEFT JOIN Weighbridge .WBFieldBlockSetup W_WeighFBS ON W_WeighFBS .FieldBlockSetupID   =   WB_WeighBlkDet.FieldBlockSetupID
        LEFT JOIN @WBT_YOP WBT_YOP ON WBT_YOP.WeighingID   =   WB_WeighBlkDet.WeighingID
        INNER JOIN Weighbridge .WBSupplier as WB_Sup ON WB_Sup .SupplierCustID =W_WeighINOUT .SupplierCustID 
        where P_GFFB.ActiveMonthYearID =@ActivemonthyearID and P_GFFB.Estateid=@Estateid 
        GROUP BY P_GFFB.GradingDate,
-- @18-06-2011 by Stanley		W_WeighFBS .Div,
-- @18-06-2011 by Stanley		W_WeighFBS.YOP,
		WBT_YOP.Div,
 		WBT_YOP.YOP,
		W_WeighINOUT .FFBDeliveryOrderNo,
		P_GFFB.UnripeFruitT, 
		P_GFFB.UnderripeT, 
		P_GFFB.RipeFruitT,
		P_GFFB.OverRipeFruitT,
		P_GFFB.EmptyBunchFruitT,
		P_GFFB.PartheT,
		P_GFFB.HardBunchT,
		P_GFFB.UnDamageT,
		P_GFFB.LightDamageT,
		WB_Sup.Name,
		P_GFFB.WeighingID ) P1
       
        inner join
        
        (select 
               
        W_WeighFBS .Div,
            
       Sum (WB_WeighBlkDet .Qty  ) as Qty
       

        from Production.GradingFFB  P_GFFB
        INNER JOIN Weighbridge .WBWeighingInOut W_WeighINOUT ON W_WeighINOUT .WeighingID = P_GFFB .WeighingID 
        LEFT Join Weighbridge .WBWeighingBlockDetail as  WB_WeighBlkDet on WB_WeighBlkDet .WeighingID =W_WeighINOUT .WeighingID 
        LEFT JOIN Weighbridge .WBFieldBlockSetup W_WeighFBS ON W_WeighFBS .FieldBlockSetupID   =   WB_WeighBlkDet.FieldBlockSetupID
        where P_GFFB.ActiveMonthYearID =@ActivemonthyearID and  P_GFFB.Estateid=@Estateid  GROUP by Div )P2 On P1 .Div  =P2 .Div
        ) P3	-- @30-06-2011 by Stanley
-- @30-06-2011 by Stanley        Order by P1.Name, P1.GradingDateForSorting
        Order by P3.SupplierName, P3.GradingDate	-- @30-06-2011 by Stanley

		-- palani        
        -- For % Columns Grand Total
		
		--SELECT 
		--SUM(UnripeFruitJ) UnripeFruitJGT, 
		--SUM(UnderripeJ) UnderripeJGT,
		--SUM(RipeFruitJ) RipeFruitJGT,
		--SUM(OverRipeFruitJ) OverRipeFruitJGT,
		--SUM(EmptyBunchFruitJ) EmptyBunchFruitJGT,
		--SUM(PartheJ) PartheJGT,
		--SUM(HardBunchJ) HardBunchJGT,
		--SUM(KgOfLooseFruit) KgOfLooseFruitGT,
		--SUM(lightdamagej) lightdamagejGT,
		--SUM(damagej) damagejGT
		--FROM Production .GradingFFB P_GFFB
		--Inner Join Weighbridge .WBWeighingInOut as WB_WeighINOUT ON WB_WeighINOUT .WeighingID =P_GFFB .WeighingID 			 			 
		--Where P_GFFB.EstateID = @Estateid   
		--AND P_GFFB.ActiveMonthYearID = @ActiveMonthYearID
		
		select 
		WB_Sup.Name SuppName,
		SUM(UnripeFruitJ) UnripeFruitJGT, 
		SUM(UnderripeJ) UnderripeJGT,
		SUM(RipeFruitJ) RipeFruitJGT,
		SUM(OverRipeFruitJ) OverRipeFruitJGT,
		SUM(EmptyBunchFruitJ) EmptyBunchFruitJGT,
		SUM(PartheJ) PartheJGT,
		SUM(HardBunchJ) HardBunchJGT,
		SUM(KgOfLooseFruit) KgOfLooseFruitGT,
		SUM(lightdamagej) lightdamagejGT,
		SUM(damagej) damagejGT,
		SUM(W_WeighINOUT.NetWeight) AS NetWeight2,
		SUM(TotalGradedBunches) as AB2
		from Production.GradingFFB  P_GFFB
		INNER JOIN Weighbridge .WBWeighingInOut W_WeighINOUT ON W_WeighINOUT .WeighingID = P_GFFB .WeighingID 
		LEFT Join Weighbridge .WBWeighingBlockDetail as  WB_WeighBlkDet on WB_WeighBlkDet .WeighingID =W_WeighINOUT .WeighingID 
--		LEFT JOIN Weighbridge .WBFieldBlockSetup W_WeighFBS ON W_WeighFBS .FieldBlockSetupID   =   WB_WeighBlkDet.FieldBlockSetupID
		INNER JOIN Weighbridge .WBSupplier as WB_Sup ON WB_Sup.SupplierCustID =W_WeighINOUT .SupplierCustID 
		where P_GFFB.ActiveMonthYearID =@ActiveMonthYearID and  P_GFFB.Estateid=@Estateid
		GROUP by WB_Sup.Name
        
         end try    
         begin catch
         DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

	RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );

END CATCH












