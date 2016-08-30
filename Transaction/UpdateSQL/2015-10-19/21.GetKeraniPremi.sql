
/****** Object:  UserDefinedFunction [Checkroll].[GetEmployeeDailyRate]    Script Date: 28/10/2015 5:55:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [Checkroll].[GetKeraniPremi] (
	@Empid nvarchar(50),@DDate as Date)
RETURNS numeric(18,4)
AS
BEGIN
	Declare @Rate numeric(18,4)
	Select @Rate=KraniPremi from Checkroll.DailyTeamActivity WHERE KraniID = @Empid and DDate = @DDate
	RETURN (@Rate);	
END;


