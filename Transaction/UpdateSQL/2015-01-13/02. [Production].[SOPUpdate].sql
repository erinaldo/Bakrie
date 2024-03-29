
GO
/****** Object:  StoredProcedure [Production].[SOPUpdate]    Script Date: 13/01/2015 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Production].[SOPUpdate]
-- Add the parameters for the stored procedure here
@SOPID nvarchar(50)OUTPUT,
        @OLFruitInEB            NUMERIC(18,3),
        @OLEBStalk              NUMERIC(18,3),
        @OLPressCakeFibre       NUMERIC(18,3),
        @OLNutExpressCake       NUMERIC(18,3),
        @OLFinalElement         NUMERIC(18,3),
        @OLOER                  NUMERIC(18,3),
        @OLFruitInEBSample      NUMERIC(18,3),
        @OLEBStalkSample        NUMERIC(18,3),
        @OLPressCakeFibreSample NUMERIC(18,3),
        @OLNutExpressCakeSample NUMERIC(18,3),
        @OLFinalElementSample   NUMERIC(18,3),
        @OLOERSample            NUMERIC(18,3),
        @OLPressFibreOWM        NUMERIC(18,3),
        @OLSludgeCentrifugeOWM  NUMERIC(18,3),
        @OLFlowOWM              NUMERIC(18,3),
        @OLPressFibreODM        NUMERIC(18,3),
        @OLSludgeCentrifugeODM  NUMERIC(18,3),
        @KLFruitInEB            NUMERIC(18,3),
        @KLFibreCyclone         NUMERIC(18,3),
        @KLLTDS1                NUMERIC(18,3),
        @KLLTDS2                NUMERIC(18,3),
        @KLLTDS3                NUMERIC(18,3),
        @KLLTDS4                NUMERIC(18,3),
        @KLHydrocyclone         NUMERIC(18,3),
        @KLKER                  NUMERIC(18,3),
        @KLFibreCycloneSample   NUMERIC(18,3),
        @KLLTDS1Sample          NUMERIC(18,3),
        @KLLTDS2Sample          NUMERIC(18,3),
        @KLLTDS3Sample          NUMERIC(18,3),
        @KLLTDS4Sample          NUMERIC(18,3),
        @KLHydrocycloneSample   NUMERIC(18,3),
        @KLKERSample            NUMERIC(18,3),
        @QltCPOFFA              NUMERIC(18,3),
        @QltCPOMoisture         NUMERIC(18,3),
        @QltCPODirt             NUMERIC(18,3),
        @QltCPKOFFA             NUMERIC(18,3),
        @QltCPKOMoisture        NUMERIC(18,3),
        @QltCPKODirt            NUMERIC(18,3),
        @QltFKMoisture          NUMERIC(18,3),
        @QltFKDirt              NUMERIC(18,3),
        @QltFKBrokenKernel      NUMERIC(18,3),
        @QltFKNutPressCake      NUMERIC(18,3),
        @QltKAMoisture          NUMERIC(18,3),
        @QltKADirt              NUMERIC(18,3),
        @QltKABrokenKernel      NUMERIC(18,3),
        @QltKANutPressCake      NUMERIC(18,3),
        @GenThroughput          NUMERIC(18,3),
        @GenPerCagCapacity      NUMERIC(18,3),
        @GenEfficiencyRolex		NUMERIC(18,3),
        @GenEfficiencyRippleMill NUMERIC(18,3),
        @GrdUnripeBunch         NUMERIC(18,3),
        @GrdUnderripeBunch      NUMERIC(18,3),
        @GrdRipeBunch           NUMERIC(18,3),
        @GrdOvrRipeBunch        NUMERIC(18,3),
        @GrdEmtBunch            NUMERIC(18,3),
        @GrdTotNrmFruit         NUMERIC(18,3),
        @GrdParthenocarpy       NUMERIC(18,3),
        @GrdHardBunch           NUMERIC(18,3),
        @GrdTotAbnormal         NUMERIC(18,3),
        @GrdGrandTotal          NUMERIC(18,3),
        @GrdLooseFruit          NUMERIC(18,3),
        @GrdUndamage            NUMERIC(18,3),
        @GrdLightDamage         NUMERIC(18,3),
        @GrdDamage              NUMERIC(18,3),
		@LongStick             NUMERIC(18,3),
        --     @ConcurrencyID rowversion output,
        @ModifiedBy nvarchar(50),
        @ModifiedOn DATETIME,
        @EstateID nvarchar(50)

AS

        BEGIN TRY

                UPDATE [Production].[SOP]
                SET    SOPID                  = @SOPID                  ,
                       OLFruitInEB            = @OLFruitInEB            ,
                       OLEBStalk              = @OLEBStalk              ,
                       OLPressCakeFibre       = @OLPressCakeFibre       ,
                       OLNutExpressCake       = @OLNutExpressCake       ,
                       OLFinalElement         = @OLFinalElement         ,
                       OLOER                  = @OLOER                  ,
                       OLFruitInEBSample      = @OLFruitInEBSample      ,
                       OLEBStalkSample        = @OLEBStalkSample        ,
                       OLPressCakeFibreSample = @OLPressCakeFibreSample ,
                       OLNutExpressCakeSample = @OLNutExpressCakeSample ,
                       OLFinalElementSample   = @OLFinalElementSample   ,
                       OLOERSample            = @OLOERSample            ,
                       OLPressFibreOWM        = @OLPressFibreOWM        ,
                       OLSludgeCentrifugeOWM  = @OLSludgeCentrifugeOWM  ,
                       OLFlowOWM              = @OLFlowOWM              ,
                       OLPressFibreODM        = @OLPressFibreODM        ,
                       OLSludgeCentrifugeODM  = @OLSludgeCentrifugeODM  ,
                       KLFruitInEB            = @KLFruitInEB            ,
                       KLFibreCyclone         = @KLFibreCyclone         ,
                       KLLTDS1                = @KLLTDS1                ,
                       KLLTDS2                = @KLLTDS2                ,
                       KLLTDS3                = @KLLTDS3                ,
                       KLLTDS4                = @KLLTDS4                ,
                       KLHydrocyclone         = @KLHydrocyclone         ,
                       KLKER                  = @KLKER                  ,
                       KLFibreCycloneSample   = @KLFibreCycloneSample   ,
                       KLLTDS1Sample          = @KLLTDS1Sample          ,
                       KLLTDS2Sample          = @KLLTDS2Sample          ,
                       KLLTDS3Sample          = @KLLTDS3Sample          ,
                       KLLTDS4Sample          = @KLLTDS4Sample          ,
                       KLHydrocycloneSample   = @KLHydrocycloneSample   ,
                       KLKERSample            = @KLKERSample            ,
                       QltCPOFFA              = @QltCPOFFA              ,
                       QltCPOMoisture         = @QltCPOMoisture         ,
                       QltCPODirt             = @QltCPODirt             ,
                       QltCPKOFFA             = @QltCPKOFFA             ,
                       QltCPKOMoisture        = @QltCPKOMoisture        ,
                       QltCPKODirt            = @QltCPKODirt            ,
                       QltFKMoisture          = @QltFKMoisture          ,
                       QltFKDirt              = @QltFKDirt              ,
                       QltFKBrokenKernel      = @QltFKBrokenKernel      ,
                       QltFKNutPressCake      = @QltFKNutPressCake      ,
                       QltKAMoisture          = @QltKAMoisture          ,
                       QltKADirt              = @QltKADirt              ,
                       QltKABrokenKernel      = @QltKABrokenKernel      ,
                       QltKANutPressCake      = @QltKANutPressCake      ,
                       GenThroughput          = @GenThroughput          ,
                       GenPerCagCapacity      = @GenPerCagCapacity      ,
                       GenEfficiencyRolex	  = @GenEfficiencyRolex		,
                       GenEfficiencyRippleMill= @GenEfficiencyRippleMill,
                       GrdUnripeBunch         = @GrdUnripeBunch         ,
                       GrdUnderripeBunch      = @GrdUnderripeBunch      ,
                       GrdRipeBunch           = @GrdRipeBunch           ,
                       GrdOvrRipeBunch        = @GrdOvrRipeBunch        ,
                       GrdEmtBunch            = @GrdEmtBunch            ,
                       GrdTotNrmFruit         = @GrdTotNrmFruit         ,
                       GrdParthenocarpy       = @GrdParthenocarpy       ,
                       GrdHardBunch           = @GrdHardBunch           ,
                       GrdTotAbnormal         = @GrdTotAbnormal         ,
                       GrdGrandTotal          = @GrdGrandTotal          ,
                       GrdLooseFruit          = @GrdLooseFruit          ,
                       GrdUndamage            = @GrdUndamage            ,
                       GrdLightDamage         = @GrdLightDamage         ,
                       GrdDamage              =@GrdDamage               ,
                       ModifiedBy             = @ModifiedBy             ,
                       ModifiedOn             = GETDATE()              ,
                       EstateID               = @EstateID,
					   LongStick =@LongStick
                WHERE  SOPID                  =@SOPID;

                SELECT 2;

                -- and ConcurrencyId=@ConcurrencyId;

                --SELECT @ConcurrencyId = ConcurrencyId FROM Production .SOP WHERE SOPID=@SOPID ;

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
