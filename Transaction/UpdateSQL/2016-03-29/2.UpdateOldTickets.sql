DECLARE @WeighingID nvarchar(50), @BarcodeEntry nvarchar(200),
	@BarcodeExit nvarchar(200),
	@WeighingDate2 datetime,
	@WeighingTime2 datetime, 
	@DO nvarchar(50),
	@Username nvarchar(50),
	@AfterDeductionWeight numeric(18,3)

DECLARE cData CURSOR FOR   
	Select  [WeighingID]
	  ,BarcodeEntry,BarcodeExit,WeighingDate2,WeighingTime2,DO,Username,AfterDeductionWeight

	 From  [10.79.50.3].RKPMS_COM.[Weighbridge].[WBWeighingInOut] 
	 Open cData  
  
 FETCH NEXT FROM cData  
 INTO @WeighingID,@BarcodeEntry,@BarcodeExit,@WeighingDate2,@WeighingTime2,@DO,@Username,@AfterDeductionWeight

 WHILE @@FETCH_STATUS = 0   
 BEGIN
	Update Weighbridge.WBWeighingInOut set 
	BarcodeEntry =@BarcodeEntry,
	BarcodeExit = @BarcodeExit ,
	WeighingDate2 = @WeighingDate2 ,
	WeighingTime2 = @WeighingTime2 , 
	DO=@DO ,
	Username=@Username ,
	AfterDeductionWeight=@AfterDeductionWeight
	 where WeighingID = @WeighingID
		
		FETCH NEXT FROM cData  
		INTO @WeighingID,@BarcodeEntry,@BarcodeExit,@WeighingDate2,@WeighingTime2,@DO,@Username,@AfterDeductionWeight
	End
CLOSE cData  
DEALLOCATE cData