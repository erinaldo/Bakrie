GO
/****** Object:  StoredProcedure [Checkroll].[DailyActivityTeamInsert]    Script Date: 02/02/2015 9:41:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Agung Batricorsila>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Checkroll].[DailyActivityTeamInsert]
	-- Add the parameters for the stored procedure here
	@DDATE date,
	@DailyTeamActivityID nvarchar(50) output,
	@EstateID nvarchar(50),
	@EstateCode nvarchar(50),
	@GangMasterID nvarchar(50),
	@GangName nvarchar(50),
	@Activity nvarchar(50),
	@MandoreID nvarchar(50),
	@KraniID nvarchar(50),
	@CreatedOn datetime,
	@ModifiedBy nvarchar(50),
	@ModifiedOn datetime,
	@CreatedBy nvarchar(50),
	@MandorBesarID nvarchar(50)
	
AS

	
BEGIN TRY
    -- Get New Primary key
  
   Declare @count int
   Declare @ConcurrencyId timestamp
  
--SELECT @DailyTeamActivityID =  @EstateCode+'R'+  CAST((CASE WHEN (ISNULL(MAX(Id), -1) = -1) THEN 1 WHEN MAX(Id) >= 1 THEN MAX(Id) + 1 END) AS VARCHAR) 
--FROM  Checkroll.DailyTeamActivity 

   SELECT @DailyTeamActivityID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                FROM   Checkroll.DailyTeamActivity
                DECLARE @i INT = 2
                WHILE EXISTS
                (SELECT id
                FROM   Checkroll.DailyTeamActivity
                WHERE   DailyTeamActivityID = @DailyTeamActivityID
                )
                BEGIN
                        SELECT @DailyTeamActivityID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                        FROM   Checkroll.DailyTeamActivity
                        SET @i = @i + 1
                END
  
	-- Insert statements for procedure here
	INSERT INTO Checkroll.DailyTeamActivity
		(
		DDate,
		DailyTeamActivityID ,
	    EstateID,
		GangMasterID ,
		GangName,
		Activity,
		MandoreID ,
		KraniID,
		CreatedBy,
		CreatedOn,
		ModifiedBy,
		ModifiedOn,
		MandorBesarID
		)
	VALUES
		(
		@DDATE,
		@DailyTeamActivityID,
		@EstateID,
		@GangMasterID ,
		@GangName,
		@Activity,
		@MandoreID,
		@KraniID,
		@CreatedBy,
		@CreatedOn,
		@ModifiedBy,
		@ModifiedOn,
		@MandorBesarID
		
		);


	RETURN SCOPE_IDENTITY();	
	
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    
    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

	RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH;















