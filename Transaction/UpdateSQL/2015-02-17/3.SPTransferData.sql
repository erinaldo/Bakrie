
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE Weighbridge.IntegrationWeighbridge 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID bigint
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
      ,[EstateID]
      ,[VHNo]
      ,[VHDescp]
      ,[VHRegNo]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[ModifiedBy]
      ,[ModifiedOn]
 FROM [BSPMS_WEIGHBRIDGE].[Weighbridge].[WBVehicle] where Id > @ID;
  Select @ID = Max(ID) FROM [BSPMS_WEIGHBRIDGE].[Weighbridge].[WBVehicle];
 UPDATE dbo.Integration SET LastRunId = @ID, LastRunDateTIME = GETDATE() where IntegrationModule = 'WeighbridgeVehicle';

-- Import WBWeighingINOUT
SELECT @ID = LastRunId FROM dbo.Integration where IntegrationModule = 'WeighbridgeINOUT';
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
Select  [WeighingID]
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
      ,[TotalBunches]
	  From [BSPMS_WEIGHBRIDGE].[Weighbridge].[WBWeighingInOut] where Id > @ID;
	  Select @ID = Max(ID) FROM [BSPMS_WEIGHBRIDGE].[Weighbridge].[WBWeighingInOut];
	  UPDATE dbo.Integration SET LastRunId = @ID, LastRunDateTIME = GETDATE() where IntegrationModule = 'WeighbridgeINOUT';;




END
GO
