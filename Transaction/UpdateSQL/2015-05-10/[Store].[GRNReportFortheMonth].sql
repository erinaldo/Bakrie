
GO

/****** Object:  StoredProcedure [Store].[GRNReportFortheMonth]    Script Date: 5/10/2015 4:59:07 PM ******/
DROP PROCEDURE [Store].[GRNReportFortheMonth]
GO

/****** Object:  StoredProcedure [Store].[GRNReportFortheMonth]    Script Date: 5/10/2015 4:59:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






--(Select GD.DistributionDescp from General.GeneralDistributionSetup GD 
--				inner join Store.STMillDelivery MILL1 on GD.DistributionSetupID =MILL1.SupplierID 
--				where MILL1.EstateID='M1' AND MILL1.ActiveMonthYearID ='01R72' AND MILL1.Status='APPROVED') 
--				end as 'Supplier Name'

-- ================================================= --
-- Created By : Arulprakasan  
-- Created date: 02-Feb-2010   
-- Modified By: ANNAL,Arul
-- Modified Date:09/08/2010 , 24/09/2010
-- Last Modified Date:
-- Module     : Store  
-- Screen(s)  : GRN REPORT
-- Description: To GENERATE GRN (SUMMARY PENERIMAAN) REPORT FOR THE Month (IDN,ITNIN & RGN)
-- ================================================= --
CREATE PROCEDURE [Store].[GRNReportFortheMonth]
	
	@EstateID nvarchar(50),
	@Amonth int,
	@AYear int 
  	
AS
	
	SET NOCOUNT ON;
	
	Declare    @ActiveMonthYearID nvarchar(50)
	
	set @ActiveMonthYearID = (Select ActiveMonthYearID  from General .ActiveMonthYear where AMonth=@Amonth and AYear =@AYear and ModID =2 and EstateID =@EstateID )
  	
	BEGIN	
			
		SELECT	CONVERT(VARCHAR(10),MILL.IDNDate,103)AS	Tanggal--,MILL.IDNNo  as  RefNo,
				,case when LPOorIPR='IPR' and MILL.IDNNo <>'' then 'IDN ' + MILL.IDNNo when MILL.LPOorIPR ='LPO' then LPO.LPONo end AS RefNo,
				MST.StockDesc as 'Nama Barang'
				,MST.StockCode,UOM.UOM AS Unit,ISNULL(DET.ReceivedQty,0)AS QTY
				,ISNULL(DET.ReceivedPrice,0) AS UnitPrice
				,(ISNULL(DET.ReceivedQty,0)*ISNULL(DET.ReceivedPrice,0)) AS TOTAL
				,CAT.STCategoryCode,CAT.STCategoryDescp,COA.COACode,COA.COADESCP,COA.ExpenditureAG,COA.OldCOACode
				,Case when MILL.LPOorIPR ='IPR' then GD.DistributionDescp when MILL.LPOorIPR ='LPO' then APS.SupplierName end as 'Supplier Name'
				,Case when MILL.LPOorIPR ='IPR' then COA1.COACode when MILL.LPOorIPR ='LPO' then COA2.COACode end as 'COA Supplier'
				
		FROM	Store.STMillDelivery MILL INNER JOIN Store.STEstMillDeliveryDet	DET ON DET.STEstMillDeliveryID=MILL.STEstMillDeliveryID
				LEFT JOIN Store.STLPO LPO on LPO.STLPOID =MILL.STLPOID
				LEFT JOIN General.APSupplierMaster APS on APS.APSupplierID =LPO.APSupplierID 
				LEFT JOIN Accounts.COA COA2 ON COA2.COAID=APS.COAID
				LEFT JOIN General.GeneralDistributionSetup GD on GD.DistributionSetupID =MILL.SupplierID
				LEFT JOIN Accounts.COA COA1 ON COA1.COAID=GD.COAID
				INNER JOIN Store.STMaster MST ON MST.StockID=DET.StockID 
				INNER JOIN Store.StockDetail STD ON DET.StockID=STD.StockID and STD.ActiveMonthYearID=MILL.ActiveMonthYearID 
				INNER JOIN Store.STCategory CAT ON CAT.STCategoryID=MST.STCategoryID
				INNER JOIN Accounts.COA COA ON COA.COAID=CAT.COAID 
				INNER JOIN General.UOM UOM ON UOM.UOMID=MST.UOMID 
		WHERE	MILL.EstateID=@EstateID AND MILL.ActiveMonthYearID =@ActiveMonthYearID AND MILL.Status='APPROVED'
		
		Union all
				
		SELECT	CONVERT(VARCHAR(10),TIN.ITNDate,103)AS	Tanggal,TIN.ItnInNo  AS RefNo,MST.StockDesc  as 'Nama Barang'
				,MST.StockCode,UOM.UOM AS Unit	,ISNULL(DET.TransferInQty,0)AS QTY
				,ISNULL(DET.UnitPrice,0) AS UnitPrice
				,(ISNULL(DET.TransferInQty,0)*ISNULL(DET.UnitPrice,0)) AS TOTAL
				,CAT.STCategoryCode,CAT.STCategoryDescp,COA.COACode,COA.COADESCP,COA.ExpenditureAG,COA.OldCOACode
				,GD.DistributionDescp as 'Supplier Name' ,COA1.COACode as 'COA Supplier'
		FROM	Store.STInternalTransferIn TIN INNER JOIN Store.STInternalTransferInDetails DET ON DET.STInternalTransferInID=TIN.STInternalTransferInID
				INNER JOIN Store.STMaster MST ON MST.StockID=DET.StockID 
				INNER JOIN Store.StockDetail STD ON DET.StockID=STD.StockID and STD.ActiveMonthYearID=TIN.ActiveMonthYearID 
				INNER JOIN Store.STCategory CAT ON CAT.STCategoryID=MST.STCategoryID
				INNER JOIN Accounts.COA COA ON COA.COAID=CAT.COAID 
				INNER JOIN General.UOM UOM ON UOM.UOMID=MST.UOMID 
				INNER JOIN General.GeneralDistributionSetup GD on GD.DistributionSetupID = TIN.SendersLocationID 
				LEFT JOIN Accounts.COA COA1 ON COA1.COAID=GD.COAID -- 5/10/2015
		WHERE	TIN.EstateID=@EstateID  AND TIN.ActiveMonthYearID =@ActiveMonthYearID AND TIN.Status='APPROVED'
		
		--
		Union all
		
		SELECT	CONVERT(VARCHAR(10),RGN.RGNDate,103)AS	Tanggal,RGN.RGNNo  AS RefNo,MST.StockDesc  as 'Nama Barang'
				,MST.StockCode,UOM.UOM AS Unit	,ISNULL(DET.ReturnQty,0)AS QTY
				,ISNULL(STD.AvgPrice,0) AS UnitPrice
				,(ISNULL(DET.ReturnQty,0)*ISNULL(STD.AvgPrice,0)) AS TOTAL
				,CAT.STCategoryCode,CAT.STCategoryDescp,COA.COACode,COA.COADESCP,COA.ExpenditureAG,COA.OldCOACode 
				,'' as 'Supplier Name' ,'' as 'COA Supplier'
		FROM	Store.STReturnGoodsNote RGN INNER JOIN Store.STReturnGoodsDetails  DET ON DET.STReturnGoodsNoteID=RGN.STReturnGoodsNoteID
				INNER JOIN Store.STMaster MST ON MST.StockID=DET.StockID 
				INNER JOIN Store.StockDetail STD ON DET.StockID=STD.StockID and STD.ActiveMonthYearID=RGN.ActiveMonthYearID 
				INNER JOIN Store.STCategory CAT ON CAT.STCategoryID=MST.STCategoryID
				INNER JOIN Accounts.COA COA ON COA.COAID=CAT.COAID 
				INNER JOIN General.UOM UOM ON UOM.UOMID=MST.UOMID 
				
		WHERE	RGN.EstateID=@EstateID  AND RGN.ActiveMonthYearID =@ActiveMonthYearID AND RGN.Status='APPROVED'
		
		-- 
		
		ORDER BY Tanggal 	
		
	
  END
















GO


