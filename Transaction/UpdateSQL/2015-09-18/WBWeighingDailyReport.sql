
/****** Object:  StoredProcedure [Weighbridge].[WBWeighingDailyReport]    Script Date: 18/9/2015 5:58:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











ALTER PROCEDURE [Weighbridge].[WBWeighingDailyReport]
	
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50),
	@FromDate Datetime,
	@ToDate Datetime
 

	
AS   
	SET NOCOUNT ON;
	
BEGIN
		SELECT	CONVERT(VARCHAR(10), WBWeighingInOut.WeighingDate, 103) AS WeighingDate,
				WBWeighingInOut.WBTicketNo, 
				CONVERT(VARCHAR(5), WBWeighingInOut.WeighingTime, 108) AS WeighingTime, 
				CONVERT(VARCHAR(5), WBWeighingInOut.TimeOut, 108) AS TimeOut, 
				WBProductMaster.ProductCode, 
				WBProductMaster.ProductDescp, 
				WBVehicle.VHNo AS VehicleCode,
				WBVehicle.VHRegNo AS VehicleRegNo,
				WBVehicle.VHDescp  AS VehicleDescp, 
				WBSupplier.Name AS Supplier, 
				FLOOR(WBWeighingInOut.FirstWeight) As FirstWeight,
				FLOOR(WBWeighingInOut.SecondWeight) As SecondWeight, 
				FLOOR(WBWeighingInOut.NetWeight) As NetWeight,
				WBWeighingInOut.ManualWeight  
				FROM	Weighbridge.WBWeighingInOut	
				LEFT JOIN Weighbridge.WBVehicle ON WBVehicle.WBVehicleID = WBWeighingInOut.WBVehicleID 
				LEFT JOIN Weighbridge.WBProductMaster ON WBWeighingInOut.ProductID = WBProductMaster.ProductID 
				LEFT JOIN Weighbridge.WBSupplier ON WBWeighingInOut.SupplierCustID = WBSupplier.SupplierCustID 
				INNER JOIN General.Estate ON WBWeighingInOut.EstateID = Estate.EstateID 
				WHERE	(WBWeighingInOut.EstateID = @EstateID AND WBWeighingInOut.ActiveMonthYearID = @ActiveMonthYearID AND 
				 (Weighbridge.WBWeighingInOut.WeighingDate  between @FromDate  AND @ToDate))

END







