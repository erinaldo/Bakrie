
/****** Object:  StoredProcedure [Production].[DispatchDetailsReport]    Script Date: 15/9/2015 11:21:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<vinoth>
-- Create date: <15=-12-2010>
-- Description:	<DispatchDetailsReport>
-- =============================================
ALTER PROCEDURE [Production].[DispatchDetailsReport]

 @EstateID nVarchar(50),
 @Period Int,
 @FYear Int

	 
AS
BEGIN
 
	Declare @ActiveMonthYearID nvarchar(50) ,@a nvarchar (10)
	
		Select @ActiveMonthYearID= ActiveMonthYearID 
		from General .ActiveMonthYear 
		where AMonth =@Period  
		AND AYear =@FYear 
		AND EstateID =@EstateID
		AND ModID = 4
		
		
    select Dis.ShipPontoon,Dis.DOL,Dis.DCL,Dis.DispatchDate,Dis.MillWeight,DIS.LoadingLocationID as LoadingLocationCode ,Dis.BAPNo, Dis.BuyerName,W_WB.ProductCode from Production.CPODispatch Dis 
    Left JOIN LoadingLocation LL ON Dis .LoadingLocationID =LL .LoadingLocationID
    INNER JOIN Weighbridge.WBProductMaster  W_WB ON W_WB .ProductID = Dis .ProductID    
    where ActiveMonthYearID=@ActiveMonthYearID  
    AND Dis.EstateID= @EstateID
    AND W_WB.ProductCode in ('CPO','Kernel')
    
    
    
    
    
END


