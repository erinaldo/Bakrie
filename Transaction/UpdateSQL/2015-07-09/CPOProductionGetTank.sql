
/****** Object:  StoredProcedure [Production].[CPOGetStorageBalanceBF]    Script Date: 8/7/2015 10:48:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--======================================================          
-- ALTERd By : Kumaravel        
-- ALTERd date:  feb 20 2010      
-- Modified By: Kumaravel     
-- Last Modified Date: sep 2010          
-- Module     : Production     
-- Screen(s)  : CPO production 
-- Description: To Select CPO Production        
--====================================================== 
ALTER PROCEDURE [Production].[CPOGetStorageBalanceBF]

	-- Add the parameters for the stored procedure here
	
	@EstateID nvarchar(50),
	@ProductionDate as Date,
	@CropYieldID nvarchar(50),
	@Tankid Nvarchar(50)
	
	
		
AS			
			
						
		--	Select Top 1
		--	CPO_Stock .CurrentReading - Isnull(DP2.TotalDispatch,0) as BalanceBF  
		--	from Production .CPOProduction CPO
		--	Inner Join Production .CPOProductionStockCPO CPO_Stock ON CPO_Stock .ProductionID = CPO .ProductionID 
		--	Inner Join Production .TankMaster  P_TM ON CPO_Stock .TankID  = P_TM.TankID 
		--	LEft join (select ISNull(Sum(MillWeight),0) as TotalDispatch,LoadingLocationID  from Production.CPODispatch DP  
		----change here
		----	WHERE DP.DispatchDate = DateAdd(d,-1,@ProductionDate) Group By LoadingLocationID) as DP2 on P_TM.TankNo = DP2.LoadingLocationID
		--	WHERE DP.DispatchDate = @ProductionDate Group By LoadingLocationID) as DP2 on P_TM.TankNo = DP2.LoadingLocationID
		--	where CPO .EstateID =@EstateID 
		--	AND CPO.CPOProductionDate < @ProductionDate	
		--	AND CPO .CropYieldID = @CropYieldID 
		--	AND P_TM .TankID = @Tankid 
		--	Order by CPO .CPOProductionDate Desc
			
			Select BFQty as BalanceBF FROM Production.TankMaster WHere TankID = @Tankid	

			Select 
			ISNULL(SUM(CPO_Load .CurrentQty),0)  as PontoonPrevQty  
			from Production .CPOProduction CPO
			Inner Join Production .CPOProductionLoad  CPO_Load ON CPO_Load .ProductionID = CPO .ProductionID 
			where CPO .EstateID =@EstateID 
		-- change here
		--	AND CPO.CPOProductionDate = DATEADD (Day,-1, @ProductionDate)
			AND CPO.CPOProductionDate = @ProductionDate
			AND CPO .CropYieldID = @CropYieldID 
			


