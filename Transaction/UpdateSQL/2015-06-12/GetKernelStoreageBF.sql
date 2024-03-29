
/****** Object:  StoredProcedure [Production].[KernelGetStorageBalanceBF]    Script Date: 12/6/2015 11:21:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--======================================================          
-- ALTERd By : Kumaravel        
-- ALTERd date:  feb 20 2010      
-- Modified By: Kumaravel     
-- Last Modified Date:  dec 12 2010         
-- Module     : Production     
-- Screen(s)  : CPO production 
-- Description: To Select CPO Production        
--====================================================== 
ALTER PROCEDURE [Production].[KernelGetStorageBalanceBF]

	-- Add the parameters for the stored procedure here
	
	@EstateID nvarchar(50),
	@ProductionDate as Date,
	@CropYieldID nvarchar(50),
	@KernelStorageID Nvarchar(50)
	
	
		
AS			
			Declare @BalanceBf as numeric(18,3)=0 
						
			Select 
			@BalanceBf = CPO_Stock .CurrentReading - Isnull(DP2.TotalDispatch,0)
			from Production .CPOProduction CPO
			Inner Join Production .CPOProductionStockCPO CPO_Stock ON CPO_Stock .ProductionID = CPO .ProductionID 
			Inner Join Production .KernelStorage   P_TM ON CPO_Stock .KernelStorageID  = P_TM.KernelStorageID  
			LEft join (select ISNull(Sum(MillWeight),0) as TotalDispatch,LoadingLocationID  from Production.CPODispatch DP  
			WHERE DP.DispatchDate =@ProductionDate Group By LoadingLocationID) as DP2 on P_TM.Code = DP2.LoadingLocationID
			where CPO .EstateID =@EstateID 
			AND CPO.CPOProductionDate = @ProductionDate
			AND CPO .CropYieldID = @CropYieldID 
			AND P_TM .KernelStorageID = @KernelStorageID 
				
			if @BalanceBf = 0 
			Select top 1
				CPO_Stock .CurrentReading as BalanceBF  
				from Production .CPOProduction CPO
				Inner Join Production .CPOProductionStockCPO CPO_Stock ON CPO_Stock .ProductionID = CPO .ProductionID 
				Inner Join Production .KernelStorage   P_TM ON CPO_Stock .KernelStorageID  = P_TM.KernelStorageID  
				where CPO .EstateID =@EstateID 
				AND CPO.CPOProductionDate < @ProductionDate	
				AND CPO .CropYieldID = @CropYieldID 
				AND P_TM .KernelStorageID = @KernelStorageID 
				order by CPO .Id Desc
			else
				Select @BalanceBf as BalanceBF




			Select 
			ISNULL(SUM(CPO_Load .CurrentQty),0)  as PontoonPrevQty  
			from Production .CPOProduction CPO
			Inner Join Production .CPOProductionLoad  CPO_Load ON CPO_Load .ProductionID = CPO .ProductionID 
			where CPO .EstateID =@EstateID 
			AND CPO.CPOProductionDate = @ProductionDate
			AND CPO .CropYieldID = @CropYieldID 
			












