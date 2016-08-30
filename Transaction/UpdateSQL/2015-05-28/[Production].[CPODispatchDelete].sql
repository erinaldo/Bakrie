
GO

/****** Object:  StoredProcedure [Production].[CPODispatchDelete]    Script Date: 5/28/2015 8:22:54 PM ******/
DROP PROCEDURE [Production].[CPODispatchDelete]
GO

/****** Object:  StoredProcedure [Production].[CPODispatchDelete]    Script Date: 5/28/2015 8:22:54 PM ******/
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
	@EstateID nvarchar(50)
AS

	BEGIN

		Declare @BFQty float, @LoadingLocationID nvarchar(50), @MillWeight numeric (18,3)

		select @LoadingLocationID = LoadingLocationID, @MillWeight = MillWeight from Production.CPODispatch where EstateID =@EstateID AND DispatchID =@DispatchID 

		Delete From Production .CPODispatchDetail 
		Where EstateID =@EstateID AND DispatchID =@DispatchID 
	
		DELETE FROM [Production].[CPODispatch]  
		WHERE  EstateID =@EstateID AND DispatchID =@DispatchID 

		select @BFQty = Production.TankMaster.BFQty from Production.TankMaster where Production.TankMaster.TankNo = @LoadingLocationID
		 if @BFQty >= 0
			Update Production.TankMaster set Production.TankMaster.BFQty = Production.TankMaster.BFQty + @MillWeight where Production.TankMaster.TankNo = @LoadingLocationID
	END























GO


