
/****** Object:  UserDefinedFunction [Checkroll].[GetEmployeeDailyRate]    Script Date: 16/12/2015 4:41:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [Checkroll].[GetEmployeeMonthlyRate] (
	@Empid nvarchar(50))
RETURNS numeric(18,4)
AS
BEGIN
	DECLARE @Category nvarchar(50)
	DECLARE @Grade nvarchar(100)
	DECLARE @Level nvarchar(100)
	DECLARE @Rate numeric(18,4)
	SELECT 
		@Category = category, @Grade = Grade, @Level = [Level] from Checkroll.CREmployee	
	WHERE
		Empid = @Empid
	
	if @Category = 'KHL' or @Category = 'PKWT'
		BEGIN 
			Select @Rate = BasicRate * RiceDividerDays from Checkroll.RateSetup where Category = 'KHL'
		END
	ELSE
		if @Category = 'KHT'
			begin 
				Select @Rate = BasicRate * RiceDividerDays from Checkroll.RateSetup where Category = 'KHT'
			end 
		else
			if @Category = 'KT' or @Category = 'HIP' or @Category = 'HIPS' 
				begin
				select @Rate = StdRate from Checkroll.RateSetup where HIPLevel = @Level and Grade = @grade
				end			
	RETURN (@Rate);	
END;



GO


