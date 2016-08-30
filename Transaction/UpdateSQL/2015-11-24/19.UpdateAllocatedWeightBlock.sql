/****** Object:  StoredProcedure [Checkroll].[AverageBunchWeightInsert]    Script Date: 26/11/2015 4:24:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Procedure to update allocated weight per field based can be by per weighbridge ticket or entire month

CREATE PROCEDURE Weighbridge.UpdateAllocatedWeightBlock
	@WeighingId nvarchar(50),
	@ActiveMonthYearId nvarchar(50)
AS	

BEGIN TRY
	DECLARE @NoOfBlocks nvarchar(50)
	DECLARE @NetWeight as numeric(18,3)
	DECLARE @LooseFruitsTotal as numeric(18,3)
	DECLARE @GrossWeight as numeric(18,3)
	DECLARE @HABWWeght as numeric(18,3)
	DECLARE @PreviousMonthNo as int
	DECLARE @PreviousYearNo as int
	Declare @PreviousMonthID nvarchar(50)
	
	Select @PreviousMonthNo = Amonth,@PreviousYearNo = AYear from General.ActiveMonthYear where ActiveMonthYearID = @ActiveMonthYearId
	if @PreviousMonthNo = 1
		begin
				Set @PreviousYearNo = @PreviousYearNo - 1
				Set @PreviousMonthNo = 12
		end
	else
		begin
			Set @PreviousMonthNo = @PreviousMonthNo - 1
		end

	SELECT @PreviousMonthID = ActiveMonthYearID FROM General.ActiveMonthYear 
	WHERE ModID = 4 AND AYear = @PreviousYearNo AND AMonth =@PreviousMonthNo

	
	DECLARE CR_DA CURSOR FOR   


		
	--First get count of blocks for the same weighingID
	Select count(*) as NoOfBlocks,b.WeighingID,b.NetWeight from Weighbridge.WBWeighingBlockDetail a
	inner join Weighbridge.WBWeighingInOut b on a.weighingid = b.WeighingID
	where a.WeighingID = @WeighingId 
	Group BY b.WeighingID,b.NetWeight
	Open CR_DA  
  
 FETCH NEXT FROM CR_DA  
 INTO   
 @NoOfBlocks,  
 @WeighingID,@NetWeight

 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	
	if @NoOfBlocks = 1
		begin
			--Easy just take weight - loose fruit divide by bunches
			Update Weighbridge.WBWeighingBlockDetail
			SET AllocatedWeight = b.NetWeight - Isnull(a.LooseFruit,0), ABW = (b.NetWeight - Isnull(a.LooseFruit,0)) / a.Qty
			From 
				 Weighbridge.WBWeighingBlockDetail a 
			inner join Weighbridge.WBWeighingInOut b on a.weighingid = b.WeighingID
			where a.WeighingID = @WeighingId and a.Qty <> 0
		end
	else
		begin
			Select @LooseFruitsTotal = Sum(LooseFruit) from Weighbridge.WBWeighingBlockDetail where weighingID= @WeighingID
			Set @GrossWeight = @NetWeight - @LooseFruitsTotal
			SELECT a.WeighingBlockID, b.WeighingID,c.FieldBlockSetupID, Qty, LooseFruit, b.NetWeight, HABW, (HABW * Qty) as FFB_ABW,
				0 as WeightTBAllocated
			into #tempAllocatedWeight
			FROM [Weighbridge].[WBWeighingBlockDetail] a
				INNER JOIN [Weighbridge].[WBWeighingInOut] b on a.WeighingID = b.WeighingID
				INNER JOIN [Weighbridge].[WBFieldBlockSetup] c on a.FieldBlockSetupID = c.FieldBlockSetupID
				LEfT JOIN
					(
					SELECT FieldBlockSetupID, CalculatedABW as HABW 
					FROM Weighbridge.AverageBunchWeightBlock
					--WHERE ActiveMonthYearID IN (SELECT ActiveMonthYearID FROM #tempActiveMonths )
					WHERE ActiveMonthYearID = @PreviousMonthID
					--GROUP BY FieldBlockSetupID
					) as tblABW on a.FieldBlockSetupID = tblABW.FieldBlockSetupID
				WHERE b.ActiveMonthYearID = @ActiveMonthYearId  and b.WeighingID = @WeighingId

			 	Select @HABWWeght = Sum(FFB_ABW) from #tempAllocatedWeight
				
				UPDATE Weighbridge.WBWeighingBlockDetail 
					Set AllocatedWeight =  Round(FFB_ABW / @HABWWeght * @GrossWeight,0), ABW = HABW
				from  Weighbridge.WBWeighingBlockDetail a
				inner join #tempAllocatedWeight b on a.WeighingBlockID= b.WeighingBlockID

				DROP table #tempAllocatedWeight
		end
		

    FETCH NEXT FROM CR_DA  
    INTO   
 @NoOfBlocks,  
 @WeighingID,@NetWeight

 END  
 CLOSE CR_DA  
  
 DEALLOCATE CR_DA  
 
	
	
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
