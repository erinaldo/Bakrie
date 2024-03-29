
/****** Object:  StoredProcedure [Checkroll].[SalaryProcessing]    Script Date: 14/10/2015 10:14:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Created by : Nelson
--Date : July 2010
--Description: For Monthly Processing of Checkroll
--
-- AFTER MTH END CLOSING SCRIPT

ALTER Procedure [Checkroll].[SalaryProcessing](@NPWP nvarchar(50),
@ActiveMonth int,
@year int,
@EmpCode nvarchar(50),
@EstateID nvarchar(50),

	@DedAdvance NUMERIC(18, 2),
	@DedOther NUMERIC(18, 2),
	@TotalBruto NUMERIC(18, 2),
 
   @THR NUMERIC(18, 2),
   @DedTaxCompany NUMERIC(18, 2),
   @ActiveMonthYearID nvarchar(50),
   @User nvarchar(50),
   @EmpID nvarchar(50),
   
   @ActiveMonthYearID1 NVARCHAR (50),
   @ActiveMonthYearID2 NVARCHAR (50),
   @ActiveMonthYearID3 NVARCHAR (50),
   @ActiveMonthYearID4 NVARCHAR (50),
   @ActiveMonthYearID5 NVARCHAR (50),
   @ActiveMonthYearID6 NVARCHAR (50),
   @ActiveMonthYearID7 NVARCHAR (50),
   @ActiveMonthYearID8 NVARCHAR (50),
   @ActiveMonthYearID9 NVARCHAR (50),
   @ActiveMonthYearID10 NVARCHAR (50),
   @ActiveMonthYearID11 NVARCHAR (50),
   @ActiveMonthYearID12 NVARCHAR (50),
     
  @PPH_21_IRRegular1R1 NUMERIC(18, 2),
  @PPH_21_IRRegular2R1 NUMERIC(18, 2),
  @PPH_21_IRRegular3R1 NUMERIC(18, 2),
  @PPH_21_IRRegular4R1 NUMERIC(18, 2),
  @PPH_21_IRRegular5R1 NUMERIC(18, 2),
  @PPH_21_IRRegular6R1 NUMERIC(18, 2),
  @PPH_21_IRRegular7R1 NUMERIC(18, 2),
  @PPH_21_IRRegular8R1 NUMERIC(18, 2),
  @PPH_21_IRRegular9R1 NUMERIC(18, 2),
  @PPH_21_IRRegular10R1 NUMERIC(18, 2),
  @PPH_21_IRRegular11R1 NUMERIC(18, 2),
  @PPH_21_IRRegular12R1 NUMERIC(18, 2),
     
      @PPH_21_IRRegular1R2 NUMERIC(18, 2),
      @PPH_21_IRRegular2R2 NUMERIC(18, 2),
      @PPH_21_IRRegular3R2 NUMERIC(18, 2),
      @PPH_21_IRRegular4R2 NUMERIC(18, 2),
      @PPH_21_IRRegular5R2 NUMERIC(18, 2),
      @PPH_21_IRRegular6R2 NUMERIC(18, 2),
      @PPH_21_IRRegular7R2 NUMERIC(18, 2),
      @PPH_21_IRRegular8R2 NUMERIC(18, 2),
      @PPH_21_IRRegular9R2 NUMERIC(18, 2),
      @PPH_21_IRRegular10R2 NUMERIC(18, 2),
      @PPH_21_IRRegular11R2 NUMERIC(18, 2),
      @PPH_21_IRRegular12R2 NUMERIC(18, 2),

	  @PPH_21_IRRegular1R3 NUMERIC(18, 2),
      @PPH_21_IRRegular2R3 NUMERIC(18, 2),
      @PPH_21_IRRegular3R3 NUMERIC(18, 2),
      @PPH_21_IRRegular4R3 NUMERIC(18, 2),
      @PPH_21_IRRegular5R3 NUMERIC(18, 2),
      @PPH_21_IRRegular6R3 NUMERIC(18, 2),
      @PPH_21_IRRegular7R3 NUMERIC(18, 2),
      @PPH_21_IRRegular8R3 NUMERIC(18, 2),
      @PPH_21_IRRegular9R3 NUMERIC(18, 2),
      @PPH_21_IRRegular10R3 NUMERIC(18, 2),
      @PPH_21_IRRegular11R3 NUMERIC(18, 2),
      @PPH_21_IRRegular12R3 NUMERIC(18, 2),

      @PPH_21_IRRegular1R4 NUMERIC(18, 2),
      @PPH_21_IRRegular2R4 NUMERIC(18, 2),
      @PPH_21_IRRegular3R4 NUMERIC(18, 2),
      @PPH_21_IRRegular4R4 NUMERIC(18, 2),
      @PPH_21_IRRegular5R4 NUMERIC(18, 2),
      @PPH_21_IRRegular6R4 NUMERIC(18, 2),
      @PPH_21_IRRegular7R4 NUMERIC(18, 2),
      @PPH_21_IRRegular8R4 NUMERIC(18, 2),
      @PPH_21_IRRegular9R4 NUMERIC(18, 2),
      @PPH_21_IRRegular10R4 NUMERIC(18, 2),
      @PPH_21_IRRegular11R4 NUMERIC(18, 2),
      @PPH_21_IRRegular12R4 NUMERIC(18, 2),

      @PPH_21_IRRegular1R5 NUMERIC(18, 2),
      @PPH_21_IRRegular2R5 NUMERIC(18, 2),
      @PPH_21_IRRegular3R5 NUMERIC(18, 2),
      @PPH_21_IRRegular4R5 NUMERIC(18, 2),
      @PPH_21_IRRegular5R5 NUMERIC(18, 2),
      @PPH_21_IRRegular6R5 NUMERIC(18, 2),
      @PPH_21_IRRegular7R5 NUMERIC(18, 2),
      @PPH_21_IRRegular8R5 NUMERIC(18, 2),
      @PPH_21_IRRegular9R5 NUMERIC(18, 2),
      @PPH_21_IRRegular10R5 NUMERIC(18, 2),
      @PPH_21_IRRegular11R5 NUMERIC(18, 2),
      @PPH_21_IRRegular12R5 NUMERIC(18, 2),
      
      @PPH_21_Regular1R1 NUMERIC(18, 2),
      @PPH_21_Regular2R1 NUMERIC(18, 2),
      @PPH_21_Regular3R1 NUMERIC(18, 2),
      @PPH_21_Regular4R1 NUMERIC(18, 2),
      @PPH_21_Regular5R1 NUMERIC(18, 2),
      @PPH_21_Regular6R1 NUMERIC(18, 2),
      @PPH_21_Regular7R1 NUMERIC(18, 2),
      @PPH_21_Regular8R1 NUMERIC(18, 2),
      @PPH_21_Regular9R1 NUMERIC(18, 2),
      @PPH_21_Regular10R1 NUMERIC(18, 2),
      @PPH_21_Regular11R1 NUMERIC(18, 2),
      @PPH_21_Regular12R1 NUMERIC(18, 2),
     
      @PPH_21_Regular1R2 NUMERIC(18, 2),
      @PPH_21_Regular2R2 NUMERIC(18, 2),
      @PPH_21_Regular3R2 NUMERIC(18, 2),
      @PPH_21_Regular4R2 NUMERIC(18, 2),
      @PPH_21_Regular5R2 NUMERIC(18, 2),
      @PPH_21_Regular6R2 NUMERIC(18, 2),
      @PPH_21_Regular7R2 NUMERIC(18, 2),
      @PPH_21_Regular8R2 NUMERIC(18, 2),
      @PPH_21_Regular9R2 NUMERIC(18, 2),
      @PPH_21_Regular10R2 NUMERIC(18, 2),
      @PPH_21_Regular11R2 NUMERIC(18, 2),
      @PPH_21_Regular12R2 NUMERIC(18, 2),

      @PPH_21_Regular1R3 NUMERIC(18, 2),
      @PPH_21_Regular2R3 NUMERIC(18, 2),
      @PPH_21_Regular3R3 NUMERIC(18, 2),
      @PPH_21_Regular4R3 NUMERIC(18, 2),
      @PPH_21_Regular5R3 NUMERIC(18, 2),
      @PPH_21_Regular6R3 NUMERIC(18, 2),
      @PPH_21_Regular7R3 NUMERIC(18, 2),
      @PPH_21_Regular8R3 NUMERIC(18, 2),
      @PPH_21_Regular9R3 NUMERIC(18, 2),
      @PPH_21_Regular10R3 NUMERIC(18, 2),
      @PPH_21_Regular11R3 NUMERIC(18, 2),
      @PPH_21_Regular12R3 NUMERIC(18, 2),

	  @PPH_21_Regular1R4 NUMERIC(18, 2),
      @PPH_21_Regular2R4 NUMERIC(18, 2),
      @PPH_21_Regular3R4 NUMERIC(18, 2),
      @PPH_21_Regular4R4 NUMERIC(18, 2),
      @PPH_21_Regular5R4 NUMERIC(18, 2),
      @PPH_21_Regular6R4 NUMERIC(18, 2),
      @PPH_21_Regular7R4 NUMERIC(18, 2),
      @PPH_21_Regular8R4 NUMERIC(18, 2),
      @PPH_21_Regular9R4 NUMERIC(18, 2),
      @PPH_21_Regular10R4 NUMERIC(18, 2),
      @PPH_21_Regular11R4 NUMERIC(18, 2),
      @PPH_21_Regular12R4 NUMERIC(18, 2),

      @PPH_21_Regular1R5 NUMERIC(18, 2),
      @PPH_21_Regular2R5 NUMERIC(18, 2),
      @PPH_21_Regular3R5 NUMERIC(18, 2),
      @PPH_21_Regular4R5 NUMERIC(18, 2),
      @PPH_21_Regular5R5 NUMERIC(18, 2),
      @PPH_21_Regular6R5 NUMERIC(18, 2),
      @PPH_21_Regular7R5 NUMERIC(18, 2),
      @PPH_21_Regular8R5 NUMERIC(18, 2),
      @PPH_21_Regular9R5 NUMERIC(18, 2),
      @PPH_21_Regular10R5 NUMERIC(18, 2),
      @PPH_21_Regular11R5 NUMERIC(18, 2),
      @PPH_21_Regular12R5 NUMERIC(18, 2),
      
	  @FunctionalAllowanceP NUMERIC(18, 0),
	  @MaxAllowance NUMERIC(18, 0),
	  @DedAstek NUMERIC(18, 2)
)
as
   
BEGIN    
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET nocount  ON;

			DECLARE @TotalDed NUMERIC(18, 2)
			DECLARE @TotalNett NUMERIC(18, 2)
			DECLARE @TotalRoundUP NUMERIC(18, 2)
	   
		   DECLARE @TaxImposedR1 NUMERIC(18, 2)
		   DECLARE @TaxImposedR2 NUMERIC(18, 2)
		   DECLARE @TaxImposedR3 NUMERIC(18, 2)
		   DECLARE @TaxImposedR4 NUMERIC(18, 2)
		   DECLARE @TaxImposedR5 NUMERIC(18, 2)
		   DECLARE @TaxImposedR6 NUMERIC(18, 2)
		   DECLARE @TaxImposedR7 NUMERIC(18, 2)
		   DECLARE @TaxImposedR8 NUMERIC(18, 2)
		   DECLARE @TaxImposedR9 NUMERIC(18, 2)
		   DECLARE @TaxImposedR10 NUMERIC(18, 2)
		   DECLARE @TaxImposedR11 NUMERIC(18, 2)
		   DECLARE @TaxImposedR12 NUMERIC(18, 2)
	       
		   DECLARE @TaxImposedIR1 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR2 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR3 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR4 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR5 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR6 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR7 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR8 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR9 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR10 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR11 NUMERIC(18, 2)
		   DECLARE @TaxImposedIR12 NUMERIC(18, 2)

		DECLARE @Sal1 NUMERIC(18, 0)
		DECLARE @Sal2 NUMERIC(18, 0)
		DECLARE @Sal3 NUMERIC(18, 0)
		DECLARE @Sal4 NUMERIC(18, 0)
		DECLARE @Sal5 NUMERIC(18, 0)
		DECLARE @Sal6 NUMERIC(18, 0)
		DECLARE @Sal7 NUMERIC(18, 0)
		DECLARE @Sal8 NUMERIC(18, 0)
		DECLARE @Sal9 NUMERIC(18, 0)
		DECLARE @Sal10 NUMERIC(18, 0)
		DECLARE @Sal11 NUMERIC(18, 0)
		DECLARE @Sal12 NUMERIC(18, 0)
	     
		 DECLARE @PPH_21_Diff1 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff2 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff3 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff4 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff5 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff6 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff7 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff8 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff9 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff10 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff11 NUMERIC(18, 2)
		 DECLARE @PPH_21_Diff12 NUMERIC(18, 2)
		 DECLARE   @DedTaxEmployee NUMERIC(18, 2)
	   
		DECLARE @Tax_calculated_month1 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month2 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month3 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month4 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month5 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month6 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month7 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month8 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month9 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month10 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month11 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month12 NUMERIC(18, 2)
		DECLARE @Tax_calculated_month NUMERIC(18, 2)
	       
	   DECLARE @Tax_Payable1 NUMERIC(18, 2)
	   DECLARE @Tax_Payable2 NUMERIC(18, 2)
	   DECLARE @Tax_Payable3 NUMERIC(18, 2)
	   DECLARE @Tax_Payable4 NUMERIC(18, 2)
	   DECLARE @Tax_Payable5 NUMERIC(18, 2)
	   DECLARE @Tax_Payable6 NUMERIC(18, 2)
	   DECLARE @Tax_Payable7 NUMERIC(18, 2)
	   DECLARE @Tax_Payable8 NUMERIC(18, 2)
	   DECLARE @Tax_Payable9 NUMERIC(18, 2)
	   DECLARE @Tax_Payable10 NUMERIC(18, 2)
	   DECLARE @Tax_Payable11 NUMERIC(18, 2)
	   DECLARE @Tax_Payable12 NUMERIC(18, 2)
	        
	-----PPH21(Diff)
	set @TaxImposedR1=0
	set @TaxImposedR2=0
	set @TaxImposedR3=0
	set @TaxImposedR4=0
	set @TaxImposedR5=0
	set @TaxImposedR6=0
	set @TaxImposedR7=0
	set @TaxImposedR8=0
	set @TaxImposedR9=0
	set @TaxImposedR10=0
	set @TaxImposedR11=0
	set @TaxImposedR12=0

	set @TaxImposedR1=@PPH_21_Regular1R1+@PPH_21_Regular1R2+@PPH_21_Regular1R3+@PPH_21_Regular1R4+@PPH_21_Regular1R5
	set @TaxImposedR2=@PPH_21_Regular2R1+@PPH_21_Regular2R2+@PPH_21_Regular2R3+@PPH_21_Regular2R4+@PPH_21_Regular2R5
	set @TaxImposedR3=@PPH_21_Regular3R1+@PPH_21_Regular3R2+@PPH_21_Regular3R3+@PPH_21_Regular3R4+@PPH_21_Regular3R5
	set @TaxImposedR4=@PPH_21_Regular4R1+@PPH_21_Regular4R2+@PPH_21_Regular4R3+@PPH_21_Regular4R4+@PPH_21_Regular4R5
	set @TaxImposedR5=@PPH_21_Regular5R1+@PPH_21_Regular5R2+@PPH_21_Regular5R3+@PPH_21_Regular5R4+@PPH_21_Regular5R5
	set @TaxImposedR6=@PPH_21_Regular6R1+@PPH_21_Regular6R2+@PPH_21_Regular6R3+@PPH_21_Regular6R4+@PPH_21_Regular6R5
	set @TaxImposedR7=@PPH_21_Regular7R1+@PPH_21_Regular7R2+@PPH_21_Regular7R3+@PPH_21_Regular7R4+@PPH_21_Regular7R5
	set @TaxImposedR8=@PPH_21_Regular8R1+@PPH_21_Regular8R2+@PPH_21_Regular8R3+@PPH_21_Regular8R4+@PPH_21_Regular8R5
	set @TaxImposedR9=@PPH_21_Regular9R1+@PPH_21_Regular9R2+@PPH_21_Regular9R3+@PPH_21_Regular9R4+@PPH_21_Regular9R5
	set @TaxImposedR10=@PPH_21_Regular10R1+@PPH_21_Regular10R2+@PPH_21_Regular10R3+@PPH_21_Regular10R4+@PPH_21_Regular10R5
	set @TaxImposedR11=@PPH_21_Regular11R1+@PPH_21_Regular11R2+@PPH_21_Regular11R3+@PPH_21_Regular11R4+@PPH_21_Regular11R5
	set @TaxImposedR12=@PPH_21_Regular12R1+@PPH_21_Regular12R2+@PPH_21_Regular12R3+@PPH_21_Regular12R4+@PPH_21_Regular12R5 

	set @TaxImposedIR1=0
	set @TaxImposedIR2=0
	set @TaxImposedIR3=0
	set @TaxImposedIR4=0
	set @TaxImposedIR5=0
	set @TaxImposedIR6=0
	set @TaxImposedIR7=0
	set @TaxImposedIR8=0
	set @TaxImposedIR9=0
	set @TaxImposedIR10=0
	set @TaxImposedIR11=0
	set @TaxImposedIR12=0
	
	-- @PPH_21_IRRegular1R1 - this value coming from the Called SP
	set @TaxImposedIR1=@PPH_21_IRRegular1R1+@PPH_21_IRRegular1R2+@PPH_21_IRRegular1R3+@PPH_21_IRRegular1R4+@PPH_21_IRRegular1R5
	set @TaxImposedIR2=@PPH_21_IRRegular2R1+@PPH_21_IRRegular2R2+@PPH_21_IRRegular2R3+@PPH_21_IRRegular2R4+@PPH_21_IRRegular2R5
	set @TaxImposedIR3=@PPH_21_IRRegular3R1+@PPH_21_IRRegular3R2+@PPH_21_IRRegular3R3+@PPH_21_IRRegular3R4+@PPH_21_IRRegular3R5
	set @TaxImposedIR4=@PPH_21_IRRegular4R1+@PPH_21_IRRegular4R2+@PPH_21_IRRegular4R3+@PPH_21_IRRegular4R4+@PPH_21_IRRegular4R5
	set @TaxImposedIR5=@PPH_21_IRRegular5R1+@PPH_21_IRRegular5R2+@PPH_21_IRRegular5R3+@PPH_21_IRRegular5R4+@PPH_21_IRRegular5R5
	set @TaxImposedIR6=@PPH_21_IRRegular6R1+@PPH_21_IRRegular6R2+@PPH_21_IRRegular6R3+@PPH_21_IRRegular6R4+@PPH_21_IRRegular6R5
	set @TaxImposedIR7=@PPH_21_IRRegular7R1+@PPH_21_IRRegular7R2+@PPH_21_IRRegular7R3+@PPH_21_IRRegular7R4+@PPH_21_IRRegular7R5
	set @TaxImposedIR8=@PPH_21_IRRegular8R1+@PPH_21_IRRegular8R2+@PPH_21_IRRegular8R3+@PPH_21_IRRegular8R4+@PPH_21_IRRegular8R5
	set @TaxImposedIR9=@PPH_21_IRRegular9R1+@PPH_21_IRRegular9R2+@PPH_21_IRRegular9R3+@PPH_21_IRRegular9R4+@PPH_21_IRRegular9R5
	set @TaxImposedIR10=@PPH_21_IRRegular10R1+@PPH_21_IRRegular10R2+@PPH_21_IRRegular10R3+@PPH_21_IRRegular10R4+@PPH_21_IRRegular10R5
	set @TaxImposedIR11=@PPH_21_IRRegular11R1+@PPH_21_IRRegular11R2+@PPH_21_IRRegular11R3+@PPH_21_IRRegular11R4+@PPH_21_IRRegular11R5
	set @TaxImposedIR12=@PPH_21_IRRegular12R1+@PPH_21_IRRegular12R2+@PPH_21_IRRegular12R3+@PPH_21_IRRegular12R4+@PPH_21_IRRegular12R5 


	set @PPH_21_Diff1=0
	set @PPH_21_Diff2=0
	set @PPH_21_Diff3=0
	set @PPH_21_Diff4=0
	set @PPH_21_Diff5=0
	set @PPH_21_Diff6=0
	set @PPH_21_Diff7=0
	set @PPH_21_Diff8=0
	set @PPH_21_Diff9=0
	set @PPH_21_Diff10=0
	set @PPH_21_Diff11=0
	set @PPH_21_Diff12=0

	set @PPH_21_Diff1=@TaxImposedIR1-@TaxImposedR1
	set @PPH_21_Diff2=@TaxImposedIR2-@TaxImposedR2
	set @PPH_21_Diff3=@TaxImposedIR3-@TaxImposedR3
	set @PPH_21_Diff4=@TaxImposedIR4-@TaxImposedR4
	set @PPH_21_Diff5=@TaxImposedIR5-@TaxImposedR5
	set @PPH_21_Diff6=@TaxImposedIR6-@TaxImposedR6
	set @PPH_21_Diff7=@TaxImposedIR7-@TaxImposedR7
	set @PPH_21_Diff8=@TaxImposedIR8-@TaxImposedR8
	set @PPH_21_Diff9=@TaxImposedIR9-@TaxImposedR9
	set @PPH_21_Diff10=@TaxImposedIR10-@TaxImposedR10
	set @PPH_21_Diff11=@TaxImposedIR11-@TaxImposedR11
	set @PPH_21_Diff12=@TaxImposedIR12-@TaxImposedR12
	--End

	set @Sal1=0
	set @Sal2=0
	set @Sal3=0
	set @Sal4=0
	set @Sal5=0
	set @Sal6=0
	set @Sal7=0
	set @Sal8=0
	set @Sal9=0
	set @Sal10=0
	set @Sal11=0
	set @Sal12=0


	-- get resigned month
	declare @ResignedMonth int
	declare @StatusDate as datetime

	select @StatusDate = StatusDate from Checkroll.CREmployee where EmpID = @EmpID
	if( not @StatusDate is null) and (not @StatusDate = '')
		Begin
			set @ResignedMonth= datepart(mm,@StatusDate)
		End
	Else
		Begin
			set @ResignedMonth=0
		End
	-- end of getting resigned month details


	--Tax Calculated month

	if exists
	( 
	select mnth,mnthSalary,MnthTax,YEAR from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode 

	)
	Begin
		select  @Sal1=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=01 and ISNULL(mnthSalary,0)<>0
		select  @Sal2=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=02 and ISNULL(mnthSalary,0)<>0
		select  @Sal3=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=03 and ISNULL(mnthSalary,0)<>0
		select  @Sal4=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=04 and ISNULL(mnthSalary,0)<>0
		select  @Sal5=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=05 and ISNULL(mnthSalary,0)<>0
		select  @Sal6=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=06 and ISNULL(mnthSalary,0)<>0
		select  @Sal7=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=07 and ISNULL(mnthSalary,0)<>0
		select  @Sal8=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=08 and ISNULL(mnthSalary,0)<>0
		select  @Sal9=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=09 and ISNULL(mnthSalary,0)<>0
		select  @Sal10=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=10 and ISNULL(mnthSalary,0)<>0
		select  @Sal11=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=11 and ISNULL(mnthSalary,0)<>0
		select  @Sal12=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=12 and ISNULL(mnthSalary,0)<>0
	End

	if(@Sal1=0)
	Begin
	select  @Sal1=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID1
	End
	if(@Sal2=0)
	Begin
	select  @Sal2=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID2
	End
	if(@Sal3=0)
	Begin
	select  @Sal3=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID3
	End
	if(@Sal4=0)
	Begin
	select  @Sal4=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID4
	End
	if(@Sal5=0)
	Begin
	select  @Sal5=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID5
	End
	if(@Sal6=0)
	Begin
	select  @Sal6=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID6
	End
	if(@Sal7=0)
	Begin
	select  @Sal7=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID7
	End
	if(@Sal8=0)
	Begin
	select  @Sal8=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID8
	End
	if(@Sal9=0)
	Begin
	select  @Sal9=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID9
	End
	if(@Sal10=0)
	Begin
	select  @Sal10=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID10
	End
	if(@Sal11=0)
	Begin
	select  @Sal11=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID11
	End
	if(@Sal12=0)
	Begin
	select  @Sal12=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID12
	End


	--End
	set @Tax_calculated_month1=0
	set @Tax_calculated_month2=0
	set @Tax_calculated_month3=0
	set @Tax_calculated_month4=0
	set @Tax_calculated_month5=0
	set @Tax_calculated_month6=0
	set @Tax_calculated_month7=0
	set @Tax_calculated_month8=0
	set @Tax_calculated_month9=0
	set @Tax_calculated_month10=0
	set @Tax_calculated_month11=0
	set @Tax_calculated_month12=0
	

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

-- Palani
-- For updating newly added 2 fields (NMonth & NMonthYear) in Checkroll.TaxProcessingDet
Declare @AMonth smallint
Declare @AYear int
select @AMonth = AMonth, @AYear= AYear from General.ActiveMonthYear where ActiveMonthYearID = @ActiveMonthYearID

Declare @DOJ date 
Declare @NMonth tinyint
Declare @NMonthYear tinyint  

Declare @DOJFiscalMonth tinyint 
Declare @DOJFiscalYear int

select @DOJ = doj from Checkroll.CREmployee where EmpID = @EmpID
print @DOJ

-- Because records available in Fiscal Year table from 2010 Year onwards only
if year(@DOJ) >= 2010
begin
	select @DOJFiscalMonth = Period, @DOJFiscalYear = FYear from General.FiscalYear FY
	inner join Checkroll.CREmployee EMP on (EMP.DOJ between FY.FromDT and FY.ToDT)
	where EmpID = @EmpID
	
print @DOJFiscalMonth
print @DOJFiscalYear
end

-- Year < 2010
if isnull(@DOJFiscalYear,0) = 0
	begin
		select @NMonth = @AMonth
		select @NMonthYear = 12
	end
else
	begin 
		if @DOJFiscalYear < @AYear 
			Begin
				select @NMonth = @AMonth
				select @NMonthYear = 12
			End
		else if @DOJFiscalYear =@AYear  
			Begin 
				select @NMonth = (@AMonth - @DOJFiscalMonth + 1) 
				select @NMonthYear = (13 - @DOJFiscalMonth) 
			END
		else
			Begin 
				select @NMonth = 0
				select @NMonthYear = 0
			END
	end
	


	if(@Sal1>0)
	Begin
		if(@ResignedMonth = 1)
			set @Tax_calculated_month1 = @TaxImposedR1 + @PPH_21_Diff1
		else
			set @Tax_calculated_month1=(@TaxImposedR1*@NMonth/(@NMonthYear))+@PPH_21_Diff1
	End

	if(@Sal2>0)
		Begin
			if(@ResignedMonth = 2)
				set @Tax_calculated_month2 = @TaxImposedR2 + @PPH_21_Diff2
			else
				set @Tax_calculated_month2=(@TaxImposedR2*@NMonth/(@NMonthYear))+@PPH_21_Diff2
		End
	else
		Begin
			set @Tax_calculated_month2=(@TaxImposedR2*1/(12-1))+@PPH_21_Diff2
		End

	if(@Sal3>0)
		Begin
			if(@ResignedMonth = 3)
				set @Tax_calculated_month3 = @TaxImposedR3 + @PPH_21_Diff3
			else
				set @Tax_calculated_month3=(@TaxImposedR3*@NMonth/(@NMonthYear))+@PPH_21_Diff3
		End
	else
		Begin
			set @Tax_calculated_month3=(@TaxImposedR3*1/(12-2))+@PPH_21_Diff3
		End

	if(@Sal4>0)
		Begin
			if(@ResignedMonth = 4)
				set @Tax_calculated_month4 = @TaxImposedR4 + @PPH_21_Diff4
			else
				set @Tax_calculated_month4=(@TaxImposedR4*@NMonth/(@NMonthYear))+@PPH_21_Diff4
		End
	else
		Begin
			set @Tax_calculated_month4=(@TaxImposedR4*1/(12-3))+@PPH_21_Diff4
		End

	if(@Sal5>0)
		Begin
			if(@ResignedMonth = 5)
				set @Tax_calculated_month5 = @TaxImposedR5 + @PPH_21_Diff5
			else
				set @Tax_calculated_month5=(@TaxImposedR5*@NMonth/(@NMonthYear))+@PPH_21_Diff5
		End
	else
		Begin
			set @Tax_calculated_month5=(@TaxImposedR5*1/(12-4))+@PPH_21_Diff5
		End


	if(@Sal6>0)
		Begin
			if(@ResignedMonth = 6)
				set @Tax_calculated_month6 = @TaxImposedR6 + @PPH_21_Diff6
			else
				set @Tax_calculated_month6=(@TaxImposedR6*@NMonth/(@NMonthYear))+@PPH_21_Diff6
		End
	else
		Begin
			set @Tax_calculated_month6=(@TaxImposedR6*1/(12-5))+@PPH_21_Diff6
		End

	if(@Sal7>0)
		Begin
			if(@ResignedMonth = 7)
				set @Tax_calculated_month7 = @TaxImposedR7 + @PPH_21_Diff7
			else
				set @Tax_calculated_month7=(@TaxImposedR7*@NMonth/(@NMonthYear))+@PPH_21_Diff7
		End
	else
		Begin
			set @Tax_calculated_month7=(@TaxImposedR7*1/(12-6))+@PPH_21_Diff7
		End

	if(@Sal8>0)
		Begin
			if(@ResignedMonth = 8)
				set @Tax_calculated_month8 = @TaxImposedR8 + @PPH_21_Diff8
			else
				set @Tax_calculated_month8=(@TaxImposedR8*@NMonth/(@NMonthYear))+@PPH_21_Diff8
		End
	else
		Begin
			set @Tax_calculated_month8=(@TaxImposedR8*1/(12-7))+@PPH_21_Diff8
		End

	if(@Sal9>0)
		Begin
			if(@ResignedMonth = 9)
				set @Tax_calculated_month9 = @TaxImposedR9 + @PPH_21_Diff9
			else
				set @Tax_calculated_month9=(@TaxImposedR9*@NMonth/(@NMonthYear))+@PPH_21_Diff9
		End
	else
		Begin
			set @Tax_calculated_month9=(@TaxImposedR9*1/(12-8))+@PPH_21_Diff9
		End

	if(@Sal10>0)
		Begin
			if(@ResignedMonth = 10)
				set @Tax_calculated_month10 = @TaxImposedR10 + @PPH_21_Diff10
			else
				set @Tax_calculated_month10=(@TaxImposedR10*@NMonth/(@NMonthYear))+@PPH_21_Diff10
		End
	else
		Begin
			set @Tax_calculated_month10=(@TaxImposedR10*1/(12-9))+@PPH_21_Diff10
		End


	if(@Sal11>0)
		Begin
			if(@ResignedMonth = 11)
				set @Tax_calculated_month11 = @TaxImposedR11 + @PPH_21_Diff11
			else
				set @Tax_calculated_month11=(@TaxImposedR11*@NMonth/(@NMonthYear))+@PPH_21_Diff11
		End
	else
		Begin
			set @Tax_calculated_month11=(@TaxImposedR11*1/(12-10))+@PPH_21_Diff11
		End


	if(@Sal12>0)
		Begin
			if(@ResignedMonth = 12)
				set @Tax_calculated_month12 = @TaxImposedR12 + @PPH_21_Diff12
			else
				set @Tax_calculated_month12=(@TaxImposedR12*@NMonth/(@NMonthYear))+@PPH_21_Diff12
		End
	else
		Begin
			set @Tax_calculated_month12=(@TaxImposedR12*1/(12-11))+@PPH_21_Diff12
		End
		


	---Tax Payable Monthly
	set @Tax_Payable1=0
	set @Tax_Payable2=0
	set @Tax_Payable3=0
	set @Tax_Payable4=0
	set @Tax_Payable5=0
	set @Tax_Payable6=0
	set @Tax_Payable7=0
	set @Tax_Payable8=0
	set @Tax_Payable9=0
	set @Tax_Payable10=0
	set @Tax_Payable11=0
	set @Tax_Payable12=0

-- PALANI
	set @Tax_Payable1=@Tax_calculated_month1
	set @Tax_Payable2=@Tax_calculated_month2-@Tax_calculated_month1
	set @Tax_Payable3=@Tax_calculated_month3-@Tax_calculated_month2
	set @Tax_Payable4=@Tax_calculated_month4-@Tax_calculated_month3
	set @Tax_Payable5=@Tax_calculated_month5-@Tax_calculated_month4
	set @Tax_Payable6=@Tax_calculated_month6-@Tax_calculated_month5
	set @Tax_Payable7=@Tax_calculated_month7-@Tax_calculated_month6
	set @Tax_Payable8=@Tax_calculated_month8-@Tax_calculated_month7
	set @Tax_Payable9=@Tax_calculated_month9-@Tax_calculated_month8
	set @Tax_Payable10=@Tax_calculated_month10-@Tax_calculated_month9
	set @Tax_Payable11=@Tax_calculated_month11-@Tax_calculated_month10
	set @Tax_Payable12=@Tax_calculated_month12-@Tax_calculated_month11
	

	set @Tax_Payable1= case when isnull(@THR,0) > 0  then @PPH_21_Diff1 else @Tax_Payable1 end
	set @Tax_Payable2= case when  isnull(@THR,0) > 0  then @PPH_21_Diff2 else @Tax_Payable2 end
	set @Tax_Payable3= case when  isnull(@THR,0) > 0  then @PPH_21_Diff3 else @Tax_Payable3 end
	set @Tax_Payable4= case when  isnull(@THR,0) > 0  then @PPH_21_Diff4 else @Tax_Payable4 end
	set @Tax_Payable5= case when  isnull(@THR,0) > 0  then @PPH_21_Diff5 else @Tax_Payable5 end
	set @Tax_Payable6= case when  isnull(@THR,0) > 0  then @PPH_21_Diff6 else @Tax_Payable6 end
	set @Tax_Payable7= case when  isnull(@THR,0) > 0  then @PPH_21_Diff7 else @Tax_Payable7 end
	set @Tax_Payable8= case when  isnull(@THR,0) > 0   then @PPH_21_Diff8 else @Tax_Payable8 end
	set @Tax_Payable9= case when  isnull(@THR,0) > 0  then @PPH_21_Diff9 else @Tax_Payable9 end
	set @Tax_Payable10= case when  isnull(@THR,0) > 0  then @PPH_21_Diff10 else @Tax_Payable10 end
	set @Tax_Payable11= case when  isnull(@THR,0) > 0  then @PPH_21_Diff11 else @Tax_Payable11 end
	set @Tax_Payable12= case when  isnull(@THR,0) > 0  then @PPH_21_Diff12  else @Tax_Payable12 end
	
	set @DedTaxEmployee=0
	if(@ActiveMonth=1)
		set @DedTaxEmployee=@Tax_Payable1
	else if @ActiveMonth=2
		set @DedTaxEmployee=@Tax_Payable2
	else if @ActiveMonth=3
		set @DedTaxEmployee=@Tax_Payable3
	else if @ActiveMonth=4
		set @DedTaxEmployee=@Tax_Payable4
	else if @ActiveMonth=5
		set @DedTaxEmployee=@Tax_Payable5
	else if @ActiveMonth=6
		set @DedTaxEmployee=@Tax_Payable6
	else if @ActiveMonth=7
		set @DedTaxEmployee=@Tax_Payable7
	else if @ActiveMonth=8
		set @DedTaxEmployee=@Tax_Payable8
	else if @ActiveMonth=9
		set @DedTaxEmployee=@Tax_Payable9
	else if @ActiveMonth=10
		set @DedTaxEmployee=@Tax_Payable10
	else if @ActiveMonth=11
		set @DedTaxEmployee=@Tax_Payable11
	else if @ActiveMonth=12
		set @DedTaxEmployee=@Tax_Payable12


	-- Palani
	Declare @DedJamsostekTemp AS Numeric(18,2)

	select @DedJamsostekTemp = isnull(SUM(DedJamsostek),0) from Checkroll.AdvancePaymentDet 
	where AdvancePaymentID in 
	(select AdvancePaymentID from Checkroll.AdvancePayment where EstateID =@EstateID and ActiveMonthYearID  = @ActiveMonthYearID) and EmpID=@EmpID

	DECLARE @Category nvarchar(50);
	Declare @HariTemp NUMERIC(18, 2)
	select @Category = Category,@HariTemp =Hari from Checkroll.Salary WHERE ActiveMonthYearID =@ActiveMonthYearId and EstateID =@EstateId and EmpID=@EmpID

	Declare @DedAstekForEmployee AS Numeric(18,2)
	set @DedAstekForEmployee = 0

	if (@DedJamsostekTemp <= 0)
		begin
			DECLARE @BasicRate numeric(18,2);
			DECLARE @JHTPercent numeric(18,2);
			DECLARE @JKKPercent numeric(18,2);
			DECLARE @JKPercent numeric(18,2);
			DECLARE @JHTEmployerPercent numeric(18,2);
			DECLARE @RiceDividerDays int;
			DECLARE @AdvancePremium int;

			IF (@Category = 'KHT' OR @Category = 'KHL' or @Category = 'PKWT')
				begin
					SET @BasicRate = 0

					SELECT 
					@BasicRate = Checkroll.GetEmployeeDailyRate(@EmpId)
					,@JHTPercent = JHT
					,@JKKPercent = JKK
					,@JKPercent = JK
					,@JHTEmployerPercent = JHTEmployer
					,@RiceDividerDays = RiceDividerDays
					,@AdvancePremium= AdvancePremium 
					FROM
					Checkroll.RateSetup 
					WHERE
					Category = @Category
					AND EstateID = @EstateId

					DECLARE @AstekPerDay numeric(18,2);
					SET @AstekPerDay=@BasicRate * @RiceDividerDays * (@JHTPercent /100)

					-- set @DedAstekForEmployee = (@AstekPerDay * @HariTemp)
					 set @DedAstekForEmployee = (@AstekPerDay)
				end
		end

		---- Palani 04 May 2011
		--Declare @DedAstekForEmployeeAdvance AS Numeric(18,2)
		--set @DedAstekForEmployeeAdvance = 0
		--select SUM(isnull(DedJamsostek,0)) from Checkroll.AdvancePaymentDet 
		--where AdvancePaymentID in 
		--(select AdvancePaymentID from Checkroll.AdvancePayment where EstateID =@EstateId and ActiveMonthYearID  =@ActiveMonthYearID) 
		--and EmpID=@EmpID


		SET @TotalDed = 
			ISNULL(@DedAstekForEmployee, 0) +
			ISNULL(@DedTaxEmployee, 0) + 
			ISNULL(@DedAdvance, 0) +
			ISNULL(@DedOther, 0) 
			--- ISNULL(@DedAstekForEmployeeAdvance, 0)
										
		-- Update, Kamis, 07 Jan 2009, 01:40
		SET @TotalBruto = @TotalBruto + ISNULL(@THR, 0);
		-- END Update, Kamis, 07 Jan 2009, 01:40
		
		SET @TotalNett = @TotalBruto - @TotalDed
		SET @TotalRoundUP=ceiling(@TotalNett /1000.0)*1000
		--SET @TotalRoundUP = ROUND(@TotalNett * 0.001, 0) * 1000;

		-- NOTE : Checkroll.Salary  is again updated in SP : [Checkroll].[TaxSalProcessingDML], later bring those logics here

		UPDATE  Checkroll.Salary 
		SET 
		DedTaxEmployee = @DedTaxEmployee,
		DedAstek = @DedAstekForEmployee,
		DedTaxCompany = @DedTaxCompany,
		THR = @THR,
		TotalBruto = @TotalBruto,
		TotalDed = @TotalDed,
		TotalNett = @TotalNett,
		FunctionalAllowanceP=@FunctionalAllowanceP,
		MaxAllowance=@MaxAllowance,
		TotalRoundUP = @TotalRoundUP,
		ModifiedBy = @User ,
		ModifiedOn = GETDATE()
		WHERE 
		EstateID = @EstateId AND 
		ActiveMonthYearID = @ActiveMonthYearID AND
		EmpID = @EmpID
						
	Exec [Checkroll].[TaxSalProcessingDML]
	@TotalDed ,
	@TotalNett ,
	@TotalRoundUP ,
	@EmpCode ,
	@EstateID,
	@TotalBruto ,
	@THR ,
	@DedTaxCompany ,
	@ActiveMonthYearID ,
	@EmpID ,
	@TaxImposedR1 ,
	@TaxImposedR2 ,
	@TaxImposedR3 ,
	@TaxImposedR4 ,
	@TaxImposedR5 ,
	@TaxImposedR6 ,
	@TaxImposedR7 ,
	@TaxImposedR8 ,
	@TaxImposedR9 ,
	@TaxImposedR10 ,
	@TaxImposedR11 ,
	@TaxImposedR12 ,
	@TaxImposedIR1 ,
	@TaxImposedIR2 ,
	@TaxImposedIR3 ,
	@TaxImposedIR4 ,
	@TaxImposedIR5 ,
	@TaxImposedIR6 ,
	@TaxImposedIR7 ,
	@TaxImposedIR8 ,
	@TaxImposedIR9 ,
	@TaxImposedIR10 ,
	@TaxImposedIR11 ,
	@TaxImposedIR12 ,
	@Sal1 ,
	@Sal2 ,
	@Sal3 ,
	@Sal4 ,
	@Sal5 ,
	@Sal6 ,
	@Sal7 ,
	@Sal8 ,
	@Sal9 ,
	@Sal10 ,
	@Sal11 ,
	@Sal12 ,
	@PPH_21_Diff1 ,
	@PPH_21_Diff2 ,
	@PPH_21_Diff3 ,
	@PPH_21_Diff4 ,
	@PPH_21_Diff5 ,
	@PPH_21_Diff6 ,
	@PPH_21_Diff7 ,
	@PPH_21_Diff8 ,
	@PPH_21_Diff9 ,
	@PPH_21_Diff10 ,
	@PPH_21_Diff11 ,
	@PPH_21_Diff12 ,
	@DedTaxEmployee ,
	@Tax_calculated_month1 ,
	@Tax_calculated_month2 ,
	@Tax_calculated_month3 ,
	@Tax_calculated_month4 ,
	@Tax_calculated_month5 ,
	@Tax_calculated_month6 ,
	@Tax_calculated_month7 ,
	@Tax_calculated_month8 ,
	@Tax_calculated_month9 ,
	@Tax_calculated_month10 ,
	@Tax_calculated_month11 ,
	@Tax_calculated_month12 ,
	@Tax_calculated_month ,
	@Tax_Payable1 ,
	@Tax_Payable2 ,
	@Tax_Payable3 ,
	@Tax_Payable4 ,
	@Tax_Payable5 ,
	@Tax_Payable6 ,
	@Tax_Payable7 ,
	@Tax_Payable8 ,
	@Tax_Payable9 ,
	@Tax_Payable10 ,
	@Tax_Payable11 ,
	@Tax_Payable12 ,
	@ActiveMonthYearID1,
	@ActiveMonthYearID2,
	@ActiveMonthYearID3,
	@ActiveMonthYearID4,
	@ActiveMonthYearID5,
	@ActiveMonthYearID6,
	@ActiveMonthYearID7,
	@ActiveMonthYearID8,
	@ActiveMonthYearID9,
	@ActiveMonthYearID10,
	@ActiveMonthYearID11,
	@ActiveMonthYearID12,
	@User
						
	select @PPH_21_Diff11 as diff11,@PPH_21_Diff10 as diff10, @Tax_calculated_month11,@PPH_21_Regular11R1 as ppr,@Tax_calculated_month11 as taxcalmonth11,@Tax_calculated_month10 as taxcalmonth10,
	@Sal11 as sal11, @Sal10 as sal10,@TaxImposedR11 as taximp11,@TaxImposedR10 as taximp10,@PPH_21_Regular11R1 as ss,@PPH_21_Regular11R2,@PPH_21_Regular11R3,@PPH_21_Regular11R4,@DedTaxEmployee as tax,
	@PPH_21_IRRegular11R1 as pph21IR11,@PPH_21_IRRegular11R2 as pph21IR11,@PPH_21_IRRegular11R3 as pph21IR11,@PPH_21_IRRegular11R4 as pph21IR11
	,@PPH_21_IRRegular9R1 as PPH_21_IRRegular9R1,@TaxImposedR9 as TaxImposedR9,@TaxImposedIR9 as TaxImposedIR9,@PPH_21_Diff9 as PPH_21_Diff9
	,@Tax_calculated_month9 as Tax_calculated_month9,@Tax_Payable9 as Tax_Payable9,
	@Tax_calculated_month8 as Tax_calculated_month8,@Sal9 as Sal9,((@TaxImposedR9*9/(12))+@PPH_21_Diff9) as taxcalc9,
	(@TaxImposedR9*9/(12-8))+@PPH_21_Diff9 as temp
					
END

