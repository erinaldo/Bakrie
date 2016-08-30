alter table Checkroll.PremiSetupRubber
add Rate decimal null
go

GO
/****** Object:  StoredProcedure [Checkroll].[PremiSetupRubberInsertUpdate]    Script Date: 02/01/2015 16:29:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










--======================================================          
-- Created By : Chadra        
-- Created date:  November       
-- Module     : [Checkroll]     
-- Screen(s)  : Journal      
-- Description: To Insert Master PremiSetupRubber
--======================================================  




ALTER PROCEDURE [Checkroll].[PremiSetupRubberInsertUpdate]

	@EstateID [nvarchar](50) ,
	
	@Product [nvarchar](50) ,
	@Class [nchar](1) ,
	@Min [numeric](18, 0),
	@Max [numeric](18, 0),
	@Rate [numeric](18, 0)
		
AS
	BEGIN
		select * from Checkroll.PremiSetupRubber where EstateID=@EstateID and @Product =Product and @Class=Class
		if(@@rowcount =0)
			insert into Checkroll.PremiSetupRubber (EstateId,Product,Class,Min,Max,Rate) values (@EstateID,@Product,@Class,@min,@max,@Rate)	
		else
		update Checkroll.PremiSetupRubber set min=@min,max=@max,Rate = @Rate  where EstateID=@EstateID and @Product =Product and @Class=Class
			
	END	
	








