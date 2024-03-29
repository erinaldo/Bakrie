
/****** Object:  StoredProcedure [Store].[STConfigurationInsert]    Script Date: 28/04/2015 19:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Created By :
-- Modified By:  Siva Subramanian S
-- Created date:
-- Last Modified Date:16th Nov 2009
-- Module     : Store
-- Screen(s)  :
-- Description:
-- =============================================
ALTER PROCEDURE [Store].[STConfigurationInsert]
--Add the parameters for the stored procedure here
@STCONFIGURATIONID NVARCHAR(50) OUTPUT,
        @ESTATEID NVARCHAR(50),
        @IPRPREFIX NVARCHAR(10),
        @IPRCOMMENCE NVARCHAR(10),
        @RGNPREFIX NVARCHAR(10),
        @RGNCOMMENCE NVARCHAR(10),
        @ITNOUTPREFIX NVARCHAR(10),
        @ITNOUTCOMMENCE NVARCHAR(10),
        @ADJUSTPREFIX NVARCHAR(10),
        @ADJUSTCOMMENCE NVARCHAR(10),
        @LPOPREFIX NVARCHAR(10),
        @LPOCOMMENCE NVARCHAR(10),
        @ISRPREFIX NVARCHAR(10),
        @ISRCOMMENCE NVARCHAR(10),
        --@ConcurrencyId rowversion output,
        @ESTATECODE NVARCHAR(50),
        @CREATEDBY NVARCHAR(50),
        @CREATEDON DATETIME,
        @MODIFIEDBY NVARCHAR(50),
        @MODIFIEDON DATETIME
AS
        BEGIN TRY
                -- Get New Primary key
                DECLARE @I INT = 2
                BEGIN
                        SELECT @STCONFIGURATIONID = @ESTATECODE + 'R' + CAST ( (ISNULL(MAX(ID),0) + 1) AS VARCHAR)
                        FROM   [Store].[STConfiguration]
                        WHILE EXISTS
                        (SELECT ID
                        FROM    [Store].[STConfiguration]
                        WHERE   STCONFIGURATIONID = @STCONFIGURATIONID
                        )
                        BEGIN
                                SELECT @STCONFIGURATIONID = @ESTATECODE + 'R' + CAST ( (ISNULL(MAX(ID),0) + @I) AS VARCHAR)
                                FROM   [Store].[STConfiguration]
                                SET @I = @I + 1
                        END
                        --SELECT @count = (ISNULL(MAX(Id),0) + 1) FROM Store.STConfiguration ;
                        --SET @STConfigurationID = 'S'+ CONVERT(NVARCHAR,@count);
                        -- Insert statements for procedure here
						
						if(@ISRPrefix is null)
							set @ISRPrefix ='-'
						if(@ISRCommence is null)
						set @ISRCommence ='-'
                        INSERT
                        INTO   STORE.STCONFIGURATION
                               (
                                      STCONFIGURATIONID,
                                      ESTATEID         ,
                                      IPRPREFIX        ,
                                      IPRCOMMENCE      ,
                                      RGNPREFIX        ,
                                      RGNCOMMENCE      ,
                                      ITNOUTPREFIX     ,
                                      ITNOUTCOMMENCE   ,
                                      ADJUSTPREFIX     ,
                                      ADJUSTCOMMENCE   ,
                                      LPOPREFIX        ,
                                      LPOCOMMENCE      ,
                                      ISRPREFIX        ,
                                      ISRCOMMENCE      ,
                                      CREATEDBY        ,
                                      CREATEDON        ,
                                      MODIFIEDBY       ,
                                      MODIFIEDON
                               )
                               VALUES
                               (
                                      @STCONFIGURATIONID,
                                      @ESTATEID         ,
                                      @IPRPREFIX        ,
                                      @IPRCOMMENCE      ,
                                      @RGNPREFIX        ,
                                      @RGNCOMMENCE      ,
                                      @ITNOUTPREFIX     ,
                                      @ITNOUTCOMMENCE   ,
                                      @ADJUSTPREFIX     ,
                                      @ADJUSTCOMMENCE   ,
                                      @LPOPREFIX        ,
                                      @LPOCOMMENCE      ,
                                      ISNULL(@ISRPREFIX ,0)       ,
                                      ISNULL(@ISRCommence,0)      ,
                                      @CREATEDBY        ,
                                      @CREATEDON        ,
                                      @MODIFIEDBY       ,
                                      @MODIFIEDON
                               );
                        
                        SELECT 1
                        --SELECT @ConcurrencyId = ConcurrencyId FROM Store.STConfiguration  WHERE STConfigurationID=@STConfigurationID;
                END
        END TRY
        BEGIN CATCH
                DECLARE @ERRORMESSAGE NVARCHAR(4000);
                DECLARE @ERRORSEVERITY INT;
                DECLARE @ERRORSTATE    INT;
                SELECT @ERRORMESSAGE  = ERROR_MESSAGE() ,
                       @ERRORSEVERITY = ERROR_SEVERITY(),
                       @ERRORSTATE    = ERROR_STATE();
                
                RAISERROR (@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE);
        END CATCH;




