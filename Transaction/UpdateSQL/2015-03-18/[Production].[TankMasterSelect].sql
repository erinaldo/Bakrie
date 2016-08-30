
GO

/****** Object:  StoredProcedure [Production].[TankMasterSelect]    Script Date: 3/18/2015 10:54:07 PM ******/
DROP PROCEDURE [Production].[TankMasterSelect]
GO

/****** Object:  StoredProcedure [Production].[TankMasterSelect]    Script Date: 3/18/2015 10:54:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
















-- ====================================================  
-- ALTERd By : Nelson 
-- Modified By:  
-- ALTERd date: 15 Sep 2009  
-- Last Modified Date:
-- Module     :Production, RKPMS Web  
-- Screen(s)  : TankMaster.aspx  
-- Description:Binding Gridview in TankMaster screen
-- ===================================================== 
CREATE PROCEDURE [Production].[TankMasterSelect]
	-- Add the parameters for the stored procedure here
	@TankID nvarchar(50),
	@TankNo nvarchar(50),
	@EstateID nvarchar(50)
	
		
	
AS


if(@TankNo is not null)
begin

select Production.TankMaster.BFQty ,TankMaster.Capacity ,TankMaster.EstateID,TankMaster.CropYieldID ,TankMaster.LastCleanedDate ,TankMaster.StartUseDate ,TankMaster.TankID ,TankMaster.TankNo,TankMaster.ConcurrencyId,General.CropYield.CropYieldCode   from Production.TankMaster left outer join General.CropYield on TankMaster.CropYieldID=CropYield.CropYieldID  where TankMaster.EstateID=@EstateID and TankMaster.TankNo like '%' + @TankNo +'%' order by TankMaster.ModifiedOn desc

end

Else
Begin
select Production.TankMaster.BFQty ,TankMaster.Capacity ,TankMaster.EstateID,TankMaster.CropYieldID ,TankMaster.LastCleanedDate ,TankMaster.StartUseDate ,TankMaster.TankID ,TankMaster.TankNo,TankMaster.ConcurrencyId  ,General.CropYield.CropYieldCode   from Production.TankMaster left outer join General.CropYield on TankMaster.CropYieldID=CropYield.CropYieldID where TankMaster.EstateID=@EstateID  order by  TankMaster.ModifiedOn desc

End



	
--	SET NOCOUNT ON;
	
--IF (@TankID IS NULL) -- Select all
--	BEGIN
		
--		IF (@TankNo IS NULL)
--		SET @TankNo='';
		
		
--		IF (@EstateID IS NULL)
--		SET @EstateID='';
		
		
		
--		SELECT ROW_NUMBER() OVER(ORDER BY id) AS RowRank, * 
--		FROM Production.TankMaster 
--		WHERE TankNo LIKE '%' + @TankNo +'%' 
--		and EstateID  LIKE '%' + @EstateID +'%'
--		order by ID desc
		
--	END
--ELSE
--	BEGIN
--		SELECT ROW_NUMBER() OVER(ORDER BY id) AS RowRank, * 
--		FROM Production.TankMaster 
--		WHERE TankID = @TankID and EstateID = @EstateID
--		order by ID desc
--	END
















GO


