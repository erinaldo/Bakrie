alter table checkroll.PremiSetupRubber
add PremiType varchar(100) null;


GO
/****** Object:  StoredProcedure [Checkroll].[PremiSetupRubberInsertUpdate]    Script Date: 30/01/2015 11:21:04 ******/
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
	@Rate [numeric](18, 0),
	@PremiType varchar(100)
		
AS
	BEGIN
		select * from Checkroll.PremiSetupRubber where EstateID=@EstateID and @Product =Product and @Class=Class and @PremiType=PremiType
		if(@@rowcount =0)
			insert into Checkroll.PremiSetupRubber (EstateId,Product,Class,Min,Max,PremiType,rate) values (@EstateID,@Product,@Class,@min,@max,@PremiType,@Rate)	
		else
		update Checkroll.PremiSetupRubber set min=@min,max=@max,Rate=@Rate  where EstateID=@EstateID and @Product =Product and @Class=Class  and @PremiType=PremiType
			
	END	
	








