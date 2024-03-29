
/****** Object:  StoredProcedure [Weighbridge].[IntegrationWeighbridge]    Script Date: 14/9/2015 9:15:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Weighbridge].[IntegrationWeighbridge] 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID bigint;
	DECLARE @ActiveMonthWeighbridge nvarchar(50);
	DECLARE @LastRunDate datetime;
	DECLARE @WeighingID nvarchar(50),@WeighingDate date,@WeighingTime time(7),@Section nvarchar(50),@Others char(1)
	DECLARE @WBTicketNo nvarchar(50),@FFBDeliveryOrderNo nvarchar(50),@SupplierCustID nvarchar(50),@ProductID nvarchar(50)
	DECLARE @DriverName nvarchar(80),@NoTrip int,@FirstWeight numeric(18,3),@SecondWeight numeric(18,3),@NetWeight numeric(18,3),@Remarks nvarchar(200)
	DECLARE @WBVehicleID nvarchar(50),@TimeOut time(7),@FFBDeduction decimal(18,2),@TotalABW numeric(18,3),@TotalBunches numeric(18,3)
-- Import WBVEHICLE

SELECT @ID = LastRunId FROM dbo.Integration where IntegrationModule = 'WeighbridgeVehicle';
INSERT INTO  [Weighbridge].[WBVehicle] ( 
	   [WBVehicleID]
      ,[EstateID]
      ,[VHNo]
      ,[VHDescp]
      ,[VHRegNo]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ModifiedBy]
      ,[ModifiedOn])
SELECT [WBVehicleID]
      ,'M8'
      ,[VHNo]
      ,[VHDescp]
      ,[VHRegNo]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ModifiedBy]
      ,[ModifiedOn]
 FROM [10.79.50.3].RKPMS_COM.[Weighbridge].[WBVehicle] where Id > @ID;
  Select @ID = Max(ID) FROM [10.79.50.3].RKPMS_COM.[Weighbridge].[WBVehicle];
 UPDATE dbo.Integration SET LastRunId = @ID, LastRunDateTIME = GETDATE() where IntegrationModule = 'WeighbridgeVehicle';

-- Import WBWeighingINOUT
--SELECT @ID = LastRunId FROM dbo.Integration where IntegrationModule = 'WeighbridgeINOUT';
SELECT @LastRunDate = LastRunDateTime FROM dbo.Integration where IntegrationModule = 'WeighbridgeINOUT';
select @ActiveMonthWeighbridge = ActiveMonthYearID from General.ActiveMonthYear where modid = 4 and Status ='A';

DECLARE cData CURSOR FOR   
-- select statement here
	Select  [WeighingID]
      ,[WeighingDate]
      ,[WeighingTime]
      ,[Section]
      ,[Others]
      ,[WBTicketNo]
      ,[FFBDeliveryOrderNo]
      ,[SupplierCustID]
      ,[ProductID]
      ,[DriverName]
      ,[NoTrip]
      ,[FirstWeight]
      ,[SecondWeight]
      ,[NetWeight]
      ,[Remarks]
	  ,[WBVehicleID]
	  ,[TimeOut]
      ,[FFBDeduction]
      ,[TotalABW]
      ,[TotalBunches]
	  From [10.79.50.3].RKPMS_COM.[Weighbridge].[WBWeighingInOut] where ModifiedOn > @LastRunDate;
	
Open cData  
  
 FETCH NEXT FROM cData  
 INTO @WeighingID,@WeighingDate,@WeighingTime,@Section,@Others,@WBTicketNo,@FFBDeliveryOrderNo,@SupplierCustID,@ProductID,
 @DriverName,@NoTrip,@FirstWeight,@SecondWeight,@NetWeight,@Remarks,@WBVehicleID,@TimeOut,@FFBDeduction,@TotalABW,@TotalBunches
     
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	Select @Id= Id from Weighbridge.WBWeighingInOut where weighingid = @weighingid
	if @@ROWCOUNT = 0 
		Insert INTO Weighbridge.WBWeighingInOut([WeighingID]
		,[EstateID]
		  ,[ActiveMonthYearID]
		  ,[WeighingDate]
		  ,[WeighingTime]
		  ,[Section]
		  ,[Others]
		  ,[WBTicketNo]
		  ,[FFBDeliveryOrderNo]
		  ,[SupplierCustID]
		  ,[ProductID]
		  ,[DriverName]
		  ,[NoTrip]
		  ,[FirstWeight]
		  ,[SecondWeight]
		  ,[NetWeight]
		  ,[ManualWeight]
		  ,[Remarks]
		  ,[CreatedBy]
		  ,[CreatedOn]
		  ,[ModifiedBy]
		  ,[ModifiedOn]
		  ,[WBVehicleID]
		  ,[TimeOut]
		  ,[FFBDeduction]
		  ,[TotalABW]
		  ,[TotalBunches])
		  VALUES
		   (@WeighingID,'M8',@ActiveMonthWeighbridge,@WeighingDate ,@WeighingTime ,@Section ,@Others,
		   @WBTicketNo ,@FFBDeliveryOrderNo ,@SupplierCustID ,@ProductID,@DriverName,@NoTrip,@FirstWeight,@SecondWeight,@NetWeight ,0,
		   @Remarks,'System', GetDATE(), 'System',GETDATE(),@WBVehicleID,@TimeOut,@FFBDeduction,@TotalABW,@TotalBunches)
	else
		UPDATE Weighbridge.WBWeighingInOut set 
		WeighingDate = @WeighingDate, WeighingTime = @WeighingTime,
		Section = @Section,Others = @Others,Wbticketno = @WBTicketNo ,FFBDeliveryOrderNo = @FFBDeliveryOrderNo ,
		SupplierCustID =@SupplierCustID , ProductID = @ProductID,DriverName = @DriverName, NoTrip = @NoTrip,
		FirstWeight = @FirstWeight,SecondWeight = @SecondWeight,NetWeight = @NetWeight ,ManualWeight = 0,
		Remarks = @Remarks, ModifiedBy = 'System', ModifiedOn = GETDATE(), 
		WBVehicleID = @WBVehicleID,[TimeOut] = @TimeOut,FFBDeduction = @FFBDeduction,TotalABW = @TotalABW,TotalBunches = @TotalBunches
		WHERE id  =@ID
    FETCH NEXT FROM cData  
     INTO @WeighingID,@WeighingDate,@WeighingTime,@Section,@Others,@WBTicketNo,@FFBDeliveryOrderNo,@SupplierCustID,@ProductID,
	@DriverName,@NoTrip,@FirstWeight,@SecondWeight,@NetWeight,@Remarks,@WBVehicleID,@TimeOut,@FFBDeduction,@TotalABW,@TotalBunches
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData  



	  Select @ID = Max(ID) FROM [10.79.50.3].RKPMS_COM.[Weighbridge].[WBWeighingInOut];
	  UPDATE dbo.Integration SET LastRunId = @ID, LastRunDateTIME = GETDATE() where IntegrationModule = 'WeighbridgeINOUT';;
END


