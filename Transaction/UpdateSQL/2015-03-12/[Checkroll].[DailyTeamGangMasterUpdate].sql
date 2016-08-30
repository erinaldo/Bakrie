
GO

/****** Object:  StoredProcedure [Checkroll].[DailyTeamGangMasterUpdate]    Script Date: 12/03/2015 15:51:49 ******/
DROP PROCEDURE [Checkroll].[DailyTeamGangMasterUpdate]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyTeamGangMasterUpdate]    Script Date: 12/03/2015 15:51:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyTeamGangMasterUpdate]
	-- Add the parameters for the stored procedure here
	@MandorBesarID as varchar(50),
	@MandorID as varchar(50),
	@KraniID as varchar(50),
	@EstateID as varchar(50),
	@DailyDate as varchar(50),
	@GangMasterID as varchar(50)
AS
BEGIN TRY
BEGIN
Declare @result as int

	Update Checkroll.DailyTeamActivity set MandoreID = @MandorID, KraniID = @KraniID where EstateID  = @EstateID and  CONVERT(DATE,DDate)= @DailyDate and GangMasterID = @GangMasterID
	--Update Checkroll.GangMaster set MandoreID = @MandorID, KraniID = @KraniID where GangMasterID = @GangMasterID

	--Select @result = Count(*) from Checkroll.GangMasterBesar where GangMasterID = @GangMasterID
	--if @result = 0
	--INSERT INTO Checkroll.GangMasterBesar (GangMasterID, GangMasterBesarID) Values (@GangMasterID, @MandorBesarID)
	--else
	--Update Checkroll.GangMasterBesar set GangMasterBesarID = @MandorBesarID where GangMasterID = @GangMasterID

END
END TRY
        BEGIN CATCH
                DECLARE @ErrorMessage NVARCHAR ( 4000 );
                DECLARE @ErrorSeverity INT;
                DECLARE @ErrorState    INT;
                SELECT @ErrorMessage  = ERROR_MESSAGE() ,
                       @ErrorSeverity = ERROR_SEVERITY(),
                       @ErrorState    = ERROR_STATE();
                
                RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
        END CATCH;


GO


