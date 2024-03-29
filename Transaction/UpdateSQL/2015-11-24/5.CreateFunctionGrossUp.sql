
/****** Object:  UserDefinedFunction [Checkroll].[GetTaxRate]    Script Date: 25/11/2015 4:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	Checks The TaxandRiceSetup Range and returns tax payable
-- =============================================
CREATE FUNCTION [Checkroll].[GetTaxRateGrossUp]
(
	-- Add the parameters for the function here
	@TaxValue numeric(18,4),
	@HasNPWP char(1),
	@EstateId nvarchar(50)
)
RETURNS numeric(18,4)
AS
BEGIN
	
DECLARE @GradeI numeric(18,2)
DECLARE @GradeIRange numeric(18,2)
DECLARE @GradeII numeric(18,2)
DECLARE @GradeIIRangeFrom numeric(18,2)
DECLARE @GradeIIRangeTo numeric(18,2)
DECLARE @GradeIII numeric(18,2)
DECLARE @GradeIIIRangeFrom numeric(18,2)
DECLARE @GradeIIIRangeTo numeric(18,2)
DECLARE @GradeIV numeric(18,2)
DECLARE @GradeIVRangeFrom numeric(18,2)
DECLARE @GradeIVRangeTo numeric(18,2)
DECLARE @GradeV numeric(18,2)
DECLARE @GradeVRange numeric(18,2)
DECLARE @GradeINPWP numeric(18,2)
DECLARE @GradeIRangeNPWP numeric(18,2)
DECLARE @GradeIINPWP numeric(18,2)
DECLARE @GradeIIRangeFromNPWP numeric(18,2)
DECLARE @GradeIIRangeToNPWP numeric(18,2)
DECLARE @GradeIIINPWP numeric(18,2)
DECLARE @GradeIIIRangeFromNPWP numeric(18,2)
DECLARE @GradeIIIRangeToNPWP numeric(18,2)
DECLARE @GradeIVNPWP numeric(18,2)
DECLARE @GradeIVRangeFromNPWP numeric(18,2)
DECLARE @GradeIVRangeToNPWP numeric(18,2)
DECLARE @GradeVNPWP numeric(18,2)
DECLARE @GradeVRangeNPWP numeric(18,2)



-- NEw GRade Ranges after adjusted calculation
DECLARE @NewGradeINPWP numeric(18,2)
DECLARE @NewGradeIRangeNPWP numeric(18,2)
DECLARE @NewGradeIINPWP numeric(18,2)
DECLARE @NewGradeIIRangeFromNPWP numeric(18,2)
DECLARE @NewGradeIIRangeToNPWP numeric(18,2)
DECLARE @NewGradeIIINPWP numeric(18,2)
DECLARE @NewGradeIIIRangeFromNPWP numeric(18,2)
DECLARE @NewGradeIIIRangeToNPWP numeric(18,2)
DECLARE @NewGradeIVNPWP numeric(18,2)
DECLARE @NewGradeIVRangeFromNPWP numeric(18,2)
DECLARE @NewGradeIVRangeToNPWP numeric(18,2)
DECLARE @NewGradeVNPWP numeric(18,2)
DECLARE @NewGradeVRangeNPWP numeric(18,2)

DECLARE @NewGradeI numeric(18,2)
DECLARE @NewGradeIRange numeric(18,2)
DECLARE @NewGradeII numeric(18,2)
DECLARE @NewGradeIIRangeFrom numeric(18,2)
DECLARE @NewGradeIIRangeTo numeric(18,2)
DECLARE @NewGradeIII numeric(18,2)
DECLARE @NewGradeIIIRangeFrom numeric(18,2)
DECLARE @NewGradeIIIRangeTo numeric(18,2)
DECLARE @NewGradeIV numeric(18,2)
DECLARE @NewGradeIVRangeFrom numeric(18,2)
DECLARE @NewGradeIVRangeTo numeric(18,2)
DECLARE @NewGradeV numeric(18,2)
DECLARE @NewGradeVRange numeric(18,2)



DECLARE @TaxPayable numeric(18,2)

Select
@GradeI = GradeI,@GradeIRange= GradeIRange,
@GradeII=GradeII,@GradeIIRangeFrom=GradeIIRangeFrom,@GradeIIRangeTo=GradeIIRangeTo,@GradeIII=GradeIII,
@GradeIIIRangeFrom=GradeIIIRangeFrom,
@GradeIIIRangeTo=GradeIIIRangeTo,
@GradeIV=GradeIV,
@GradeIVRangeFrom=GradeIVRangeFrom,
@GradeIVRangeTo=GradeIVRangeTo,
@GradeV=GradeV,
@GradeVRange=GradeVRange,
@GradeINPWP = GradeINPWP,@GradeIRangeNPWP= GradeIRangeNPWP,
@GradeIINPWP=GradeIINPWP,@GradeIIRangeFromNPWP=GradeIIRangeFromNPWP,
@GradeIIRangeToNPWP=GradeIIRangeToNPWP,
@GradeIIINPWP=GradeIIINPWP,
@GradeIIIRangeFromNPWP=GradeIIIRangeFromNPWP,
@GradeIIIRangeToNPWP=GradeIIIRangeToNPWP,
@GradeIVNPWP=GradeIVNPWP,
@GradeIVRangeFromNPWP=GradeIVRangeFromNPWP,
@GradeIVRangeToNPWP=GradeIVRangeToNPWP,
@GradeVNPWP=GradeVNPWP,
@GradeVRangeNPWP=GradeVRangeNPWP 
from Checkroll.TaxAndRiceSetup where EstateID = @EstateId


--This is to calculate gross up value, formula taken form the following link
--http://arsyrevandi.blogspot.co.id/2013/04/menghitung-pph-pasal-21-gross-up-dengan.html

-- First Calculate the new ranges based on formula below

Set @NewGradeIRangeNPWP = ((100 - @GradeINPWP)/@GradeINPWP) * (@GradeINPWP * @GradeIRangeNPWP / 100)

Set @NewGradeIIRangeToNPWP = ((100 - @GradeIINPWP)/@GradeIINPWP) * ((@GradeIIRangeToNPWP- @GradeIRangeNPWP) * @GradeIINPWP / 100)
set @NewGradeIIRangeToNPWP = @NewGradeIIRangeToNPWP + @NewGradeIRangeNPWP

Set @NewGradeIIIRangeToNPWP = ((100 - @GradeIIINPWP)/@GradeIIINPWP) * ((@GradeIIIRangeToNPWP- @GradeIIRangeToNPWP) * @GradeIIINPWP / 100)
Set @NewGradeIIIRangeToNPWP = @NewGradeIIIRangeToNPWP +  @NewGradeIIRangeToNPWP 

Set @NewGradeIVRangeToNPWP = ((100 - @GradeIVNPWP)/@GradeIVNPWP) * ((@GradeIVRangeToNPWP- @GradeIIIRangeToNPWP) * @GradeIVNPWP / 100)
Set @NewGradeIVRangeToNPWP = @NewGradeIVRangeToNPWP +  @NewGradeIIIRangeToNPWP 

Set @NewGradeVRangeNPWP = ((100 - @GradeVNPWP)/@GradeVNPWP) * ((@GradeVRangeNPWP- @GradeIVRangeToNPWP) * @GradeVNPWP / 100)
Set @NewGradeVRangeNPWP = @NewGradeVRangeNPWP +  @NewGradeIVRangeToNPWP 


Set @NewGradeIRange = ((100 - @GradeI)/@GradeI) * (@GradeI * @GradeIRange / 100)

Set @NewGradeIIRangeTo = ((100 - @GradeII)/@GradeII) * ((@GradeIIRangeTo- @GradeIRange) * @GradeII / 100)
set @NewGradeIIRangeTo = @NewGradeIIRangeTo + @NewGradeIRange

Set @NewGradeIIIRangeTo = ((100 - @GradeIII)/@GradeIII) * ((@GradeIIIRangeTo- @GradeIIRangeTo) * @GradeIII / 100)
Set @NewGradeIIIRangeTo = @NewGradeIIIRangeTo +  @NewGradeIIRangeTo

Set @NewGradeIVRangeTo = ((100 - @GradeIV)/@GradeIV) * ((@GradeIVRangeTo- @GradeIIIRangeTo) * @GradeIV / 100)
Set @NewGradeIVRangeTo = @NewGradeIVRangeTo +  @NewGradeIIIRangeTo 



--Some fucking idot when a messed up the checkroll tax and rice setup saving, now non npwp range saves as npwp and vice versa
if @HasNPWP  = 'N' 
	begin
		Set @TaxPayable = 
		 case 
			WHEN @TaxValue <= @GradeIRangeNPWP THEN  @TaxValue * @GradeINPWP / (100 - @GradeINPWP)
			WHEN @TaxValue > @GradeIIRangeFromNPWP and @TaxValue <= @GradeIIRangeToNPWP THEN @TaxValue * @GradeIINPWP / 100
			WHEN @TaxValue > @GradeIIIRangeFromNPWP and @TaxValue <= @GradeIIIRangeToNPWP THEN @TaxValue * @GradeIIINPWP / 100
			WHEN @TaxValue > @GradeIVRangeFromNPWP and @TaxValue <= @GradeIVRangeToNPWP THEN @TaxValue * @GradeIVNPWP / 100
			WHEN @TaxValue > @GradeIVRangeFromNPWP and @TaxValue <= @GradeIVRangeToNPWP THEN @TaxValue * @GradeVNPWP / 100
			ELSE 0
		end
	end
else
	begin
		Set @TaxPayable = 
		 case 
			WHEN @TaxValue <= @NewGradeIRange THEN @TaxValue * @GradeI / (100 - @GradeI)
			WHEN @TaxValue > @NewGradeIRange and @TaxValue <= @NewGradeIIRangeTo THEN (@TaxValue - @NewGradeIRange)  * @GradeII / (100 - @GradeII)
			WHEN @TaxValue > @NewGradeIIRangeTo and @TaxValue <= @NewGradeIIIRangeTo THEN (@TaxValue -@NewGradeIIRangeTo) * @GradeIII / (100 - @GradeIII)
			WHEN @TaxValue > @NewGradeIIIRangeTo THEN (@TaxValue - @NewGradeIIIRangeTo )  * @GradeIV / (100 - @GradeIV)
			ELSE 0
		end
	end
Return @TaxPayable
END
