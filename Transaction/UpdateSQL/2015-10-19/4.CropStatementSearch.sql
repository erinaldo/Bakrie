/****** Object:  StoredProcedure [Checkroll].[CropStatementSearch]    Script Date: 19/10/2015 10:50:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Annal tham ko	
-- Create date: 02/12/2010
-- Description:	Get Crop Statement
-- =============================================
ALTER PROCEDURE  [Checkroll].[CropStatementSearch] 
	 
	  @EstateID nvarchar(50),
	  @BlockID nvarchar(50),
	  @CropYieldID nvarchar(50)
	 
AS
BEGIN
	 
	SET NOCOUNT ON;

    
	SELECT CS . CropStatementID ,
		   CS .	BlockID ,
		   BM . BlockName ,
		   CS . DivID ,
		   DI . DivName ,
		   CS . YOPID ,
		   YO . YOP ,
		   CS . CropYieldID , 
		   CY .CropYieldCode ,
		   CS.MilWeight  ,
		   CS.Bunches,
		   CS.DDate
	From   Checkroll .CropStatement CS  INNER JOIN General .CropYield CY on CS.CropYieldID =CY .CropYieldID 
										INNER JOIN General .BlockMaster BM on CS .BlockID =BM .BlockID 
										INNER JOIN General .Division DI on CS.DivID =DI .DivID 
										INNER JOIN General .YOP YO on CS .YOPID =YO .YOPID  
	Where  CS .EstateID =@EstateID AND (case when @BlockID is null then 1  end =1 or CS .BlockID  = @BlockID ) AND

									   (case when @CropYieldID   is null then  1 end =1 or CS .CropYieldID =@CropYieldID )
									   
										Order by CS .CropStatementID ASC
	
		
	
	
END

