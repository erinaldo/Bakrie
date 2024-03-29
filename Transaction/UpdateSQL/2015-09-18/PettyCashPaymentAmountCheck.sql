
/****** Object:  StoredProcedure [Accounts].[PettyCashPaymentAmountCheck]    Script Date: 21/9/2015 10:23:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO












--======================================================          
-- Created By : Kumaravel        
-- Created date:  Apr 20 2010       
-- Modified By: Kumaravel     
-- Last Modified Date: nov 01 2010             
-- Module     : Accounts     
-- Screen(s)  : PCP Approval     
-- Description: To Calculate Approval amount        
--======================================================  


ALTER PROCEDURE [Accounts].[PettyCashPaymentAmountCheck]


    @EstateID nvarchar(50),
   	@ActiveMonthYearID nvarchar(50)   	
	

AS
	
	SET NOCOUNT ON;
			
			Declare @AvailableAmount as numeric(18,0)
			Declare @PettyCashReceiptAmount as numeric(18,0)
			Declare @PettyCashApprovedPaymentAmount as numeric(18,0),@PettyCashApprovedPaymentAmountCredit as numeric(18,0)
			Declare @FloatAmount as numeric(18,0)
			Declare @PettyCashFloatAmount as numeric(18,0)
			
			SET @AvailableAmount =0
			SET @PettyCashReceiptAmount =0
			SET @PettyCashApprovedPaymentAmount =0
			SET @PettyCashApprovedPaymentAmountCredit =0
			SET @FloatAmount =0
			
			Select Top 1
			@AvailableAmount=ISNULL(PettyCashCF,0)
			from Accounts .PettyCashCF 
			where EstateID =@EstateID and AYear =(Select AYear from General .ActiveMonthYear where ActiveMonthYearID =@ActiveMonthYearID )
			AND AMonth =(Select AMonth  from General .ActiveMonthYear where ActiveMonthYearID =@ActiveMonthYearID )
			order by Id desc
			
			if @AvailableAmount =0 
			BEGIN
			Select top 1
			@AvailableAmount=ISNULL(PettyCashCF,0)
			from Accounts .PettyCashCF 
			where EstateID =@EstateID 
			order by Id desc
			END
			
			
			Select 
			@PettyCashFloatAmount= PettyCashFloatAmount 
			from General .GeneralConfiguration 
			where EstateID = @EstateID 
			
			Select 
			@PettyCashReceiptAmount = ISNULL(Sum(Amount ),0)
			from Accounts .PettyCashReceipt
			Where EstateID = @EstateID 
			AND ActiveMonthYearID = @ActiveMonthYearID 
			AND Approved ='Y' 
			AND CashReconDate  IS NULL

			Select 
			@PettyCashApprovedPaymentAmount =ISNULL(SUM(Amount ),0)
			from Accounts .PettyCashPayment
			Where EstateID = @EstateID 
			AND ActiveMonthYearID =@ActiveMonthYearID 
			AND Approved= 'Y'
			and TransactionType ='Debit'
			AND CashReconDate  IS NULL
			
			Select 
			@PettyCashApprovedPaymentAmountCredit =ISNULL(SUM(Amount ),0)
			from Accounts .PettyCashPayment
			Where EstateID = @EstateID 
			AND ActiveMonthYearID =@ActiveMonthYearID 
			AND Approved= 'Y'
			and TransactionType ='Credit'
			AND CashReconDate  IS NULL
			
			 
			 Set @FloatAmount = (@AvailableAmount + @PettyCashFloatAmount + @PettyCashReceiptAmount+@PettyCashApprovedPaymentAmountCredit) - @PettyCashApprovedPaymentAmount
			 Select @FloatAmount as CalculatedPCPAmount

Declare @CreditNotApprovedAmount as numeric(18,0),
@DebitNotApprovedAmount as numeric(18,0)
			
			Select 
			@DebitNotApprovedAmount  =ISNULL(SUM(Amount ),0) --as NotApprovedAmount 
			from Accounts .PettyCashPayment
			Where EstateID = @EstateID 
			AND ActiveMonthYearID =@ActiveMonthYearID 
			AND Approved= 'N'
			AND TransactionType ='Debit'
			AND RejectedReason IS NULL
			
			Select 
			@CreditNotApprovedAmount=ISNULL(SUM(Amount ),0) 
			from Accounts .PettyCashPayment
			Where EstateID = @EstateID 
			AND ActiveMonthYearID =@ActiveMonthYearID 
			AND Approved= 'N'
			AND TransactionType ='Credit'
			AND RejectedReason IS NULL
			
			
Select (@DebitNotApprovedAmount -@CreditNotApprovedAmount)as NotApprovedAmount 








