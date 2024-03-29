
/****** Object:  StoredProcedure [Vehicle].[VehicleRunningLogUPDATE]    Script Date: 7/10/2015 5:01:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










-- =============================================  
-- Created By : Babu Kumarasamy  
-- Modified By:  SIVASUBRAMANIAN.S
-- Created date: 27th Feb 2009  
-- Last Modified Date: 2nd April 2009, 15TH Jun 2010   
-- Module     : Vehicle  
-- Screen(s)  : VehicleRunningLog  
-- Description: Procedure to Update VehicleRunningLog by ID  
-- =============================================  
  
ALTER PROCEDURE [Vehicle].[VehicleRunningLogUPDATE] ( @Id      INT,
                                                       @LogDate DATETIME ,
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
                                                       @ModifiedBy NVARCHAR(50),
                                                       @EstateID NVARCHAR(50),
                                                       @ActiveMonthYearID NVARCHAR(50),
                                                       @ConcurrencyId TIMESTAMP)
AS
        DECLARE @VHRunLogID NVARCHAR(50),
                @ISFFBDeliveryOrderNoDuplicate NVARCHAR(50),
                @ISDuplicateTime NVARCHAR(50),
                @ISWorkshopServicedTime NVARCHAR(50),
                @ISDuplicateKms NVARCHAR(50),
                @ISDuplicateBreakDown NVARCHAR(50),
                @IsConcurrecyIdChanged TIMESTAMP,
                @DivCode NVARCHAR(50),
                @YOPCode NVARCHAR(50),
                @BlockCode NVARCHAR(50),
                @ContractID nvarchar(50)
        BEGIN
                /* Procedure body */
                --Checking for ConcurrecyId Changed
                SELECT @IsConcurrecyIdChanged = VRL.ConcurrencyId
                FROM   Vehicle.VHRunningLog AS VRL
                WHERE  VRL.Id             = @ID
                   AND VRL.ConcurrencyId  = @ConcurrencyId
                IF @IsConcurrecyIdChanged = @ConcurrencyId
                BEGIN
                
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
				   AND VRL.Id     <> @Id                          
				   END
				   IF ISNULL( @ISDuplicateBreakDown , 'NotNull') = 'NotNull'
				   BEGIN
                        IF @Status <> 'B'
						BEGIN 
                        --Check For Duplicate Hrs
                        SELECT @ISDuplicateTime = VRL.VHID
                        FROM   Vehicle.VHRunningLog        AS VRL
                               INNER JOIN Vehicle.VHMaster AS VM
                               ON     VM.VHID = VRL.VHID
                        WHERE ( 
        --               (VRL.StartTime	<= @StartTime	and	VRL.EndTime	> @StartTime) 
        --               OR (VRL.StartTime	< @EndTime	and	VRL.EndTime	>= @EndTime)
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
						   AND VRL.StartTime <> '00:00:00.0000000' AND VRL.EndTime <> '00:00:00.0000000'
                           AND VRL.Id     <> @Id
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
                           AND VRL.LogDate                                        = @LogDate
                           AND VM.VHWSCode                                        = @VHWSCode
                           AND VM.EstateID                                        = @EstateID
                           AND VRL.Id                                            <> @Id
                           AND @StartKMs <> 0 AND @EndKms <> 0
                          
                           
                        IF ISNULL( @ISDuplicateKms , 'NotNull') = 'NotNull'
                        BEGIN
                                --IF ISNULL( @ISDuplicateTime , 'NotNull') = 'NotNull'
                                --BEGIN
										--Check For Duplicate FFBDeliveryOrderNoDuplicate
										SELECT @ISFFBDeliveryOrderNoDuplicate = FFBDeliveryOrderNo
										FROM   [Vehicle].VHRunningLog VRL
											   INNER JOIN [Vehicle].VHMaster AS VM
											   ON     VM.VHID         = VRL.VHID
										WHERE  VM.VHWSCode            = @VHWSCode
										   AND VRL.LogDate            = @LogDate
										   AND VRL.FFBDeliveryOrderNo = @FFBDeliveryOrderNo
										   AND VRL.Id                <> @Id
										   AND VM .EstateID =@EstateID 
										
                        
                                    IF ISNULL(@ISFFBDeliveryOrderNoDuplicate, 'NotDuplicate') = 'NotDuplicate'
                                    BEGIN
          --                              IF @Status <> 'B'
										--BEGIN 
          --                              SELECT @ISWorkshopServicedTime = WL.VHID
										--FROM   Vehicle.WorkshopLog        AS WL
										--	   INNER JOIN Vehicle.VHMaster AS VM
										--	   ON     VM.VHID = WL.VHID
										--WHERE ( 
						    ----           (WL.StartTime	<= @StartTime	and	WL.EndTime	> @StartTime) 
						    ----           OR (WL.StartTime	< @EndTime	and	WL.EndTime	>= @EndTime)
									 ----  OR (WL.StartTime	> @StartTime	and	WL.EndTime	< @EndTime))
									 -- (
										--			 @StartTime BETWEEN WL.StartTime AND WL.EndTime
										--	  )
										--   OR
										--	  (
										--			 @EndTime BETWEEN WL.StartTime AND WL.EndTime
										--	  )
										--   OR
										--	  (
										--			  WL.StartTime BETWEEN @StartTime AND @EndTime
										--	  )
										--   OR
										--	  (
										--			  WL.EndTime BETWEEN @StartTime AND @EndTime
										--	  )
										--)  
										--   AND WL.LogDate = @LogDate
										--   AND VM.VHWSCode = @VHWSCode
										--   AND VM.EstateID = @EstateID
										--   AND WL.StartTime <> '00:00:00.0000000' AND WL.EndTime <> '00:00:00.0000000'
										-- --  AND WL.Id     <> @Id
          --                              END
          --                              IF ISNULL( @ISWorkshopServicedTime , 'NotNull') = 'NotNull'
										--BEGIN                                     
										 
                                                SELECT @DivCode = DivID
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
                                                UPDATE [Vehicle].VHRunningLog
                                                SET --LogDate            = @LogDate           ,
                                                       --VHID               = @VHID              ,
                                                       ContractID          = @ContractID         ,
                                                       DistributionSetupID = @DistributionSetupID,
                                                       StartKMs            = @StartKMs           ,
                                                       EndKms              = @EndKms             ,
                                                       TotalKM             = @TotalKM            ,
                                                       StartTime           = @StartTime          ,
                                                       EndTime             = @EndTime            ,
                                                       TotalHrs            = @TotalHrs           ,
                                                       MorningEvening      = @Shift              ,
                                                       DivID               = @DivCode            ,
                                                       YOPID               = @YOPCode            ,
                                                       BlockID             = @BlockCode          ,
                                                       Activity            = @Activity           ,
                                                       Status              = @Status             ,
                                                       FFBDeliveryOrderNo  = @FFBDeliveryOrderNo ,
                                                       Bunches             = @Bunches            ,
                                                       ActualBunch         = @ActualBunch        ,
                                                       CollectionPoint     = @CollectionPoint    ,
                                                       MillWeight          = @MillWeight         ,
                                                       DateHarvested       = @DateHarvested      ,
                                                       DateCollected       = @DateCollected      ,
                                                       DoubleHandledFFB    = @DoubleHandledFFB   ,
                                                       WeighedBy           = @WeighedBy          ,
                                                       DispatchedBy        = @DispatchedBy       ,
                                                       Remarks             = @Remarks            ,
                                                       ModifiedBy          = @ModifiedBy         ,
                                                       ModifiedOn          = GETDATE()
                                                WHERE  ID                  = @Id
                                                SELECT 2 AS Success
                                                
												update Vehicle.VHRunningLog set Posted = 'Y' where Status = 'B'

                                                DECLARE   @D DATETIME, @AYear INT, @AMonth INT
                
												SELECT @D= GETDATE(), @AYear = AYear, @AMonth = AMonth
												FROM    General.ActiveMonthYear
												WHERE   ActiveMonthYearID = @ActiveMonthYearID
												
												if @Status <> 'B' 
													begin
													EXEC General.TaskMonitorUPDATE @EstateID,@AYear,@AMonth,3,'Vehicle Distribution approval','N',@ModifiedBy,@D--,@ModifiedBy,@D
													end
                                        END
										--ELSE
										--BEGIN
										-- SELECT 12 AS DuplicateTime
										--END        
									--END
									ELSE
									BEGIN
									 SELECT 13 AS DuplicateFFOrderNo
									END
                                
                        --END
                        --ELSE
                        --BEGIN
                        --        SELECT 11 AS DuplicateKms
                        --END
					END
					ELSE
					BEGIN
							SELECT 11
					END
                END
                ELSE
                BEGIN
                        SELECT 14
                END
					END
					ELSE
					BEGIN
					SELECT 15 AS DuplicateBreakDown
					END
				END
                ELSE
                BEGIN
                        SELECT 5
                END
        END









