
/****** Object:  StoredProcedure [Store].[StoreMonthlyProcessing]    Script Date: 11/5/2016 1:45:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--==================================================================================================================================    
-- Created By : Arulprakasan    
-- Created date:  15-Dec-2009    
-- Modified By: Arulprakasan    
-- Last Modified Date: 09-April-2010     
-- Modified By: Stanley    
-- Last Modified Date: 13-Dec-2011     
-- Module     : Store    
-- Screen(s)  : Monthly Processing  
-- Description: MonthlyProcessing  
--==================================================================================================================================      
ALTER PROCEDURE [Store].StoreMonthlyProcessing  
   
 @EstateID nVarchar(50),    
 @EstateCode nVarchar(50),    
 @EstateCodeL nVarchar(50),  
 @ActiveMonthYearID nVarchar(50),  
 @LoginMonth int,  
 @LoginYear int,  
 @AYear int,  
 @AMonth int,  
 @CreatedBy nvarchar(50),  
 --@CreatedOn datetime,  
 @ModifiedBy nvarchar(50)  
 --@ModifiedOn datetime    
   
AS    

 DECLARE   
 @COAID nvarchar(50),    
 @DC char(1),      
 @Value numeric(18,0),     
 @DivID nvarchar(50),  
 @YOPID nvarchar(50),      
 @BlockID nvarchar(50),    
 @VHID nvarchar(50),      
 @VHDetailCostCodeID nvarchar(50),  
 @T0 nvarchar(50),       
 @T1 nvarchar(50),     
 @T2 nvarchar(50),      
 @T3 nvarchar(50),  
 @T4 nvarchar(50),       
 @StationID nvarchar(50),  
 @DescpSIVStock nvarchar(200),  
 @DescpStockIssue nvarchar(200),  
 @DescpITNOUTStock nvarchar(200),  
 @DescpReceiverLocation nvarchar(200),  
 @Flag nvarchar(50),  
 @StockID nvarchar(50),      
 @SIVPrice numeric(18,0),   
 @VariancePrice numeric(18,0),   
 @STDPrice numeric(18,0),  
 @StockCOAID nvarchar(50),     
 @VarianceCOAID nvarchar(50),  
 @JournalDetID nvarchar(50),  
 @VHUom nvarchar(50),
 @VHQty nvarchar(50)
     
 DECLARE @STIssueDetailsID nvarchar(50)  
   
 DECLARE @ModName nvarchar(50),   
 @LedgerDate datetime,    
 @LedgerType nvarchar(50),    
 @LedgerDescp nvarchar(500),   
 @BatchAmount numeric(18,0)  
 DECLARE  @SIVCount INT     
 DECLARE @SIVDetCount INT   
   
 DECLARE @STIssueID nvarchar(50) ,  
 @ITNOUTPRICE numeric(18,0)   
 DECLARE  @STInternalTransferOutID nvarchar(50) ,  
 @STInternalTransferOutDetailsID  nvarchar(50)   
   
 Declare @count int,  
 @LedgerID nvarchar(50),  
 @LedgerNo nvarchar(50),  
 @ModID int,  
 @ModCode nvarchar(50),  
      
 @CreatedOn datetime,  
 @ModifiedOn datetime  
   
 Declare @countJournal int  
   
 Declare @VHWSCode nvarchar(50),    
 @VHDetailCostCode nvarchar(50),    
 @Type nvarchar(1),    
 @VHChargeValue numeric(18,0),  --Store.STIssueDetails.IssuedValue  
 @JDescp nvarchar(300),    
 @VHChargeDetailID nvarchar(50),  
 @ITNOUTGDST0 nvarchar(50),  
 @ITNOUTGDST1 nvarchar(50),  
 @ITNOUTGDST2 nvarchar(50),  
 @ITNOUTGDST3 nvarchar(50),  
 @ITNOUTGDST4 nvarchar(50),  
   
 @SIVCATT0 nvarchar(50),  
 @SIVCATT1 nvarchar(50),  
 @SIVCATT2 nvarchar(50),  
 @SIVCATT3 nvarchar(50),  
 @SIVCATT4 nvarchar(50),  
 @ITNOUTCATT0 nvarchar(50),  
 @ITNOUTCATT1 nvarchar(50),  
 @ITNOUTCATT2 nvarchar(50),  
 @ITNOUTCATT3 nvarchar(50),  
 @ITNOUTCATT4 nvarchar(50),  
 @i INT  
   
 --  
 declare @sLoginMonthYear nvarchar(50)  
 set @sLoginMonthYear=(SELECT case   
 when @LoginMonth=1 then 'Jan' when @LoginMonth=2 then 'Feb' when @LoginMonth=3 then 'Mar' when @LoginMonth=4 then 'Apr'   
 when @LoginMonth=5 then 'May' when @LoginMonth=6 then 'Jun' when @LoginMonth=7 then 'Jul' when @LoginMonth=8 then 'Aug'   
 when @LoginMonth=9 then 'Sep' when @LoginMonth=10 then 'Oct' when @LoginMonth=11 then 'Nov' when @LoginMonth=12 then 'Dec'   
 end as LoginMonth)+convert(nvarchar,@LoginYear)  
 --  
        
BEGIN TRY  
BEGIN TRANSACTION  -- Start the transaction  
BEGIN    
  
------- Clear All the Data (Ledgerallmodule,journaldetail and vhchargedetail) start-----------  
  
 -- SELECT * FROM Accounts.JournalDetail WHERE LedgerID IN (SELECT LedgerID FROM Accounts.LedgerAllModule WHERE EstateID='M1' AND LedgerType='STORE-SIV')  
 DELETE FROM Accounts.JournalDetail    
 WHERE LedgerID IN (SELECT LedgerID FROM Accounts.LedgerAllModule   
 WHERE EstateID=@EstateID AND AYEAR=@AYear AND AMonth=@AMonth AND  
  LedgerType in('STORE-SIV','STORE-RGN','STORE-ITNOUT') )  
   
 DELETE FROM Accounts.LedgerAllModule   
 WHERE  EstateID=@EstateID AND AYEAR=@AYear AND AMonth=@AMonth AND  
 LedgerType in('STORE-SIV','STORE-RGN','STORE-ITNOUT')  
     
   
 --DELETE FROM Vehicle.VHChargeDetail  WHERE LedgerType in ('STORE-SIV','STORE-RGN') AND EstateCodeL=@EstateCodeL  AND EstateCode=@EstateCode     
 DELETE FROM Vehicle.VHChargeDetail    
 WHERE  AYEAR=@AYear AND AMonth=@AMonth AND LedgerType in ('STORE-SIV','STORE-RGN')   
 --AND EstateCodeL=@EstateCodeL    
 AND EstateCode=@EstateCode     
   
------- Clear All the Data (Ledgerallmodule,journaldetail and vhchargedetail) end-------------   
  
------- Take all the item for the current month from stock detail table  start----------------  
  
 --UPDATE  Store.StockDetail   
 --SET AvgPrice=ABS((ISNULL(BFValue,0)+ISNULL(IDNValue,0)+ISNULL(AdjValue,0)+ISNULL(ITNInValue,0)-ISNULL(ITNOutValue,0)+ISNULL(RGNValue,0))/  
 --     (ISNULL(BFQty,0) +ISNULL(IDNQty,0)  + ISNULL(AdjQty,0)  +ISNULL(ITNInQty,0)  -ISNULL(ITNOutQty,0)  + ISNULL(RGNQty,0)))  
 --WHERE ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID   
 --and (ISNULL(BFQty,0)  +ISNULL(IDNQty,0)  + ISNULL(AdjQty,0)  +ISNULL(ITNInQty,0)  -ISNULL(ITNOutQty,0)  + ISNULL(RGNQty,0))<>0  
   
 --select 'avgprice Update Start'  
 UPDATE  Store.StockDetail   
 SET AvgPrice=ABS((ISNULL(BFValue,0)+ISNULL(IDNValue,0)+ISNULL(AdjValue,0)+ISNULL(ITNInValue,0))/  
      (ISNULL(BFQty,0)   +ISNULL(IDNQty,0)  +ISNULL(AdjQty,0) +ISNULL(ITNInQty,0))) ,  
 ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()        
 WHERE ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID   
 and (ISNULL(BFQty,0)  +ISNULL(IDNQty,0)  +ISNULL(AdjQty,0)  +ISNULL(ITNInQty,0))<>0  
  
 ----UPDATE  Store.StockDetail   
 ----SET AvgPrice=0  
 ----WHERE ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID   
 ----and (ISNULL(BFQty,0)  +ISNULL(IDNQty,0)  +ISNULL(AdjQty,0)  +ISNULL(ITNInQty,0))=0  
   
 --select 'avgprice Update End'  
 ----SELECT SIV.STOCKID,STD.StockID,SIV.ISSUEUNITPRICE,STD.AvgPrice,SIV.IssuedQty ,STD.AvgPrice*SIV.IssuedQty FROM STORE.STIssueDetails SIV INNER JOIN Store.StockDetail STD ON STD.StockID =SIV.StockID WHERE SIV.ActiveMonthYearID=@ActiveMonthYearID AND SIV.ActiveMonthYearID=STD.ActiveMonthYearID   
   
 --SIV Update Start  
 --select 'SIV Update Start'  
 UPDATE Store.STIssueDetails   
 SET Store.STIssueDetails.IssueUnitPrice=ISNULL(Store.StockDetail.AvgPrice,0),  
 Store.STIssueDetails.IssuedValue=ISNULL(Store.StockDetail.AvgPrice,0)*(ISNULL(Store.STIssueDetails.IssuedQty,0)),  
 Store.STIssueDetails.ModifiedBy=@ModifiedBy,Store.STIssueDetails.ModifiedOn=GETDATE()  
 FROM Store.STIssueDetails INNER JOIN Store.StockDetail ON Store.STIssueDetails.StockID =Store.StockDetail.StockID   
 WHERE Store.STIssueDetails.ActiveMonthYearID=Store.StockDetail.ActiveMonthYearID AND   
 Store.STIssueDetails.ActiveMonthYearID =@ActiveMonthYearID AND Store.STIssueDetails.EstateID=@EstateID   
  
  
 --select 'SIV Update End'  
 --SIV Update End  
   
 --RGN Update Start  
 UPDATE Store.STReturnGoodsDetails  
 SET Store.STReturnGoodsDetails.ReturnedValue=ISNULL(Store.StockDetail.AvgPrice,0)*ISNULL(Store.STReturnGoodsDetails.ReturnQty,0) ,  
 Store.STReturnGoodsDetails.ModifiedBy=@ModifiedBy,Store.STReturnGoodsDetails.ModifiedOn=GETDATE()  
 FROM Store.STReturnGoodsDetails INNER JOIN Store.StockDetail ON Store.STReturnGoodsDetails.StockID =Store.StockDetail.StockID   
 WHERE Store.STReturnGoodsDetails.ActiveMonthYearID=Store.StockDetail.ActiveMonthYearID AND   
 Store.STReturnGoodsDetails.ActiveMonthYearID =@ActiveMonthYearID AND Store.STReturnGoodsDetails.EstateID=@EstateID   
 --RGN Update End  
   
 --ITNOUT Update Start  
 UPDATE Store.STInternalTransferOutDetails  
 SET Store.STInternalTransferOutDetails.UnitPrice=ISNULL(Store.StockDetail.AvgPrice,0) ,  
 Store.STInternalTransferOutDetails.TransferOutValue=ISNULL(Store.StockDetail.AvgPrice,0)*ISNULL(Store.STInternalTransferOutDetails.TransferOutQty,0) ,  
 Store.STInternalTransferOutDetails.ModifiedBy=@ModifiedBy,Store.STInternalTransferOutDetails.ModifiedOn=GETDATE()  
 FROM Store.STInternalTransferOutDetails INNER JOIN Store.StockDetail ON Store.STInternalTransferOutDetails.StockID =Store.StockDetail.StockID   
 WHERE Store.STInternalTransferOutDetails.ActiveMonthYearID=Store.StockDetail.ActiveMonthYearID AND   
 Store.STInternalTransferOutDetails.ActiveMonthYearID =@ActiveMonthYearID AND Store.STInternalTransferOutDetails.EstateID=@EstateID   
 --ITNOUT Update End  
   
  
 --commented by anand to fix incosistent data in SIV, TOUT, RGN compare to Stocdetail.SIV,TOUT, RGN Values.  
 /*UPDATE  Store.StockDetail   
 SET SIVValue = ISNULL(AvgPrice,0) * ISNULL(SIVQty,0),  
 RGNValue = ISNULL(AvgPrice,0) * ISNULL(RGNQty,0),  
 ITNOutValue = ISNULL(AvgPrice,0) * ISNULL(ITNOutQty,0),  
 ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()        
 WHERE ActiveMonthYearID=@ActiveMonthYearID AND EstateID=@EstateID */  
 
