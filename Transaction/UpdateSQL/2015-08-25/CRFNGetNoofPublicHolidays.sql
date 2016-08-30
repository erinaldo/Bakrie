

/****** Object:  UserDefinedFunction [Checkroll].[CRFnGetNoOfPublicHolidays]    Script Date: 25/8/2015 8:51:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [Checkroll].[CRFnGetNoOfPublicHolidays] (
	@EstateID nvarchar(50)
	,@AMonth int
	,@AYear int)
RETURNS int
AS
BEGIN
	DECLARE @NoOfPH int;

	SELECT 
		--G_FY.FromDT
		@NoOfPH =
		
		/* Jml Hari Minggu */
		Count(*)
	FROM
		Checkroll.PublicHolidaySetup G_FY	
		
	WHERE  G_FY.EstateID = @EstateID
		AND MOnth(G_FY.PHDate) = @AMonth
		AND Year(G_FY.PHDate) = @AYear
	
	RETURN (@NoOfPH);	
END;




GO


