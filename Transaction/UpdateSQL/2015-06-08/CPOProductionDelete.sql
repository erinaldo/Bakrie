
/****** Object:  StoredProcedure [Production].[CPOProductionDelete]    Script Date: 8/6/2015 11:06:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Reeta Sheba.D>
-- modified by : Kumaravel
-- ALTER date: <sep 21 , 2009>
-- Description:	<To Delete Production Details >
-- =============================================

ALTER PROCEDURE [Production].[CPOProductionDelete]
	-- Add the parameters for the stored procedure here
	--@EstateID nvarchar(50),
	--@ProductionID nvarchar(50)
	--@TankNo nvarchar(50)
	--@ProdTranshipID nvarchar(50),
	--@ProdStockID nvarchar(50),
	--@ProdLoadingID nvarchar(50)
	--@StockTankID nvarchar(50),
	--@StockTankNo nvarchar(50),
	@CPOProductionDate datetime,
    @CropYieldID nvarchar(50)

	
AS

Declare @LastReading float
Declare @TankId nvarchar(20)
--Declare @lCount int =0
--Select @lCount = COUNT(*) from Production .CPOProductionStockCPO 

  --While  @lCount > 0
	BEGIN		
		Begin
		Declare @ProductionID nvarchar(50)
		SELECT @ProductionID= CPO_PR.ProductionID from Production.CPOProduction as CPO_PR
		where CPO_PR.CPOProductionDate =@CPOProductionDate--'2010-01-06'--
		and CPO_PR.CropYieldID=@CropYieldID 
	 	END
----For Stock CPO----
		BEGIN
		Select @LastReading = PrevDayReading,@TankId = TankID from Production.CPOProductionStockCPO
		DELETE FROM Production.CPOProductionStockCPO  
		WHERE 
		ProductionID =@ProductionID--'01R74'--
		UPDATE Production.TankMaster SET BFQty = @LastReading WHERE Production.TankMaster.TANKID = @TankId
		ENd
-----For Load CPO----
		BEGIN
		DELETE FROM Production.CPOProductionLoad  
		WHERE ProductionID =@ProductionID--'01R74'--
		END


--For CPOProduction------


	BEGIN
		DELETE FROM Production.CPOProduction 
		WHERE 
		 ProductionID =@ProductionID 
		and CropYieldID=@CropYieldID--'M1'--
		
	
	END
	--Set @lCount =@lCount -1
END





















