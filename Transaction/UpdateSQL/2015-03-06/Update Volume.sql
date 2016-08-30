alter table Production.VolumeMaster
add Difference numeric(18, 3);
go

GO
/****** Object:  StoredProcedure [Production].[VolumeMasterInsert]    Script Date: 06/03/2015 11:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Created By :
-- Modified By:  
-- Created date:
-- Module     : Production
-- Screen(s)  :
-- Description:
-- =============================================
ALTER PROCEDURE [Production].[VolumeMasterInsert]
-- Add the parameters for the stored procedure here
--@Pkey nvarchar(50) output,
@VolumeID nvarchar(50) output,
@EstateID nvarchar(50),
@EstateCode nvarchar(50),
@TankID nvarchar(50),
--@TankNo nvarchar(80),
@Height numeric(18, 0),
@Volume numeric(18, 0),
--@ConcurrencyId rowversion output,
@CreatedBy nvarchar(50),
@CreatedOn DATETIME,
@ModifiedBy nvarchar(50),
@ModifiedOn DATETIME,
@Difference numeric(18, 0)
AS
        BEGIN TRY
				DECLARE @i INT = 2
                SELECT @VolumeID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                        FROM   Production.VolumeMaster
                        WHILE EXISTS
                        (SELECT id
                        FROM    Production.VolumeMaster
                        WHERE   VolumeID = @VolumeID
                        )
                        BEGIN
                                SELECT @VolumeID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                                FROM   Production.MachineryMaster
                                SET @i = @i + 1
                        END
                
               
						-- Insert statements for procedure here
						INSERT
						INTO   Production.VolumeMaster
							   (
									  VolumeID   ,
									  EstateID ,
									  TankID,
									 -- TankNo,
									  Height,
									  Volume    ,
									  CreatedBy   ,
									  CreatedOn   ,
									  ModifiedBy  ,
									  ModifiedOn ,
									  Difference
							   )
							   VALUES
							   (
									  @VolumeID   ,
									  @EstateID ,
									  @TankID    ,
									--  @TankNo,
									  @Height,
									  @Volume,
									  @CreatedBy   ,
									  GETDATE ()   ,
									  @ModifiedBy  ,
									  GETDATE (),
									  @Difference
							   );
		                
                --SELECT @ConcurrencyId = ConcurrencyId FROM Production.Station WHERE StationID=@StationID;
                SELECT 1 
               -- RETURN SCOPE_IDENTITY();
        
        END TRY
        BEGIN CATCH
                DECLARE @ErrorMessage NVARCHAR(4000);
                DECLARE @ErrorSeverity INT;
                DECLARE @ErrorState    INT;
                SELECT @ErrorMessage  = ERROR_MESSAGE() ,
                       @ErrorSeverity = ERROR_SEVERITY(),
                       @ErrorState    = ERROR_STATE();
                
                RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
        END CATCH;


		GO

		
GO
/****** Object:  StoredProcedure [Production].[VolumeMasterUpdate]    Script Date: 06/03/2015 11:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- ALTERd By :
-- Modified By:  Siva Subramanian S
-- ALTERd date:
-- Last Modified Date:16th Nov 2009
-- Module     : Production
-- Screen(s)  :
-- Description:
-- =============================================
--select * from Production.VolumeMaster
--exec [Production].[VolumeMasterUpdate] '01R3','M1','01R6',7,8,'2012-10-16','2012-10-16'
ALTER PROCEDURE [Production].[VolumeMasterUpdate]
-- Add the parameters for the stored procedure here

@VolumeID nvarchar(50),
@EstateID nvarchar(50),
@TankID nvarchar(50),
--@TankNo nvarchar(50),
@Height numeric(18,0),
@Volume numeric(18,0),
@ModifiedBy nvarchar(50),
@ModifiedOn DATETIME,
@Difference numeric(18,0)

AS

        BEGIN TRY

		UPDATE Production.VolumeMaster
        SET    Height =@Height,
			   Volume =@Volume,
               ModifiedBy  =@ModifiedBy  ,
               ModifiedOn  =GETDATE() ,
			   Difference=@Difference
        WHERE  VolumeID   = @VolumeID ;

        SELECT 2;

          
        END TRY
        BEGIN CATCH

                DECLARE @ErrorMessage NVARCHAR(4000);
                DECLARE @ErrorSeverity INT;
                DECLARE @ErrorState    INT;

                SELECT @ErrorMessage  = ERROR_MESSAGE() ,
                       @ErrorSeverity = ERROR_SEVERITY(),
                       @ErrorState    = ERROR_STATE();

                RAISERROR (@ErrorMessage, -- Message text.
                @ErrorSeverity,           -- Severity.
                @ErrorState               -- State.
                );

        END CATCH;


		go

		GO
/****** Object:  StoredProcedure [Production].[VolumeMasterSelect]    Script Date: 06/03/2015 11:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from Production.VolumeMaster
--exec [Production].[VolumeMasterSelect] 01,'00\','M1'
ALTER PROCEDURE [Production].[VolumeMasterSelect]
-- Add the parameters for the stored procedure here
@VolumeID nvarchar(50),
@TankNo varchar(50),
@EstateID nvarchar(50)
AS
        SET NOCOUNT ON;
        IF (@VolumeID IS NULL and @TankNo='0') -- Select all
        BEGIN
                SELECT   ROW_NUMBER() OVER(ORDER BY v.id) AS RowRank,
                         v.VolumeID                                ,
                         v.EstateID ,
                         v.TankID,
					     t.TankNo                              ,
                         v.Height  ,
                         v.Volume                                ,
                         v.CreatedBy                                ,
                         v.CreatedOn                                ,
                         v.ModifiedBy                               ,
                         v.ModifiedOn,
						 v.Difference
                FROM     Production.VolumeMaster v
                INNER join Production.TankMaster t
                ON t.TankID=v.TankID
                WHERE    v.EstateID=@EstateID 
                --and v.VolumeID=@VolumeID
				--AND t.TankID=@TankID
                ORDER BY ModifiedOn DESC

        END
        ELSE
        BEGIN
                SELECT   ROW_NUMBER() OVER(ORDER BY a.id) AS RowRank,
                         a.VolumeID                                ,
                         a.EstateID ,
                         a.TankID,
                        b.TankNo,
                         a.Height,
                         a.Volume,
                         a.CreatedBy                                ,
                         a.CreatedOn                                ,
                         a.ModifiedBy                               ,
                         a.ModifiedOn,
						 a.Difference
                FROM     Production.VolumeMaster a
                inner join Production.TankMaster b
                on a.TankID=b.TankID
                WHERE    a.EstateID =@EstateID
                     --AND a.VolumeID=@VolumeID 
                     AND b.TankNo like '%' + @TankNo + '%'
                ORDER BY ModifiedOn DESC

        END
