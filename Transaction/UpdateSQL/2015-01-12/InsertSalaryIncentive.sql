
/****** Object:  StoredProcedure [Checkroll].[InsertSalaryIncentive]    Script Date: 12/1/2015 4:54:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------
-- Modified by : Stanley 
-- Modified on : 26-07-2011
---------------------------------------------

ALTER PROCEDURE [Checkroll].[InsertSalaryIncentive]
@ActiveMonthYearId nvarchar (50),
@EstateId nvarchar (50),
@User nvarchar (50)

AS

Declare @count int
Declare	@pTotRow Numeric(18,0)
Declare @EmpId as Nvarchar (50)
Declare @AttIncentive as Numeric (18,0)

BEGIN	
			
SET XACT_ABORT ON


-- Palani / 15-Mar-2011
DECLARE @FromDate datetime
DECLARE @ToDate datetime

SELECT 
@FromDate = G_FY.FromDT, @ToDate = G_FY.ToDT 
FROM
General.FiscalYear AS G_FY
INNER JOIN General.ActiveMonthYear AS G_AMY ON G_FY.Period = G_AMY.AMonth AND G_FY.FYear = G_AMY.AYear
WHERE
G_AMY.ActiveMonthYearID = @ActiveMonthYearID AND
G_AMY.EstateID = @EstateID

DECLARE CR_DA CURSOR FOR 
SELECT     ActiveMonthYearId,Checkroll.Salary.EstateID,Empid,
-- Commented by Stanley@26-07-2011		   Case ISNULL(Sum(Absent),0)
		   Case (30 - SUM(ISNULL(Hari,0)+ISNULL(HariLain,0)))
		   When -1 THEN ISNULL(Sum(Checkroll.RateSetup.AIFull),0)
		   When 0  THEN ISNULL(Sum(Checkroll.RateSetup.AIFull),0)
		   WHEN 1  THEN ISNULL(Sum(Checkroll.RateSetup.AIHalf),0)
		   WHEN 2  THEN '0'
		   ELSE '0' 
		   END AS AttIncentive
FROM       Checkroll.Salary
inner join checkroll.ratesetup on Checkroll.Salary.Category = Checkroll.RateSetup.Category
WHERE	   ActiveMonthYearID =@ActiveMonthYearId and Checkroll.Salary.EstateID =@EstateId 
-- Palani
-- Commented by Stanley@26-07-2011 AND EmpID IN (Select EmpId from Checkroll.CREmployee where [Status]= 'Active' and NOT(DOJ between @FromDate and @ToDate))
AND EmpID IN (Select EmpId from Checkroll.CREmployee where [Status]= 'Active' and NOT(DOJ > @ToDate))
AND EmpID IN (SELECT EMPID FROM Checkroll.GangEmployeeSetup GMS 
INNER JOIN Checkroll.GangMaster GM ON GM.GangMasterID = GMS.GangMasterID  AND GM.EstateID = @EstateID)
and Checkroll.Salary.Category   = 'KHL'


GROUP BY ActiveMonthYearId,Checkroll.Salary.EstateID,Empid

	Open CR_DA

		FETCH NEXT FROM CR_DA
 		INTO @ActiveMonthYearId,@EstateID,@Empid,@AttIncentive
		
	    SELECT  @pTotRow = @@CURSOR_ROWS
		WHILE @@FETCH_STATUS = 0 
		BEGIN
		
		IF EXISTS(SELECT EmpID from Checkroll.Salary 
		WHERE EstateID = @EstateId AND ActiveMonthYearID =@ActiveMonthYearId 
		AND  EmpID = @EmpID)
					
			BEGIN
			UPDATE  Checkroll.Salary 
			SET 
			AttIncentiveRp = ISNULL(@AttIncentive,0),
			ModifiedBy=@User ,
			ModifiedOn=GETDATE()
			WHERE EstateID = @EstateId AND ActiveMonthYearID =@ActiveMonthYearId 
			AND  EmpID = @EmpID  

			END
				
			
			
		FETCH NEXT FROM CR_DA
 		INTO @ActiveMonthYearId,@EstateID,@Empid,@AttIncentive
  					
		END
		CLOSE CR_DA

DEALLOCATE CR_DA

SELECT     ActiveMonthYearId,Checkroll.Salary.EstateID,Empid,
-- Commented by Stanley@26-07-2011		   Case ISNULL(Sum(Absent),0)
		   Case (30 - SUM(ISNULL(Hari,0)+ISNULL(HariLain,0)))
		   When -1 THEN ISNULL(Sum(Checkroll.RateSetup.AIFull),0)
		   When 0 THen ISNULL(Sum(Checkroll.RateSetup.AIFull),0)
		   WHEN 1 THEN ISNULL(Sum(Checkroll.RateSetup.AIHalf),0)
		   WHEN 2 THEN '0'
		   ELSE '0' 
		   END AS AttIncentive
FROM       Checkroll.Salary
inner join checkroll.ratesetup on Checkroll.Salary.Category = Checkroll.RateSetup.Category
WHERE	   ActiveMonthYearID =@ActiveMonthYearId and Checkroll.Salary.EstateID =@EstateId 
-- Palani
-- Commented by Stanley@26-07-2011 AND EmpID IN (Select EmpId from Checkroll.CREmployee where [Status]= 'Active' and NOT(DOJ between @FromDate and @ToDate))
AND EmpID IN (Select EmpId from Checkroll.CREmployee where [Status]= 'Active' and NOT(DOJ > @ToDate))
AND EmpID IN (SELECT EMPID FROM Checkroll.GangEmployeeSetup GMS 
INNER JOIN Checkroll.GangMaster GM ON GM.GangMasterID = GMS.GangMasterID
AND GM.EstateID = @EstateID)
AND checkroll.salary.category='KHT'

GROUP BY ActiveMonthYearId,Checkroll.Salary.EstateID,Empid


-- [Checkroll].[InsertSalaryIncentive] '01R101','M1','superadmin'
END
