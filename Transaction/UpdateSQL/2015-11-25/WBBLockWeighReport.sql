/****** Object:  StoredProcedure [Weighbridge].[WBWeighingDailyReport]    Script Date: 2/12/2015 2:54:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [Weighbridge].[WBFieldBlockDailyReport]
	
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50),
	@FromDate Datetime,
	@ToDate Datetime
 

--Active mOnth year id not used in filter to prevent so that previous month can still be reported and printed.
	
AS   
	SET NOCOUNT ON;
	
BEGIN
		SELECT	CONVERT(VARCHAR(10), WBWeighingInOut.WeighingDate, 103) AS WeighingDate,
				WBWeighingInOut.WBTicketNo, 
				WBProductMaster.ProductCode, 
				WBProductMaster.ProductDescp, 
				WBSupplier.Name AS Supplier, 
				Weighbridge.WBWeighingBlockDetail.FieldBlockSetupID,
				Weighbridge.WBWeighingBlockDetail.LooseFruit,
				Weighbridge.WBWeighingBlockDetail.AllocatedWeight,
				Weighbridge.WBWeighingBlockDetail.ABW,
				Weighbridge.WBWeighingBlockDetail.Qty,
				Weighbridge.WBFieldBlockSetup.Block,
				Weighbridge.WBFieldBlockSetup.YOP,
				FLOOR(WBWeighingInOut.NetWeight) As NetWeight
				FROM	Weighbridge.WBWeighingInOut	
				LEFT JOIN Weighbridge.WBVehicle ON WBVehicle.WBVehicleID = WBWeighingInOut.WBVehicleID 
				LEFT JOIN Weighbridge.WBProductMaster ON WBWeighingInOut.ProductID = WBProductMaster.ProductID 
				LEFT JOIN Weighbridge.WBSupplier ON WBWeighingInOut.SupplierCustID = WBSupplier.SupplierCustID 
				INNER JOIN General.Estate ON WBWeighingInOut.EstateID = Estate.EstateID 
				inner join Weighbridge.WBWeighingBlockDetail  on Weighbridge.WBWeighingInOut.WeighingID = Weighbridge.WBWeighingBlockDetail.WeighingID
				inner join Weighbridge.WBFieldBlockSetup on Weighbridge.WBWeighingBlockDetail.FieldBlockSetupID = WBFieldBlockSetup.FieldBlockSetupID
				WHERE	(WBWeighingInOut.EstateID = @EstateID  AND 
				 (Weighbridge.WBWeighingInOut.WeighingDate  between @FromDate  AND @ToDate))

END







