
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorGenerate]    Script Date: 3/24/2015 8:28:45 PM ******/
DROP PROCEDURE [Checkroll].[DailyAttendanceMandorGenerate]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorGenerate]    Script Date: 3/24/2015 8:28:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyAttendanceMandorGenerate]
	-- Add the parameters for the stored procedure here
	@EstateID as nvarchar(50)
AS
BEGIN
	SELECT         EmpID, EmpCode, EmpName, General.EmpJobDescription.Description
FROM            Checkroll.CREmployee INNER JOIN
                         General.EmpJobDescription ON Checkroll.CREmployee.EmpJobDescriptionId = General.EmpJobDescription.Id where CREmployee.EmpJobDescriptionId <> 1 and EstateID = @EstateID
END


GO


