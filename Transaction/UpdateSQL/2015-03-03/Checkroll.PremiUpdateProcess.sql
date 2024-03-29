/****** Object:  StoredProcedure [Checkroll].[DailyReceptionBlkHKPremiValueUpdateProcess]    Script Date: 3/3/2015 11:10:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author		: AHMED NAXIM
-- Create date	: 25/03/2013
-- Updated on	: 31/07/2013
-- Description: <to process and update Premi value and Block wise HK>  
-- =============================================  
ALTER PROCEDURE [Checkroll].[DailyReceptionBlkHKPremiValueUpdateProcess]  
  @EstateID nvarchar(50),   
  @EstateCode nvarchar(50),   
  @ActiveMonthYearID nvarchar(50),  
  @CreatedBy nvarchar(50),  
  @EmpID nvarchar(50),  
  @RDate Date  
  
AS  
BEGIN TRY  
	BEGIN  
	 -- SET NOCOUNT ON added to prevent extra result sets from  
	 -- interfering with SELECT statements.  
	 SET NOCOUNT ON;

	--04R19646 - 1
	--04R1358 - 2
	--04R1191 - 3 blocks - did not reach target
	--04R1219 - 2 blocks - 1st one did not reach target 1

	SELECT 
	Row_Number() OVER ( Order By a.DailyReceiptionID ASC ) as Row,
	a.DailyReceiptionID, a.EstateID, EstateCode, ActiveMonthYearID, MandoreID, KraniID, RDate, c.EmpID, a.DivID, a.YOPID, a.BlockID, i.AttendanceSetupID, i.AttendanceCode, j.GangMasterID,
	SUM(b.PaidNormal) as PaidNormal, SUM(b.PaidBorongan) as PaidBorongan, SUM(b.LooseFruitNormal) as LooseFruitNormal, SUM(b.LooseFruitBorongan) as LooseFruitBorongan
	INTO #tempPremi
	FROM [Checkroll].[DailyReceiption] a 
	INNER JOIN [Checkroll].[DailyReceptionWithTeam] b ON a.DailyReceiptionDetID = b.DailyReceiptionDetID
	INNER JOIN [Checkroll].[DailyAttendance] c ON c.DailyReceiptionID = a.DailyReceiptionID
	INNER JOIN [Checkroll].[CREmployee] d ON d.EmpID = c.EmpID
	INNER JOIN [General].[BlockMaster] e ON a.BlockID = e.BlockID
	INNER JOIN [General].[YOP] f ON a.YOPID = f.YOPID
	INNER JOIN [General].[Division] g ON a.DivID = g.DivID
	INNER JOIN [General].[Estate] h ON a.EstateID = h.EstateID
	INNER JOIN [Checkroll].[AttendanceSetup] i ON c.AttendanceSetupID = i.AttendanceSetupID AND c.EstateID = i.EstateID
	INNER JOIN [Checkroll].[DailyTeamActivity] j ON c.DailyTeamActivityID = j.DailyTeamActivityID
	WHERE 
	d.EmpID = @EmpID AND c.RDate = @RDate
	GROUP BY a.DailyReceiptionID, a.EstateID, EstateCode, ActiveMonthYearID, MandoreID, KraniID, RDate, c.EmpID, a.DivID, a.YOPID, a.BlockID, i.AttendanceSetupID, i.AttendanceCode, j.GangMasterID


	SELECT a.YOPID, a.BlockID, a.AttendanceSetupID, a.PaidNormal, a.PaidBorongan, a.LooseFruitNormal, a.LooseFruitBorongan, c.LooseFruitsRate,
	MinBunches1, MaxBunches1, BunchRate1, MinBunches2, MaxBunches2, BunchRate2, MinBunches3, MaxBunches3, BunchRate3, BoronganRate, 
	DailyReceiptionID, a.EstateID, EstateCode, ActiveMonthYearID, a.EmpID, a.MandoreID, a.KraniID, a.RDate, a.DivID, a.AttendanceCode, a.GangMasterID
	INTO #tempPremiTarget
	FROM #tempPremi a 
	LEFT JOIN (
	SELECT MinBunches1, MaxBunches1, BunchRate1, MinBunches2, MaxBunches2, BunchRate2, MinBunches3, MaxBunches3, BunchRate3, T1.AttendanceSetupID, T1.BlockID, LooseFruitsRate
	FROM 
	(Select * from 
	(SELECT Row_Number() OVER (PARTITION BY BlockID,AttendanceSetupId Order By  [Checkroll].[PremiSetup].MinBunches ASC ) as Row1,  '1' AS ID1, BlockID, AttendanceSetupID, MinBunches as MinBunches1, MaxBunches AS MaxBunches1, BunchRate AS BunchRate1, LooseFruitsRate
	FROM [Checkroll].[PremiSetup] ) Target1
	Where Target1.Row1 = 1) T1
	LEFT JOIN 
	(Select * from 
	(SELECT Row_Number() OVER (PARTITION BY BlockID,AttendanceSetupId Order By  [Checkroll].[PremiSetup].MinBunches ASC ) as Row1,  '1' AS ID2, BlockID, AttendanceSetupID, MinBunches as MinBunches2, MaxBunches AS MaxBunches2, BunchRate AS BunchRate2
	FROM [Checkroll].[PremiSetup] ) Target2
	Where Target2.Row1 = 2) AS T2 ON T1.ID1 = T2.ID2 AND T1.BlockID = T2.BlockID AND T1.AttendanceSetupID = T2.AttendanceSetupID
	LEFT JOIN 
	(Select * from (SELECT Row_Number() OVER (PARTITION BY BlockID,AttendanceSetupId Order By  [Checkroll].[PremiSetup].MinBunches ASC ) as Row1,  '1' AS ID3, BlockID, AttendanceSetupID, MinBunches as MinBunches3, MaxBunches AS MaxBunches3, BunchRate AS BunchRate3
	FROM [Checkroll].[PremiSetup] ) Target3
	Where Target3.Row1 = 3) AS T3 ON T2.ID2 = T3.ID3 AND T1.BlockID = T3.BlockID AND T1.AttendanceSetupID = T3.AttendanceSetupID
	) as b ON a.AttendanceSetupID = b.AttendanceSetupID AND a.BlockID = b.BlockID
	LEFT JOIN 
	(
	SELECT MAX(BunchRate) as BoronganRate, LooseFruitsRate, AttendanceSetupID, BlockID FROM [Checkroll].[PremiSetup] 
	Group by LooseFruitsRate, AttendanceSetupID, BlockID
	) as c ON c.BlockID = a.BlockID AND c.AttendanceSetupID = a.AttendanceSetupID
	ORDER BY a.Row



	SELECT 
	YOPID, BlockID, AttendanceSetupID, PaidNormal, 
	CASE 
		WHEN (PaidNormal <= MaxBunches1) THEN
			PaidNormal
		ELSE
			MaxBunches1
	END as Target1,
	CASE 
		WHEN (PaidNormal <= MaxBunches1) THEN
			PaidNormal * BunchRate1
		ELSE
			-- commented on 18 July 2013
			MaxBunches1 * BunchRate1
			--MaxBunches1 * 0
	END as Value1,
	CASE 
		WHEN (PaidNormal > MaxBunches1 AND PaidNormal <= MaxBunches2) THEN
			PaidNormal - MaxBunches1
		ELSE
			CASE
				WHEN (PaidNormal > MaxBunches2) THEN
					MaxBunches2-MaxBunches1
				ELSE 0
			END	
	END as Target2,
	CASE 
		WHEN (PaidNormal > MaxBunches1 AND PaidNormal <= MaxBunches2) THEN
			(PaidNormal - MaxBunches1) * BunchRate2
		ELSE
			CASE
				WHEN (PaidNormal > MaxBunches2) THEN
					(MaxBunches2-MaxBunches1) * BunchRate2
				ELSE 0
			END	
	END as Value2,
	CASE 
		WHEN (PaidNormal > MaxBunches2) THEN
			PaidNormal - MaxBunches2
		ELSE 0	
	END as Target3,
	CASE 
		WHEN (PaidNormal > MaxBunches2) THEN
			(PaidNormal - MaxBunches2) * BunchRate3
		ELSE 0	
	END as Value3,
	LooseFruitNormal,
	LooseFruitBorongan,
	LooseFruitsRate,
	((IsNull(LooseFruitNormal,0) + ISNULL(LooseFruitBorongan,0))* ISNULL(LooseFruitsRate,90)) as LooseValue, PaidBorongan, (CAST(PaidBorongan as numeric(18,0))*BoronganRate) as PaidBoronganValue,
	BunchRate1, BunchRate2, BunchRate3, MaxBunches1, MaxBunches2, MaxBunches3,
	DailyReceiptionID, EstateID, EstateCode, ActiveMonthYearID, EmpID, MandoreID, KraniID, RDate, DivID, AttendanceCode, GangMasterID, '1' AS RowTarget
	INTO #tempPremiCalculate
	FROM #tempPremiTarget

	--select * from #tempPremiCalculate


	DECLARE @BlockID varchar(50)
	DECLARE @YOP varchar(50)
	DECLARE @MandoreID varchar(50)
	DECLARE @KraniID varchar(50)
	DECLARE @PaidNormal decimal(18,2)
	DECLARE @PaidBorongan numeric(18,2)
	DECLARE @PaidBoronganValue decimal(18,2)
	DECLARE @T1 decimal(18,0)
	DECLARE @T2 decimal(18,0)
	DECLARE @T3 decimal(18,0)
	DECLARE @V1 decimal(18,2)
	DECLARE @V2 decimal(18,2)
	DECLARE @V3 decimal(18,2)
	DECLARE @Rate1 decimal(18,2)
	DECLARE @Rate2 decimal(18,2)
	DECLARE @Rate3 decimal(18,2)
	DECLARE @Max1 decimal(18,2)
	DECLARE @Max2 decimal(18,2)
	DECLARE @Max3 decimal(18,2)

	DECLARE @PrevYOP varchar(50)
	DECLARE @PrevPaidNormal decimal(18,2)
	DECLARE @PrevT1 decimal(18,0)
	DECLARE @PrevT2 decimal(18,0)
	DECLARE @PrevT3 decimal(18,0)
	
	SET @PrevT1 = 0
	SET @PrevT2 = 0
	SET @PrevT3 = 0
	
	DECLARE @PrevMax1 decimal(18,2)
	DECLARE @PrevMax2 decimal(18,2)
	DECLARE @PrevMax3 decimal(18,2)
	DECLARE @RowTarget int
	DECLARE @PrevRowTarget int
	
	DECLARE @CurrentTarget int 
	SET @PrevPaidNormal = 0
	SET @CurrentTarget = 1

	DECLARE @NewT1 decimal(18,2)
	DECLARE @NewT2 decimal(18,2)
	DECLARE @NewT3 decimal(18,2)
	
	-- count the total number of different YOPS harvested
	DECLARE @TotalYOP int
	SELECT @TotalYOP = COUNT(YOPID) FROM ( SELECT YOPID, COUNT(YOPID) as NoYOP FROM #tempPremiCalculate GROUP BY YOPID) tblRows
	
	DECLARE @WorkedHours decimal(18,2)	
	DECLARE @WorkingHours decimal(18,2)	
	SET @WorkedHours = 0
	SET @WorkingHours = 7
	
	DECLARE Receptions CURSOR LOCAL FOR 
	SELECT BlockID, YOPID, MandoreID, KraniID, PaidNormal, PaidBorongan, PaidBoronganValue, Target1, Target2, Target3, Value1, Value2, Value3, BunchRate1, BunchRate2, BunchRate3, MaxBunches1, MaxBunches2,  MaxBunches3, 
	CASE 
		WHEN Target2 = 0 THEN '1' 
		WHEN Target3 > 0 THEN '3'
		ELSE '2'
	END as RowTarget
	FROM #tempPremiCalculate

	OPEN Receptions
	FETCH NEXT FROM Receptions into @BlockID, @YOP, @MandoreID, @KraniID, @PaidNormal, @PaidBorongan, @PaidBoronganValue, @T1, @T2, @T3, @V1, @V2, @V3, @Rate1, @Rate2, @Rate3, @Max1, @Max2, @Max3, @RowTarget
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		--print 'Paid Borongan = ' + CAST(@PaidBorongan as varchar(50))
		
		IF @TotalYOP = 1
			BEGIN
				print 'PrevPaidNormal = ' + CAST(@PrevPaidNormal as varchar(50))
				IF @PrevPaidNormal > 0 
					BEGIN
						
						
						IF (@PrevRowTarget = 1 OR @PrevRowTarget is NULL)
							BEGIN
								SET @CurrentTarget = 1
							END
						ELSE IF @PrevRowTarget = 2
							BEGIN
								SET @CurrentTarget = 2
							END
						ELSE SET @CurrentTarget = 3
				
						PRINT 'Same YOP: Current Target = ' + CAST(@CurrentTarget as varchar(5))
				
						IF @CurrentTarget = 1
							BEGIN
								
								SET @NewT1 = (@Max1 - @PrevT1)
								IF @PaidNormal < @NewT1
									SET @NewT1 = @PaidNormal
								
								SET @NewT2 = (@Max2-@Max1)
								IF @NewT2 > (@PaidNormal-@NewT1)
									SET @NewT2 =  @PaidNormal-@NewT1
								
								SET @NewT3 = @PaidNormal - @NewT1 - @NewT2
								IF @NewT3 < 0
									SET @NewT3 = 0
								
								IF @NewT2 > 0
									SET @RowTarget = 2
								IF @NewT3 > 0
									SET @RowTarget = 3
									
								Print CAST(@NewT2  as varchar(50)) + ' X ' + CAST(@Rate2 as varchar(50))
								
								UPDATE #tempPremiCalculate SET 
									Target1 = @NewT1,
									Target2 = @NewT2,
									Target3 = @NewT3,
									Value1 = CAST(@NewT1 as numeric(18,0)) * @Rate1,
									Value2 = CAST(@NewT2 as numeric(18,0)) * @Rate2,
									Value3 = CAST(@NewT3 as numeric(18,0)) * @Rate3,
									RowTarget = @RowTarget
								WHERE YOPID = @YOP AND BlockID = @BlockID AND PaidNormal = @PaidNormal
							END
						ELSE IF @CurrentTarget = 2
							BEGIN
								SET @NewT2 = (@Max2-@Max1) - @PrevT2
								
								IF @T2 < @NewT2
									SET @NewT2 = @NewT2 - @T2
									
								IF @NewT2 > @PaidNormal 
									Begin
										SET @NewT2 = @PaidNormal
										SET @RowTarget = 2
									End
								
								SET @NewT3 = @PaidNormal - @NewT2
								IF @NewT3 < 0
									SET @NewT3 = 0
								
								IF @NewT3 > 0
									SET @RowTarget = 3
								ELSE IF @NewT2 < (@Max2-@Max1)
									SET @RowTarget = 2
									
								Print '==========================='
								Print 'Target 2: Same YOP'
								Print 'Next Target = ' + CAST(@RowTarget as varchar(5))
								Print '@NewT2 = ' + CAST(@NewT2 as varchar(10))
								Print '@NewT3 = ' + CAST(@NewT3 as varchar(10))
								Print '@T2 = ' + CAST(@T2 as varchar(10))
								Print '@PrevT2 = ' + CAST(@PrevT2 as varchar(10))
								Print CAST(@NewT2  as varchar(50)) + ' X ' + CAST(@Rate2 as varchar(50))
								Print '----------------------------'
									
								UPDATE #tempPremiCalculate SET 
									Target1 = 0,
									Target2 = @NewT2,
									Target3 = @NewT3,
									Value1 = 0,
									Value2 = CAST(@NewT2 as numeric(18,0)) * @Rate2,
									Value3 = CAST(@NewT3 as numeric(18,0)) * @Rate3,
									RowTarget = @RowTarget
								WHERE YOPID = @YOP AND BlockID = @BlockID AND PaidNormal = @PaidNormal
								
							END
						ELSE IF @CurrentTarget = 3
							BEGIN
								SET @NewT3 = @PaidNormal
								SET @RowTarget = 3
								
								UPDATE #tempPremiCalculate SET 
									Target1 = 0,
									Target2 = 0,
									Target3 = @NewT3,
									Value1 = 0,
									Value2 = 0,
									Value3 = CAST(@NewT3 as numeric(18,0)) * @Rate3,
									RowTarget = @RowTarget
								WHERE YOPID = @YOP AND BlockID = @BlockID AND PaidNormal = @PaidNormal
								
							END
					END
				END -- end of YOP = 1
			ELSE 
				-- Multiple YOPs
				BEGIN
					IF (@PrevRowTarget = 1 OR @PrevRowTarget is NULL)
						BEGIN
							SET @CurrentTarget = 1
						END
					ELSE IF @PrevRowTarget = 2
						BEGIN
							SET @CurrentTarget = 2
						END
					ELSE SET @CurrentTarget = 3
				
					PRINT 'Multiple YOP : Target = ' + CAST(@CurrentTarget as varchar(5)) + 'Prev: ' + CAST(@PrevRowTarget as varchar(5))
					
					IF @CurrentTarget = 1
						BEGIN
							DECLARE @HourlyRate DECIMAL(18,2)
							DECLARE @RemainingHours Decimal(18,2)
							print @WorkingHours
							SET @HourlyRate = @Max1 / @WorkingHours
							if @HourlyRate = 0
							begin set @HourlyRate = 1 end
							print @HourlyRate
							SET @NewT1 = @PaidNormal
							
							IF @WorkedHours < @WorkingHours
								BEGIN
									-- if working hours does not meet Working hours which is 7 hr add the current reception's working hr
									SET @RemainingHours = @WorkingHours - @WorkedHours
									if @HourlyRate = 0
									begin set @HourlyRate = 1 end
									SET @WorkedHours = @WorkedHours + (@PaidNormal/@HourlyRate)
									IF @WorkedHours > @WorkingHours
										BEGIN
											SET @NewT1 = FLOOR(@RemainingHours * @HourlyRate)
										END
								END
							
							print 'hourly rate: ' + CAST (@HourlyRate as varchar(10))
							print 'worked hrs: ' + CAST (@WorkedHours as varchar(10))
							print 'remaining hrs: ' + CAST (@RemainingHours as varchar(10))
							
							-- Update the table
							print 'Before1: ' + cast(@Max2 as varchar(50))
							print 'Before2: ' + cast(@Max1 as varchar(50))
							SET @NewT2 = (@Max2-@Max1)

							print 'Before: ' + Cast(@NewT2 as varchar(10))

							IF @NewT2 > (@PaidNormal-@NewT1)
								SET @NewT2 =  FLOOR(@PaidNormal-@NewT1)
								
							SET @NewT3 = @PaidNormal - @NewT1 - @NewT2
							IF @NewT3 < 0
								SET @NewT3 = 0
								
							IF @NewT2 > 0 
								SET @RowTarget = 2
							ELSE IF @NewT3 > 0
								SET @RowTarget = 3
							
							Print '@NewT2==' + CAST(@NewT2  as varchar(50))
							
							--Print 'Target 1'
							--Print CAST(@NewT2  as varchar(50)) + ' X ' + CAST(@Rate2 as varchar(50))
								
							UPDATE #tempPremiCalculate SET 
									Target1 = @NewT1,
									Target2 = @NewT2,
									Target3 = @NewT3,
								    Value1 = CAST(@NewT1 as numeric(18,0)) * @Rate1,
									Value2 = CAST(@NewT2 as numeric(18,0)) * @Rate2,
									Value3 = CAST(@NewT3 as numeric(18,0)) * @Rate3,
									RowTarget = @RowTarget
							WHERE YOPID = @YOP AND BlockID = @BlockID AND PaidNormal = @PaidNormal

														
						END
					ELSE IF @CurrentTarget = 2
						BEGIN
								SET @NewT2 = (@Max2-@Max1) - @PrevT2
								
								IF @T2 < @NewT2
									SET @NewT2 = @NewT2 - @T2
								IF @NewT2 > @PaidNormal 
									Begin
										SET @NewT2 = @PaidNormal
										SET @RowTarget = 2
									End
								
								SET @NewT3 = @PaidNormal - @NewT2
								IF @NewT3 < 0
									Begin
										SET @NewT3 = 0
										SET @RowTarget = 2
									End
								
								IF @NewT3 > 0
									SET @RowTarget = 3
									
								Print 'Target 2'
								Print '@RowTarget = ' + CAST(@RowTarget as varchar(50))
								Print CAST(@NewT2  as varchar(50)) + ' X ' + CAST(@Rate2 as varchar(50))
								
								UPDATE #tempPremiCalculate SET 
									Target1 = 0,
									Target2 = @NewT2,
									Target3 = @NewT3,
									Value1 = 0,
									Value2 = CAST(@NewT2 as numeric(18,0)) * @Rate2,
									Value3 = CAST(@NewT3 as numeric(18,0)) * @Rate3,
									RowTarget = @RowTarget
								WHERE YOPID = @YOP AND BlockID = @BlockID AND PaidNormal = @PaidNormal
								
						END
					ELSE IF @CurrentTarget = 3
						BEGIN
						
							SET @NewT3 = @PaidNormal
							SET @RowTarget = 3
							
							UPDATE #tempPremiCalculate SET 
									Target1 = 0,
									Target2 = 0,
									Target3 = @NewT3,
									Value1 = 0,
									Value2 = 0,
									Value3 = CAST(@NewT3 as numeric(18,0)) * @Rate3,
									RowTarget = 3
							WHERE YOPID = @YOP AND BlockID = @BlockID AND PaidNormal = @PaidNormal
						
						END
					
				END
				
		SET @PrevPaidNormal = @PaidNormal
		SET @PrevYOP = @YOP
		
		IF @TotalYOP =  1
			BEGIN
				SET @PrevT1 = @PrevT1 + @T1
				SET @PrevT2 = @PrevT2 + @T2 
				SET @PrevT3 = @PrevT3 + @T3
				IF @T2 = 0
					SET @PrevT2 = @PrevT2 + ISNULL(@NewT2,0)
				IF @T3 = 0
					SET @PrevT3 = @PrevT3 + ISNULL(@NewT3,0)
			END
		ELSE
			BEGIN
				SET @PrevT1 = @PrevT1 + @NewT1
				SET @PrevT2 = @PrevT2 + @NewT2
				SET @PrevT3 = @PrevT3 + @NewT3
			END
		
		SET @PrevMax1 = @Max1
		SET @PrevMax2 = @Max2
		SET @PrevMax3 = @Max3
		
		SET @NewT1 = 0
		SET @NewT2 = 0
		SET @NewT3 = 0

		SET @PrevRowTarget = @RowTarget
		
		FETCH NEXT FROM Receptions INTO @BlockID, @YOP, @MandoreID, @KraniID, @PaidNormal, @PaidBorongan, @PaidBoronganValue, @T1, @T2, @T3, @V1, @V2, @V3, @Rate1, @Rate2, @Rate3, @Max1, @Max2, @Max3, @RowTarget
	END

	CLOSE Receptions
	DEALLOCATE Receptions


	--SELECT * FROM #tempPremiCalculate
	--SELECT TOP 2 * FROM Checkroll.ReceptionTargeDetail ORDER BY RDate DESC
	
	-- delete employees current data for the selected date first coz we are going to update all records for the selected date
	DELETE FROM [Checkroll].[ReceptionTargetDetail] WHERE RDate = @RDate AND EmpID = @EmpID;
	
	INSERT INTO [Checkroll].[ReceptionTargetDetail]
		(
			EstateID,
			EstateCode,
			ActiveMonthYearID,
			AttendanceSetupID,
			MandoreID,
			KraniID,
			Activity,
			RDate,
			EmpID,
			DivID,
			YOPID,
			BlockID,
			TotalBunches,
			TotalLooseFruits,
			TotalTonnage,
			TotalBorongan,
			TotalBoronganValue,
			TBunches1,
			TValue1,
			TBunches2,
			TValue2,
			TBunches3,
			TValue3,
			TLooseFruitsValue,
			GangMasterID,
			CreatedBy,
			CreatedOn
		)
		SELECT 
			EstateID,
			EstateCode,
			ActiveMonthYearID,
			AttendanceSetupID,
			MandoreID,
			KraniID,
			'PANEN',
			RDate,
			EmpID,
			DivID,
			YOPID,
			BlockID,
			IsNull(PaidNormal,0),
			IsNull(LooseFruitNormal,0) + ISNULL(LooseFruitBorongan,0),
			'0',
			IsNull(PaidBorongan,0),
			IsNull(PaidBoronganValue,0),
			IsNull(Target1,0),
			IsNull(Value1,0),
			IsNull(Target2,0),
			IsNull(Value2,0),
			IsNull(Target3,0),
			IsNull(Value3,0),
			IsNull(LooseValue,0),
			GangMasterID,
			@CreatedBy,
			GETDATE()
		FROM #tempPremiCalculate

	--SELECT * FROM #tempPremiCalculate
	
	-- DELETE all temporary tables
	DROP TABLE #tempPremi
	DROP TABLE #tempPremiTarget
	DROP TABLE #tempPremiCalculate


	-- Update BlkHK in DailyReceiption Table - Added on 6 August 2013
	exec [Checkroll].[DailyReceptionBlkHKPremiValueUpdateProcess_Blk]  
	  @EstateID = @EstateID,   
	  @EstateCode = @EstateCode,   
	  @ActiveMonthYearID = @ActiveMonthYearID,  
	  @CreatedBy = @CreatedBy,  
	  @EmpID = @EmpID,  
	  @RDate = @RDate;


	--SELECT Empid FROM Checkroll.DailyAttendance WHERE EstateID =@EstateID AND ActiveMonthYearID =@ActiveMonthYearID AND EmpID =@EmpID   
	SELECT @EmpID as EmpID;


	END

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
