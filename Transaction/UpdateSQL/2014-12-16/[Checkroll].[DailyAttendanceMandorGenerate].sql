
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorGenerate]    Script Date: 28/11/2014 15:48:18 ******/
DROP PROCEDURE [Checkroll].[DailyAttendanceMandorGenerate]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorGenerate]    Script Date: 28/11/2014 15:48:18 ******/
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
	select EmpID, EmpCode, EmpName from Checkroll.CREmployee where CREmployee.EmpJobDescriptionId <> 1 and EstateID = @EstateID
END

GO


