
GO


/****** Object:  StoredProcedure [Checkroll].[GangEmployeeSetupModify]    Script Date: 06/01/2015 11:39:38 ******/
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
        @CreatedBy nvarchar(50)
AS
        BEGIN TRY
                DECLARE @GangEmployeeID NVARCHAR(50), @isExist int
                DECLARE @i INT = 2
                BEGIN
                        SELECT @GangEmployeeID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                        FROM   Checkroll.GangEmployeeSetup
                        WHILE EXISTS
                        (SELECT id
                        FROM    Checkroll.GangEmployeeSetup
                        WHERE   GangEmployeeID = @GangEmployeeID
                        )
                        BEGIN
                                SELECT @GangEmployeeID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                                FROM   Checkroll.GangEmployeeSetup
                                SET @i = @i + 1
                        END

						-- Update Header
						if @MandorBesarID <> '' and @KraniID <> '' and @MandorBesarID <> ''
						begin
						UPDATE Checkroll.GangMaster set MandoreID = @MandorID, KraniID = @KraniID where GangMasterID = @GangMasterID
						UPDATE Checkroll.GangMasterBesar set GangMasterBesarID = @MandorBesarID where GangMasterID = @GangMasterID
						end
						-- Check Employee
						select @isExist = count(*) from Checkroll.GangEmployeeSetup where EmpID = @EmpID
						if @isExist = 1
							Begin
							Delete from Checkroll.GangEmployeeSetup where EmpID = @EmpID
							-- Insert statements for procedure here
							INSERT
							INTO   Checkroll.GangEmployeeSetup
								   (
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
							INTO   Checkroll.GangEmployeeSetup
								   (
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


