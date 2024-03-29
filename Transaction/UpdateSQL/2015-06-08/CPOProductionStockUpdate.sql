
ALTER PROCEDURE [Production].[CPOProductionStockUpdate]

	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50), 
	@EstateCode nvarchar(50),
	@StockTankID nvarchar(50),
	@ProdStockID nvarchar(50),
	@Capacity numeric(18,2),
	@PrevDayReading numeric(18,3),
	@CurrentReading numeric(18,3),
	@Writeoff numeric(18,3),
	@Reason nvarchar(150),
	@Measurement numeric(18,2),
	@Temp numeric(18,2),
	@FFAP numeric(18,2),
	@MoistureP numeric(18,2),
	@DirtP numeric(18,3),
	@CreatedBy nvarchar(50),
	@CreatedOn datetime,
	@ModifiedBy nvarchar(50),
	@ModifiedOn datetime,
	@ProductionID nvarchar(50) 
AS
--For CPOSTock

BEGIN 
	UPDATE Production.CPOProductionStockCPO  SET 
	 ProductionID=@ProductionID,
	 EstateID=@EstateID, 
	 ActiveMonthYearID=@ActiveMonthYearID,
	 TankID=@StockTankID,
	-- KernelStorageID=@StockKernalID,
	 Capacity=@Capacity,
	 PrevDayReading=@PrevDayReading,
	 CurrentReading=@CurrentReading,
	 Writeoff = @Writeoff,
	 Reason = @Reason,
	 Measurement=@Measurement,
	 Temp=@Temp,
	 FFAP=@FFAP,
	 MoistureP=@MoistureP,
	 DirtP=@DirtP,
	 ModifiedBy=@ModifiedBy,
	 ModifiedOn=GETDATE()  
	WHERE ProdStockID=@ProdStockID ;
		
	UPDATE Production.TankMaster SET BFQty = @CurrentReading WHERE TANKID = @StockTankID;
		--SELECT @ConcurrencyId = ConcurrencyId FROM Store.STAdjustment WHERE STAdjustmentID=@STAdjustmentID;
END
