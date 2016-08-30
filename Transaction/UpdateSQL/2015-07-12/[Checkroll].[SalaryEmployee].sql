



/****** Object:  StoredProcedure [Checkroll].[SalaryEmployee]    Script Date: 12/07/2015 20:10:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[SalaryEmployee]
	@StartDate as datetime, -- = '2015-03-05'
	@FinishDate as datetime --	= '2015-03-05'
AS
BEGIN
	DECLARE @DATE AS DATETIME

SELECT @DATE = (SELECT TOP 1 Salary.SalaryProcDate from Checkroll.Salary GROUP BY Checkroll.Salary.SalaryProcDate order by dateadd(day,datediff(day,0,Salary.SalaryProcDate),0) desc)
PRINT @DATE

SELECT DISTINCT 
                         Checkroll.Salary.Id, Checkroll.Salary.SalaryID, Checkroll.Salary.EstateID, Checkroll.Salary.ActiveMonthYearID, Checkroll.Salary.SalaryProcDate, 
                         Checkroll.Salary.Category, Checkroll.Salary.GangMasterID, Checkroll.Salary.MandoreID, Checkroll.Salary.KraniID, Checkroll.Salary.Activity, Checkroll.Salary.EmpID, 
                         Checkroll.Salary.MStatus, Checkroll.Salary.NPWP, Checkroll.Salary.Absent, Checkroll.Salary.Hari, Checkroll.Salary.Upah as GajiPokok, Checkroll.Salary.HariLain, 
                         Checkroll.Salary.HarinLainUpah, Checkroll.Salary.TotalBasic, Checkroll.Salary.TotalOT, Checkroll.Salary.TotalOTValue, Checkroll.Salary.Premi, 
                         Checkroll.Salary.MandorPremi, Checkroll.Salary.KraniPremi, Checkroll.Salary.DriverPremi, Checkroll.Salary.AttIncentiveRp, Checkroll.Salary.K3Panen, 
                         Checkroll.Salary.Allowance, Checkroll.Salary.THR, Checkroll.Salary.TotalBruto, Checkroll.Salary.DedAstek, Checkroll.Salary.DedTaxEmployee, 
                         Checkroll.Salary.DedTaxCompany, Checkroll.Salary.DedAdvance, Checkroll.Salary.DedOther, Checkroll.Salary.TotalDed, Checkroll.Salary.TotalNett, 
                         Checkroll.Salary.TotalRoundUP, Checkroll.Salary.AllowanceRiceForKT, Checkroll.Salary.FunctionalAllowanceP,
						 Checkroll.CREmployee.EmpName, Checkroll.CREmployee.OEEmpLocation
FROM            Checkroll.Salary LEFT JOIN Checkroll.CREmployee on Checkroll.Salary.EmpID = Checkroll.CREmployee.EmpID
WHERE        
(DATEADD(month, DATEDIFF(month, 0, Checkroll.Salary.SalaryProcDate), 0) >= DATEADD(month, DATEDIFF(month, 0, @StartDate), 0) 
AND (DATEADD(month, DATEDIFF(month, 0, Checkroll.Salary.SalaryProcDate), 0) <= DATEADD(month, DATEDIFF(month, 0, @FinishDate), 0))
)
AND SalaryProcDate = @DATE
ORDER BY Checkroll.Salary.EmpID ASC

END

GO


