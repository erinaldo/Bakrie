
GO

/****** Object:  StoredProcedure [Checkroll].[GangEmployeeSetupModify]    Script Date: 12/03/2015 15:52:04 ******/
DROP PROCEDURE [Checkroll].[GangEmployeeSetupModify]
GO

/****** Object:  StoredProcedure [Checkroll].[GangEmployeeSetupModify]    Script Date: 12/03/2015 15:52:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE[Checkroll].[GangEmployeeSetupModify]
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50),
        @EstateCode nvarchar(50),
        @GangMasterID nvarchar(50),
        @EmpID nvarchar(50),
		@MandorBesarID nvarchar(50),
		@MandorID nvarchar(50),
		@KraniID nvarchar(50),
        @CreatedBy nvarchar(50),
		@DDAte datetime,
		@DailyTeamActivityID nvarchar(50)
AS
        BEGIN TRY
                DECLARE @GangEmployeeID NVARCHAR(50), @isExist int
                DECLARE @i INT = 2
                BEGIN
                        SELECT @GangEmployeeID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                        FROM   Checkroll.DailyGangEmployeeSetup
                        WHILE EXISTS
                        (SELECT id
                        FROM    Checkroll.DailyGangEmployeeSetup
                        WHERE   GangEmployeeID = @GangEmployeeID
                        )
                        BEGIN
                                SELECT @GangEmployeeID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                                FROM   Checkroll.DailyGangEmployeeSetup
                                SET @i = @i + 1
                        END

						-- Update Header
						--if @MandorBesarID <> '' and @KraniID <> '' and @MandorBesarID <> ''
						--begin
						--UPDATE Checkroll.GangMaster set MandoreID = @MandorID, KraniID = @KraniID where GangMasterID = @GangMasterID
						--UPDATE Checkroll.GangMasterBesar set GangMasterBesarID = @MandorBesarID where GangMasterID = @GangMasterID
						--Update Checkroll.DailyTeamActivity set MandoreID = @MandorID, KraniID = @KraniID where EstateID  = @EstateID and  CONVERT(DATE,DDate)= @DailyDate and GangMasterID = @GangMasterID
						--end
						-- Check Employee
						select @isExist = count(*) from Checkroll.DailyGangEmployeeSetup where EmpID = @EmpID AND DDAte = @DDAte AND DailyTeamActivityID = @DailyTeamActivityID
						if @isExist = 1
							Begin
							Delete from Checkroll.DailyGangEmployeeSetup where EmpID = @EmpID AND DDAte = @DDAte AND DailyTeamActivityID = @DailyTeamActivityID
							-- Insert statements for procedure here
							INSERT
							INTO   Checkroll.DailyGangEmployeeSetup
								   (
										  DDAte,
										  DailyTeamActivityID,
										  GangEmployeeID,
										  EstateID      ,
										  GangMasterID  ,
										  EmpID         ,
										  CreatedBy     ,
										  CreatedOn     ,
										  ModifiedBy    ,
										  ModifiedOn
								   )
								   VALUES
								   (
										  @DDAte,
										  @DailyTeamActivityID,
										  @GangEmployeeID,
										  @EstateID      ,
										  @GangMasterID  ,
										  @EmpID         ,
										  @CreatedBy     ,
										  GETDATE ()     ,
										  @CreatedBy     ,
										  GETDATE ()
								   )
							SELECT 1 AS Inserted
							END
						else if @isExist = 0
							-- Insert statements for procedure here
							INSERT
							INTO   Checkroll.DailyGangEmployeeSetup
								   (
										  DDAte,
										  DailyTeamActivityID,
										  GangEmployeeID,
										  EstateID      ,
										  GangMasterID  ,
										  EmpID         ,
										  CreatedBy     ,
										  CreatedOn     ,
										  ModifiedBy    ,
										  ModifiedOn
								   )
								   VALUES
								   (
										  @DDAte,
										  @DailyTeamActivityID,
										  @GangEmployeeID,
										  @EstateID      ,
										  @GangMasterID  ,
										  @EmpID         ,
										  @CreatedBy     ,
										  GETDATE ()     ,
										  @CreatedBy     ,
										  GETDATE ()
								   )
							SELECT 1 AS Inserted
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


