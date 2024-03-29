
/****** Object:  StoredProcedure [Accounts].[PenerimaanCashReceiptReport]    Script Date: 21/9/2015 11:28:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








--======================================================          
-- Created By : Kumaravel        
-- Created date:  may 31 2010   
-- Modified By: Kumaravel
-- Last Modified Date: Aug 7  2010
-- Module     : Accounts    
-- Screen(s)/Reports  : PenerimanCashREceipt
-- Description: To Generate Peneriman Cash REceipt Reports         
--======================================================  
ALTER PROCEDURE [Accounts].[PenerimaanCashReceiptReport]
	@ReceiptNo nvarchar(50),
	@EstateID nvarchar(50),
    @ActiveMonthYearID nvarchar(50)
    
    
	
AS
BEGIN
	
SELECT DISTINCT  
		CONVERT(VARCHAR(10),A_PCR.ReceiptDate, 103) AS  ReceiptDate
		,A_PCR.ReceiptNo
		,A_PCR.ReceiptDescp
		,CONVERT(VARCHAR(10),A_PCR.CashReconcilationDate, 103) AS  CashReconcilationDate
		,A_PCR.Amount
		,A_PCR .ReceivedFrom
		,A_COA .COACode as PettyCashAccountCode
		,A_COA .OldCOACode as PettyCashOldaccountCode
		,A_COASam .COACode as SamarindaAccountCode	
		,A_COASam .OldCOACode as SamarindaOldCOACode
		,ISNULL(G_T0.TValue,'') as T0,
		 ISNULL(G_T1.TValue,'')as T1,
		 ISNULL(G_T2.TValue,'') T2,
		 ISNULL(G_T3.TValue,'') T3,
		 ISNULL(G_T4.TValue,'') T4	
		
		
FROM	Accounts .PettyCashReceipt  A_PCR
INNER JOIN  General.GeneralDistributionSetup G_GDS ON G_GDS .EstateID = A_PCR .EstateID
INNER JOIN Accounts .COA A_COA ON A_COA .COAID = G_GDS .COAID  
INNER JOIN  General.GeneralDistributionSetup G_GDSSam ON G_GDSSam .EstateID = A_PCR .EstateID
INNER JOIN Accounts .COA A_COASam ON A_COASam .COAID = G_GDSSam .COAID  
LEFT JOIN General.TAnalysis G_T0 ON G_GDSSam.T0=G_T0.TAnalysisID
LEFT JOIN General.TAnalysis G_T1 ON G_GDSSam.T1=G_T1.TAnalysisID
LEFT JOIN General.TAnalysis G_T2 ON G_GDSSam.T2=G_T2.TAnalysisID
LEFT JOIN General.TAnalysis G_T3 ON G_GDSSam.T3=G_T3.TAnalysisID
LEFT JOIN General.TAnalysis G_T4 ON G_GDSSam.T4=G_T4.TAnalysisID
WHERE	 G_GDS .DistributionDescp ='Petty Cash'
AND G_GDSSam.DistributionDescp ='Due To HO Kisaran'	
AND A_PCR .ReceiptNo  = @ReceiptNo 
AND A_PCR.EstateID =@EstateID 
and A_PCR.ActiveMonthYearID =@ActiveMonthYearID


END
	 
	




   










