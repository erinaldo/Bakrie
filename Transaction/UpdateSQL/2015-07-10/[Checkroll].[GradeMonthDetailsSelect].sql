

/****** Object:  StoredProcedure [Checkroll].[GradeMonthDetailsSelect]    Script Date: 6/21/2015 6:46:25 PM ******/
DROP PROCEDURE [Checkroll].[GradeMonthDetailsSelect]
GO

/****** Object:  StoredProcedure [Checkroll].[GradeMonthDetailsSelect]    Script Date: 6/21/2015 6:46:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Checkroll].[GradeMonthDetailsSelect]
	-- Add the parameters for the stored procedure here
	@GradeMonthId as varchar(50),
	@DateRubber as varchar(50)
AS
BEGIN
SELECT        Checkroll.GradeMonth.Id, Checkroll.GradeMonth.ZMonth, Checkroll.GradeMonth.ZYear, Checkroll.GradeMonth.TotalBudget, 
                         Checkroll.GradeMonthDetails.GradeMonthId, Checkroll.GradeMonthDetails.EmpId, Checkroll.GradeMonthDetails.Class, Checkroll.CREmployee.EmpName, 
                         SumRubber.Latex, SumRubber.CupLump, SumRubber.TreeLace,
						  Checkroll.GangMaster.GangName
FROM            Checkroll.CREmployee INNER JOIN
                         Checkroll.GradeMonthDetails ON Checkroll.CREmployee.EmpID = Checkroll.GradeMonthDetails.EmpId RIGHT OUTER JOIN
                         Checkroll.GradeMonth ON Checkroll.GradeMonthDetails.GradeMonthId = Checkroll.GradeMonth.Id 
						 INNER JOIN
                             (SELECT        NIK, SUM(Latex) AS Latex, SUM(CupLamp) AS CupLump, SUM(TreeLace) AS TreeLace, CONVERT(char(7), DateRubber, 20) AS daterubber
                               FROM            Checkroll.DailyReceptionForRubber
                               WHERE        (CONVERT(char(7), DateRubber, 20) = @DateRubber) --'2014-10' sample format
                               GROUP BY NIK, CONVERT(char(7), DateRubber, 20)) AS SumRubber ON Checkroll.CREmployee.EmpCode = SumRubber.NIK
							   LEFT OUTER JOIN
							   Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID
							   LEFT OUTER JOIN
							   Checkroll.GangMaster ON Checkroll.GangEmployeeSetup.GangMasterID = Checkroll.GangMaster.GangMasterID
	WHERE		  Checkroll.GradeMonthDetails.GradeMonthId = @GradeMonthId
END


GO


