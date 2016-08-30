
GO

/****** Object:  StoredProcedure [Checkroll].[CRDailyAttendanceNikSelectByJobsID]    Script Date: 16/01/2015 9:03:04 ******/
DROP PROCEDURE [Checkroll].[CRDailyAttendanceNikSelectByJobsID]
GO

/****** Object:  StoredProcedure [Checkroll].[CRDailyAttendanceNikSelectByJobsID]    Script Date: 16/01/2015 9:03:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- ==========================================
CREATE PROCEDURE [Checkroll].[CRDailyAttendanceNikSelectByJobsID]
	-- Add the parameters for the stored procedure here
	@Activity varchar(50)	
AS
BEGIN
	SELECT DISTINCT 
                         Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.AccountNo AS [Old NIK],Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
                         Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
                         Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
                         Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay, Checkroll.CREmployee.EmpJobDescriptionId
FROM            Checkroll.CREmployee LEFT OUTER JOIN
                         General.EmpJobDescription ON Checkroll.CREmployee.EmpJobDescriptionId = General.EmpJobDescription.Id LEFT OUTER JOIN
                         Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category LEFT OUTER JOIN
                         Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID
where General.EmpJobDescription.FilterType = @Activity

	
END


GO


