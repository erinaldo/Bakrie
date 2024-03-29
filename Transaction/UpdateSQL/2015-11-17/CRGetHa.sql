
/****** Object:  UserDefinedFunction [Checkroll].[CRGetHA]    Script Date: 18/11/2015 9:26:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [Checkroll].[CRGetHA] (
	@MandorebesarId nvarchar(50)
	,@Activity nvarchar(50)
	,@DDate smalldatetime)
RETURNS int
AS
BEGIN
	Declare @DailyReceptionId nvarchar(50)
	DECLARE @HaDiawasi numeric(18,4)
	Declare @DivId nvarchar(50)
	Declare @DailyTeamActivityID nvarchar(50)
	-- First Get  DailyTeamActivityID and then get the ReceptionId
	Select @DailyTeamActivityID = DailyTeamActivityID from Checkroll.DailyTeamActivity where MandorBesarID = @MandorebesarId and DDate = @DDate AND Activity = @Activity ANd MandorPremi > 0

	
	if @Activity = 'Panen'
	begin
	    select top 1 @DivId = DivID from Checkroll.DailyAttendance 
		inner join checkroll.DailyReceiption ON Checkroll.DailyAttendance.DailyReceiptionID = Checkroll.DailyReceiption.DailyReceiptionID
		where DailyTeamActivityID = @DailyTeamActivityID and attendancesetupid = '02R94'
		Select @HaDiawasi=Sum(PlantedHect) from General.blockmaster where DivID = @DivId and BlockStatus = 'Matured' and Cropid = 'M1'
	end
	else
	begin
		select top 1 @DivId = Afdeling from Checkroll.DailyAttendance 
		inner join checkroll.DailyReceptionForRubber ON Checkroll.DailyAttendance.DailyReceiptionID = Checkroll.DailyReceptionForRubber.DailyReceiptionID
		where DailyTeamActivityID = @DailyTeamActivityID and attendancesetupid = '02R94'
		--select top 1 @DivId = Afdeling from Checkroll.DailyReceptionForRubber where DailyReceiptionID = @DailyReceptionId
		Select @HaDiawasi=Sum(PlantedHect) from General.blockmaster where DivID = @DivId and BlockStatus = 'Matured' and Cropid = 'M2'
	end		

	RETURN (@HaDiawasi);	
END;



