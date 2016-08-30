
GO

/****** Object:  StoredProcedure [Weighbridge].[WBWeighingInOutSelect]    Script Date: 5/10/2015 6:12:48 PM ******/
DROP PROCEDURE [Weighbridge].[WBWeighingInOutSelect]
GO

/****** Object:  StoredProcedure [Weighbridge].[WBWeighingInOutSelect]    Script Date: 5/10/2015 6:12:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Created By : Raja
-- Modified By: Palani
-- Created date: 15th June 2009
-- Last Modified Date:   28 Feb 2011
-- Module     : WeighBridge
-- Screen(s)  :  WBWeighingInOUT
-- Description: Procedure to select WBWeighingInOut

-- =============================================

CREATE PROCEDURE [Weighbridge].[WBWeighingInOutSelect]
	
	-- Add the parameters for the stored procedure here
	
	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50),
	@WeighingDate datetime,
	@WBTicketNo nvarchar(50),
	@VHNo nvarchar(50),
	-- @ProductCode nvarchar(50),
	@ProductDescp  nvarchar(80),
	@Weight nvarchar(50),
	@NOTFBDetails bit
	
AS   
	SET NOCOUNT ON;
	
BEGIN

		IF @Weight = 'First'
			BEGIN
			
						-- SELECT	WBWeighingInOut.WeighingID, WBWeighingInOut.FFBDeliveryOrderNo, WBWeighingInOut.Others, 
						SELECT	WBWeighingInOut.WeighingID, WBWeighingInOut.FFBDeliveryOrderNo, WBWeighingInOut.Others, 
						CONVERT(VARCHAR(10), WBWeighingInOut.WeighingDate, 103) AS WeighingDate, 
						CONVERT(VARCHAR(5), WBWeighingInOut.WeighingTime, 108) AS WeighingTime, 
						WBWeighingInOut.Section,WBWeighingInOut.WBTicketNo, 
						CONVERT(VARCHAR(5), WBWeighingInOut.TimeOut, 108) AS TimeOut, 
						WBWeighingInOut.SupplierCustID, WBWeighingInOut.WBVehicleID, WBWeighingInOut.ProductID, WBProductMaster.ProductDescp,
						WBWeighingInOut.DriverName,  WBWeighingInOut.NoTrip, FLOOR(WBWeighingInOut.FirstWeight) As FirstWeight,
						FLOOR(WBWeighingInOut.SecondWeight) AS SecondWeight, 
						FLOOR(WBWeighingInOut.NetWeight) AS NetWeight,
						WBWeighingInOut.Remarks,WBWeighingInOut.ManualWeight, 
						WBVehicle.VHNo  AS VehicleCode, WBProductMaster.ProductCode,WBSupplier.Name AS Supplier, 
						WBSupplier.Code  AS SupplierCode 
				FROM	Weighbridge.WBWeighingInOut	
						LEFT JOIN Weighbridge.WBVehicle ON WBVehicle.WBVehicleID = WBWeighingInOut.WBVehicleID 
						LEFT JOIN Weighbridge.WBProductMaster ON WBWeighingInOut.ProductID = WBProductMaster.ProductID 
						LEFT JOIN Weighbridge.WBSupplier ON WBWeighingInOut.SupplierCustID = WBSupplier.SupplierCustID 
				WHERE	WBWeighingInOut.EstateID = @EstateID AND WBWeighingInOut.ActiveMonthYearID = @ActiveMonthYearID AND 
						SecondWeight IS NULL AND
						Weighbridge.WBProductMaster.ProductDescp = 'FFB' AND
						--WBWeighingInOut.Others  = @Others AND 
						(case when @WeighingDate  is null then 1  end =1 or WBWeighingInOut.WeighingDate = @WeighingDate ) and 
						(case when @WBTicketNo   is null then  1 end =1 or WBWeighingInOut.WBTicketNo like '%' + @WBTicketNo + '%') and 
						(case  when @VHNo  is null  then 1 end =1 or WBVehicle.VHNo  like '%' + @VHNo + '%') and 
						-- (case  when @ProductCode  is null then 1 end =1 or WBProductMaster.ProductCode like '%' + @ProductCode + '%') --And
					    (case  when @ProductDescp  is null then 1 end =1 or WBProductMaster.ProductDescp like '%' + @ProductDescp + '%')  	
						--(case  when @Others  is null then 1 end =1 or WBWeighingInOut.Others  = @Others )
						order by WBWeighingInOut.ModifiedOn desc
				
			END
		
		IF @Weight = 'Second'
			BEGIN
				-- SELECT	WBWeighingInOut.WeighingID, WBWeighingInOut.FFBDeliveryOrderNo, WBWeighingInOut.Others, 
				
				--SELECT	WBWeighingInOut.WeighingID, WBWeighingInOut.FFBDeliveryOrderNo,
				--		CONVERT(VARCHAR(10), WBWeighingInOut.WeighingDate, 103) AS WeighingDate, 
				--		CONVERT(VARCHAR(5), WBWeighingInOut.WeighingTime, 108) AS WeighingTime, 
				--		WBWeighingInOut.Section,WBWeighingInOut.WBTicketNo, 
				--		CONVERT(VARCHAR(5), WBWeighingInOut.TimeOut, 108) AS TimeOut, 
				--		WBWeighingInOut.SupplierCustID, WBWeighingInOut.WBVehicleID, WBWeighingInOut.ProductID, WBProductMaster.ProductDescp,
				--		WBWeighingInOut.DriverName,  WBWeighingInOut.NoTrip, FLOOR(WBWeighingInOut.FirstWeight) As FirstWeight,
				--		FLOOR(WBWeighingInOut.SecondWeight) AS SecondWeight, 
				--		FLOOR(WBWeighingInOut.NetWeight) AS NetWeight, WBWeighingInOut.Remarks,WBWeighingInOut.ManualWeight, 
				--		WBVehicle.VHNo  AS VehicleCode, WBProductMaster.ProductCode,WBSupplier.Name AS Supplier, 
				--		WBSupplier.Code  AS SupplierCode 
				
				
						SELECT	WBWeighingInOut.WeighingID, 
						CONVERT(VARCHAR(10), WBWeighingInOut.WeighingDate, 103) AS WeighingDate, 
						WBWeighingInOut.WBTicketNo, WBWeighingInOut.Others, 
						WBProductMaster.ProductDescp,
						WBSupplier.Name AS Supplier, 
						WBVehicle.VHNo  AS VehicleCode
				FROM	Weighbridge.WBWeighingInOut	
						LEFT JOIN Weighbridge.WBVehicle ON WBVehicle.WBVehicleID = WBWeighingInOut.WBVehicleID 
						LEFT JOIN Weighbridge.WBProductMaster ON WBWeighingInOut.ProductID = WBProductMaster.ProductID 
						LEFT JOIN Weighbridge.WBSupplier ON WBWeighingInOut.SupplierCustID = WBSupplier.SupplierCustID 
				WHERE	WBWeighingInOut.EstateID = @EstateID AND WBWeighingInOut.ActiveMonthYearID = @ActiveMonthYearID AND 
						SecondWeight IS NOT NULL AND
						Weighbridge.WBProductMaster.ProductDescp = 'FFB' AND
						--WBWeighingInOut.Others  = @Others AND 
						(case when @WeighingDate  is null then 1 end =1 or WBWeighingInOut.WeighingDate = @WeighingDate ) and 
						(case when @WBTicketNo   is null then  1 end =1 or WBWeighingInOut.WBTicketNo like '%' + @WBTicketNo + '%') and 
						(case  when @VHNo  is null  then 1 end =1 or WBVehicle.VHNo  like '%' + @VHNo + '%') and 
						-- (case  when @ProductCode  is null then 1 end =1 or WBProductMaster.ProductCode like '%' + @ProductCode + '%') and 
			 (case  when @ProductDescp  is null then 1 end =1 or WBProductMaster.ProductDescp like '%' + @ProductDescp + '%') and --And		
						--(case  when @Others  is null then 1 end =1 or WBWeighingInOut.Others  = @Others )
						(case when @NOTFBDetails =0 then 1 end =1 or Weighbridge.WBWeighingInOut.WeighingID not in 
						(select distinct WeighingID from Weighbridge.WBWeighingBlockDetail where EstateID = @EstateID)
						and (WBWeighingInOut.ProductID = '001')) order by WBWeighingInOut.ModifiedOn desc
				--WBWeighingInOut.ProductID = 5 or WBWeighingInOut.ProductID = 7
			END
		
	END

GO


