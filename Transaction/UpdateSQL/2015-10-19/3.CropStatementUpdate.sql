/****** Object:  StoredProcedure [Checkroll].[CropStatementUpdate]    Script Date: 19/10/2015 10:41:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author	  :	Annal tham ko
-- Create date: 02/12/2010
-- Description:	Crop Statement Updste
-- =============================================
ALTER PROCEDURE [Checkroll].[CropStatementUpdate]
	 
	 @CropStatementID nvarchar(50),
	 @EstateID nvarchar(50),
 
	 @CropYieldID nvarchar(50),
	 @DivID nvarchar(50),
	 @YOPID nvarchar(50),
	 @BlockID nvarchar(50),
	 @MilWeight numeric(18,0),
	 @Bunches numeric(18,0),
	 @ModifiedBy nvarchar(50),
	 @ModifiedOn datetime,
	 @DDate date
AS
BEGIN
	 
	SET NOCOUNT ON;

    Update Checkroll .CropStatement set EstateID=@EstateID ,CropYieldID=@CropYieldID ,DivID=@DivID ,YOPID=@YOPID  ,BlockID=@BlockID 
										,MilWeight=@MilWeight  ,Bunches=@Bunches  ,ModifiedBy=@ModifiedBy  ,ModifiedOn=@ModifiedOn, DDate = @DDate 
									Where CropStatementID =@CropStatementID    
	  
END

