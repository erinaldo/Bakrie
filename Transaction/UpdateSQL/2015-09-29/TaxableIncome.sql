
/****** Object:  StoredProcedure [Checkroll].[Taxable_Income]    Script Date: 11/10/2015 11:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--Created by : Nelson
--Date : July 2010
--Description: For Monthly Processing of Checkroll
--Modified  : Stanley, 27-09-2011 
--          : include annual THR instead of just active month THR into annual irregular.
--Modified  : Stanley, 09-12-2011~13-12-2011
--          : Include THR from TaxSalaryHistory into annual irregular. (additional to above) 
--Modified	: Naxim on 26 Feb 2014
-- AFTER MTH END CLOSING SCRIPT


ALTER Procedure [Checkroll].[Taxable_Income](
@dDeductionCostMax NUMERIC(18, 2),
@RiceDividerDays int,
@BasicRate numeric(18,2),
@Status nvarchar(50),
@StatusDate nvarchar(50),
@ActiveMonth int,
@PTKP NUMERIC(18, 2),
@HIPMonthlyRate NUMERIC(18, 2),
@Category NVARCHAR(50),
@JHTPercent NUMERIC(18, 2),
@Income_Regular1 NUMERIC(18, 2),
@Income_Regular2 NUMERIC(18, 2),
@Income_Regular3 NUMERIC(18, 2),
@Income_Regular4 NUMERIC(18, 2),
@Income_Regular5 NUMERIC(18, 2),
@Income_Regular6 NUMERIC(18, 2),
@Income_Regular7 NUMERIC(18, 2),
@Income_Regular8 NUMERIC(18, 2),
@Income_Regular9 NUMERIC(18, 2),
@Income_Regular10 NUMERIC(18, 2),
@Income_Regular11 NUMERIC(18, 2),
@Income_Regular12 NUMERIC(18, 2),
@Income_Irregular1  NUMERIC(18, 2),
@Income_Irregular2  NUMERIC(18, 2),
@Income_Irregular3  NUMERIC(18, 2),
@Income_Irregular4  NUMERIC(18, 2),
@Income_Irregular5  NUMERIC(18, 2),
@Income_Irregular6  NUMERIC(18, 2),
@Income_Irregular7  NUMERIC(18, 2),
@Income_Irregular8  NUMERIC(18, 2),
@Income_Irregular9  NUMERIC(18, 2),
@Income_Irregular10  NUMERIC(18, 2),
@Income_Irregular11  NUMERIC(18, 2),
@Income_Irregular12  NUMERIC(18, 2),
@Accident_Insurance1 NUMERIC(18, 2),
@Accident_Insurance2 NUMERIC(18, 2),
@Accident_Insurance3 NUMERIC(18, 2),
@Accident_Insurance4 NUMERIC(18, 2),
@Accident_Insurance5 NUMERIC(18, 2),
@Accident_Insurance6 NUMERIC(18, 2),
@Accident_Insurance7 NUMERIC(18, 2),
@Accident_Insurance8 NUMERIC(18, 2),
@Accident_Insurance9 NUMERIC(18, 2),
@Accident_Insurance10 NUMERIC(18, 2),
@Accident_Insurance11 NUMERIC(18, 2),
@Accident_Insurance12 NUMERIC(18, 2),
@ActiveMonth1Sal NUMERIC(18, 2),
@ActiveMonth2Sal NUMERIC(18, 2),
@ActiveMonth3Sal NUMERIC(18, 2),
@ActiveMonth4Sal NUMERIC(18, 2),
@ActiveMonth5Sal NUMERIC(18, 2),
@ActiveMonth6Sal NUMERIC(18, 2),
@ActiveMonth7Sal NUMERIC(18, 2),
@ActiveMonth8Sal NUMERIC(18, 2),
@ActiveMonth9Sal NUMERIC(18, 2),
@ActiveMonth10Sal NUMERIC(18, 2),
@ActiveMonth11Sal NUMERIC(18, 2),
@ActiveMonth12Sal NUMERIC(18, 2),

@ActiveMonth1Tax NUMERIC(18, 2),
@ActiveMonth2Tax NUMERIC(18, 2),
@ActiveMonth3Tax NUMERIC(18, 2),
@ActiveMonth4Tax NUMERIC(18, 2),
@ActiveMonth5Tax NUMERIC(18, 2),
@ActiveMonth6Tax NUMERIC(18, 2),
@ActiveMonth7Tax NUMERIC(18, 2),
@ActiveMonth8Tax NUMERIC(18, 2),
@ActiveMonth9Tax NUMERIC(18, 2),
@ActiveMonth10Tax NUMERIC(18, 2),
@ActiveMonth11Tax NUMERIC(18, 2),
@ActiveMonth12Tax NUMERIC(18, 2),
@FunctionalAllowanceP NUMERIC(18, 0),
@MaxAllowance NUMERIC(18, 0),
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
@year int,
@EmpCode nvarchar(50),
@EstateID nvarchar(50),
-- Palani
@ActiveMonthYearID NVARCHAR(50)
)
as
DECLARE @Gross_Income_Regular1 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular2 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular3 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular4 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular5 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular6 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular7 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular8 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular9 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular10 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular11 NUMERIC(18, 2)
DECLARE @Gross_Income_Regular12 NUMERIC(18, 2)


DECLARE @Gross_Income_Irregular1  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular2  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular3  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular4  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular5  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular6  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular7  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular8  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular9  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular10  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular11  NUMERIC(18, 2)
DECLARE @Gross_Income_Irregular12  NUMERIC(18, 2)


DECLARE @Income_Regular_Annualised NUMERIC(18, 2)
DECLARE @Income_Irregular_Annualised NUMERIC(18, 2)
DECLARE @Functional_Allowance NUMERIC(18, 2)
DECLARE @Luran_JHT_Pension NUMERIC(18, 2)

DECLARE @Nett_Income_Regular1 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular2 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular3 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular4 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular5 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular6 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular7 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular8 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular9 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular10 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular11 NUMERIC(18, 2)
DECLARE @Nett_Income_Regular12 NUMERIC(18, 2)

DECLARE @Nett_Income_IRRegular1 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular2 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular3 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular4 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular5 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular6 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular7 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular8 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular9 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular10 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular11 NUMERIC(18, 2)
DECLARE @Nett_Income_IRRegular12 NUMERIC(18, 2)

DECLARE @ARJan NUMERIC(18, 2)
DECLARE @ARFeb NUMERIC(18, 2)
DECLARE @ARMar NUMERIC(18, 2)
DECLARE @ARAPr NUMERIC(18, 2)
DECLARE @ARMay NUMERIC(18, 2)
DECLARE @ARJun NUMERIC(18, 2)
DECLARE @ARJul NUMERIC(18, 2)
DECLARE @ARAug NUMERIC(18, 2)
DECLARE @ARSep NUMERIC(18, 2)
DECLARE @AROct NUMERIC(18, 2)
DECLARE @ARNov NUMERIC(18, 2)
DECLARE @ARDec NUMERIC(18, 2)

DECLARE @AIJan NUMERIC(18, 2)
DECLARE @AIFeb NUMERIC(18, 2)
DECLARE @AIMar NUMERIC(18, 2)
DECLARE @AIAPr NUMERIC(18, 2)
DECLARE @AIMay NUMERIC(18, 2)
DECLARE @AIJun NUMERIC(18, 2)
DECLARE @AIJul NUMERIC(18, 2)
DECLARE @AIAug NUMERIC(18, 2)
DECLARE @AISep NUMERIC(18, 2)
DECLARE @AIOct NUMERIC(18, 2)
DECLARE @AINov NUMERIC(18, 2)
DECLARE @AIDec NUMERIC(18, 2)

DECLARE @AFJan NUMERIC(18, 2)
DECLARE @AFFeb NUMERIC(18, 2)
DECLARE @AFMar NUMERIC(18, 2)
DECLARE @AFAPr NUMERIC(18, 2)
DECLARE @AFMay NUMERIC(18, 2)
DECLARE @AFJun NUMERIC(18, 2)
DECLARE @AFJul NUMERIC(18, 2)
DECLARE @AFAug NUMERIC(18, 2)
DECLARE @AFSep NUMERIC(18, 2)
DECLARE @AFOct NUMERIC(18, 2)
DECLARE @AFNov NUMERIC(18, 2)
DECLARE @AFDec NUMERIC(18, 2)  

DECLARE @ALurJan NUMERIC(18, 2)
DECLARE @ALurFeb NUMERIC(18, 2)
DECLARE @ALurMar NUMERIC(18, 2)
DECLARE @ALurAPr NUMERIC(18, 2)
DECLARE @ALurMay NUMERIC(18, 2)
DECLARE @ALurJun NUMERIC(18, 2)
DECLARE @ALurJul NUMERIC(18, 2)
DECLARE @ALurAug NUMERIC(18, 2)
DECLARE @ALurSep NUMERIC(18, 2)
DECLARE @ALurOct NUMERIC(18, 2)
DECLARE @ALurNov NUMERIC(18, 2)
DECLARE @ALurDec NUMERIC(18, 2)  

-- Stanley@27-09-2011.b
DECLARE @Annual_THR NUMERIC(18, 2)	
DECLARE @ActiveMth_THR NUMERIC(18, 2)	
-- Stanley@27-09-2011.e
DECLARE @Annual_THR_TSH NUMERIC(18, 2)		--09-12-2011	

--Income regular

DECLARE @Taxable_Income_Regular1 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular2 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular3 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular4 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular5 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular6 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular7 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular8 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular9 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular10 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular11 NUMERIC(18, 2)
DECLARE @Taxable_Income_Regular12 NUMERIC(18, 2)

DECLARE @Taxable_Income_Irregular1 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular2 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular3 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular4 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular5 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular6 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular7 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular8 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular9 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular10 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular11 NUMERIC(18, 2)
DECLARE @Taxable_Income_Irregular12 NUMERIC(18, 2)

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

set @Taxable_Income_Regular1 =0
set @Taxable_Income_Regular2 =0
set @Taxable_Income_Regular3 =0
set @Taxable_Income_Regular4 =0
set @Taxable_Income_Regular5 =0
set @Taxable_Income_Regular6 =0
set @Taxable_Income_Regular7 =0
set @Taxable_Income_Regular8 =0
set @Taxable_Income_Regular9 =0
set @Taxable_Income_Regular10 =0
set @Taxable_Income_Regular11 =0
set @Taxable_Income_Regular12 =0

set @Taxable_Income_Irregular1 =0
set @Taxable_Income_Irregular2 =0
set @Taxable_Income_Irregular3 =0
set @Taxable_Income_Irregular4 =0
set @Taxable_Income_Irregular5 =0
set @Taxable_Income_Irregular6 =0
set @Taxable_Income_Irregular7 =0
set @Taxable_Income_Irregular8 =0
set @Taxable_Income_Irregular9 =0
set @Taxable_Income_Irregular10 =0
set @Taxable_Income_Irregular11 =0
set @Taxable_Income_Irregular12 =0

set @ARJan=0
set @ARFeb=0
set @ARMar=0
set @ARAPr=0
set @ARMay=0
set @ARJun=0
set @ARJul=0
set @ARAug=0
set @ARSep=0
set @AROct=0
set @ARNov=0
set @ARDec=0

set @AIJan=0
set @AIFeb=0
set @AIMar=0
set @AIAPr=0
set @AIMay=0
set @AIJun=0
set @AIJul=0
set @AIAug=0
set @AISep=0
set @AIOct=0
set @AINov=0
set @AIDec=0

set @AFJan=0
set @AFFeb=0
set @AFMar=0
set @AFAPr=0
set @AFMay=0
set @AFJun=0
set @AFJul=0
set @AFAug=0
set @AFSep=0
set @AFOct=0
set @AFNov=0
set @AFDec=0  


SET @ALurJan = 0
SET @ALurFeb = 0
SET @ALurMar = 0
SET @ALurAPr = 0
SET @ALurMay = 0
SET @ALurJun = 0
SET @ALurJul = 0
SET @ALurAug = 0
SET @ALurSep = 0
SET @ALurOct = 0
SET @ALurNov = 0
SET @ALurDec =0  

set @Gross_Income_Regular1 =0
set @Gross_Income_Regular2 =0
set @Gross_Income_Regular3 =0
set @Gross_Income_Regular4 =0
set @Gross_Income_Regular5 =0
set @Gross_Income_Regular6 =0
set @Gross_Income_Regular7 =0
set @Gross_Income_Regular8 =0
set @Gross_Income_Regular9 =0
set @Gross_Income_Regular10 =0
set @Gross_Income_Regular11 =0
set @Gross_Income_Regular12 =0

set @Gross_Income_Irregular1  =0
set @Gross_Income_Irregular2  =0
set @Gross_Income_Irregular3  =0
set @Gross_Income_Irregular4  =0
set @Gross_Income_Irregular5  =0
set @Gross_Income_Irregular6  =0
set @Gross_Income_Irregular7  =0
set @Gross_Income_Irregular8  =0
set @Gross_Income_Irregular9  =0
set @Gross_Income_Irregular10  =0
set @Gross_Income_Irregular11  =0
set @Gross_Income_Irregular12  =0

set @Nett_Income_Regular1 =0
set @Nett_Income_Regular2 =0
set @Nett_Income_Regular3 =0
set @Nett_Income_Regular4 =0
set @Nett_Income_Regular5 =0
set @Nett_Income_Regular6 =0
set @Nett_Income_Regular7 =0
set @Nett_Income_Regular8 =0
set @Nett_Income_Regular9 =0
set @Nett_Income_Regular10 =0
set @Nett_Income_Regular11 =0
set @Nett_Income_Regular12 =0

set @Nett_Income_IRRegular1 =0
set @Nett_Income_IRRegular2 =0
set @Nett_Income_IRRegular3 =0
set @Nett_Income_IRRegular4 =0
set @Nett_Income_IRRegular5 =0
set @Nett_Income_IRRegular6 =0
set @Nett_Income_IRRegular7 =0
set @Nett_Income_IRRegular8 =0
set @Nett_Income_IRRegular9 =0
set @Nett_Income_IRRegular10 =0
set @Nett_Income_IRRegular11 =0
set @Nett_Income_IRRegular12 =0

-- added by naxim, maxallowance 60 mil is for 12 months so get maxallowance for number of months the employee worked
DECLARE @WorkedMonths as int;
select @WorkedMonths = NMonthYear from checkroll.TaxProcessingDet where Empid = @EmpID AND @ActiveMonthYearID = @ActiveMonthYearID;
SET @MaxAllowance = (@MaxAllowance / 12) * @WorkedMonths;


-- Stanley@27-09-2011.b
set @ActiveMth_THR = 0
set @Annual_THR = 0
-- Stanley@27-09-2011.e
set @Annual_THR_TSH = 0		--09-12-2011

set @Gross_Income_Regular1=isnull(@Income_Regular1  ,0)
set @Gross_Income_Regular2=isnull(@Income_Regular2  ,0)
set @Gross_Income_Regular3=isnull(@Income_Regular3  ,0)
set @Gross_Income_Regular4=isnull(@Income_Regular4 ,0)
set @Gross_Income_Regular5=@Income_Regular5 
set @Gross_Income_Regular6=@Income_Regular6 
set @Gross_Income_Regular7=@Income_Regular7 
set @Gross_Income_Regular8=@Income_Regular8 
set @Gross_Income_Regular9=@Income_Regular9 
set @Gross_Income_Regular10=@Income_Regular10 
set @Gross_Income_Regular11=@Income_Regular11 
set @Gross_Income_Regular12=@Income_Regular12 

--Gross Income_Irregular 
--= Bonus + THR + Others
set @Gross_Income_Irregular1 =@Income_Irregular1
set @Gross_Income_Irregular2 =@Income_Irregular2
set @Gross_Income_Irregular3 =@Income_Irregular3
set @Gross_Income_Irregular4 =@Income_Irregular4
set @Gross_Income_Irregular5 =@Income_Irregular5
set @Gross_Income_Irregular6 =@Income_Irregular6
set @Gross_Income_Irregular7 =@Income_Irregular7
set @Gross_Income_Irregular8 =@Income_Irregular8
set @Gross_Income_Irregular9 =@Income_Irregular9
set @Gross_Income_Irregular10 =@Income_Irregular10
set @Gross_Income_Irregular11 =@Income_Irregular11
set @Gross_Income_Irregular12 =@Income_Irregular12

-- Stanley@27-09-2011.b
SELECT  
--30-11-2011 @ActiveMth_THR = ISNULL(Bruto,0)   
@ActiveMth_THR = ISNULL(SUM(RoundUp),0)   
FROM   Checkroll.THR  
WHERE  estateid = @EstateId  
AND yearperiod = @Year  
AND ActiveMonthYearID = @ActiveMonthYearID  
AND empid = @EmpId 

SELECT  
--30-11-2011 @Annual_THR = ISNULL(Bruto,0)   
@Annual_THR = ISNULL(SUM(RoundUP),0)  
FROM   Checkroll.THR  
WHERE  estateid = @EstateId  
AND yearperiod = @Year  
AND empid = @EmpId
-- Stanley@27-09-2011.e

--09-12-2011
SELECT
@Annual_THR_TSH = ISNULL(SUM(TSH.THRBonus),0)  
FROM   Checkroll.TaxSalaryHistory TSH
LEFT JOIN Checkroll.CREmployee Emp ON Emp.EmpCode = TSH.EmpCode 
WHERE  TSH.EstateId = @EstateId  
AND TSH.[Year] = @Year  
AND Emp.Empid = @EmpId
--09-12-2011

-- PALANI
-- XXXXXX

-- ######### FOR Checkroll.TaxProcessingDet table - anregular field #########
-- Variable required for Calculating [Checkroll].[TaxProcessingDet] -  [AnRegular] & [AnIrRegular] fields  
-- Gathering the Employee Joining Date, Joining Month, Joining Year for 
-- For the Employees joined in the middle of the year

Declare @ActiveYear as int
select @ActiveYear = AYEAR from General.ActiveMonthYear where EstateID = @EstateID and  ModID = 1 and Status='A'
-- print @ActiveYear

Declare @EmpDOJ as date
select @EmpDOJ = DOJ from Checkroll.CREmployee where EstateID = @EstateID and EmpID = @EmpID
-- print @EmpDOJ

Declare @YEarOfJoining as int, @MonthOfJoining as int
select @MonthOfJoining = Period, @YEarOfJoining =FYear from General.FiscalYear where @EmpDOJ between FromDT and ToDT

-- print @YEarOfJoining
-- print @MonthOfJoining

Declare @AccoutableMonths as int
Declare @EmpWorkedMonths as int


-- XXXXXX

--Income_Regular_Annualised
---[Gross Income_Regular(Jan+Feb)*12]/2 for feb
if(@StatusDate <> '') and (@StatusDate is not null)
	Begin
	-- if resigns means
		 set @ARJan=(@Gross_Income_Regular1)
		 set @ARFeb=(@Gross_Income_Regular1+@Gross_Income_Regular2)
		 set @ARMar=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3)
		 set @ARApr=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4)
		 set @ARMay=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5)
		 set @ARJun=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6)
		 set @ARJul=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7)
		 set @ARAug=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8)
		 set @ARSep=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9)
		 set @AROct=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10)
		 set @ARNov=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11)
		 set @ARDec=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11+@Gross_Income_Regular12 )
	End
Else -- Status <> 'Resign'
-- For the Employees joined in the middle of the year
if not (@YEarOfJoining < @ActiveYear or (@YEarOfJoining = @ActiveYear and @MonthOfJoining=1))
	Begin
		set @AccoutableMonths  = 0
		set @AccoutableMonths = (12 - @MonthOfJoining + 1) -- E.g DOJ = MARCH 2011, DEC - MAR = 9 + 1 = 10
		-- print @AccoutableMonths 
		
		set @EmpWorkedMonths = 0
		set @EmpWorkedMonths = (@ActiveMonth - @MonthOfJoining + 1) -- E.g Active Month = 11 - 3 (Mar) + 1
		-- print @EmpWorkedMonths 
		-- print @AccoutableMonths/ convert(decimal,@EmpWorkedMonths)
		
			-- Jan N/A so set to 0
		set @ARJan = 0
			set @ARFeb = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2) )
			set @ARMar = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2 + @Gross_Income_Regular3) )
			set @ARApr = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2 + @Gross_Income_Regular3 + @Gross_Income_Regular4) )
			set @ARMay = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5) )
			set @ARJun = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6) )
			set @ARJul = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7) )
			set @ARAug = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8) )
			set @ARSep = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9) )
			set @AROct = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9 + @Gross_Income_Regular10) )
			set @ARNov = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9 + @Gross_Income_Regular10+ @Gross_Income_Regular11) )
			set @ARDec = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9 + @Gross_Income_Regular10 + @Gross_Income_Regular11 + @Gross_Income_Regular12) )
	End
else
	Begin
		 set @ARJan=((@Gross_Income_Regular1)*12)/1
		 set @ARFeb=((@Gross_Income_Regular1+@Gross_Income_Regular2)*12)/2
		 set @ARMar=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3)*12)/3
		 set @ARApr=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4)*12)/4
		 set @ARMay=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5)*12)/5
		 set @ARJun=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6)*12)/6
		 set @ARJul=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7)*12)/7
		 set @ARAug=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8)*12)/8
		 set @ARSep=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9)*12)/9
		 set @AROct=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10)*12)/10
		 set @ARNov=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11)*12)/11
		 set @ARDec=((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11+@Gross_Income_Regular12 )*12)/12
	End


--Income_IrRegular_Annualised
--[Gross Income_Regular(Jan+Feb)*12]/2 }  + Gross Income_Irregular(Jan+Feb) for feb
if (@StatusDate <> '') and (@StatusDate is not null)
 Begin

     set @AIJan=(@Gross_Income_Regular1)
     set @AIFeb=(@Gross_Income_Regular1+@Gross_Income_Regular2)
     set @AIMar=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3)
     set @AIApr=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4)
     set @AIMay=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5)
     set @AIJun=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6)
     set @AIJul=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7)
     set @AIAug=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8)
     set @AISep=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9)
     set @AIOct=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10)
     set @AINov=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11)
     set @AIDec=(@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11+@Gross_Income_Regular12 )
     
End
Else
-- For the Employees joined in the middle of the year
	if not (@YEarOfJoining < @ActiveYear or (@YEarOfJoining = @ActiveYear and @MonthOfJoining=1))
		Begin
			set @AccoutableMonths = 0
			set @AccoutableMonths = (12 - @MonthOfJoining + 1) -- E.g DOJ = MARCH 2011, DEC - MAR = 9 + 1 = 10
			-- print @AccoutableMonths 
			
			set @EmpWorkedMonths  = 0
			set @EmpWorkedMonths = (@ActiveMonth - @MonthOfJoining + 1) -- E.g Active Month = 11 - 3 (Mar) + 1
			-- print @EmpWorkedMonths 
			-- print @AccoutableMonths/ convert(decimal,@EmpWorkedMonths)
			
				-- Jan N/A so set to 0
			set @AIJan = 0
				set @AIFeb = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2)+ (@Gross_Income_Irregular2) )
				set @AIMar = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2 + @Gross_Income_Regular3) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3)  )
				set @AIApr = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2 + @Gross_Income_Regular3 + @Gross_Income_Regular4) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4) )
				set @AIMay = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5))
				set @AIJun = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5 + @Gross_Income_Irregular6))
				set @AIJul = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5 + @Gross_Income_Irregular6 + @Gross_Income_Irregular7))
				set @AIAug = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5 + @Gross_Income_Irregular6 + @Gross_Income_Irregular7 + @Gross_Income_Irregular8))
				set @AISep = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5 + @Gross_Income_Irregular6 + @Gross_Income_Irregular7 + @Gross_Income_Irregular8 + @Gross_Income_Irregular9))
				set @AIOct = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9 + @Gross_Income_Regular10) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5 + @Gross_Income_Irregular6 + @Gross_Income_Irregular7 + @Gross_Income_Irregular8 + @Gross_Income_Irregular9 + @Gross_Income_Irregular10))
				set @AINov = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9 + @Gross_Income_Regular10+ @Gross_Income_Regular11) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5 + @Gross_Income_Irregular6 + @Gross_Income_Irregular7 + @Gross_Income_Irregular8 + @Gross_Income_Irregular9 + @Gross_Income_Irregular10 + @Gross_Income_Irregular11))
				set @AIDec = ( (@AccoutableMonths / convert(decimal,@EmpWorkedMonths)) * (@Gross_Income_Regular2+ @Gross_Income_Regular3 + @Gross_Income_Regular4 + @Gross_Income_Regular5  + @Gross_Income_Regular6 + @Gross_Income_Regular7 + @Gross_Income_Regular8 + @Gross_Income_Regular9 + @Gross_Income_Regular10 + @Gross_Income_Regular11 + @Gross_Income_Regular12) + (@Gross_Income_Irregular2 + @Gross_Income_Irregular3 + @Gross_Income_Irregular4 + @Gross_Income_Irregular5 + @Gross_Income_Irregular6 + @Gross_Income_Irregular7 + @Gross_Income_Irregular8 + @Gross_Income_Irregular9 + @Gross_Income_Irregular10 + @Gross_Income_Irregular11 + @Gross_Income_Irregular12))
		End
else
	Begin

		 set @AIJan=(((@Gross_Income_Regular1)*12)/1)+@Gross_Income_Irregular1
		 set @AIFeb=(((@Gross_Income_Regular1+@Gross_Income_Regular2)*12)/2)+@Gross_Income_Irregular1+@Gross_Income_Irregular2
		 set @AIMar=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3)*12)/3)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3
		 set @AIApr=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4)*12)/4)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4
		 set @AIMay=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5)*12)/5)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5
		 set @AIJun=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6)*12)/6)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5+@Gross_Income_Irregular6
		 set @AIJul=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7)*12)/7)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5+@Gross_Income_Irregular6+@Gross_Income_Irregular7
		 set @AIAug=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8)*12)/8)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5+@Gross_Income_Irregular6+@Gross_Income_Irregular7+@Gross_Income_Irregular8
		 set @AISep=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9)*12)/9)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5+@Gross_Income_Irregular6+@Gross_Income_Irregular7+@Gross_Income_Irregular8+@Gross_Income_Irregular9
		 set @AIOct=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10)*12)/10)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5+@Gross_Income_Irregular6+@Gross_Income_Irregular7+@Gross_Income_Irregular8+@Gross_Income_Irregular9+@Gross_Income_Irregular10
		 set @AINov=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11)*12)/11)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5+@Gross_Income_Irregular6+@Gross_Income_Irregular7+@Gross_Income_Irregular8+@Gross_Income_Irregular9+@Gross_Income_Irregular10+@Gross_Income_Irregular11
		 set @AIDec=(((@Gross_Income_Regular1+@Gross_Income_Regular2+@Gross_Income_Regular3+@Gross_Income_Regular4+@Gross_Income_Regular5+@Gross_Income_Regular6+@Gross_Income_Regular7+@Gross_Income_Regular8+@Gross_Income_Regular9+@Gross_Income_Regular10+@Gross_Income_Regular11+@Gross_Income_Regular12 )*12)/12)+@Gross_Income_Irregular1+@Gross_Income_Irregular2+@Gross_Income_Irregular3+@Gross_Income_Irregular4+@Gross_Income_Irregular5+@Gross_Income_Irregular6+@Gross_Income_Irregular7+@Gross_Income_Irregular8+@Gross_Income_Irregular9+@Gross_Income_Irregular10+@Gross_Income_Irregular11+@Gross_Income_Irregular12
	     
	End
   
-- Stanley@27-09-2011.b
if (@ActiveMonth = 1) begin
	set @AIJan = @AIJan - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else if (@ActiveMonth = 2) begin
	set @AIFeb = @AIFeb - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 3) begin
	set @AIMar = @AIMar - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 4) begin
	set @AIApr = @AIApr - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 5) begin
	set @AIMay = @AIMay - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 6) begin
	set @AIJun = @AIJun - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 7) begin
	set @AIJul = @AIJul - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 8) begin
	set @AIAug = @AIAug - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 9) begin
	set @AISep = @AISep - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 10) begin
	set @AIOct = @AIOct - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 11) begin
	set @AINov = @AINov - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
else  if (@ActiveMonth = 12) begin
	set @AIDec = @AIDec - @ActiveMth_THR + @Annual_THR + @Annual_THR_TSH
end
-- Stanley@27-09-2011.e
   
if exists
( 
select mnth,mnthSalary,MnthTax,YEAR from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode 

)
Begin

select  @Sal1=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=01 and isnull(mnthSalary,0)<>0
select  @Sal2=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=02 and isnull(mnthSalary,0)<>0
select  @Sal3=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=03 and isnull(mnthSalary,0)<>0
select  @Sal4=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=04 and isnull(mnthSalary,0)<>0
select  @Sal5=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=05 and isnull(mnthSalary,0)<>0
select  @Sal6=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=06 and isnull(mnthSalary,0)<>0
select  @Sal7=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=07 and isnull(mnthSalary,0)<>0
select  @Sal8=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=08 and isnull(mnthSalary,0)<>0
select  @Sal9=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=09 and isnull(mnthSalary,0)<>0
select  @Sal10=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=10 and isnull(mnthSalary,0)<>0
select  @Sal11=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=11 and isnull(mnthSalary,0)<>0
select  @Sal12=count(mnthSalary) from Checkroll.TaxSalaryHistory  where Year=@Year And EstateId=@EstateId and Empcode=@EmpCode  and Mnth=12 and isnull(mnthSalary,0)<>0
End

if(isnull(@Sal1,0)=0)
Begin
select  @Sal1=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID1
End
if(isnull(@Sal2,0)=0)
Begin
select  @Sal2=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID2
End
if(isnull(@Sal3,0)=0)
Begin
select  @Sal3=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID3
End
if(isnull(@Sal4,0)=0)
Begin
select  @Sal4= count(TotalBasic) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID4
End
if(isnull(@Sal5,0)=0)
Begin
select  @Sal5=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID5
End
if(isnull(@Sal6,0)=0)
Begin
select  @Sal6=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID6
End
if(isnull(@Sal7,0)=0)
Begin
select  @Sal7=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID7
End
if(isnull(@Sal8,0)=0)
Begin
select  @Sal8=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID8
End
if(isnull(@Sal9,0)=0)
Begin
select  @Sal9=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID9
End
if(isnull(@Sal10,0)=0)
Begin
select  @Sal10=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID10
End
if(isnull(@Sal11,0)=0)
Begin
select  @Sal11=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID11
End
if(isnull(@Sal12,0)=0)
Begin
select  @Sal12=count(TotalBasic ) from Checkroll.Salary  where EstateId=@EstateId and EmpID=@EmpID and ActiveMonthYearID=@ActiveMonthYearID12
End

       --   --Based on doj in employee master 
                    -- need to give accident allowance from the month he joined not before .
          --Functional Allowance
          ---@FunctionalAllowanceP =5%
          --@MaxAllowance=500000 from taxandricesetup table

		  
          IF (@Sal1>0)
          Begin 
			  -- if ((@Gross_Income_Irregular1*(@FunctionalAllowanceP/100))>(@MaxAllowance))
			  if ((@AIJan *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
			  Begin
				  set @AFJan= @MaxAllowance
			  End
			  Else
			  Begin
				set @AFJan=@AIJan *(@FunctionalAllowanceP/100)
			  End
          End
          
          if(@Sal2>0)
          Begin
          
           -- if ((@Gross_Income_Irregular2*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          if ((@AIFeb *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
          Begin
          set @AFFeb=(@MaxAllowance)
          End
          Else
          Begin
            set @AFFeb=@AIFeb *(@FunctionalAllowanceP/100)
          End
          End
          
          if(@Sal3>0)
			Begin
				-- if ((@Gross_Income_Irregular3*(@FunctionalAllowanceP/100))>(@MaxAllowance))
				if ((@AIMar *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
					Begin
						set @AFmar=(@MaxAllowance)
					End
				Else
					Begin
						set @AFmar=@AImar *(@FunctionalAllowanceP/100)
						
					End
			End
          

		if(@Sal4>0)
			Begin
				-- if ((@Gross_Income_Irregular4*(@FunctionalAllowanceP/100))>(@MaxAllowance))
				if ((@AIAPr *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
					Begin
						set @AFApr=(@MaxAllowance)
					End
				Else
					Begin
						set @AFApr = @AIApr *(@FunctionalAllowanceP/100)
					End
			End
           
             
             
             if(@Sal5>0)
          Begin
           -- if ((@Gross_Income_Irregular5*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          if ((@AIMay *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
          Begin
          set @AFMay=(@MaxAllowance)
          End
          Else
          Begin
            set @AFMay=@AIMay *(@FunctionalAllowanceP/100)
          End
          End
          
             if(@Sal6>0)
          Begin
          if ((@AIJun *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
           -- if ((@Gross_Income_Irregular6*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          Begin
          set @AFJun=(@MaxAllowance)
          End
          Else
          Begin
            set @AFJun=@AIJun *(@FunctionalAllowanceP/100)
          End
          End

			if(@Sal7>0)
          Begin
          if ((@AIJul *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
           -- if ((@Gross_Income_Irregular7*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          Begin
          set @AFJul=(@MaxAllowance)
          End
          Else
          Begin
            set @AFJul=@AIJul *(@FunctionalAllowanceP/100)
          End
          End
          
             if(@Sal8>0)
          Begin
           -- if ((@Gross_Income_Irregular8*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          if ((@AIAug *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
          Begin
          set @AFAug=(@MaxAllowance)
          End
          Else
          Begin
            set @AFAug=@AIAug *(@FunctionalAllowanceP/100)
          End
          End
          
             if(@Sal9>0)
          Begin
           -- if ((@Gross_Income_Irregular9*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          if ((@AISep *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
          Begin
          set @AFSep=(@MaxAllowance)
          End
          Else
          Begin
            set @AFSep=@AISep *(@FunctionalAllowanceP/100)
          End
          End
          
             if(@Sal10>0)
          Begin
           -- if ((@Gross_Income_Irregular10*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          if ((@AIOct *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
          Begin
          set @AFOct=(@MaxAllowance)
          End
          Else
          Begin
            set @AFOct=@AIOct *(@FunctionalAllowanceP/100)
          End
          End
          
             if(@Sal11>0)
          Begin
           -- if ((@Gross_Income_Irregular11*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          if ((@AINov *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
          Begin
          set @AFNov=(@MaxAllowance)
          End
          Else
          Begin
            set @AFNov=@AINov *(@FunctionalAllowanceP/100)
          End
          End
          
             if(@Sal12>0)
          Begin
           -- if ((@Gross_Income_Irregular12*(@FunctionalAllowanceP/100))>(@MaxAllowance))
          if ((@AIDec *(@FunctionalAllowanceP/100))>(@MaxAllowance)) 
          Begin
          set @AFDec=(@MaxAllowance)
          End
          Else
          Begin
            set @AFDec=@AIDec *(@FunctionalAllowanceP/100)
          End
          End
     
       --End
       --Luran JHT (Pension)
       --@JHTPercent=2%

-- FOR RESIGNED 
if(@StatusDate <> '') and (@StatusDate is not null)
	
	Begin
		IF @Category = 'KHT' or @Category = 'PKWT'
		--  set @ALurJan=(@ActiveMonth1Sal+@ActiveMonth1Tax)*12*(@JHTPercent/100)
		-- for aprl 4 * Basic rate * @RiceDividerDays *(@JHTPercent/100)
			Begin
				set @ALurJan=0
				set @ALurFeb=0
				set @ALurmar=0
				set @ALurapr=0
				set @ALurmay=0
				set @ALurJun=0
				set @ALurJul=0
				set @ALuraug=0
				set @ALursep=0
				set @ALuroct=0
				set @ALurnov=0
				set @ALurdec=0

				set @ALurJan=1*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurFeb =2*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurMar=3*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurApr = 4*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurMay=5*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurJun=6*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurJul=7*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurAug=8*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurSep=9*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurOct=10*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurNov=11*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
				set @ALurDec=12*@BasicRate*@RiceDividerDays*(@JHTPercent/100)
			End
		       
		if  @Category = 'KHL'
			Begin
				-- for aprl 4 *  @dDeductionCostMax *(@JHTPercent/100)
				set @ALurJan=0
				set @ALurFeb=0
				set @ALurmar=0
				set @ALurapr=0
				set @ALurmay=0
				set @ALurJun=0
				set @ALurJul=0
				set @ALuraug=0
				set @ALursep=0
				set @ALuroct=0
				set @ALurnov=0
				set @ALurdec=0

				set @ALurJan=1*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurFeb =2*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurMar=3*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurApr=4*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurMay=5*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurJun=6*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurJul=7*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurAug=8*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurSep=9*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurOct=10*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurNov=11*@dDeductionCostMax*(@JHTPercent/100)
				set @ALurDec=12*@dDeductionCostMax*(@JHTPercent/100)
			End

		--we not using KT 
		IF @Category = 'KT'
			--SET @IuranTHT = ( @HIPMonthlyRate * 12 ) *(@JHTPercent/100);
			Begin
				set @ALurJan=( @HIPMonthlyRate * 12 ) *(@JHTPercent/100);
				set @ALurFeb =( @HIPMonthlyRate * 11 ) *(@JHTPercent/100);
				set @ALurMar=( @HIPMonthlyRate * 10 ) *(@JHTPercent/100);
				set @ALurApr=( @HIPMonthlyRate * 9 ) *(@JHTPercent/100);
				set @ALurMay=( @HIPMonthlyRate * 8 ) *(@JHTPercent/100);
				set @ALurJun=( @HIPMonthlyRate * 7 ) *(@JHTPercent/100);
				set @ALurJul=( @HIPMonthlyRate * 6 ) *(@JHTPercent/100);
				set @ALurAug=( @HIPMonthlyRate * 5 ) *(@JHTPercent/100);
				set @ALurSep=( @HIPMonthlyRate * 4 ) *(@JHTPercent/100);
				set @ALurOct=( @HIPMonthlyRate * 3) *(@JHTPercent/100);
				set @ALurNov=( @HIPMonthlyRate * 2 ) *(@JHTPercent/100);
				set @ALurDec=( @HIPMonthlyRate * 1 ) *(@JHTPercent/100);
			End
	End 

-- NOT RESIGNED
else

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

	-- check if employee is terminated this month, if terminated NMonthYear should be current month (edited on 17 feb 2014 by naxim)
	Declare @TerminatedDate as datetime;
	select @TerminatedDate = StatusDate from Checkroll.CREmployee a,
	General.ActiveMonthYear b
	where a.EmpID = @EmpID and b.ActiveMonthYearID = @ActiveMonthYearID and (Datepart(mm,a.StatusDate) = AMonth and Datepart(yy,a.StatusDate) = AYear)
	
	IF @TerminatedDate IS NOT NULL
		begin
			SET @NMonthYear = @NMonth;
		end
	

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$



	Begin
		IF @Category = 'KHT' 
			--  set @ALurJan=(@BasicRate*@RiceDividerDays)*12*(@JHTPercent/100)
			-- for aprl  Basic rate * @RiceDividerDays * 12 *(@JHTPercent/100)
			Begin
				set @ALurJan=0
				set @ALurFeb=0
				set @ALurmar=0
				set @ALurapr=0
				set @ALurmay=0
				set @ALurJun=0
				set @ALurJul=0
				set @ALuraug=0
				set @ALursep=0
				set @ALuroct=0
				set @ALurnov=0
				set @ALurdec=0

				set @ALurJan=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurFeb =@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurMar=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurApr=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurMay=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurJun=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurJul=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurAug=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurSep=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurOct=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurNov=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				set @ALurDec=@BasicRate*@RiceDividerDays*@NMonthYear*(@JHTPercent/100)
				
				
			End
			
		if  @Category = 'KHL' or @Category = 'PKWT'
			Begin
				-- for aprl  @dDeductionCostMax*12 *(@JHTPercent/100)
				set @ALurJan=0
				set @ALurFeb=0
				set @ALurmar=0
				set @ALurapr=0
				set @ALurmay=0
				set @ALurJun=0
				set @ALurJul=0
				set @ALuraug=0
				set @ALursep=0
				set @ALuroct=0
				set @ALurnov=0
				set @ALurdec=0

				set @ALurJan=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurFeb =@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurMar=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurApr=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurMay=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurJun=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurJul=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurAug=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurSep=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurOct=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurNov=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
				set @ALurDec=@dDeductionCostMax*@NMonthYear*(@JHTPercent/100)
			End
		--we not using KT 
		IF @Category = 'KT'
			--SET @IuranTHT = ( @HIPMonthlyRate * 12 ) *(@JHTPercent/100);
			Begin
				set @ALurJan=( @HIPMonthlyRate * 12 ) *(@JHTPercent/100);
				set @ALurFeb =( @HIPMonthlyRate * 11 ) *(@JHTPercent/100);
				set @ALurMar=( @HIPMonthlyRate * 10 ) *(@JHTPercent/100);
				set @ALurApr=( @HIPMonthlyRate * 9 ) *(@JHTPercent/100);
				set @ALurMay=( @HIPMonthlyRate * 8 ) *(@JHTPercent/100);
				set @ALurJun=( @HIPMonthlyRate * 7 ) *(@JHTPercent/100);
				set @ALurJul=( @HIPMonthlyRate * 6 ) *(@JHTPercent/100);
				set @ALurAug=( @HIPMonthlyRate * 5 ) *(@JHTPercent/100);
				set @ALurSep=( @HIPMonthlyRate * 4 ) *(@JHTPercent/100);
				set @ALurOct=( @HIPMonthlyRate * 3) *(@JHTPercent/100);
				set @ALurNov=( @HIPMonthlyRate * 2 ) *(@JHTPercent/100);
				set @ALurDec=( @HIPMonthlyRate * 1 ) *(@JHTPercent/100);
			End
	End
       
       ---Nett Income_Regular
       ---( Income_Regular(Annualised) )- Functional Allowance - Luran JHT
         set @Nett_Income_Regular1=@ARJan-@AFJan-@ALurJan
         set @Nett_Income_Regular2=@ARFeb-@AFFeb-@ALurFeb
         set @Nett_Income_Regular3=@ARMar-@AFMar-@ALurMar
         set @Nett_Income_Regular4=@ARApr-@AFApr-@ALurApr
         set @Nett_Income_Regular5=@ARMay-@AFMay-@ALurMay
         set @Nett_Income_Regular6=@ARJun-@AFJun-@ALurJun
         set @Nett_Income_Regular7=@ARJul-@AFJul-@ALurJul
         set @Nett_Income_Regular8=@ARAug-@AFAug-@ALurAug
         set @Nett_Income_Regular9=@ARSep-@AFSep-@ALurSep
         set @Nett_Income_Regular10=@AROct-@AFOct-@ALurOct
         set @Nett_Income_Regular11=@ARNov-@AFNov-@ALurNov
         set @Nett_Income_Regular12=@ARDec-@AFDec-@ALurDec
 
       
       ---End
              ---Nett Income_IRRegular
       --( Income_Irregular(Annualised) ) - Functional Allowance - Luran JHT
         set @Nett_Income_IRRegular1=@AIJan-@AFJan-@ALurJan
         set @Nett_Income_IRRegular2=@AIFeb-@AFFeb-@ALurFeb
         set @Nett_Income_IRRegular3=@AIMar-@AFMar-@ALurMar
         set @Nett_Income_IRRegular4=@AIApr-@AFApr-@ALurApr
         set @Nett_Income_IRRegular5=@AIMay-@AFMay-@ALurMay
         set @Nett_Income_IRRegular6=@AIJun-@AFJun-@ALurJun
         set @Nett_Income_IRRegular7=@AIJul-@AFJul-@ALurJul
         set @Nett_Income_IRRegular8=@AIAug-@AFAug-@ALurAug
         set @Nett_Income_IRRegular9=@AISep-@AFSep-@ALurSep
         set @Nett_Income_IRRegular10=@AIOct-@AFOct-@ALurOct
         set @Nett_Income_IRRegular11=@AINov-@AFNov-@ALurNov
         set @Nett_Income_IRRegular12=@AIDec-@AFDec-@ALurDec
 
       
       ---End
       
--Taxable Income_Regular
---Positive balance value of (Nett Income Regular - PTKP )   Note: if negative balance, display zero value
if((@Nett_Income_Regular1-@PTKP )>0)
Begin
set @Taxable_Income_Regular1=@Nett_Income_Regular1-@PTKP
End
Else
Begin
set @Taxable_Income_Regular1=0
End

if((@Nett_Income_Regular2-@PTKP )>0)
Begin
set @Taxable_Income_Regular2=@Nett_Income_Regular2-@PTKP
End
Else
Begin
set @Taxable_Income_Regular2=0
End

if((@Nett_Income_Regular3-@PTKP )>0)
Begin
set @Taxable_Income_Regular3=@Nett_Income_Regular3-@PTKP
End
Else
Begin
set @Taxable_Income_Regular3=0
End

if((@Nett_Income_Regular4-@PTKP )>0)
Begin
set @Taxable_Income_Regular4=@Nett_Income_Regular4-@PTKP
End
Else
Begin
set @Taxable_Income_Regular4=0
End

if((@Nett_Income_Regular5-@PTKP )>0)
Begin
set @Taxable_Income_Regular5=@Nett_Income_Regular5-@PTKP
End
Else
Begin
set @Taxable_Income_Regular5=0
End

if((@Nett_Income_Regular6-@PTKP )>0)
Begin
set @Taxable_Income_Regular6=@Nett_Income_Regular6-@PTKP
End
Else
Begin
set @Taxable_Income_Regular6=0
End

if((@Nett_Income_Regular7-@PTKP )>0)
Begin
set @Taxable_Income_Regular7=@Nett_Income_Regular7-@PTKP
End
Else
Begin
set @Taxable_Income_Regular7=0
End

if((@Nett_Income_Regular8-@PTKP )>0)
Begin
set @Taxable_Income_Regular8=@Nett_Income_Regular8-@PTKP
End
Else
Begin
set @Taxable_Income_Regular8=0
End

if((@Nett_Income_Regular9-@PTKP )>0)
Begin
set @Taxable_Income_Regular9=@Nett_Income_Regular9-@PTKP
End
Else
Begin
set @Taxable_Income_Regular9=0
End

if((@Nett_Income_Regular10-@PTKP )>0)
Begin
set @Taxable_Income_Regular10=@Nett_Income_Regular10-@PTKP
End
Else
Begin
set @Taxable_Income_Regular10=0
End

if((@Nett_Income_Regular11-@PTKP )>0)
Begin
set @Taxable_Income_Regular11=@Nett_Income_Regular11-@PTKP
End
Else
Begin
set @Taxable_Income_Regular11=0
End

if((@Nett_Income_Regular12-@PTKP )>0)
Begin
set @Taxable_Income_Regular12=@Nett_Income_Regular12-@PTKP
End
Else
Begin
set @Taxable_Income_Regular12=0
End


--End

  
--Taxable Income_IrRegular

---Positive balance value of (Nett Income Irregular - PTKP )   Note: if negative balance, display zero value
if((@Nett_Income_IRRegular1-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular1=@Nett_Income_IRRegular1-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular1=0
End

if((@Nett_Income_IRRegular2-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular2=@Nett_Income_IRRegular2-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular2=0
End

if((@Nett_Income_IRRegular3-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular3=@Nett_Income_IRRegular3-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular3=0
End

if((@Nett_Income_IRRegular4-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular4=@Nett_Income_IRRegular4-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular4=0
End

if((@Nett_Income_IRRegular5-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular5=@Nett_Income_IRRegular5-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular5=0
End

if((@Nett_Income_IRRegular6-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular6=@Nett_Income_IRRegular6-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular6=0
End

if((@Nett_Income_IRRegular7-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular7=@Nett_Income_IRRegular7-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular7=0
End

if((@Nett_Income_IRRegular8-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular8=@Nett_Income_IRRegular8-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular8=0
End

if((@Nett_Income_IRRegular9-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular9=@Nett_Income_IRRegular9-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular9=0
End

if((@Nett_Income_IRRegular10-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular10=@Nett_Income_IRRegular10-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular10=0
End

if((@Nett_Income_IRRegular11-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular11=@Nett_Income_IRRegular11-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular11=0
End

if((@Nett_Income_IRRegular12-@PTKP )>0)
Begin
set @Taxable_Income_IRRegular12=@Nett_Income_IRRegular12-@PTKP
End
Else
Begin
set @Taxable_Income_IRRegular12=0
End

if(@ActiveMonth=1)
Begin
set @Taxable_Income_Regular2=0
set @Taxable_Income_Regular3=0
set @Taxable_Income_Regular4=0
set @Taxable_Income_Regular5=0
set @Taxable_Income_Regular6=0
set @Taxable_Income_Regular7=0
set @Taxable_Income_Regular8=0
set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0

set @Taxable_Income_IRRegular2=0
set @Taxable_Income_IRRegular3=0
set @Taxable_Income_IRRegular4=0
set @Taxable_Income_IRRegular5=0
set @Taxable_Income_IRRegular6=0
set @Taxable_Income_IRRegular7=0
set @Taxable_Income_IRRegular8=0
set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End
if(@ActiveMonth=2)
Begin


set @Taxable_Income_Regular3=0
set @Taxable_Income_Regular4=0
set @Taxable_Income_Regular5=0
set @Taxable_Income_Regular6=0
set @Taxable_Income_Regular7=0
set @Taxable_Income_Regular8=0
set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0


set @Taxable_Income_IRRegular3=0
set @Taxable_Income_IRRegular4=0
set @Taxable_Income_IRRegular5=0
set @Taxable_Income_IRRegular6=0
set @Taxable_Income_IRRegular7=0
set @Taxable_Income_IRRegular8=0
set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End
if(@ActiveMonth=3)
Begin

set @Taxable_Income_Regular4=0
set @Taxable_Income_Regular5=0
set @Taxable_Income_Regular6=0
set @Taxable_Income_Regular7=0
set @Taxable_Income_Regular8=0
set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0


set @Taxable_Income_IRRegular4=0
set @Taxable_Income_IRRegular5=0
set @Taxable_Income_IRRegular6=0
set @Taxable_Income_IRRegular7=0
set @Taxable_Income_IRRegular8=0
set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End

if(@ActiveMonth=4)
Begin


set @Taxable_Income_Regular5=0
set @Taxable_Income_Regular6=0
set @Taxable_Income_Regular7=0
set @Taxable_Income_Regular8=0
set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0


set @Taxable_Income_IRRegular5=0
set @Taxable_Income_IRRegular6=0
set @Taxable_Income_IRRegular7=0
set @Taxable_Income_IRRegular8=0
set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End

if(@ActiveMonth=5)
Begin


set @Taxable_Income_Regular6=0
set @Taxable_Income_Regular7=0
set @Taxable_Income_Regular8=0
set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0


set @Taxable_Income_IRRegular6=0
set @Taxable_Income_IRRegular7=0
set @Taxable_Income_IRRegular8=0
set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End

if(@ActiveMonth=6)
Begin

set @Taxable_Income_Regular7=0
set @Taxable_Income_Regular8=0
set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0



set @Taxable_Income_IRRegular7=0
set @Taxable_Income_IRRegular8=0
set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End


if(@ActiveMonth=7)
Begin


set @Taxable_Income_Regular8=0
set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0



set @Taxable_Income_IRRegular8=0
set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End


if(@ActiveMonth=8)
Begin


set @Taxable_Income_Regular9=0
set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0



set @Taxable_Income_IRRegular9=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End


if(@ActiveMonth=9)
Begin

set @Taxable_Income_Regular10=0
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0
set @Taxable_Income_IRRegular10=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End
if(@ActiveMonth=10)
Begin
set @Taxable_Income_Regular11=0
set @Taxable_Income_Regular12=0
set @Taxable_Income_IRRegular11=0
set @Taxable_Income_IRRegular12=0
End
if(@ActiveMonth=11)
Begin
set @Taxable_Income_Regular12=0
set @Taxable_Income_IRRegular12=0
End



Exec [Checkroll].[TaxDetTax_IncomeDML]
@EstateID ,
@PTKP,
@Gross_Income_Regular1 ,
@Gross_Income_Regular2 ,
@Gross_Income_Regular3 ,
@Gross_Income_Regular4 ,
@Gross_Income_Regular5 ,
@Gross_Income_Regular6 ,
@Gross_Income_Regular7 ,
@Gross_Income_Regular8 ,
@Gross_Income_Regular9 ,
@Gross_Income_Regular10 ,
@Gross_Income_Regular11 ,
@Gross_Income_Regular12 ,
@Gross_Income_Irregular1  ,
@Gross_Income_Irregular2  ,
@Gross_Income_Irregular3  ,
@Gross_Income_Irregular4  ,
@Gross_Income_Irregular5  ,
@Gross_Income_Irregular6  ,
@Gross_Income_Irregular7  ,
@Gross_Income_Irregular8  ,
@Gross_Income_Irregular9  ,
@Gross_Income_Irregular10  ,
@Gross_Income_Irregular11  ,
@Gross_Income_Irregular12  ,
@FunctionalAllowanceP ,
@Nett_Income_Regular1 ,
@Nett_Income_Regular2 ,
@Nett_Income_Regular3 ,
@Nett_Income_Regular4 ,
@Nett_Income_Regular5 ,
@Nett_Income_Regular6 ,
@Nett_Income_Regular7 ,
@Nett_Income_Regular8 ,
@Nett_Income_Regular9 ,
@Nett_Income_Regular10 ,
@Nett_Income_Regular11 ,
@Nett_Income_Regular12 ,
@Nett_Income_IRRegular1 ,
@Nett_Income_IRRegular2 ,
@Nett_Income_IRRegular3 ,
@Nett_Income_IRRegular4 ,
@Nett_Income_IRRegular5 ,
@Nett_Income_IRRegular6 ,
@Nett_Income_IRRegular7 ,
@Nett_Income_IRRegular8 ,
@Nett_Income_IRRegular9 ,
@Nett_Income_IRRegular10 ,
@Nett_Income_IRRegular11 ,
@Nett_Income_IRRegular12 ,
@ARJan ,
@ARFeb ,
@ARMar ,
@ARAPr ,
@ARMay ,
@ARJun ,
@ARJul ,
@ARAug ,
@ARSep ,
@AROct ,
@ARNov ,
@ARDec ,
@AIJan ,
@AIFeb ,
@AIMar ,
@AIAPr ,
@AIMay ,
@AIJun ,
@AIJul ,
@AIAug ,
@AISep ,
@AIOct ,
@AINov ,
@AIDec ,
@AFJan ,
@AFFeb ,
@AFMar ,
@AFAPr ,
@AFMay ,
@AFJun ,
@AFJul ,
@AFAug ,
@AFSep ,
@AFOct ,
@AFNov ,
@AFDec ,  
@ALurJan ,
@ALurFeb ,
@ALurMar ,
@ALurAPr ,
@ALurMay ,
@ALurJun ,
@ALurJul ,
@ALurAug ,
@ALurSep ,
@ALurOct ,
@ALurNov ,
@ALurDec ,  
@Taxable_Income_Regular1 ,
@Taxable_Income_Regular2 ,
@Taxable_Income_Regular3 ,
@Taxable_Income_Regular4 ,
@Taxable_Income_Regular5 ,
@Taxable_Income_Regular6 ,
@Taxable_Income_Regular7 ,
@Taxable_Income_Regular8 ,
@Taxable_Income_Regular9 ,
@Taxable_Income_Regular10 ,
@Taxable_Income_Regular11 ,
@Taxable_Income_Regular12 ,
@Taxable_Income_Irregular1 ,
@Taxable_Income_Irregular2 ,
@Taxable_Income_Irregular3 ,
@Taxable_Income_Irregular4 ,
@Taxable_Income_Irregular5 ,
@Taxable_Income_Irregular6 ,
@Taxable_Income_Irregular7 ,
@Taxable_Income_Irregular8 ,
@Taxable_Income_Irregular9 ,
@Taxable_Income_Irregular10 ,
@Taxable_Income_Irregular11 ,
@Taxable_Income_Irregular12 ,
@EmpID ,
@ActiveMonthYearID1 ,
@ActiveMonthYearID2 ,
@ActiveMonthYearID3 ,
@ActiveMonthYearID4 ,
@ActiveMonthYearID5 ,
@ActiveMonthYearID6 ,
@ActiveMonthYearID7 ,
@ActiveMonthYearID8 ,
@ActiveMonthYearID9 ,
@ActiveMonthYearID10 ,
@ActiveMonthYearID11 ,
@ActiveMonthYearID12 ,
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
@MaxAllowance,
@StatusDate,
-- Palani
@ActiveMonthYearID

select @Taxable_Income_Irregular1 as Taxable_Income_Irregular1 ,@Taxable_Income_IRRegular2 as Taxable_Income_IRRegular2,
@Taxable_Income_IRRegular3 as Taxable_Income_IRRegular3,@Taxable_Income_IRRegular4 as Taxable_Income_IRRegular4,
@Taxable_Income_IRRegular5 as Taxable_Income_IRRegular5,@Taxable_Income_IRRegular6 as Taxable_Income_IRRegular6,
@Taxable_Income_IRRegular7 as Taxable_Income_IRRegular7,@Taxable_Income_IRRegular8 as Taxable_Income_IRRegular8,
@Taxable_Income_IRRegular9 as Taxable_Income_IRRegular9,@Taxable_Income_IRRegular10 as Taxable_Income_IRRegular10,
@Taxable_Income_IRRegular11 as Taxable_Income_IRRegular11,@Taxable_Income_IRRegular12 as Taxable_Income_IRRegular12,

@Taxable_Income_Regular1 as Taxable_Income_Regular1,@Taxable_Income_Regular2 as Taxable_Income_Regular2,
@Taxable_Income_Regular3 as Taxable_Income_Regular3,@Taxable_Income_Regular4 as Taxable_Income_Regular4,
@Taxable_Income_Regular5 as Taxable_Income_Regular5,@Taxable_Income_Regular6 as Taxable_Income_Regular6,
@Taxable_Income_Regular7 as Taxable_Income_Regular7,@Taxable_Income_Regular8 as Taxable_Income_Regular8,
@Taxable_Income_Regular9 as Taxable_Income_Regular9,@Taxable_Income_Regular10 as Taxable_Income_Regular10,
@Taxable_Income_Regular11 as Taxable_Income_Regular11,@Taxable_Income_Regular12 as Taxable_Income_Regular12,

@Gross_Income_regular1 as Gross_Income_Regular1,
@Gross_Income_regular2 as Gross_Income_Regular2,
@Gross_Income_regular3 as Gross_Income_Regular3,
@Gross_Income_regular4 as Gross_Income_Regular4,
@Gross_Income_regular5 as Gross_Income_Regular5,
@Gross_Income_regular6 as Gross_Income_Regular6,
@Gross_Income_regular7 as Gross_Income_Regular7,
@Gross_Income_regular8 as Gross_Income_Regularr8,
@Gross_Income_regular9 as Gross_Income_Regular9,
@Gross_Income_regular10 as Gross_Income_Regular10,
@Gross_Income_regular11 as Gross_Income_Regular11,
@Gross_Income_regular12 as Gross_Income_Regular12,

@Gross_Income_Irregular1 as grossirr1,
@Gross_Income_Irregular2 as grossirr2,
@Gross_Income_Irregular3 as grossirr3,
@Gross_Income_Irregular4 as grossirr4,
@Gross_Income_Irregular5 as grossirr5,
@Gross_Income_Irregular6 as grossirr6,
@Gross_Income_Irregular7 as grossirr7,
@Gross_Income_Irregular8 as grossirr8,
@Gross_Income_Irregular9 as grossirr9,
@Gross_Income_Irregular10 as grossirr10,
@Gross_Income_Irregular11 as grossirr11,
@Gross_Income_Irregular12 as grossirr12,

@Nett_Income_Regular1 as Nett_Income_Regular1,
@Nett_Income_Regular2 as Nett_Income_Regular2,
@Nett_Income_Regular3 as Nett_Income_Regular3,
@Nett_Income_Regular4 as Nett_Income_Regular4,
@Nett_Income_Regular5 as Nett_Income_Regular5,
@Nett_Income_Regular6 as Nett_Income_Regular6,
@Nett_Income_Regular7 as Nett_Income_Regular7,
@Nett_Income_Regular8 as Nett_Income_Regular8,
@Nett_Income_Regular9 as Nett_Income_Regular9,
@Nett_Income_Regular10 as Nett_Income_Regular10,
@Nett_Income_Regular11  as Nett_Income_Regular11,
@Nett_Income_Regular12 as Nett_Income_Regular12,

@Nett_Income_IRRegular1 as Nett_Income_IRRegular1,
@Nett_Income_IRRegular2 as Nett_Income_IRRegular2,
@Nett_Income_IRRegular3 as Nett_Income_IRRegular3,
@Nett_Income_IRRegular4 as Nett_Income_IRRegular4,
@Nett_Income_IRRegular5 as Nett_Income_IRRegular5,
@Nett_Income_IRRegular6 as Nett_Income_IRRegular6,
@Nett_Income_IRRegular7 as Nett_Income_IRRegular7,
@Nett_Income_IRRegular8 as Nett_Income_IRRegular8,
@Nett_Income_IRRegular9 as Nett_Income_IRRegular9,
@Nett_Income_IRRegular10 as Nett_Income_IRRegular10,
@Nett_Income_IRRegular11  as Nett_Income_IRRegular11,
@Nett_Income_IRRegular12 as Nett_Income_IRRegular12,


@Accident_Insurance1 as Accident_Insurance1,
@Accident_Insurance2 as Accident_Insurance2,
@Accident_Insurance3 as Accident_Insurance3,
@Accident_Insurance4 as Accident_Insurance4,
@Accident_Insurance5 as Accident_Insurance5,
@Accident_Insurance6 as Accident_Insurance6,
@Accident_Insurance7 as Accident_Insurance7,
@Accident_Insurance8 as Accident_Insurance8,
@Accident_Insurance9 as Accident_Insurance9,
@Accident_Insurance10 as Accident_Insurance10,
@Accident_Insurance11  as Accident_Insurance11,
@Accident_Insurance12 as Accident_Insurance12,
@ARJan as ARJan,@ARFeb as ARFeb,@ARMar as ARMar,@ARAPr as ARApr,@ARMay as ARMay,@ARJun as ARJun,@ARJul as ARJul,
@ARAug as ARAug,@ARSep as ARSep,@AROct as AROct,@ARNov as ARNov,@ARDec as ARDec,
@AIJan as AIJan,@AIFeb as AIFeb,@AIMar as AIMar,@AIAPr as AIApr,@AIMay as AIMay,@AIJun as AIJun,@AIJul as AIJul,
@AIAug as AIAug,@AISep as AISep,@AIOct as AIOct,@AINov as AINov,@AIDec as AIDec,
@AFJan as AFJan,@AFFeb as AFFeb,@AFMar as AFMar,@AFAPr as AFApr,@AFMay as AFMay,@AFJun as AFJun,@AFJul as AFJul,
@AFAug as AFAug,@AFSep as AFSep,@AFOct as AFOct,@AFNov as AFNov,@AFDec as AFDec,
@PTKP as PTKP,@JHTPercent as JHTPercent,
@ALurJan  as ALurJan,@ALurFeb as ALurFeb,@ALurMar as ALurMar,@ALurAPr as ALurAPr,@ALurMay as ALurMay,@ALurJun as ALurJun ,
@ALurJul as ALurJul ,@ALurAug as ALurAug,@ALurSep as ALurSep,@ALurOct as ALurOct,@ALurNov as ALurNov,@ALurDec  as ALurDec ,
@ActiveMonthYearID 