-- COmmented on 18June2011 because following query wrong update the SIVValue in StockDetail,in next query Store.stockdetailSummaryView.Type ='RGN' value also added
 --UPDATE  Store.StockDetail   
 --SET SIVValue = ISNULL(Store.stockdetailSummaryView.Value,0),  
 ---- palani  
 ----SIVqty= ISNULL(Store.stockdetailSummaryView.Qty,0),  
 --ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()  
 --FROM Store.StockDetail 
 --INNER JOIN Store.stockdetailSummaryView ON  Store.stockdetailSummaryView.StockID= Store.StockDetail.StockID   
 --AND Store.stockdetailSummaryView.EstateID = Store.StockDetail.EstateID   
 --AND Store.stockdetailSummaryView.ActiveMonthYearID = Store.StockDetail.ActiveMonthYearID   
 --AND Store.stockdetailSummaryView.ActiveMonthYearID = Store.StockDetail.ActiveMonthYearID   
 --AND Store.stockdetailSummaryView.Type='SIV'  
 --WHERE Store.Stockdetail.ActiveMonthYearID=@ActiveMonthYearID AND Store.Stockdetail.EstateID=@EstateID    

UPDATE Store.StockDetail
SET SIVValue = (ISNULL(SDSV_SIV.Value,0) + ISNULL(SDSV_RET.Value,0)),
ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE() 
-- select SD.SIVQty, SD.StockID,isnull(SD.SIVValue,0) SIVValue,ISNULL(SDSV_SIV.Value,0) as SDSV_SIV,ISNULL(SDSV_RET.Value,0) as SDSV_RET, ModifiedBy='Palani',ModifiedOn=GETDATE()  
FROM Store.StockDetail SD  
left outer JOIN Store.stockdetailSummaryView SDSV_SIV ON  SDSV_SIV.StockID= SD.StockID AND SDSV_SIV.EstateID = SD.EstateID AND SDSV_SIV.ActiveMonthYearID = SD.ActiveMonthYearID AND SDSV_SIV.ActiveMonthYearID = SD.ActiveMonthYearID AND SDSV_SIV.Type='SIV'  
left outer JOIN Store.stockdetailSummaryView SDSV_RET ON  SDSV_RET.StockID= SD.StockID AND SDSV_RET.EstateID = SD.EstateID AND SDSV_RET.ActiveMonthYearID = SD.ActiveMonthYearID AND SDSV_RET.ActiveMonthYearID = SD.ActiveMonthYearID AND SDSV_RET.Type='RGN'  
WHERE SD.ActiveMonthYearID=@ActiveMonthYearID AND SD.EstateID=@EstateID
  
 UPDATE  Store.StockDetail   
 SET ITNOutValue = ISNULL(Store.stockdetailSummaryView.Value,0),  
   
    -- palani  
 --ITNOutQty= ISNULL(Store.stockdetailSummaryView.Qty,0),  
   
 ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()  
 FROM Store.StockDetail INNER JOIN Store.stockdetailSummaryView    
 ON  Store.stockdetailSummaryView.StockID= Store.StockDetail.StockID   
 AND Store.stockdetailSummaryView.EstateID = Store.StockDetail.EstateID   
 AND Store.stockdetailSummaryView.ActiveMonthYearID = Store.StockDetail.ActiveMonthYearID   
 AND Store.stockdetailSummaryView.ActiveMonthYearID = Store.StockDetail.ActiveMonthYearID   
 AND Store.stockdetailSummaryView.Type='OUT'  
 WHERE Store.Stockdetail.ActiveMonthYearID=@ActiveMonthYearID AND Store.Stockdetail.EstateID=@EstateID    
  
    UPDATE  Store.StockDetail   
 SET RGNValue = ISNULL(Store.stockdetailSummaryView.Value,0),  
   
 -- palani  
 --RGNQty= ISNULL(Store.stockdetailSummaryView.Qty,0),  
   
   
 ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()  
 FROM Store.StockDetail INNER JOIN Store.stockdetailSummaryView    
 ON  Store.stockdetailSummaryView.StockID= Store.StockDetail.StockID   
 AND Store.stockdetailSummaryView.EstateID = Store.StockDetail.EstateID   
 AND Store.stockdetailSummaryView.ActiveMonthYearID = Store.StockDetail.ActiveMonthYearID   
 AND Store.stockdetailSummaryView.ActiveMonthYearID = Store.StockDetail.ActiveMonthYearID   
 AND Store.stockdetailSummaryView.Type='RGN'  
 WHERE Store.Stockdetail.ActiveMonthYearID=@ActiveMonthYearID AND Store.Stockdetail.EstateID=@EstateID    
  
 ------- Take all the item for the current month from stock detail table  end----------------  
   
 --------Create Ledger for all SIV of the month start----------------------------------------  
   
 --DECLARE @ModName nvarchar(50), @LedgerDate datetime,  @LedgerType nvarchar(50),  @LedgerDescp nvarchar(500), @BatchAmount numeric(18,0)  
 --DECLARE  @SIVCount INT   DECLARE @SIVDetCount INT DECLARE @STIssueID nvarchar(50)   
   
 DECLARE @getSTIssueID CURSOR  
 SET @getSTIssueID = CURSOR FOR  
   
 SELECT STI.STIssueID,SIVDate,SIVNO +' '+ISNULL(Remarks,'')  FROM Store.STIssue  STI   
 WHERE  STI.Status='APPROVED' AND STI.ActiveMonthYearID=@ActiveMonthYearID  AND STI.EstateID=@EstateID   
   
 OPEN @getSTIssueID  
 FETCH NEXT  
   
 FROM @getSTIssueID INTO @STIssueID,@LedgerDate,@LedgerDescp  
    WHILE @@FETCH_STATUS = 0  
 BEGIN  
  --------------------------------------  
  --PRINT @STIssueID -- PROCESS  
  --Declare @count int,  @LedgerID nvarchar(50),  @LedgerNo nvarchar(50),  @ModID int,  @ModCode nvarchar(50),  
  --   @CreatedOn datetime, @ModifiedOn datetime  
       
    BEGIN   
  SET @count = 0  
  SET @ModID=2  
  SET @ModCode='ST'  
  SET @ModName='STORE'  
  SET @LedgerType='STORE-SIV'  
  --SET @LedgerDate=GETDATE()  
  SET @BatchAmount=NULL  
  SET @CreatedOn=GETDATE()  
  SET @ModifiedOn =GETDATE()  
   
  --SELECT  @LedgerDescp=SIVNO+' '+ISNULL(Remarks,'')  
  --FROM Store.STIssue WHERE STIssueID=@STIssueID   
    
  ------------SELECT @count =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
  ------------FROM Accounts.LedgerAllModule  
  ------------SET @LedgerID = @EstateCode + 'R' + CONVERT(NVARCHAR,@count);  
    
  --DECLARE @i INT   
    
 ------- for running number-----  
 SET @count = 0;  
 SELECT @count = (ISNULL(MAX(Id),0) + 1) FROM Accounts.LedgerAllModule;  
 SELECT @count =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
 FROM Accounts.LedgerAllModule  
 -------  
   
  SET @i= 2  
  SELECT @LedgerID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
  FROM   Accounts.LedgerAllModule   
  WHILE EXISTS  
  (SELECT id  
  FROM    Accounts.LedgerAllModule   
  WHERE   LedgerID  = @LedgerID  
  )  
  BEGIN  
   SELECT @LedgerID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
   FROM   Accounts.LedgerAllModule   
   SET @i = @i + 1  
  END  
  
  
  --SELECT @ModID=ModID  ,@ModCode = ModCode  FROM General.Module WHERE ModName=@ModName  
    
  --SET @LedgerNo=rtrim(@EstateCode)+rtrim(@MODCODE)+rtrim(@LedgerType)+CONVERT(NVARCHAR,@LoginMonth)+CONVERT(NVARCHAR,@LoginYear)+CONVERT(NVARCHAR,@count)  
  SET @LedgerNo=rtrim(@LedgerType)+CONVERT(NVARCHAR,@LoginMonth)+CONVERT(NVARCHAR,@LoginYear)+CONVERT(NVARCHAR,@count)  
   
  INSERT INTO Accounts.LedgerAllModule  
     (LedgerID,  EstateID,  Ayear,   Amonth ,  ModID,  LedgerDate,  LedgerType,  LedgerNo,    
     Descp,   BatchAmount, CreatedBy,  CreatedOn,  ModifiedBy, ModifiedOn)  
  VALUES  
     (@LedgerID,  @EstateID,  @AYear,   @AMonth ,  @ModID,  @LedgerDate, @LedgerType, @LedgerNo,  
     @LedgerDescp, @BatchAmount, @CreatedBy,  GETDATE(),  @ModifiedBy, GETDATE());  
   
 --SELECT @LedgerID=LedgerID--,LedgerNo,LedgerType    
 --FROM Accounts.LedgerAllModule WHERE LedgerID= @LedgerID  
   
 --------NESTED CURSER FOR JOURNAL DETAL INSERT start----------------------------------------  
   
  --DECLARE @COAID nvarchar(50),  @DC char(1),    @Value numeric(18,0),   @DivID nvarchar(50),  
  --@YOPID nvarchar(50),    @BlockID nvarchar(50),  @VHID nvarchar(50),    @VHDetailCostCodeID nvarchar(50),  
  --@T0 nvarchar(50),     @T1 nvarchar(50),   @T2 nvarchar(50),    @T3 nvarchar(50),  
  --@T4 nvarchar(50),     @StationID nvarchar(50), @Descp nvarchar(200),   @Flag nvarchar(50),  
  --@StockID nvarchar(50),    @SIVPrice numeric(18,0), @VariancePrice numeric(18,0), @STDPrice numeric(18,0),  
  --@StockCOAID nvarchar(50),   @VarianceCOAID nvarchar(50),@JournalDetID nvarchar(50)  
       
  --DECLARE @STIssueDetailsID nvarchar(50)  
    
  DECLARE @getSTIssueDetailsID CURSOR  
  SET @getSTIssueDetailsID = CURSOR FOR  
   
  SELECT STI.STIssueDetailsID,  
  STD.STOCKID,  
  --(ISNULL(STI.IssuedQty,0)-ISNULL(STI.returnqty,0))*ISNULL(STD.AvgPrice,0), --Actual value  
  ISNULL(STI.IssuedValue,0)-ISNULL(STRD.ReturnedValue,0), --Actual value  
  SIV.sivno+'-'+stm.stockcode+'-'+STM.StockDesc,  
  SIV.sivno+'-'+'Stock Issue'+'-'+@sLoginMonthYear,  
  (ISNULL(STI.IssuedQty,0)-ISNULL(STI.returnqty,0))*ISNULL(STD.StdPrice,0), --standard Value  
  --ABS((ISNULL(STD.StdPrice,0)*ISNULL(STI.IssuedQty,0))-ABS(ISNULL(STI.IssuedValue,0))), --variance price  
  ((ISNULL(STI.IssuedQty,0)-ISNULL(STI.returnqty,0))*ISNULL(STD.AvgPrice,0))-((ISNULL(STI.IssuedQty,0)-ISNULL(STI.returnqty,0))*ISNULL(STD.StdPrice,0)), --variance value  
  ISNULL(CAT.COAID,'') ,--stock coa id  
  ISNULL(CAT.VarianceCOAID,''),--variance coa id  
  ISNULL(STI.COAID,''),--siv coa id  
  STI.DivID,STI.YOPid,STI.BlockID,STI.VHID,STI.VHDetailCostCodeID,  
  STI.T0,STI.T1,STI.T2,STI.T3,STI.T4,STI.StationID,  
  CAT.T0,CAT.T1,CAT.T2,CAT.T3,CAT.T4  
  FROM Store.STIssueDetails STI   
  INNER JOIN Store.STIssue SIV ON SIV.STIssueID=STI.STIssueID AND SIV.ActiveMonthYearID=STI.ActiveMonthYearID  
  INNER JOIN Store.StockDetail STD ON STD.StockID = STI.StockID AND STD.ActiveMonthYearID=STI.ActiveMonthYearID  
  INNER JOIN Store.STMaster STM ON STM.StockID = STI.StockID  
  INNER JOIN Store.STCategory CAT ON CAT.STCategoryID=STM.STCategoryID   
  LEFT OUTER JOIN Store.STReturnGoodsDetails STRD on STRD.STIssueDetailsID=STI.STIssueDetailsID  
  WHERE STI.STIssueID=@STIssueID AND STI.EstateID=@EstateID AND STI.ActiveMonthYearID =@ActiveMonthYearID       
  --SELECT STIssueDetailsID  FROM STORE.STISSUEDETAILS WHERE STIssueID=@STIssueID AND EstateID=@EstateID AND ActiveMonthYearID=@ActiveMonthYearID  
  
  OPEN @getSTIssueDetailsID  
  
  FETCH NEXT  
  FROM @getSTIssueDetailsID   
  INTO @STIssueDetailsID,  
  @STOCKID,  
  @SIVPrice,  
  @DescpSIVStock,  
  @DescpStockIssue,  
  @STDPrice,  
  @VariancePrice,  
  @StockCOAID,  
  @VarianceCOAID,  
  @COAID,  
  @DivID,  
  @YOPID,  
  @BlockID,  
  @VHID,  
  @VHDetailCostCodeID,  
  @T0,  
  @T1,  
  @T2,  
  @T3,  
  @T4,  
  @StationID,  
  @SIVCATT0,  
  @SIVCATT1,  
  @SIVCATT2,  
  @SIVCATT3,  
  @SIVCATT4  
   
  WHILE @@FETCH_STATUS = 0  
  BEGIN  
   -- PROCESS START--   
      
   ----SELECT @StockID=STOCKID FROM Store.STIssueDetails WHERE STIssueDetailsID=@STIssueDetailsID AND EstateID=@EstateID AND ActiveMonthYearID=@ActiveMonthYearID  
   
   ----SELECT @SIVPrice=ISNULL(STI.IssuedValue,0), @Descp=STM.StockDesc,@STDPrice=ISNULL(STD.StdPrice,0), --,STD.AvgPrice  
   ----  @VariancePrice=ABS(ISNULL(ISNULL(STD.StdPrice,0)-ISNULL(STI.IssuedValue,0),0)),  
   ----  @StockCOAID=ISNULL(CAT.COAID,'') ,@VarianceCOAID=ISNULL(CAT.VarianceCOAID,''),--STI.IssuedQty,  
   ----  @COAID=ISNULL(STI.COAID,''),@DivID=STI.DivID,@YOPID=STI.YOPid,@BlockID=STI.BlockID,@VHID=STI.VHID,@VHDetailCostCodeID=STI.VHDetailCostCodeID,  
   ----  @T0=STI.T0,@T1=STI.T1,@T2=STI.T2,@T3=STI.T3,@T4=STI.T4--,@Flag='SIVPRICE'  
   ----FROM Store.STIssueDetails STI   
   ----  INNER JOIN Store.STIssue SIV ON SIV.STIssueID=STI.STIssueID   
   ----  INNER JOIN Store.STMaster STM ON STI.StockID = STM.StockID   
   ----  INNER JOIN Store.StockDetail STD ON STM.StockID = STD.StockID  
   ----  INNER JOIN Store.STCategory CAT ON STM.STCategoryID=CAT.STCategoryID   
   ----WHERE STIssueDetailsID=@STIssueDetailsID   
   ----  AND STI.StockID =@StockID AND  STI.EstateID=@EstateID   
   ----  AND STD.EstateID=@EstateID AND STI.ActiveMonthYearID =@ActiveMonthYearID   
   ----  AND STD.ActiveMonthYearID=@ActiveMonthYearID   
     
   --SIV JournalDetail INSERT START--  
     
     
   ------------SET @countJournal = 0;  
   ------------SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
   ------------FROM Accounts.JournalDetail  
   ------------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
     
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
  
   IF @STDPrice=0  
   BEGIN  
   --SIVPRICE START--  
   INSERT INTO Accounts.JournalDetail  
     (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
     Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
     VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,       CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
   VALUES  
     (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @COAID,   'D',  
     @SIVPrice,    @DescpSIVStock,   'SIVPRICE' , @DivID,    @YOPID,    @BlockID,  @VHID,  
     @VHDetailCostCodeID, @T0,    @T1,   @T2,    @T3,    @T4,   @StationID,  
     @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
    
   ----------SET @countJournal = 0;  
   ----------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
   ----------       FROM Accounts.JournalDetail  
   ----------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
     
     
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
   INSERT INTO Accounts.JournalDetail  
     (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
     Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
     VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
     CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
   VALUES  
     (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @StockCOAID , 'C',  
     @SIVPrice,    @DescpStockIssue, 'SIVPRICE' , NULL,    NULL,    NULL,   NULL,  
     NULL,     @SIVCATT0,   @SIVCATT1,  @SIVCATT2,   @SIVCATT3,   @SIVCATT4,  NULL,  
     @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END  
   --SIVPRICE END--  
     
   --STDPRICE START--  
  
   IF @STDPrice>0 AND @StockCOAID<>''  
   BEGIN  
     
    --------SET @countJournal = 0;  
    --------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    --------       FROM Accounts.JournalDetail  
    --------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
      
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
    INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @COAID ,  'D',  
      @STDPrice ,    @DescpSIVStock,   'SIVSTDPRICE' , @DivID,    @YOPID,    @BlockID,  @VHID,  
      @VHDetailCostCodeID, @T0,    @T1,   @T2,    @T3,    @T4,   @StationID,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
  
    ----------SET @countJournal = 0;  
    ----------SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ----------       FROM Accounts.JournalDetail  
    ----------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
  
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @STOCKCOAID , 'C',  
      @STDPrice ,    @DescpStockIssue, 'SIVSTDPRICE' , NULL,    NULL,    NULL,   NULL,  
      NULL,     @SIVCATT0,   @SIVCATT1,  @SIVCATT2,   @SIVCATT3,   @SIVCATT4,  NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END     
   
   --STDPRICE END--  
     
   -- SIVVARIANCEPRICE Price IF -ve START  
   IF @VariancePrice <0 AND @STDPrice>0 AND @VarianceCOAID <>''  
   BEGIN  
  
    ------------SET @countJournal = 0;  
  
    ------------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ------------       FROM Accounts.JournalDetail  
    ------------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
  
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @StockCOAID  , 'D',  
      ABS(@VariancePrice)  , @DescpStockIssue+'-Variance','SIVVARIANCEPRICE', NULL,   NULL,    NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
  
    --------SET @countJournal = 0;  
  
    --------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    --------       FROM Accounts.JournalDetail  
    --------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
  
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @VarianceCOAID, 'C',  
      ABS(@VariancePrice)  , @DescpSIVStock+'-Variance','SIVVARIANCEPRICE' ,NULL,   NULL,    NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END    
  -- SIVVARIANCEPRICE Price IF -ve END  
   
   -- SIVVARIANCEPRICE Price IF +ve START  
   IF @VariancePrice >0 AND @STDPrice>0 AND @VarianceCOAID <>''  
   BEGIN  
  
    ------------SET @countJournal = 0;  
  
    ------------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ------------       FROM Accounts.JournalDetail  
    ------------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
      
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
  
    INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @VarianceCOAID  ,'D',  
      ABS(@VariancePrice)  , @DescpSIVStock+'-Variance','SIVVARIANCEPRICE', NULL,   NULL,    NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
  
    ----------SET @countJournal = 0;  
  
    ----------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ----------       FROM Accounts.JournalDetail  
    ----------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
      
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
  
    INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @StockCOAID, 'C',  
      ABS(@VariancePrice)  , @DescpStockIssue+'-Variance','SIVVARIANCEPRICE' ,NULL,   NULL,    NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END    
  -- SIVVARIANCEPRICE Price IF +ve END  
    
     
  --SIV JournalDetail INSERT END--  
  
  -- Vehicle.VHChargeDetail  Insert Start  
    
  IF @VHID IS NOT NULL AND @VHDetailCostCodeID IS NOT NULL  
  BEGIN  
     
  SELECT @VHID=STID.VHID,@VHDetailCostCodeID=STID.VHDetailCostCodeID,   
  @VHWSCode=VHM.VHWSCode ,@JDescp=VHM.VHDescp,@Type=VHM.[Type],  
  --@VHDetailCostCode=VHD.VHDetailCostCode,@EstateCodeL= VHM.LocationID  
  @VHDetailCostCode=VHD.VHDetailCostCode,@EstateCodeL= EST.EstateCode,
  @VHQty =STID.IssuedQty, @VhUOM = u.UOM  
  FROM Store.STIssueDetails STID  
  INNER JOIN Vehicle.VHMaster VHM ON STID.VHID=VHM.VHID  
  LEFT JOIN Vehicle.VHDetailCostCode VHD ON STID.VHDetailCostCodeID=VHD.VHDetailCostCodeID  
  INNER JOIN General.Estate EST ON VHM.LocationID=EST.EstateID   
   inner join store.STMaster STM on STID.StockID = STM.StockID
  inner join General.UOM U on stm.UOMID = u.UOMID
  --INNER JOIN General.Estate EST ON VHM.LocationID=EST.EstateID   
  WHERE STIssueDetailsID=@STIssueDetailsID   
    
  IF @STDPrice=0  
  BEGIN  
  SET @VHChargeValue=@SIVPrice  
  END  
  ELSE IF @STDPrice<>0  
  BEGIN  
  SET @VHChargeValue=@STDPrice  
  END  
   Declare @countVHChargeDetailID int  
     
   --------------SET @countVHChargeDetailID = 0;  
   --------------   SELECT @countVHChargeDetailID =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
   --------------       FROM Vehicle.VHChargeDetail    
   --------------SET @VHChargeDetailID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countVHChargeDetailID);    
     
   SET @i  = 2  
   SELECT @VHChargeDetailID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Vehicle.VHChargeDetail  
   WHILE EXISTS  
   (SELECT id  
   FROM    Vehicle.VHChargeDetail  
   WHERE   VHChargeDetailID  = @VHChargeDetailID  
   )  
   BEGIN  
     SELECT @VHChargeDetailID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Vehicle.VHChargeDetail  
     SET @i = @i + 1  
   END  
     
     
   --SELECT @ModID=ModID  FROM General.Module WHERE ModName=@ModName    
     
   INSERT INTO Vehicle.VHChargeDetail    
       (VHChargeDetailID, EstateCodeL, VHWSCode, EstateCode, VHDetailCostCode,   
       Type,    ModID,   LedgerType, LedgerNo, AYear,      
       AMonth,    Value,   JDescp,  CreatedBy, CreatedOn,  
       ModifiedBy, ModifiedOn,UOMID,QtyUsed,RefNo)    
    VALUES    
       (@VHChargeDetailID, @EstateCodeL,   @VHWSCode,  @EstateCode,@VHDetailCostCode,    
       @Type,    @ModID,   @LedgerType,@LedgerNo, @AYear,      
       @AMonth,   @VHChargeValue,   @JDescp,    @CreatedBy, GETDATE(),  
       @ModifiedBy, GETDATE(),@VHUom,@VHQty,@STIssueDetailsID);    
     
  END  
  -- Vehicle.VHChargeDetail  Insert End   
    
  -- PROCESS END--   
   
   FETCH NEXT  
   FROM @getSTIssueDetailsID   
   INTO @STIssueDetailsID,  
   @STOCKID,  
   @SIVPrice,  
   @DescpSIVStock,  
   @DescpStockIssue,  
   @STDPrice,  
   @VariancePrice,  
   @StockCOAID,  
   @VarianceCOAID,  
   @COAID,  
   @DivID,  
   @YOPID,  
   @BlockID,  
   @VHID,  
   @VHDetailCostCodeID,  
   @T0,  
   @T1,  
   @T2,  
   @T3,  
   @T4,  
   @StationID,  
   @SIVCATT0,  
   @SIVCATT1,  
   @SIVCATT2,  
   @SIVCATT3,  
   @SIVCATT4  
  END  
   CLOSE @getSTIssueDetailsID  
   DEALLOCATE @getSTIssueDetailsID  
   
 --------NESTED CURSER FOR JOURNAL DETAL INSERT end----------------------------------------  
   
 --------Create Ledger for all SIV of the month end----------------------------------------  
   
 --------LEDGER ALL MODULE BATCH AMOUNT UPDATE  start----------------------------------------  
   
 SELECT @BatchAmount=ABS(SUM(VALUE))   
 FROM Accounts.JournalDetail   
 WHERE LedgerID=@LedgerID AND DC='D' AND EstateID=@EstateID  
   
 UPDATE Accounts.LedgerAllModule   
 SET BatchAmount=@BatchAmount ,  
 ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()  
 WHERE LedgerID=@LedgerID  AND EstateID=@EstateID  
   
 --------LEDGER ALL MODULE BATCH AMOUNT UPDATE  end----------------------------------------  
END  
 --------------------------------------  
 FETCH NEXT  
 FROM @getSTIssueID INTO @STIssueID,@LedgerDate,@LedgerDescp  
   
 END  
 CLOSE @getSTIssueID  
 DEALLOCATE @getSTIssueID  
   
 -----------------------------------------------------------------------------------------------------------------------------------------------  
    
 --============================================================================================================================================--  
 --@AvgPrice=(@BFValue+@IDNValue +@AdjValue +@ITNInValue -@ITNOutValue +@RGNValue)/(@BFQty +@IDNQty  +@AdjQty  +@ITNInQty -@ITNOutQty +@RGNQty)  
 ----DECLARE @StockID nvarchar(50)  
 ----DECLARE @getStockID CURSOR  
 ----SET @getStockID = CURSOR FOR  
 ----SELECT StockID  
 ----FROM Store.StockDetail WHERE ActiveMonthYearID=@ActiveMonthYearID  
 ----OPEN @getStockID  
 ----FETCH NEXT  
 ----FROM @getStockID INTO @StockID  
 ----WHILE @@FETCH_STATUS = 0  
 ----BEGIN  
 ----PRINT @StockID -- CALCULTAE AVG PRICE HERE  
 ----FETCH NEXT  
 ----FROM @getStockID INTO @StockID  
 ----END  
 ----CLOSE @getStockID  
 ----DEALLOCATE @getStockID  
--============================================================================================================================================--  
  
------------------------------------------------------ITN-OUT Start----------------------------------------------------------------------------  
  
    DECLARE @getSTInternalTransferOutID CURSOR  
 SET @getSTInternalTransferOutID= CURSOR FOR  
   
 SELECT STITNOUT.STInternalTransferOutID ,STITNOUT.ITNDate  ,STITNOUT.ItnOutNo  +' '+ISNULL(STITNOUT.Remarks,'')  FROM Store.STInternalTransferOut  STITNOUT  
 WHERE  STITNOUT.Status='APPROVED' AND STITNOUT.ActiveMonthYearID=@ActiveMonthYearID  AND STITNOUT.EstateID=@EstateID   
   
 OPEN @getSTInternalTransferOutID  
 FETCH NEXT  
   
 FROM @getSTInternalTransferOutID INTO @STInternalTransferOutID ,@LedgerDate,@LedgerDescp  
   
 WHILE @@FETCH_STATUS = 0  
 BEGIN  
        
    BEGIN   
  SET @count = 0  
  SET @ModID=2  
  SET @ModCode='ST'  
  SET @ModName='STORE'  
  SET @LedgerType='STORE-ITNOUT'  
  SET @BatchAmount=NULL  
  SET @CreatedOn=GETDATE()  
  SET @ModifiedOn =GETDATE()  
   
  ----------SELECT @count =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
  ----------FROM Accounts.LedgerAllModule  
          
  ----------SET @LedgerID = @EstateCode + 'R' + CONVERT(NVARCHAR,@count);  
    
 ------- for running number-----  
 SET @count = 0;  
 SELECT @count = (ISNULL(MAX(Id),0) + 1) FROM Accounts.LedgerAllModule;  
 SELECT @count =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
 FROM Accounts.LedgerAllModule  
 -------  
  
   
  SET @i= 2  
  SELECT @LedgerID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
  FROM   Accounts.LedgerAllModule   
  WHILE EXISTS  
  (SELECT id  
  FROM    Accounts.LedgerAllModule   
  WHERE   LedgerID  = @LedgerID  
  )  
  BEGIN  
   SELECT @LedgerID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
   FROM   Accounts.LedgerAllModule   
   SET @i = @i + 1  
  END  
  
  
  
  
    
  --SELECT @ModID=ModID  ,@ModCode = ModCode  FROM General.Module WHERE ModName=@ModName  
    
  --SET @LedgerNo=rtrim(@EstateCode)+rtrim(@MODCODE)+rtrim(@LedgerType)+CONVERT(NVARCHAR,@LoginMonth)+CONVERT(NVARCHAR,@LoginYear)+CONVERT(NVARCHAR,@count)  
  SET @LedgerNo=rtrim(@LedgerType)+CONVERT(NVARCHAR,@LoginMonth)+CONVERT(NVARCHAR,@LoginYear)+CONVERT(NVARCHAR,@count)  
   
  INSERT INTO Accounts.LedgerAllModule  
     (LedgerID,  EstateID,  Ayear,   Amonth ,  ModID,  LedgerDate,  LedgerType,  LedgerNo,    
     Descp,   BatchAmount, CreatedBy,  CreatedOn,  ModifiedBy, ModifiedOn)  
  VALUES  
     (@LedgerID,  @EstateID,  @AYear,   @AMonth ,  @ModID,  @LedgerDate, @LedgerType, @LedgerNo,  
     @LedgerDescp, @BatchAmount, @CreatedBy,  GETDATE(),  @ModifiedBy, GETDATE());  
    
 --------NESTED CURSER FOR JOURNAL DETAL INSERT start----------------------------------------  
     
  DECLARE @getSTInternalTransferOutDetailsID CURSOR  
  SET @getSTInternalTransferOutDetailsID = CURSOR FOR  
   
  SELECT STI.STInternalTransferOutDetailsID,  
   STD.STOCKID,  
  ISNULL(STI.TransferOutValue,0),   
  SIV.ItnOutNo+'-'+STM.STOCKcode+'-'+ STM.StockDesc,   --<ITN-OUT No.> -<” StockCode-Stock Description” as selected in the TransferNote-OUT>  
  SIV.ItnOutNo+'-'+GDS.DistributionDescp+'-'+@sLoginMonthYear,--<ITN-OUT No.> -<Receiver Location Name> <loginMonth&Year>  
  (ISNULL(STI.TransferOutQty,0))*(ISNULL(STD.StdPrice,0)), --standard price  
  ISNULL(STI.TransferOutValue,0)-(ISNULL(STD.StdPrice,0)*ISNULL(STI.TransferOutQty,0)), --variance price  
  ISNULL(CAT.COAID,'') ,--stock coa id  
  ISNULL(CAT.VarianceCOAID,''),--variance coa id  
  ISNULL(GDS.COAID,''),--SUPPLIER COAID  
  GDS.T0 as 'ITNOUTGDST0' ,GDS.T1 as 'ITNOUTGDST1',GDS.T2 as 'ITNOUTGDST2',GDS.T3 as 'ITNOUTGDST3',GDS.T4 as 'ITNOUTGDST4',  
  CAT.T0  ,CAT.T1 ,CAT.T2 ,CAT.T3 ,CAT.T4   
    
  FROM Store.STInternalTransferOutDetails STI   
  INNER JOIN Store.STInternalTransferOut SIV ON SIV.STInternalTransferOutID=STI.STInternalTransferOutID AND SIV.ActiveMonthYearID=STI.ActiveMonthYearID  
  INNER JOIN Store.StockDetail STD ON STD.StockID = STI.StockID AND STD.ActiveMonthYearID=STI.ActiveMonthYearID  
  INNER JOIN Store.STMaster STM ON STM.StockID = STI.StockID  
  INNER JOIN Store.STCategory CAT ON CAT.STCategoryID=STM.STCategoryID   
  INNER JOIN GENERAL.GeneralDistributionSetup GDS ON GDS.DistributionSetupID= SIV.ReceiverLocationID  
  WHERE STI.STInternalTransferOutID=@STInternalTransferOutID AND STI.EstateID=@EstateID AND STI.ActiveMonthYearID =@ActiveMonthYearID       
    
  OPEN @getSTInternalTransferOutDetailsID  
  
  FETCH NEXT  
  FROM @getSTInternalTransferOutDetailsID   
  INTO @STInternalTransferOutDetailsID,  
  @STOCKID,  
  @ITNOUTPRICE,  
  @DescpITNOUTStock,  
  @DescpReceiverLocation,  
  @STDPrice,  
  @VariancePrice,  
  @StockCOAID,  
  @VarianceCOAID,  
  @COAID,  
  @ITNOUTGDST0,  
  @ITNOUTGDST1,  
  @ITNOUTGDST2,  
  @ITNOUTGDST3,  
  @ITNOUTGDST4,  
  @ITNOUTCATT0 ,  
  @ITNOUTCATT1 ,  
  @ITNOUTCATT2 ,  
  @ITNOUTCATT3 ,  
  @ITNOUTCATT4   
   
  WHILE @@FETCH_STATUS = 0  
  BEGIN  
   -- PROCESS START--   
          
   --ITN-OUT JournalDetail INSERT START--  
        
   ----------SET @countJournal = 0;  
   ----------SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
   ----------FROM Accounts.JournalDetail  
   ----------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
     
     
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
  
   IF @STDPrice=0  
   BEGIN  
   --ITNOUTPRICE START--  
   INSERT INTO Accounts.JournalDetail  
     (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
     Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
     VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
     CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
   VALUES  
     (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @COAID,   'D',  
     @ITNOUTPRICE ,   @DescpReceiverLocation ,  'ITNOUTPRICE' , NULL,    NULL,    NULL,   NULL,  
     NULL,     @ITNOUTGDST0,  @ITNOUTGDST1, @ITNOUTGDST2,  @ITNOUTGDST3,  @ITNOUTGDST4, NULL,  
     @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
    
   ----------SET @countJournal = 0;  
   ----------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
   ----------       FROM Accounts.JournalDetail  
   ----------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
     
     
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
   INSERT INTO Accounts.JournalDetail  
     (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
     Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
     VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
     CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
   VALUES  
     (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @StockCOAID , 'C',  
     @ITNOUTPRICE,   @DescpITNOUTStock ,  'ITNOUTPRICE' , NULL,    NULL,   NULL,   NULL,  
     NULL,     @ITNOUTCATT0,  @ITNOUTCATT1, @ITNOUTCATT2,  @ITNOUTCATT3,  @ITNOUTCATT4, NULL,  
     @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END  
   --ITNOUTPRICE END--  
     
   --STDPRICE START--  
  
   IF @STDPrice>0 AND @StockCOAID<>''  
   BEGIN  
     
    ----------SET @countJournal = 0;  
    ----------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ----------       FROM Accounts.JournalDetail  
    ----------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @COAID ,  'D',  
      @STDPrice ,    @DescpReceiverLocation ,'ITNOUTSTDPRICE',NULL,   NULL,    NULL,   NULL,  
      NULL,     @ITNOUTGDST0,  @ITNOUTGDST1, @ITNOUTGDST2,  @ITNOUTGDST3,  @ITNOUTGDST4,  NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
  
    ----------SET @countJournal = 0;  
    ----------SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ----------       FROM Accounts.JournalDetail  
    ----------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
      
      
   SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
  
    INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @STOCKCOAID , 'C',  
      @STDPrice ,    @DescpITNOUTStock ,  'ITNOUTSTDPRICE',NULL,   NULL,    NULL,   NULL,  
      NULL,     @ITNOUTCATT0,  @ITNOUTCATT1, @ITNOUTCATT2,  @ITNOUTCATT3,  @ITNOUTCATT4, NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END     
   
   --STDPRICE END--  
     
   -- ITNOUTVARIANCEPRICE Price IF -ve START  
   IF @VariancePrice <0 AND @STDPrice>0 AND @VarianceCOAID <>''  
   BEGIN  
  
    ------------SET @countJournal = 0;  
  
    ------------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ------------       FROM Accounts.JournalDetail  
    ------------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
  
    SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @StockCOAID  , 'D',  
      ABS(@VariancePrice)  , @DescpITNOUTStock+'-Variance','ITNOUTVARIANCEPRICE',NULL,   NULL,    NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
  
    ------------SET @countJournal = 0;  
  
    ------------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ------------       FROM Accounts.JournalDetail  
    ------------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
  
    SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @VarianceCOAID, 'C',  
      ABS(@VariancePrice)  , @DescpReceiverLocation+'-Variance',   'ITNOUTVARIANCEPRICE',NULL,NULL,  NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END    
  -- ITNOUTVARIANCEPRICE Price IF -ve END  
   
   -- ITNOUTVARIANCEPRICE Price IF +ve START  
   IF @VariancePrice >0 AND @STDPrice>0 AND @VarianceCOAID <>''  
   BEGIN  
  
    ------------SET @countJournal = 0;  
  
    ------------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ------------       FROM Accounts.JournalDetail  
    ------------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
  
    SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
     
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @VarianceCOAID  ,'D',  
      ABS(@VariancePrice)  , @DescpReceiverLocation+'-Variance', 'ITNOUTVARIANCEPRICE',NULL,   NULL,    NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
  
    ------------SET @countJournal = 0;  
  
    ------------   SELECT @countJournal =CAST(( CASE WHEN (ISNULL(MAX(Id), -1) = -1 ) THEN 1 WHEN MAX(Id) >= 0 THEN MAX(Id) + 2 END ) AS VARCHAR)   
    ------------       FROM Accounts.JournalDetail  
    ------------SET @JournalDetID = @EstateCode + 'R' + CONVERT(NVARCHAR,@countJournal);  
  
    SET @i  = 2  
   SELECT @JournalDetID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)  
   FROM   Accounts.JournalDetail   
   WHILE EXISTS  
   (SELECT id  
   FROM    Accounts.JournalDetail   
   WHERE   JournalDetID  = @JournalDetID  
   )  
   BEGIN  
     SELECT @JournalDetID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)  
     FROM   Accounts.JournalDetail   
     SET @i = @i + 1  
   END  
     
   INSERT INTO Accounts.JournalDetail  
      (JournalDetID,   EstateID,   Ayear,   Amonth ,   LedgerID,   COAID,   DC,  
      Value,     Descp ,    Flag ,   DivID,    YOPID,    BlockID,  VHID,  
      VHDetailCostCodeID,  T0,     T1,    T2,     T3,     T4,    StationID,  
      CreatedBy,    CreatedOn,   ModifiedBy,  ModifiedOn)  
    VALUES  
      (@JournalDetID,   @EstateID,   @AYear,   @AMonth ,   @LedgerID,   @StockCOAID, 'C',  
      ABS(@VariancePrice)  , @DescpITNOUTStock+'-Variance','ITNOUTVARIANCEPRICE',NULL, NULL,    NULL,   NULL,  
      NULL,     NULL,    NULL,   NULL,    NULL,    NULL,   NULL,  
      @CreatedBy,    GETDATE(),   @ModifiedBy, GETDATE());  
   END    
  -- ITNOUTVARIANCEPRICE Price IF +ve END  
       
  --ITNOUT JournalDetail INSERT END--  
   
  -- PROCESS END--   
   
   FETCH NEXT  
   FROM @getSTInternalTransferOutDetailsID  
   INTO @STInternalTransferOutDetailsID,  
   @STOCKID,  
   @ITNOUTPRICE,  
   @DescpITNOUTStock,  
   @DescpReceiverLocation,  
   @STDPrice,  
   @VariancePrice,  
   @StockCOAID,  
   @VarianceCOAID,  
   @COAID,  
   @ITNOUTGDST0,  
   @ITNOUTGDST1,  
   @ITNOUTGDST2,  
   @ITNOUTGDST3,  
   @ITNOUTGDST4,  
   @ITNOUTCATT0 ,  
   @ITNOUTCATT1 ,  
   @ITNOUTCATT2 ,  
   @ITNOUTCATT3 ,  
   @ITNOUTCATT4   
     
  END  
   CLOSE @getSTInternalTransferOutDetailsID  
   DEALLOCATE @getSTInternalTransferOutDetailsID  
   
 --------NESTED CURSER FOR JOURNAL DETAL INSERT end----------------------------------------  
   
 --------Create Ledger for all ITNOUT of the month end----------------------------------------  
   
 --------LEDGER ALL MODULE BATCH AMOUNT UPDATE  start----------------------------------------  
   
 SELECT @BatchAmount=ABS(SUM(VALUE))   
 FROM Accounts.JournalDetail   
 WHERE LedgerID=@LedgerID AND DC='D' AND EstateID=@EstateID  
   
 UPDATE Accounts.LedgerAllModule   
 SET BatchAmount=@BatchAmount ,  
 ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()  
 WHERE LedgerID=@LedgerID  AND EstateID=@EstateID  
   
 --------LEDGER ALL MODULE BATCH AMOUNT UPDATE  end----------------------------------------  
END  
 --------------------------------------  
 FETCH NEXT  
 FROM @getSTInternalTransferOutID INTO @STInternalTransferOutID,@LedgerDate,@LedgerDescp  
   
 END  
 CLOSE @getSTInternalTransferOutID  
 DEALLOCATE @getSTInternalTransferOutID  
    
 ------------------------------------------------------ITN-OUT End----------------------------------------------------------------------------  
--13-12-2011 EXEC [General].[TaskMonitorUPDATE] @EstateID,@AYear,@AMonth,@ModID,'Store monthly processing','Y',@ModifiedBy,@ModifiedOn  
EXEC [General].[TaskMonitorUPDATE] @EstateID,@AYear,@AMonth,2,'Store monthly processing','Y',@ModifiedBy,@ModifiedOn  

  
END  
COMMIT --  Commit if all transactions are success!  
  
END TRY    
    
BEGIN CATCH      
  
IF @@TRANCOUNT > 0  -- Rollback all transactions , if there was an error  
   ROLLBACK   
        
 DECLARE @ErrorMessage NVARCHAR(4000);      
    DECLARE @ErrorSeverity INT;      
    DECLARE @ErrorState INT;      
      
    SELECT       
        @ErrorMessage = ERROR_MESSAGE(),      
        @ErrorSeverity = ERROR_SEVERITY(),      
        @ErrorState = ERROR_STATE();      
      
 RAISERROR (@ErrorMessage, -- Message text.      
               @ErrorSeverity, -- Severity.      
               @ErrorState -- State.      
               );      
  
END CATCH;
