

/****** Object:  UserDefinedFunction [Checkroll].[CRFnGetWorkingDays]    Script Date: 4/9/2015 7:22:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




--===
--Gets which division and total Hectarage of that matured area based on first record in daily reception 
-- of the mandor besar's harvesting team
--===
Create FUNCTION [Checkroll].[CRGetHA] (
	@MandorebesarId nvarchar(50)
	,@Activity nvarchar(50)
	,@DailyTeamActivityID nvarchar(50))
RETURNS int
AS
BEGIN
	Declare @DailyReceptionId nvarchar(50)
	DECLARE @HaDiawasi numeric(18,4)
	Declare @DivId nvarchar(50)
	-- First Get ReceptionName

	select top 1 @DailyReceptionId = DailyReceiptionID from Checkroll.DailyAttendance where DailyTeamActivityID = @DailyTeamActivityID and attendancesetupid = '02R94'

	if @Activity = 'Panen'
	begin
		select top 1 @DivId = DivID from Checkroll.DailyReceiption where DailyReceiptionID = @DailyReceptionId
		Select @HaDiawasi=Sum(PlantedHect) from General.blockmaster where DivID = @DivId and BlockStatus = 'Matured' and Cropid = 'M1'
	end
	else
	begin
		select top 1 @DivId = Afdeling from Checkroll.DailyReceptionForRubber where DailyReceiptionID = @DailyReceptionId
		Select @HaDiawasi=Sum(PlantedHect) from General.blockmaster where DivID = @DivId and BlockStatus = 'Matured' and Cropid = 'M2'
	end		

	RETURN (@HaDiawasi);	
END;



GO


