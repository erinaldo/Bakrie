

GO
/****** Object:  StoredProcedure [Checkroll].[TaxAndRiceSetupInsert]    Script Date: 11/07/2015 20:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[TaxAndRiceSetupInsert]
@EstateID NVARCHAR(50),
        @DeductionCost         NUMERIC(18,2),
        @DeductionCostMax      NUMERIC(18,2),
        @Jamsostek             NUMERIC(18,2),
        @JkkAndJK              NUMERIC(18,2),
        @RAEmployee            NUMERIC(18,2),
        @RAHusbandOrWife       NUMERIC(18,2),
        @RAChild               NUMERIC(18,2),
        @RAPrice               NUMERIC(18,2),
        @GradeI                NUMERIC(18,2),
        @GradeIRange           NUMERIC(18,2),
        @GradeII               NUMERIC(18,2),
        @GradeIIRangeFrom      NUMERIC(18,2),
        @GradeIIRangeTo        NUMERIC(18,2),
        @GradeIII              NUMERIC(18,2),
        @GradeIIIRangeFrom     NUMERIC(18,2),
        @GradeIIIRangeTo       NUMERIC(18,2),
        @GradeIV               NUMERIC(18,2),
        @GradeIVRangeFrom      NUMERIC(18,2),
        @GradeIVRangeTo        NUMERIC(18,2),
        @GradeV                NUMERIC(18,2),
        @GradeVRange           NUMERIC(18,2),
        @GradeINPWP            NUMERIC(18,2),
        @GradeIRangeNPWP       NUMERIC(18,2),
        @GradeIINPWP           NUMERIC(18,2),
        @GradeIIRangeFromNPWP  NUMERIC(18,2),
        @GradeIIRangeToNPWP    NUMERIC(18,2),
        @GradeIIINPWP          NUMERIC(18, 2),
        @GradeIIIRangeFromNPWP NUMERIC(18, 2),
        @GradeIIIRangeToNPWP   NUMERIC(18, 2),
        @GradeIVNPWP           NUMERIC(18, 2),
        @GradeIVRangeFromNPWP  NUMERIC(18, 2),
        @GradeIVRangeToNPWP    NUMERIC(18, 2),
        @GradeVNPWP            NUMERIC(18, 2),
        @GradeVRangeNPWP       NUMERIC(18, 2),
        @TaxExemptionWorker    NUMERIC(18, 2),
        @TaxExemptionHusbWife  NUMERIC(18, 2),
        @TaxExemptionChild     NUMERIC(18, 2),
        @CreatedBy NVARCHAR(50),
        @FunctionalAllowanceP  NUMERIC(18, 2),
        @MaxAllowance     NUMERIC(18, 2),
		@RANaturaPrice     NUMERIC(18, 2)
AS
        BEGIN TRY
                -- Get New Primary key
                --DECLARE @Count INT
                DECLARE @TaxAndRiceID NVARCHAR(50)
                DECLARE @EstateCode NVARCHAR(50)
                DECLARE @IsTaxAndRiceNoDuplicate NVARCHAR(50)
                DECLARE @i INT = 2
                BEGIN
                        --SET @Count = 0;
                        SET @EstateCode =
                        (SELECT EstateCode
                        FROM    General.Estate
                        WHERE   EstateID = @EstateID
                        )
                        SELECT @TaxAndRiceID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                        FROM   Checkroll.TaxAndRiceSetup
                        WHILE EXISTS
                        (SELECT id
                        FROM    Checkroll.TaxAndRiceSetup
                        WHERE   TaxRiceSetupID = @TaxAndRiceID
                        )
                        BEGIN
                                SELECT @TaxAndRiceID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                                FROM   Checkroll.TaxAndRiceSetup
                                SET @i = @i + 1
                        END
                        -- Insert statements for procedure here
                        INSERT
                        INTO   Checkroll.TaxAndRiceSetup
                               (
                                      TaxRiceSetupID       ,
                                      EstateID             ,
                                      DeductionCost        ,
                                      DeductionCostMax     ,
                                      Jamsostek            ,
                                      JkkAndJK             ,
                                      RAEmployee           ,
                                      RAHusbandOrWife      ,
                                      RAChild              ,
                                      RAPrice              ,
                                      GradeI               ,
                                      GradeIRange          ,
                                      GradeII              ,
                                      GradeIIRangeFrom     ,
                                      GradeIIRangeTo       ,
                                      GradeIII             ,
                                      GradeIIIRangeFrom    ,
                                      GradeIIIRangeTo      ,
                                      GradeIV              ,
                                      GradeIVRangeFrom     ,
                                      GradeIVRangeTo       ,
                                      GradeV               ,
                                      GradeVRange          ,
                                      GradeINPWP           ,
                                      GradeIRangeNPWP      ,
                                      GradeIINPWP          ,
                                      GradeIIRangeFromNPWP ,
                                      GradeIIRangeToNPWP   ,
                                      GradeIIINPWP         ,
                                      GradeIIIRangeFromNPWP,
                                      GradeIIIRangeToNPWP  ,
                                      GradeIVNPWP          ,
                                      GradeIVRangeFromNPWP ,
                                      GradeIVRangeToNPWP   ,
                                      GradeVNPWP           ,
                                      GradeVRangeNPWP      ,
                                      TaxExemptionWorker   ,
                                      TaxExemptionHusbWife ,
                                      TaxExemptionChild    ,
                                      CreatedBy            ,
                                      CreatedOn            ,
                                      ModifiedBy           ,
                                      ModifiedOn		   ,
                                      FunctionalAllowanceP ,
                                      MaxAllowance,
									  RANaturaPrice
                               )
                               VALUES
                               (
                                      @TaxAndRiceID         ,
                                      @EstateID             ,
                                      @DeductionCost        ,
                                      @DeductionCostMax     ,
                                      @Jamsostek            ,
                                      @JkkAndJK             ,
                                      @RAEmployee           ,
                                      @RAHusbandOrWife      ,
                                      @RAChild              ,
                                      @RAPrice              ,
                                      @GradeI               ,
                                      @GradeIRange          ,
                                      @GradeII              ,
                                      @GradeIIRangeFrom     ,
                                      @GradeIIRangeTo       ,
                                      @GradeIII             ,
                                      @GradeIIIRangeFrom    ,
                                      @GradeIIIRangeTo      ,
                                      @GradeIV              ,
                                      @GradeIVRangeFrom     ,
                                      @GradeIVRangeTo       ,
                                      @GradeV               ,
                                      @GradeVRange          ,
                                      @GradeINPWP           ,
                                      @GradeIRangeNPWP      ,
                                      @GradeIINPWP          ,
                                      @GradeIIRangeFromNPWP ,
                                      @GradeIIRangeToNPWP   ,
                                      @GradeIIINPWP         ,
                                      @GradeIIIRangeFromNPWP,
                                      @GradeIIIRangeToNPWP  ,
                                      @GradeIVNPWP          ,
                                      @GradeIVRangeFromNPWP ,
                                      @GradeIVRangeToNPWP   ,
                                      @GradeVNPWP           ,
                                      @GradeVRangeNPWP      ,
                                      @TaxExemptionWorker   ,
                                      @TaxExemptionHusbWife ,
                                      @TaxExemptionChild    ,
                                      @CreatedBy            ,
                                      GETDATE()             ,
                                      @CreatedBy            ,
                                      GETDATE()				,
                                      @FunctionalAllowanceP ,
                                      @MaxAllowance,
									  @RANaturaPrice
                               );
                        
                        SELECT 1
                        --END
                        --ELSE
                        --BEGIN
                        -- SELECT 10
                        --END
                END
        END TRY
        BEGIN CATCH
                DECLARE @ErrorMessage NVARCHAR(4000)
                DECLARE @ErrorSeverity INT
                DECLARE @ErrorState    INT
                SELECT @ErrorMessage  = ERROR_MESSAGE() ,
                       @ErrorSeverity = ERROR_SEVERITY(),
                       @ErrorState    = ERROR_STATE() RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
        END CATCH;
        --SP_HELPTEXT 'Checkroll.TaxAndRiceSetupInsert'







go



GO
/****** Object:  StoredProcedure [Checkroll].[TaxAndRiceSetupSelect]    Script Date: 11/07/2015 20:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










-- ====================================================
-- Created By : Gopinath
-- Modified By: SIVA SUBRAMANIAN S
-- Created date: 1 Oct 2009
-- Last Modified Date:07/07/2010
-- Module     : CheckRoll, RKPMS Web
-- Screen(s)  : TaxAndRiceSetup.aspx
-- Description: Procedure to get Tax And Rice Setup
-- =====================================================
ALTER PROCEDURE [Checkroll].[TaxAndRiceSetupSelect]
-- Add the parameters for the stored procedure here
@EstateID NVARCHAR(50)
AS
        SET NOCOUNT ON;
        BEGIN
                SELECT   TaxRiceSetupID       ,
                         DeductionCost        ,
                         DeductionCostMax     ,
                         Jamsostek            ,
                         JkkAndJK             ,
                         RAEmployee           ,
                         RAHusbandOrWife      ,
                         RAChild              ,
                         RAPrice              ,
                         GradeI               ,
                         GradeIRange          ,
                         GradeII              ,
                         GradeIIRangeFrom     ,
                         GradeIIRangeTo       ,
                         GradeIII             ,
                         GradeIIIRangeFrom    ,
                         GradeIIIRangeTo      ,
                         GradeIV              ,
                         GradeIVRangeFrom     ,
                         GradeIVRangeTo       ,
                         GradeV               ,
                         GradeVRange          ,
                         GradeINPWP           ,
                         GradeIRangeNPWP      ,
                         GradeIINPWP          ,
                         GradeIIRangeFromNPWP ,
                         GradeIIRangeToNPWP   ,
                         GradeIIINPWP         ,
                         GradeIIIRangeFromNPWP,
                         GradeIIIRangeToNPWP  ,
                         GradeIVNPWP          ,
                         GradeIVRangeFromNPWP ,
                         GradeIVRangeToNPWP   ,
                         GradeVNPWP           ,
                         GradeVRangeNPWP      ,
                         TaxExemptionWorker   ,
                         TaxExemptionHusbWife ,
                         TaxExemptionChild    ,
                         FunctionalAllowanceP ,
                         MaxAllowance,
						 RANaturaPrice
                FROM     Checkroll.TaxAndRiceSetup
                WHERE    EstateID =@EstateID
                ORDER BY ModifiedOn DESC
        END

		go

		GO
/****** Object:  StoredProcedure [Checkroll].[TaxAndRiceSetupUpdate]    Script Date: 11/07/2015 20:37:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- ====================================================
-- Created By : Gopinath
-- Modified By: SIVA SUBRAMANIAN S
-- Created date: 1 Oct 2009
-- Last Modified Date:07/07/2010
-- Module     : CheckRoll, RKPMS Web
-- Screen(s)  : TaxAndRiceSetup.aspx
-- Description: Procedure to update Tax And Rice Setup
-- =====================================================
ALTER PROCEDURE [Checkroll].[TaxAndRiceSetupUpdate]
--Add the parameters for the stored procedure here
--@ID INT
@Key NVARCHAR(50),
        @EstateID NVARCHAR(50),
        @DeductionCost         NUMERIC(18,2),
        @DeductionCostMax      NUMERIC(18,2),
        @Jamsostek             NUMERIC(18,2),
        @JkkAndJK              NUMERIC(18,2),
        @RAEmployee            NUMERIC(18,2),
        @RAHusbandOrWife       NUMERIC(18,2),
        @RAChild               NUMERIC(18,2),
        @RAPrice               NUMERIC(18,2),
        @GradeI                NUMERIC(18,2),
        @GradeIRange           NUMERIC(18,2),
        @GradeII               NUMERIC(18,2),
        @GradeIIRangeFrom      NUMERIC(18,2),
        @GradeIIRangeTo        NUMERIC(18,2),
        @GradeIII              NUMERIC(18,2),
        @GradeIIIRangeFrom     NUMERIC(18,2),
        @GradeIIIRangeTo       NUMERIC(18,2),
        @GradeIV               NUMERIC(18,2),
        @GradeIVRangeFrom      NUMERIC(18,2),
        @GradeIVRangeTo        NUMERIC(18,2),
        @GradeV                NUMERIC(18,2),
        @GradeVRange           NUMERIC(18,2),
        @GradeINPWP            NUMERIC(18,2),
        @GradeIRangeNPWP       NUMERIC(18,2),
        @GradeIINPWP           NUMERIC(18,2),
        @GradeIIRangeFromNPWP  NUMERIC(18,2),
        @GradeIIRangeToNPWP    NUMERIC(18,2),
        @GradeIIINPWP          NUMERIC(18, 2),
        @GradeIIIRangeFromNPWP NUMERIC(18, 2),
        @GradeIIIRangeToNPWP   NUMERIC(18, 2),
        @GradeIVNPWP           NUMERIC(18, 2),
        @GradeIVRangeFromNPWP  NUMERIC(18, 2),
        @GradeIVRangeToNPWP    NUMERIC(18, 2),
        @GradeVNPWP            NUMERIC(18, 2),
        @GradeVRangeNPWP       NUMERIC(18, 2),
        @TaxExemptionWorker    NUMERIC(18, 2),
        @TaxExemptionHusbWife  NUMERIC(18, 2),
        @TaxExemptionChild     NUMERIC(18, 2),
        @ModifiedBy			   NVARCHAR(50)  ,
        @FunctionalAllowanceP  NUMERIC(18, 2),
        @MaxAllowance		   NUMERIC(18, 2),
		@RANaturaPrice decimal(18,2)
AS
        BEGIN TRY
                BEGIN
                        DECLARE @IsTaxAndRiceNoDuplicate NVARCHAR(50)--,
                        --@IsConcurrecyIdChanged TIMESTAMP
                        --   SELECT @IsTaxAndRiceNoDuplicate = CAS.TaxAndRiceSetupID
                        --                 FROM   Checkroll.TaxAndRiceSetup AS CAS
                        --                 WHERE  CAS.Id <> @ID AND
                        -- CAS.AttendanceSetupID           = @AttendanceSetupID
                        --AND  CAS.EstateID = @EstateID
                        UPDATE Checkroll.TaxAndRiceSetup
                        SET    DeductionCost        =@DeductionCost        ,
                               DeductionCostMax     =@DeductionCostMax     ,
                               Jamsostek            =@Jamsostek            ,
                               JkkAndJK             =@JkkAndJK             ,
                               RAEmployee           =@RAEmployee           ,
                               RAHusbandOrWife      =@RAHusbandOrWife      ,
                               RAChild              =@RAChild              ,
                               RAPrice              =@RAPrice              ,
                               GradeI               =@GradeI               ,
                               GradeIRange          =@GradeIRange          ,
                               GradeII              =@GradeII              ,
                               GradeIIRangeFrom     =@GradeIIRangeFrom     ,
                               GradeIIRangeTo       =@GradeIIRangeTo       ,
                               GradeIII             =@GradeIII             ,
                               GradeIIIRangeFrom    =@GradeIIIRangeFrom    ,
                               GradeIIIRangeTo      =@GradeIIIRangeTo      ,
                               GradeIV              =@GradeIV              ,
                               GradeIVRangeFrom     =@GradeIVRangeFrom     ,
                               GradeIVRangeTo       =@GradeIVRangeTo       ,
                               GradeV               =@GradeV               ,
                               GradeVRange          =@GradeVRange          ,
                               GradeINPWP           =@GradeINPWP           ,
                               GradeIRangeNPWP      =@GradeIRangeNPWP      ,
                               GradeIINPWP          =@GradeIINPWP          ,
                               GradeIIRangeFromNPWP =@GradeIIRangeFromNPWP ,
                               GradeIIRangeToNPWP   =@GradeIIRangeToNPWP   ,
                               GradeIIINPWP         =@GradeIIINPWP         ,
                               GradeIIIRangeFromNPWP=@GradeIIIRangeFromNPWP,
                               GradeIIIRangeToNPWP  =@GradeIIIRangeToNPWP  ,
                               GradeIVNPWP          =@GradeIVNPWP          ,
                               GradeIVRangeFromNPWP =@GradeIVRangeFromNPWP ,
                               GradeIVRangeToNPWP   =@GradeIVRangeToNPWP   ,
                               GradeVNPWP           =@GradeVNPWP           ,
                               GradeVRangeNPWP      =@GradeVRangeNPWP      ,
                               TaxExemptionWorker   =@TaxExemptionWorker   ,
                               TaxExemptionHusbWife =@TaxExemptionHusbWife ,
                               TaxExemptionChild    =@TaxExemptionChild    ,
                               ModifiedBy           =@ModifiedBy           ,
                               ModifiedOn           =GETDATE()			   , 
                               FunctionalAllowanceP	=@FunctionalAllowanceP ,					   
                               MaxAllowance			=@MaxAllowance  ,
							   RANaturaPrice=@RANaturaPrice
                        WHERE  TaxRiceSetupID       = @Key
                           AND EstateID             = @EstateID
                        SELECT 2
                               --END
                 END END TRY BEGIN CATCH DECLARE @ErrorMessage NVARCHAR(4000) DECLARE @ErrorSeverity INT DECLARE @ErrorState INT
                 SELECT @ErrorMessage  = ERROR_MESSAGE() ,
                        @ErrorSeverity = ERROR_SEVERITY(),
                        @ErrorState    = ERROR_STATE() RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState) END CATCH
                        --SP_HELPTEXT 'CHECKROLL.TaxAndRiceSetupUpdate'
















