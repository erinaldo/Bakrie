
/****** Object:  StoredProcedure [Checkroll].[SalaryEmployeeDetail]    Script Date: 12/4/2016 9:55:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[SalaryEmployeeDetail]
@ActiveMonthYearId nvarchar(50),
@EmpID as nvarchar(50)
AS
BEGIN
	DECLARE @DATE AS DATETIME
	DECLARE @StartDate as Datetime
	DECLARE @FinishDate as Datetime

select @StartDate = FromDT,@FinishDate = TODT from General.FiscalYear FY
inner join General.ActiveMonthYear AY on FY.Period = AMonth and FY.FYear = AYear
where ActiveMonthYearID = @ActiveMonthYearId

SELECT @DATE = (SELECT TOP 1 Salary.SalaryProcDate from Checkroll.Salary GROUP BY Checkroll.Salary.SalaryProcDate order by dateadd(day,datediff(day,0,Salary.SalaryProcDate),0) desc)


SELECT DISTINCT  Checkroll.Salary.EmpID,
						 Allowance.Amount ,
                         Allowance.StartDate, Allowance.EndDates,  Allowance.Remarks, Allowance.AllowDedID, Allowance.TYPE,
                         Allowance.AllowDedCode, Checkroll.CREmployee.EmpName, Checkroll.CREmployee.EmpCode, Checkroll.CREmployee.OEEmpLocation, 
						 Checkroll.CREmployee.BankID, Checkroll.CREmployee.BankAccountNo, Checkroll.Salary.GangMasterID, Checkroll.GangMaster.GangName,
						 Checkroll.GangMasterBesar.GangMasterBesarID, mb.EmpName as MandorBesarName
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
                               WHERE      
							   Checkroll.EmpAllowanceDeduction.EndDates between @StartDate  AND @FinishDate
							   AND Checkroll.AllowanceDeductionSetup.AllowDedCode <> 'A01'
							   --ORDER by Checkroll.AllowanceDeductionSetup.Type asc
							   ) 
                         AS Allowance ON Checkroll.Salary.EmpID = Allowance.EmpID
						 Left join checkroll.GangMaster on Checkroll.Salary.GangMasterID = Checkroll.GangMaster.GangMasterID
						 left join Checkroll.GangMasterBesar on Checkroll.GangMaster.GangMasterID = Checkroll.GangMasterBesar.GangMasterID
						 left join Checkroll.CREmployee MB on Checkroll.GangMasterBesar.GangMasterBesarID = mb.EmpID
WHERE        
Checkroll.Salary.ActiveMonthYearID = @ActiveMonthYearId
AND Checkroll.Salary.EmpID = @EmpID
ORDER BY Allowance.AllowDedCode ASC

END

