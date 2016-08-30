

/****** Object:  StoredProcedure [Production].[GetCPOAddStockInfo]    Script Date: 13/01/2015 14:40:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Production].[GetCPOAddStockInfo] 
	
	@EstateID nVarchar(50),
	@ActiveMonthYearID nvarchar(50),
	@CropYieldID nvarchar(50),
	@ProductionID nvarchar(50)
AS
			
BEGIN 
				
		SELECT 
		CONVERT(VARCHAR(10), CPOProductionDate , 103) AS CPOProductionDate
		,ISNULL(StockCPO.Capacity,0)as Capacity
		,ISNULL(StockCPO.PrevDayReading ,0) as Balance
		,ISNULL(StockCPO.CurrentReading,0) as CurrentReading
		,ISNULL(StockCPO.Writeoff,0) as Writeoff
		,Reason
		,ISNULL(StockCPO.Measurement,0) as Measurement
		,ISNULL(StockCPO.Temp,0) as Temperature
		,ISNULL(StockCPO.FFAP,0) as FFA
		,ISNULL(StockCPO.MoistureP,0) as Moisture,
		ISNULL(StockCPO.DirtP,0) as DirtP 
		,CPO_PR.ProductionID 
		
		,StockCPO.TankID as StockTankID,
		StockCPO.ProdStockID , StockCPO.BeritaAcara,
		(select distinct(TankMaster.TankNo) from Production.TankMaster where	TankMaster.TankId=StockCPO.TankID ) as StockTankNo
		
		From Production.CPOProduction  as CPO_PR
		INNER JOIN Production.CPOProductionStockCPO  as StockCPO ON CPO_PR.ProductionID=StockCPO.ProductionID 
		INNER JOIN Production.TankMaster as TankMaster ON TankMaster.TankID=StockCPO.TankID 
		WHERE CPO_PR .EstateID = @EstateID 
		AND CPO_PR .ActiveMonthYearID=@ActiveMonthYearID and CPO_PR.CropYieldID=@CropYieldID
		And CPO_PR.ProductionID =@ProductionID

		
		
END

GO


