/****** Object:  StoredProcedure [Checkroll].[SalaryEmployee]    Script Date: 16/12/2015 4:27:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Checkroll].[SalaryEmployee]
	@ActiveMonthYearID nvarchar(50)
AS
BEGIN

SELECT DISTINCT 
                         Checkroll.Salary.Id, Checkroll.Salary.SalaryID, Checkroll.Salary.EstateID, Checkroll.Salary.ActiveMonthYearID, Checkroll.Salary.SalaryProcDate, 
                         Checkroll.Salary.Category, Checkroll.Salary.GangMasterID, Checkroll.Salary.MandoreID, Checkroll.Salary.KraniID, Checkroll.Salary.Activity, Checkroll.Salary.EmpID, 
                         Checkroll.Salary.MStatus, Checkroll.Salary.NPWP, Checkroll.Salary.Absent, Checkroll.Salary.Hari, Checkroll.Salary.Upah as GajiPokok, Checkroll.Salary.HariLain, 
                         Checkroll.Salary.HarinLainUpah, Checkroll.Salary.TotalBasic, Checkroll.Salary.TotalOT, Checkroll.Salary.TotalOTValue, Checkroll.Salary.Premi, 
                         Checkroll.Salary.MandorPremi, Checkroll.Salary.KraniPremi, Checkroll.Salary.DriverPremi, Checkroll.Salary.AttIncentiveRp, Checkroll.Salary.K3Panen, 
                         Checkroll.Salary.Allowance, Checkroll.Salary.THR, Checkroll.Salary.TotalBruto, Checkroll.Salary.DedAstek, Checkroll.Salary.DedTaxEmployee, 
                         Checkroll.Salary.DedTaxCompany, Checkroll.Salary.DedAdvance, Checkroll.Salary.DedOther, Checkroll.Salary.TotalDed, Checkroll.Salary.TotalNett, 
                         Checkroll.Salary.TotalRoundUP, Checkroll.Salary.AllowanceRiceForKT, Checkroll.Salary.FunctionalAllowanceP,
						 Checkroll.CREmployee.EmpName, Checkroll.CREmployee.OEEmpLocation, Checkroll.CREmployee.EmpCode, Checkroll.CREmployee.Grade,Checkroll.CREmployee.Level, Checkroll.GetEmployeeMonthlyRate(Checkroll.Cremployee.EmpID) as DailyRate
FROM            Checkroll.Salary LEFT JOIN Checkroll.CREmployee on Checkroll.Salary.EmpID = Checkroll.CREmployee.EmpID
WHERE        Checkroll.Salary.ActiveMonthYearID = @ActiveMonthYearID
ORDER BY Checkroll.Salary.EmpID ASC

END

