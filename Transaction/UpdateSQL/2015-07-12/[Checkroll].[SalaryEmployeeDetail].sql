

/****** Object:  StoredProcedure [Checkroll].[SalaryEmployeeDetail]    Script Date: 12/07/2015 20:11:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[SalaryEmployeeDetail]
	@StartDate as datetime, -- = '2015-03-05'
	@FinishDate as datetime, --	= '2015-03-05'
	@EmpID as nvarchar(50)
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
						 Allowance.Amount ,
                         Allowance.StartDate, Allowance.EndDates,  Allowance.Remarks, Allowance.AllowDedID, Allowance.TYPE,
                         Allowance.AllowDedCode, Checkroll.CREmployee.EmpName, Checkroll.CREmployee.EmpCode, Checkroll.CREmployee.OEEmpLocation
FROM            Checkroll.Salary INNER JOIN
                         Checkroll.CREmployee ON Checkroll.Salary.EmpID = Checkroll.CREmployee.EmpID AND Checkroll.Salary.EmpID = Checkroll.CREmployee.EmpID LEFT OUTER JOIN
                             (SELECT Checkroll.EmpAllowanceDeduction.Id, Checkroll.EmpAllowanceDeduction.EmpAllowDedID, Checkroll.EmpAllowanceDeduction.EstateID, 
                                                         Checkroll.EmpAllowanceDeduction.EmpID, Checkroll.EmpAllowanceDeduction.AllowDedID, Checkroll.EmpAllowanceDeduction.Amount, 
                                                         Checkroll.EmpAllowanceDeduction.StartDate, Checkroll.EmpAllowanceDeduction.EndDates, 
														 (SELECT 
														 CASE 
														 WHEN AllowanceDeductionSetup.Type = 'A' THEN 'PENDAPATAN'
														 WHEN AllowanceDeductionSetup.Type = 'D' THEN 'POTONGAN' 
														 END) AS TYPE,
                                                         Checkroll.AllowanceDeductionSetup.AllowDedCode, Checkroll.AllowanceDeductionSetup.Remarks
                               FROM            Checkroll.EmpAllowanceDeduction INNER JOIN
                                                         Checkroll.AllowanceDeductionSetup ON Checkroll.EmpAllowanceDeduction.AllowDedID = Checkroll.AllowanceDeductionSetup.AllowDedID
                               WHERE        (
							   DATEADD(month, DATEDIFF(month, 0, Checkroll.EmpAllowanceDeduction.StartDate), 0) >= DATEADD(month, DATEDIFF(month, 0, @StartDate), 0) AND
							   DATEADD(month, DATEDIFF(month, 0, Checkroll.EmpAllowanceDeduction.EndDates), 0) >= DATEADD(month, DATEDIFF(month, 0, @FinishDate), 0)) 
							   --ORDER by Checkroll.AllowanceDeductionSetup.Type asc
							   ) 
                         AS Allowance ON Checkroll.Salary.EmpID = Allowance.EmpID
WHERE        
(DATEADD(month, DATEDIFF(month, 0, Checkroll.Salary.SalaryProcDate), 0) >= DATEADD(month, DATEDIFF(month, 0, @StartDate), 0) 
AND (DATEADD(month, DATEDIFF(month, 0, Checkroll.Salary.SalaryProcDate), 0) <= DATEADD(month, DATEDIFF(month, 0, @FinishDate), 0))
)
AND SalaryProcDate = @DATE

AND Checkroll.Salary.EmpID = @EmpID
ORDER BY Checkroll.Salary.EmpID ASC

END

GO


