SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	Checks The TaxandRiceSetup Range and returns tax payable
-- =============================================
CREATE FUNCTION Checkroll.GetTaxRate
(
	-- Add the parameters for the function here
	@TaxValue numeric(18,3),
	@HasNPWP char(1),
	@EstateId nvarchar(50)
)
RETURNS numeric(18,3)
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

--Because some idiot save the master values wrongly so npwp values are saved in non npwp range
if @HasNPWP  = 'N' 
	begin
		Set @TaxPayable = 
		 case 
			WHEN @TaxValue <= @GradeIRangeNPWP THEN @TaxValue * @GradeINPWP / 100
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
			WHEN @TaxValue <= @GradeIRange THEN @TaxValue * @GradeI / 100
			WHEN @TaxValue > @GradeIIRangeFrom and @TaxValue <= @GradeIIRangeTo THEN @TaxValue * @GradeII / 100
			WHEN @TaxValue > @GradeIIIRangeFrom and @TaxValue <= @GradeIIIRangeTo THEN @TaxValue * @GradeIII / 100
			WHEN @TaxValue > @GradeIVRangeFrom and @TaxValue <= @GradeIVRangeTo THEN @TaxValue * @GradeIV / 100
			WHEN @TaxValue > @GradeIVRangeFrom and @TaxValue <= @GradeIVRangeTo THEN @TaxValue * @GradeV / 100
			ELSE 0
		end
	end
Return @TaxPayable
END
GO

