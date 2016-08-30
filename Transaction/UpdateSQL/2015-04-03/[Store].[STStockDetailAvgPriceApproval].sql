
GO

/****** Object:  StoredProcedure [Store].[STStockDetailAvgPriceApproval]    Script Date: 4/3/2015 5:30:48 PM ******/
DROP PROCEDURE [Store].[STStockDetailAvgPriceApproval]
GO

/****** Object:  StoredProcedure [Store].[STStockDetailAvgPriceApproval]    Script Date: 4/3/2015 5:30:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Store].[STStockDetailAvgPriceApproval] 
	@ID nVarchar(50),-- Header/Master Table ID
	@StockId nVarchar(50),
	@Qty numeric(18,2), --General for all approvals
	@Value numeric(18,0),
	@EstateID nVarchar(50),
	@ActiveMonthYearID nVarchar(50),
	@TransType nvarchar(50),
	@ReceivedPrice numeric(18,0) --, this parameter is used only for the EMDN(IDN) Approval, pl pass this param as empty or zero if others then emdn approval.
	--@DetailsID nVarchar(50)-- Detail Table ID
AS
DECLARE 

		@AvgPrice numeric(18,2),
		@BFValue numeric(18,0),
		@IDNValue numeric(18,0),
		@AdjValue numeric(18,0),
		@ITNInValue numeric(18,0),
		@ITNOutValue numeric(18,0),
		@RGNValue numeric(18,0),
		@SIVValue numeric(18,0),
		@BFQty numeric(18,2),
		@IDNQty numeric(18,2),
		@AdjQty numeric(18,2),
		@ITNInQty numeric(18,2),
		@ITNOutQty numeric(18,2),
		@RGNQty numeric(18,2),
		@SIVQty numeric(18,2)

BEGIN
-----------------------------------------------------------------SIV APPROVAL START----------------------------------------------------------------
If @TransType='SIV'
Begin

	SELECT @AvgPrice = Avgprice from StockDetail 
	WHERE StockID =@StockId AND EstateID =@EstateID AND ActiveMonthYearID = @ActiveMonthYearID

	UPDATE STORE.STIssueDetails  SET IssueUnitPrice=isnull(@AvgPrice,0) ,IssuedValue=(isnull(IssuedQty,0)-isnull(ReturnQty,0))*(@AvgPrice) --,ModifiedBy=date(), modified by =logged in user  
	,ModifiedOn =GETDATE()
	--WHERE  STIssueDetailsID=@DetailsID AND StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
	WHERE  STIssueID=@ID AND StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID

	SELECT @SIVValue = ISNULL(IssuedValue,0) FROM  STIssueDetails 
	WHERE StockID =@StockId AND EstateID =@EstateID AND ActiveMonthYearID = @ActiveMonthYearID AND STIssueID=@ID
	--WHERE   StockID =@StockId AND EstateID =@EstateID AND ActiveMonthYearID = @ActiveMonthYearID AND STIssueDetailsID=@DetailsID  

	UPDATE Store.StockDetail SET SIVQty=(isnull(SIVQty,0)+isnull(@Qty,0)),ModifiedOn =GETDATE()
	WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID--,ModifiedBy=date(), modified by =logged in user  

	UPDATE Store.StockDetail SET SIVValue=isnull(AvgPrice,0)* SIVQty  ,ModifiedOn =GETDATE()
	WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID--,ModifiedBy=date(), modified by =logged in user  


	SELECT 
		  @BFValue=ISNULL(BFValue,0),@IDNValue=ISNULL(IDNValue,0),@AdjValue=ISNULL(ADJValue,0),@ITNInValue=ISNULL(ITNInValue,0),@ITNOutValue =ISNULL(ITNOutValue,0),@RGNValue =ISNULL(RGNValue,0),@SIVValue =ISNULL(SIVValue,0) ,
		  @BFQty=ISNULL(BFQty,0)    ,@IDNQty =ISNULL(IDNQty,0)   ,@AdjQty=ISNULL(ADJQty,0)    ,@ITNInQty =ISNULL(ITNInQty,0)   ,@ITNOutQty =ISNULL(ITNOutQty,0)    ,@RGNQty=ISNULL(RGNQty,0)     ,@SIVQty=ISNULL(SIVQty,0)   
	FROM  Store.StockDetail 
	WHERE StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
		
--	SET	  @AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue -@ITNOutValue +@RGNValue-@SIVValue)/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty -@ITNOutQty +@RGNQty-@SIVQty) 
--	SET	  @AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue -@ITNOutValue +@RGNValue)/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty -@ITNOutQty +@RGNQty) 			
	
	SET	  @AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue )/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty ) 			
	IF @AvgPrice IS NOT NULL
	BEGIN
	--'Second Step Calculate the average price and update the stockdetail table(stockdetail.avgprice=avgprice)
	--'and update the same in stissuedetail table (stissuedetail.issueunitprice=avgprice) 
		 UPDATE STORE.StockDetail SET AvgPrice=@AvgPrice ,ModifiedOn =GETDATE()
		 WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID--,ModifiedBy=date(), modified by =logged in user  
		 
		 ----UPDATE General.Taskmonitor  SET Complete='Y',ModifiedBy='',ModifiedOn='' 
		 ----WHERE  ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
		 
		 SELECT IssueUnitPrice,IssuedValue FROM STORE.STIssueDetails 
		 --WHERE  STIssueDetailsID=@DetailsID AND StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
		 WHERE  STIssueID=@ID AND StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
		 
		 -- SELECT IssueUnitPrice,IssuedValue FROM STORE.STIssueDetails WHERE STIssueID=@ID AND StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
	END
End
-----------------------------------------------------------------SIV APPROVAL END------------------------------------------------------------------
Else	
		
-----------------------------------------------------------------RGN APPROVAL Start------------------------------------------------------------------
If @TransType='RGN'
Begin

	SELECT 
		  @BFValue=ISNULL(BFValue,0),@IDNValue=ISNULL(IDNValue,0),@AdjValue=ISNULL(ADJValue,0),@ITNInValue=ISNULL(ITNInValue,0),@ITNOutValue =ISNULL(ITNOutValue,0),@RGNValue =ISNULL(RGNValue,0) ,@SIVValue =ISNULL(SIVValue,0) ,
		  @BFQty=ISNULL(BFQty,0)  ,  @IDNQty =ISNULL(IDNQty,0) ,  @AdjQty=ISNULL(ADJQty,0)  ,  @ITNInQty =ISNULL(ITNInQty,0) ,  @ITNOutQty =ISNULL(ITNOutQty,0) ,   @RGNQty=ISNULL(RGNQty,0)      ,@SIVQty=ISNULL(SIVQty,0)   
	FROM  Store.StockDetail 
	WHERE StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
	
--	SET   @AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue -@ITNOutValue +@RGNValue-@SIVValue)/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty -@ITNOutQty +@RGNQty-@SIVQty) 
	SET   @AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue )/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty ) 

	IF @AvgPrice IS NOT NULL
	BEGIN
		--'Second Step Calculate the average price and update the stockdetail table(stockdetail.avgprice=avgprice)
		--'and update the same in STReturnGoodsDetails table (STReturnGoodsDetails.?=avgprice) 
		UPDATE STORE.StockDetail SET AvgPrice=@AvgPrice ,ModifiedOn =GETDATE()
		WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID--,ModifiedBy=date(), modified by =logged in user  
	END	
		 
	UPDATE Store.StockDetail SET RGNQty=isnull(RGNQty,0)+isnull(@Qty,0),ModifiedOn =GETDATE()
	WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID--,ModifiedBy=date(), modified by =logged in user  
  	
  	UPDATE Store.StockDetail SET RGNValue=((isnull(AvgPrice,0)*isnull(RGNQty,0))),ModifiedOn =GETDATE()
  	WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID--,ModifiedBy=date(), modified by =logged in user  
  	
	--select @AvgPrice 
	IF @AvgPrice IS NOT NULL
	BEGIN
		--'Second Step Calculate the average price and update the stockdetail table(stockdetail.avgprice=avgprice)
		--'and update the same in STReturnGoodsDetails table (STReturnGoodsDetails.?=avgprice) 
		 
		UPDATE STORE.STReturnGoodsDetails  SET ReturnedValue =isnull(ReturnQty,0)*@AvgPrice  ,ModifiedOn =GETDATE()
		WHERE  STReturnGoodsNoteID=@ID AND StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID 
		AND EstateID=@EstateID--,ModifiedBy=date(), modified by =logged in user  
			 
		SELECT MILLDet.ReturnedValue ,CAT.COAID AS StockCOAID,CAT.VarianceCOAID  
		FROM   STORE.STReturnGoodsDetails MILLDet INNER JOIN Store.STMaster MST ON MST.StockID=MILLDet.StockID 
			   INNER JOIN STORE.STCategory CAT ON CAT.STCategoryID=MST.STCategoryID 
			   INNER JOIN Store.StockDetail Det ON Det.StockID=MST.StockID 
		WHERE  MILLDet.STReturnGoodsNoteID=@ID AND  MILLDet.StockID=@StockId  AND MILLDet.ActiveMonthYearID =Det.ActiveMonthYearID AND MILLDet.EstateID =Det.EstateID AND Det.StockID=MILLDet.StockID 
			   AND MILLDet.ActiveMonthYearID=@ActiveMonthYearID AND MILLDet.EstateID=@EstateID AND DET.StockID =@StockId 
	END
End	
-----------------------------------------------------------------RGN APPROVAL End------------------------------------------------------------------
		
Else
-----------------------------------------------------------------IDN APPROVAL Start------------------------------------------------------------------
If @TransType='IDN'
Begin
	
	UPDATE Store.StockDetail 
	SET IDNQty=(isnull(IDNQty,0)+isnull(@Qty,0)) ,ModifiedOn =GETDATE()
	WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
	print '1'
  	UPDATE Store.StockDetail 
  	SET IDNValue=(isnull(IDNValue,0)+isnull(@Value,0)) ,ModifiedOn =GETDATE()
  	WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
  	--UPDATE Store.StockDetail SET IDNValue=(isnull(IDNValue,0)+(isnull(UnitPrice,0)*isnull(@Qty,0))) WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
  	print '2'
  -- when ,where and how bfqty will get reduced up on successful siv approval as per the document
	SELECT 
		@BFValue=ISNULL(BFValue,0),@IDNValue=ISNULL(IDNValue,0),@AdjValue=ISNULL(ADJValue,0),@ITNInValue=ISNULL(ITNInValue,0),@ITNOutValue =ISNULL(ITNOutValue,0),@RGNValue =ISNULL(RGNValue,0) ,@SIVValue =ISNULL(SIVValue,0) ,
		@BFQty=ISNULL(BFQty,0)  ,  @IDNQty =ISNULL(IDNQty,0) ,  @AdjQty=ISNULL(ADJQty,0)  ,  @ITNInQty =ISNULL(ITNInQty,0) ,  @ITNOutQty =ISNULL(ITNOutQty,0) ,   @RGNQty=ISNULL(RGNQty,0)      ,@SIVQty=ISNULL(SIVQty,0)   
	FROM Store.StockDetail 
	WHERE StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
	print '3'

	if (@BFQty +@IDNQty  +@AdjQty  +@ITNInQty) = 0.0 
		SET	  @AvgPrice = 0.0
	else
		SET	  @AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue )/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty ) 	

	print '4'
	--SET   @AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue -@ITNOutValue +@RGNValue-@SIVValue)/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty -@ITNOutQty +@RGNQty-@SIVQty) 

	IF @AvgPrice IS NOT NULL
	BEGIN
	
		---update stockmaster lastpurchase price with emdn received price.
		 UPDATE STORE.STMaster  SET LastPurchasePrice =@ReceivedPrice,ModifiedOn =GETDATE()
		 WHERE  StockID=@StockId AND   EstateID=@EstateID
		 print '5'
		--'Second Step Calculate the average price and update the stockdetail table(stockdetail.avgprice=avgprice)
		 UPDATE STORE.StockDetail SET AvgPrice=@AvgPrice ,ModifiedOn =GETDATE()
		 WHERE  StockID=@StockId AND ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID
		 print '6'
		 
	END
	
	SELECT CAT.COAID AS StockCOAID,CAT.VarianceCOAID,ISNULL(MST.StdPrice,0) as 'StdPrice'
	FROM   STORE.STCategory CAT INNER JOIN Store.STMaster MST ON MST.STCategoryID=CAT.STCategoryID 
		   INNER JOIN Store.StockDetail DET on MST.StockID=DET.StockID and DET.EstateID=@EstateID and CAT.EstateID=DET.EstateID
		   and DET.ActiveMonthYearID=@ActiveMonthYearID 
	WHERE  CAT.EstateID=MST.EstateID AND CAT.EstateID=@EstateID AND MST.StockID=@StockId 
	print '7'
End
-----------------------------------------------------------------IDN APPROVAL End------------------------------------------------------------------
Else	

		--------------- IDNIN APPROVAL ---------------------------------------
If @TransType='IDNIN'
Begin
select * from StockDetail 
End	
	    -------------- IDNIN APPROVAL ---------------------------------------
Else
	    -------------- STOCK ADJUSTMENT APPROVAL ----------------------------
If @TransType='STA'
Begin
select * from StockDetail 
End	    
	    -------------- STOCK ADJUSTMENT APPROVAL ----------------------------
END

--EXEC [Store].[STIssueAvgPriceCalculate] '1R2','01R17','M01'



















GO


