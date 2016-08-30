
GO

/****** Object:  StoredProcedure [Vehicle].[VehicleRunningLogINSERT]    Script Date: 4/25/2015 2:54:48 PM ******/
DROP PROCEDURE [Vehicle].[VehicleRunningLogINSERT]
GO

/****** Object:  StoredProcedure [Vehicle].[VehicleRunningLogINSERT]    Script Date: 4/25/2015 2:54:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO













-- =============================================  
-- Author:  Babu Kumarasamy  
-- Modified By: Babu Kumarasamy  ,SIVASUBRAMANIAN.S
-- Create date: 27th Feb 2009  
-- Last Modified Date: 1st April 2009 , 15TH Jun 2010 
-- Module     : Vehicle  
-- Screen(s)  : VehicleRunningLog  
-- Description: Procedure to Save VehicleRunningLog  
-- =============================================  

CREATE PROCEDURE [Vehicle].[VehicleRunningLogINSERT] ( @LogDate DATETIME ,
                                                       @VHWSCode NVARCHAR(50) ,
                                                       @ContractNumber nvarchar(80),
                                                       @DistributionSetupID NVARCHAR(50) ,
                                                       @StartKMs NUMERIC(18,2),
                                                       @EndKms   NUMERIC(18,2),
                                                       @TotalKM  NUMERIC(18,2),
                                                       @StartTime TIME,
                                                       @EndTime TIME,
                                                       @TotalHrs NVARCHAR(50),
                                                       @Shift CHAR,
                                                       @DivID NVARCHAR(50),
                                                       @YOPID NVARCHAR(50),
                                                       @BlockID NVARCHAR(50),
                                                       @Activity NVARCHAR(50),
                                                       @Status NVARCHAR(1),
                                                       @FFBDeliveryOrderNo NVARCHAR(50),
                                                       @Bunches     NUMERIC(18,2),
                                                       @ActualBunch NUMERIC(18,2),
                                                       @CollectionPoint NVARCHAR(50),
                                                       @MillWeight    NUMERIC(18,2),
                                                       @DateHarvested DATETIME,
                                                       @DateCollected DATETIME,
                                                       @DoubleHandledFFB NVARCHAR(50),
                                                       @WeighedBy NVARCHAR(50),
                                                       @DispatchedBy NVARCHAR(50),
                                                       @Remarks NVARCHAR(200),
                                                       @CreatedBy NVARCHAR(50),
                                                       @EstateID NVARCHAR(50),
                                                       @ActiveMonthYearID NVARCHAR(50),
													   @NIK varchar(50),
													   @DriverName varchar(50) )
AS
        DECLARE @VHRunLogID NVARCHAR(50),
                @ISFFBDeliveryOrderNoDuplicate NVARCHAR(50),
                @ISDuplicateTime NVARCHAR(50),
                @ISWorkshopServicedTime NVARCHAR(50),
                @ISDuplicateKms NVARCHAR(50),
                @ISDuplicateBreakDown NVARCHAR(50),
                @VHID NVARCHAR(50),
                @DivCode NVARCHAR(50),
                @YOPCode NVARCHAR(50),
                @BlockCode NVARCHAR(50),
                @ContractID NVARCHAR(50),
                @EstateCode NVARCHAR(50)
        BEGIN
                /* Procedure body */
                --Check for BreakDown, only one vehicle per day
                IF @Status ='B'
                BEGIN
                SELECT @ISDuplicateBreakDown=VRL.VHID 
                 FROM   Vehicle.VHRunningLog        AS VRL
                       INNER JOIN Vehicle.VHMaster AS VM
                       ON     VM.VHID = VRL.VHID
               WHERE  VM.VHWSCode         = @VHWSCode
               AND VRL.LogDate            = @LogDate 
               AND VRL .Status			  = @Status
               AND VM .EstateID =@EstateID 
                       
               END
               IF ISNULL( @ISDuplicateBreakDown , 'NotNull') = 'NotNull'
			   BEGIN
			                 
					--Check For Duplicate FFBDeliveryOrderNoDuplicate
					SELECT @ISFFBDeliveryOrderNoDuplicate = FFBDeliveryOrderNo
					FROM   [Vehicle].VHRunningLog VRL
						   INNER JOIN Vehicle.VHMaster AS VM
						   ON     VM.VHID         = VRL.VHID
					WHERE  VM.VHWSCode            = @VHWSCode
					   AND VRL.LogDate            = @LogDate
					   AND VRL.FFBDeliveryOrderNo = @FFBDeliveryOrderNo
					   AND VRL .EstateID =@EstateID 
				
					--Check For Duplicate Hrs
	                
	                IF @Status <> 'B'
					BEGIN 
					SELECT @ISDuplicateTime = VRL.VHID
					FROM   Vehicle.VHRunningLog        AS VRL
						   INNER JOIN Vehicle.VHMaster AS VM
						   ON     VM.VHID = VRL.VHID
							WHERE ( 
						   --(VRL.StartTime	<= @StartTime	and	VRL.EndTime	> @StartTime) 
						   --OR (VRL.StartTime	< @EndTime	and	VRL.EndTime	>= @EndTime)
						   --OR (VRL.StartTime	> @StartTime	and	VRL.EndTime	< @EndTime)
						   
			                      (
			                             @StartTime BETWEEN VRL.StartTime AND VRL.EndTime
			                      )
			                   OR
			                      (
			                             @EndTime BETWEEN VRL.StartTime AND VRL.EndTime
			                      )
			                   OR
								  (
			                              VRL.StartTime BETWEEN @StartTime AND @EndTime
			                      )
			                   OR
			                      (
			                              VRL.EndTime BETWEEN @StartTime AND @EndTime
			                      )	   
							)  
					   AND VRL.LogDate = @LogDate
					   AND VM.VHWSCode = @VHWSCode
					   AND VM.EstateID = @EstateID
					   
					   --AND @Status ='B'
					   
					  -- VRL.LogDate= CASE WHEN @Status  ='B' THEN '1' ELSE '2'
					  AND VRL.StartTime <> '00:00:00.0000000' AND VRL.EndTime <> '00:00:00.0000000'
					END
	                   
					IF ISNULL( @ISDuplicateTime , 'NotNull') = 'NotNull'
					BEGIN
					
					
					                   
	                   
					--Check For Duplicate Kms
					SELECT @ISDuplicateKms = VRL.Id
					FROM   Vehicle.VHRunningLog        AS VRL
						   INNER JOIN Vehicle.VHMaster AS VM
						   ON     VM.VHID = VRL.VHID
							WHERE ( 
						   (VRL.StartKMs	<= @StartKMs	and	VRL.EndKMs	> @StartKMs) 
						   OR (VRL.StartKMs	< @EndKMs	and	VRL.EndKMs	>= @EndKMs)
						   OR (VRL.StartKMs	> @StartKMs	and	VRL.EndKMs	< @EndKMs)
							) 
					   AND VM.VHWSCode                      = @VHWSCode
					   AND VM.EstateID                      = @EstateID
					   AND VRL.LogDate = @LogDate
					   AND @StartKMs <> 0 AND @EndKms <> 0
	                   
						IF ISNULL( @ISDuplicateKms , 'NotNull') = 'NotNull'
						BEGIN
							--IF ISNULL( @ISDuplicateTime , 'NotNull') = 'NotNull'
							--BEGIN
									IF ISNULL(@ISFFBDeliveryOrderNoDuplicate, 'NotDuplicate') = 'NotDuplicate'
									BEGIN
	                                
										--SELECT @ISWorkshopServicedTime = WL.VHID
										--FROM   Vehicle.WorkshopLog        AS WL
										--	   INNER JOIN Vehicle.VHMaster AS VM
										--	   ON     VM.VHID = WL.VHID
										--		WHERE ( 
										--	   --(WL.StartTime	<= @StartTime	and	WL.EndTime	> @StartTime) 
										--	   --OR (WL.StartTime	< @EndTime	and	WL.EndTime	>= @EndTime)
										--	   --OR (WL.StartTime	> @StartTime	and	WL.EndTime	< @EndTime)
											   
										--	   (
										--			  (
										--					 @StartTime BETWEEN WL.StartTime AND WL.EndTime
										--			  )
										--		   OR
										--			  (
										--					 @EndTime BETWEEN WL.StartTime AND WL.EndTime
										--			  )
										--		   OR
										--			  (
										--					  WL.StartTime BETWEEN @StartTime AND @EndTime
										--			  )
										--		   OR
										--			  (
										--					  WL.EndTime BETWEEN @StartTime AND @EndTime
										--			  )	   
										--	   )
										--		)  
										--   AND WL.LogDate = @LogDate
										--   AND VM.VHWSCode = @VHWSCode
										--   AND VM.EstateID = @EstateID
										--   --AND @Status ='B'
										--   AND WL.StartTime <> '00:00:00.0000000' AND WL.EndTime <> '00:00:00.0000000'
										
										--IF ISNULL(@ISWorkshopServicedTime, 'NotDuplicate') = 'NotDuplicate'
										--BEGIN
									--    SELECT @VHRunLogID = @EstateID + CONVERT(VARCHAR, (IDENT_CURRENT('[Vehicle].VHRunningLog') + 1) )
											SELECT @EstateCode = EstateCode
											FROM   General.Estate
											WHERE  Estate.EstateID = @EstateID
											SELECT @VHRunLogID     = @EstateCode + 'R' + CONVERT(VARCHAR,(ISNULL(MAX(Id),0) + 1) )
											FROM   [Vehicle].VHRunningLog
											SELECT @VHID = VM.VHID
											FROM   Vehicle.VHMaster AS VM
											WHERE  VM.VHWSCode = @VHWSCode AND VM .EstateID =@EstateID 
											SELECT @DivCode    = DivID
											FROM   General.Division
											WHERE  Div      = @DivID
											SELECT @YOPCode = YOPID
											FROM   General.YOP
											WHERE  YOP        = @YOPID
											SELECT @BlockCode = BlockID
											FROM   General.BlockMaster
											WHERE  BlockName   = @BlockID
											SELECT @ContractID = ContractID
											FROM   General.ContractMaster
											WHERE  ContractNo = @ContractNumber AND EstateID =@EstateID 
											INSERT
											INTO   [Vehicle].VHRunningLog
												   (
														  VHRunLogID         ,
														  LogDate            ,
														  VHID               ,
														  ContractID         ,
														  DistributionSetupID,
														  StartKMs           ,
														  EndKms             ,
														  TotalKM            ,
														  StartTime          ,
														  EndTime            ,
														  TotalHrs           ,
														  MorningEvening     ,
														  DivID              ,
														  YOPID              ,
														  BlockID            ,
														  Activity           ,
														  Status             ,
														  FFBDeliveryOrderNo ,
														  Bunches            ,
														  ActualBunch        ,
														  CollectionPoint    ,
														  MillWeight         ,
														  DateHarvested      ,
														  DateCollected      ,
														  DoubleHandledFFB   ,
														  WeighedBy          ,
														  DispatchedBy       ,
														  Remarks            ,
														  CreatedBy          ,
														  CreatedOn          ,
														  EstateID           ,
														  ActiveMonthYearID,
														  NIK,
														  DriverName
												   )
												   VALUES
												   (
														  @VHRunLogID         ,
														  @LogDate            ,
														  @VHID               ,
														  @ContractID         ,
														  @DistributionSetupID,
														  @StartKMs           ,
														  @EndKms             ,
														  @TotalKM            ,
														  @StartTime          ,
														  @EndTime            ,
														  @TotalHrs           ,
														  @Shift              ,
														  @DivCode            ,
														  @YOPCode            ,
														  @BlockCode          ,
														  @Activity           ,
														  @Status             ,
														  @FFBDeliveryOrderNo ,
														  @Bunches            ,
														  @ActualBunch        ,
														  @CollectionPoint    ,
														  @MillWeight         ,
														  @DateHarvested      ,
														  @DateCollected      ,
														  @DoubleHandledFFB   ,
														  @WeighedBy          ,
														  @DispatchedBy       ,
														  @Remarks            ,
														  @CreatedBy          ,
														  GETDATE ()          ,
														  @EstateID           ,
														  @ActiveMonthYearID,
														  @NIK,
														  @DriverName
												   )
											SELECT 1 AS Success
	                                        
											DECLARE   @D DATETIME, @AYear INT, @AMonth INT
	                
									SELECT @D= GETDATE(), @AYear = AYear, @AMonth = AMonth
									FROM    General.ActiveMonthYear
									WHERE   ActiveMonthYearID = @ActiveMonthYearID
	                
									IF @Status <> 'B' and @Status <> 'S'
										EXEC General.TaskMonitorUPDATE @EstateID,@AYear,@AMonth,3,'Vehicle Distribution approval','N',@CreatedBy,@D--,@ModifiedBy,@D
									ELSE
										UPDATE Vehicle.VHRunningLog set Posted = 'Y' where VHRunLogID = @VHRunLogID
									
									
									--END
									--ELSE
									--BEGIN
									--		SELECT 12
									--END
									
								END
								ELSE
								BEGIN
										SELECT 13 AS DuplicateFFOrderNo
								END
							END
							ELSE
							BEGIN
									SELECT 11 AS DuplicateKms
							END
					END
					ELSE
					BEGIN
							SELECT 14 AS DuplicateTime
					END
					
			END
			ELSE
			BEGIN
			SELECT 15 AS DuplicateBreakDown
			END
END












GO


