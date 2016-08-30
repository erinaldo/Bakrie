
GO

/****** Object:  StoredProcedure [Production].[CPODispatchDelete]    Script Date: 12/06/2015 8:54:19 ******/
DROP PROCEDURE [Production].[CPODispatchDelete]
GO

/****** Object:  StoredProcedure [Production].[CPODispatchDelete]    Script Date: 12/06/2015 8:54:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO























--======================================================          
-- ALTERd By : Kumaravel        
-- ALTERd date:  Nov 7 , 2009       
-- Modified By: Kumaravel     
-- Last Modified Date:Dec 01 , 2009           
-- Module     : Production     
-- Screen(s)  : Dispatch     
-- Description: To Delete Grading FFB           
--======================================================  

CREATE PROCEDURE [Production].[CPODispatchDelete]
	-- Add the parameters for the stored procedure here
	@DispatchID nvarchar(50),
	@EstateID nvarchar(50),
	@isKernel as varchar(50) = null
AS

	BEGIN

		Declare @BFQty float, @LoadingLocationID nvarchar(50), @MillWeight numeric (18,3)

		select @LoadingLocationID = LoadingLocationID, @MillWeight = MillWeight from Production.CPODispatch where EstateID =@EstateID AND DispatchID =@DispatchID 

		Delete From Production .CPODispatchDetail 
		Where EstateID =@EstateID AND DispatchID =@DispatchID 
	
		DELETE FROM [Production].[CPODispatch]  
		WHERE  EstateID =@EstateID AND DispatchID =@DispatchID 

		if @isKernel = '1'
		begin
			select @BFQty = Production.KernelStorage.BFQty from Production.KernelStorage where Production.KernelStorage.Code = @LoadingLocationID
			 if @BFQty <> 0
				Update Production.KernelStorage set Production.KernelStorage.BFQty = Production.KernelStorage.BFQty + @MillWeight where Production.KernelStorage.Code = @LoadingLocationID
		end
		else
		begin
			select @BFQty = Production.TankMaster.BFQty from Production.TankMaster where Production.TankMaster.TankNo = @LoadingLocationID
			if @BFQty <> 0
			Update Production.TankMaster set Production.TankMaster.BFQty = Production.TankMaster.BFQty + @MillWeight where Production.TankMaster.TankNo = @LoadingLocationID
		end		
	END























GO


