
GO

/****** Object:  StoredProcedure [Production].[GradingFFBInsert]    Script Date: 4/19/2015 3:30:27 PM ******/
DROP PROCEDURE [Production].[GradingFFBInsert]
GO

/****** Object:  StoredProcedure [Production].[GradingFFBInsert]    Script Date: 4/19/2015 3:30:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--======================================================          
-- Created By : Kumaravel        
-- Created date:  Nov 7 , 2009       
-- Modified By: Naxim     
-- Last Modified Date:Oct 23 , 2013           
-- Module     : Production     
-- Screen(s)  : Grading FFB       
-- Description: To Insert Grading FFB           
--======================================================  

CREATE PROCEDURE [Production].[GradingFFBInsert]
 
		 --  @GradingID nvarchar(50) output,
           @EstateID nvarchar(50),
           @EstateCode nvarchar(50),
           @ActiveMonthYearID nvarchar(50),
           @WeighingID nvarchar(50),
           @GradingDate date,
           @GradingTime time(7),
           @MinMaturity numeric(18,3),
           @LosseFruitPerBunche numeric(18,3) ,
           @UnripeFruitJ numeric(18,3),
           @UnripeFruitP numeric(18,2),
           @UnripeFruitT nvarchar(50),
           @UnderripeJ numeric(18,3),
           @UnderripeP numeric(18,2),
           @UnderripeT nvarchar(50),
           @RipeFruitJ numeric(18,3),
           @RipeFruitP numeric(18,2),
           @RipeFruitT nvarchar(50),
           @OverRipeFruitJ numeric(18,3),
           @OverRipeFruitP nvarchar(50),
           @OverRipeFruitT nvarchar(50),
           @EmptyBunchFruitJ numeric(18,3),
           @EmptyBunchFruitP numeric(18,2),
           @EmptyBunchFruitT nvarchar(50),
           @TotalNormalFruitsJ numeric(18,3),
           @TotalNormalFruitsP numeric(18,2),
           @TotalNormalFruitsT nvarchar(50),
           @PartheJ numeric(18,3),
           @PartheP numeric(18,2),
           @PartheT nvarchar(50),
           @HardBunchJ numeric(18,3),
           @HardBunchP numeric(18,2),
           @HardBunchT nvarchar(50),
           @TotalAbnormalFruitsJ numeric(18,3),
           @TotalAbnormalFruitsP numeric(18,2),
           @TotalAbnormalFruitsT nvarchar(50),
           @GTActualBunchesJ numeric(18,3),
           @GTActualBunchesP numeric(18,2),
           @GTActualBunchesT nvarchar(50),--numeric(18,3),
           @LooseFruitsP numeric(18,2),
           @KgOfLooseFruit numeric(18,3),
           @UnDamageJ numeric(18,3),
           @UnDamageP numeric(18,2),
           @UnDamageT nvarchar(50),
           @LightDamageJ numeric(18,3),
           @LightDamageP numeric(18,2),
           @LightDamageT nvarchar(50),
           @DamageJ numeric(18,3),
           @DamageP numeric(18,2),
           @DamageT nvarchar(50),
           @TotalJ numeric(18,3),
           @TotalP numeric(18,2),
           @TotalT nvarchar(50),
           @Comment nvarchar(500),
		   
		   @LongStalksJ numeric(18,3),
		   @DirtAndStonesJ numeric(18,3),
		   @SmallBunchesJ numeric(18,3),
		   @BuahRestanJ numeric(18,3),
		   @MediumDamageJ numeric(18,3),
		   @UnripeFruitComment nvarchar (200),
           @UnderRipeComment nvarchar (200),
		   @OverRipeFruitComment nvarchar (200),
		   @EmptyBunchFruitComment nvarchar (200),
		   @LongStalksComment nvarchar (200),
		   @LooseFruitsComment nvarchar (200),
		   @DirtAndStonesComment nvarchar (200),
		   @SmallBunchesComment nvarchar (200),
		   @BuahRestanComment nvarchar (200),
		   @HardBunchComment nvarchar (200),
		   @PartheComment nvarchar (200),
		   @LightDamageComment nvarchar (200),

		   @MediumDamageComment nvarchar (200),
		   @DamageComment nvarchar (200),
		   
		   @TotalBunches numeric(18,2),
		   @DocumentNumber nvarchar(20),
		   @TotalGradedBunches numeric(18,2),

		   @CreatedBy nvarchar(50),
           @CreatedOn datetime,
           @ModifiedBy nvarchar(50),
           @ModifiedOn datetime,
           @BatuKerikil numeric(18,3),
		   @Abnormal numeric(18,2),
		   @AbnormalComment nvarchar(200),
 
        @RipeComment nvarchar(200), 
        @BunchStalkNotCutJ numeric(18,2),
        @BunchStalkNotCutComment nvarchar(200), 
        @RottenBunchJ numeric(18,2),
        @RottenBunchComment nvarchar(200), 
        @BuahRestan1to2J numeric(18,2),
        @BuahRestan1to2Comment nvarchar(200), 
        @BinNumber nvarchar(200)

AS
 
BEGIN TRY

    -- Get New Primary key
    


    Declare @GradingID nvarchar(50) 
    
                DECLARE @i INT = 2
                        SELECT @GradingID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                        FROM   Production.GradingFFB  
                        WHILE EXISTS
                        (SELECT id
                        FROM    Production.GradingFFB 
                        WHERE   GradingID   = @GradingID
                        )
                        BEGIN
                                SELECT @GradingID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                                FROM   Production.GradingFFB  
                                SET @i = @i + 1
						END
         
  
  -- Get the Supplier's Disbun ID to grade him based on Disbun Penalty Table
		Declare @DisbunID as int
		Declare @NetWeight as numeric(18,3)
		SELECT @DisbunID = b.DisbunID, @NetWeight = NetWeight FROM Weighbridge.WBWeighingInOut a
		INNER JOIN Weighbridge.WBSupplier b ON a.SupplierCustID = b.SupplierCustID
		WHERE a.WeighingID = @WeighingID

		Declare @UnripeFruitGraded as numeric(18,3)
		Declare @UnderRipeGraded as numeric(18,3)
		Declare @OverRipeFruitGraded as numeric(18,3)
		Declare @EmptyBunchFruitGraded as numeric(18,3)
		Declare @LongStalksGraded as numeric(18,3)
		Declare @LooseFruitsGraded as numeric(18,3)
		Declare @DirtAndStonesGraded as numeric(18,3)
		Declare @SmallBunchesGraded as numeric(18,3)
		Declare @BuahRestanGraded as numeric(18,3)
		Declare @IncentiveGraded as numeric(18,3)
		Declare @TotalPenalty as numeric(18,3)

		-- Calculate Grading based on Disbun Penalty table
		SELECT 
			@UnripeFruitGraded = (RawFruitEfficiency / 100) * (@UnripeFruitJ / @TotalBunches) * @NetWeight
			,@UnderRipeGraded = (RawFruitEfficiency / 100) * (@UnderripeJ / @TotalBunches) * @NetWeight
			,@OverRipeFruitGraded = (OverRipeFruitLooseFruit / 100) * ((@OverRipeFruitJ / @TotalBunches) - (AllowedOverRipeFruit / 100)) * @NetWeight
			,@EmptyBunchFruitGraded = (EmptyFruitBunch / 100) * (@EmptyBunchFruitJ / @TotalBunches) * @NetWeight
			,@LongStalksGraded = (LongStalk / 100) * (@LongStalksJ / @TotalBunches) * @NetWeight
			,@LooseFruitsGraded = (LooseFruitOilAndPalmKernelYield / 100) * ((LooseFruitThreshhold / 100) - (@KgOfLooseFruit / @TotalBunches)) * @NetWeight
			,@DirtAndStonesGraded = DirtAndStonesPenaltyFactor * @DirtAndStonesJ
			,@SmallBunchesGraded = (SmallBunchPenalty / 100) * (@SmallBunchesJ / @TotalBunches) * @NetWeight
			,@BuahRestanGraded = (RestanPenalty / 100) * ((@BuahRestanJ / @TotalBunches) - (RestanThreshhold / 100)) * @NetWeight
			,@IncentiveGraded = (Incentive / 100) * @NetWeight
		FROM Production.DisbunPenalty
		WHERE DisbunID = @DisbunID;

		IF @OverRipeFruitGraded < 0
			SET @OverRipeFruitGraded = 0
		IF @LooseFruitsGraded < 0
			SET @LooseFruitsGraded = 0
		IF @BuahRestanGraded < 0
			SET @BuahRestanGraded = 0

		SET @TotalPenalty = @UnripeFruitGraded + @UnderRipeGraded +  @OverRipeFruitGraded + @EmptyBunchFruitGraded
		+ @LongStalksGraded + @LooseFruitsGraded + @DirtAndStonesGraded + @SmallBunchesGraded + @BuahRestanGraded;

		IF @TotalPenalty > 0 
			SET @IncentiveGraded = 0

   

 INSERT INTO Production.GradingFFB  
			([GradingID]
           ,[EstateID]
           ,[ActiveMonthYearID]
           ,[WeighingID]
		   ,[DocumentNumber]
           ,[GradingDate]
           ,[GradingTime]
           ,[MinMaturity]
           ,[LosseFruitPerBunche]
           ,[UnripeFruitJ]
           ,[UnripeFruitP]
           ,[UnripeFruitT]
           ,[UnderripeJ]
           ,[UnderripeP]
           ,[UnderripeT]
           ,[RipeFruitJ]
           ,[RipeFruitP]
           ,[RipeFruitT]
           ,[OverRipeFruitJ]
           ,[OverRipeFruitP]
           ,[OverRipeFruitT]
           ,[EmptyBunchFruitJ]
           ,[EmptyBunchFruitP]
           ,[EmptyBunchFruitT]
           ,[TotalNormalFruitsJ]
           ,[TotalNormalFruitsP]
           ,[TotalNormalFruitsT]
           ,[PartheJ]
           ,[PartheP]
           ,[PartheT]
           ,[HardBunchJ]
           ,[HardBunchP]
           ,[HardBunchT]
           ,[TotalAbnormalFruitsJ]
           ,[TotalAbnormalFruitsP]
           ,[TotalAbnormalFruitsT]
           ,[GTActualBunchesJ]
           ,[GTActualBunchesP]
           ,[GTActualBunchesT]
           ,[LooseFruitsP]
           ,[KgOfLooseFruit]
           ,[UnDamageJ]
           ,[UnDamageP]
           ,[UnDamageT]
           ,[LightDamageJ]
           ,[LightDamageP]
           ,[LightDamageT]
           ,[DamageJ]
           ,[DamageP]
           ,[DamageT]
           ,[TotalJ]
           ,[TotalP]
           ,[TotalT]
           ,[Comment]
		   ,LongStalksJ
		   ,DirtAndStonesJ
		   ,SmallBunchesJ
		   ,BuahRestanJ
		   ,MediumDamageJ
		   ,UnripeFruitComment
		   ,UnderRipeComment
		   ,OverRipeFruitComment
		   ,EmptyBunchFruitComment
		   ,LongStalksComment
		   ,LooseFruitsComment
		   ,DirtAndStonesComment
		   ,SmallBunchesComment
		   ,BuahRestanComment
		   ,HardBunchComment
		   ,PartheComment
		   ,LightDamageComment
		   ,MediumDamageComment
		   ,DamageComment
		   ,UnripeFruitGraded
		   ,UnderRipeGraded
		   ,OverRipeFruitGraded
		   ,EmptyBunchFruitGraded
		   ,LongStalksGraded
		   ,LooseFruitsGraded
		   ,DirtAndStonesGraded
		   ,SmallBunchesGraded
		   ,BuahRestanGraded
		   ,IncentiveGraded 
		   ,TotalGradedBunches
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn]
           ,[BatuKerikil]
		   ,[Abnormal]
		   ,[AbnormalComment]
		   ,RipeComment
		   ,BunchStalkNotCutJ
		   ,BunchStalkNotCutComment
		   ,RottenBunchJ
		   ,RottenBunchComment
		   ,BuahRestan1to2J
		   ,BuahRestan1to2Comment
		   ,BinNumber)

		   /*
			@RipeComment nvarchar(200), 
			@BunchStalkNotCutJ numeric(18,2),
			@BunchStalkNotCutComment nvarchar(200), 
			@RottenBunchJ numeric(18,2),
			@RottenBunchComment nvarchar(200), 
			@BuahRestan1to2J numeric(18,2),
			@BuahRestan1to2Comment nvarchar(200), 
			@BinNumber nvarchar(200)
		   */
     
     Values
			(@GradingID
           ,@EstateID
           ,@ActiveMonthYearID
           ,@WeighingID 
		   ,@DocumentNumber
           ,@GradingDate
           ,@GradingTime 
           ,@MinMaturity
           ,@LosseFruitPerBunche
           ,@UnripeFruitJ
           ,@UnripeFruitP
           ,@UnripeFruitT
           ,@UnderripeJ
           ,@UnderripeP
           ,@UnderripeT
           ,@RipeFruitJ
           ,@RipeFruitP
           ,@RipeFruitT
           ,@OverRipeFruitJ
           ,@OverRipeFruitP
           ,@OverRipeFruitT
           ,@EmptyBunchFruitJ
           ,@EmptyBunchFruitP
           ,@EmptyBunchFruitT
           ,@TotalNormalFruitsJ
           ,@TotalNormalFruitsP
           ,@TotalNormalFruitsT
           ,@PartheJ
           ,@PartheP
           ,@PartheT
           ,@HardBunchJ
           ,@HardBunchP
           ,@HardBunchT
           ,@TotalAbnormalFruitsJ
           ,@TotalAbnormalFruitsP
           ,@TotalAbnormalFruitsT
           ,@GTActualBunchesJ
           ,@GTActualBunchesP
           ,@GTActualBunchesT
           ,@LooseFruitsP
           ,@KgOfLooseFruit
           ,@UnDamageJ
           ,@UnDamageP
           ,@UnDamageT
           ,@LightDamageJ
           ,@LightDamageP
           ,@LightDamageT
           ,@DamageJ
           ,@DamageP
           ,@DamageT
           ,@TotalJ
           ,@TotalP
           ,@TotalT
           ,@Comment
		   ,@LongStalksJ
		   ,@DirtAndStonesJ
		   ,@SmallBunchesJ 
		   ,@BuahRestanJ 
		   ,@MediumDamageJ 
		   ,@UnripeFruitComment 
		   ,@UnderRipeComment 
		   ,@OverRipeFruitComment 
		   ,@EmptyBunchFruitComment
		   ,@LongStalksComment 
		   ,@LooseFruitsComment 
		   ,@DirtAndStonesComment 
		   ,@SmallBunchesComment 
		   ,@BuahRestanComment 
		   ,@HardBunchComment 
		   ,@PartheComment 
		   ,@LightDamageComment 
		   ,@MediumDamageComment 
		   ,@DamageComment 
		   ,@UnripeFruitGraded
		   ,@UnderRipeGraded
		   ,@OverRipeFruitGraded
		   ,@EmptyBunchFruitGraded
		   ,@LongStalksGraded
		   ,@LooseFruitsGraded
		   ,@DirtAndStonesGraded
		   ,@SmallBunchesGraded
		   ,@BuahRestanGraded
		   ,@IncentiveGraded 
		   ,@TotalGradedBunches
           ,@CreatedBy
           ,GETDATE ()
           ,@ModifiedBy
           ,GETDATE ()
           ,@BatuKerikil
		   ,@Abnormal
		   ,@AbnormalComment
		   ,@RipeComment
		   ,@BunchStalkNotCutJ
		   ,@BunchStalkNotCutComment
		   ,@RottenBunchJ
		   ,@RottenBunchComment
		   ,@BuahRestan1to2J
		   ,@BuahRestan1to2Comment
		   ,@BinNumber);
         

 
  select 1
		
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



GO


