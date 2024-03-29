
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[TaxAndRiceSetupSelect]
-- Add the parameters for the stored procedure here
@EstateID NVARCHAR(50)
AS
        SET NOCOUNT ON;
        BEGIN
                SELECT   TaxRiceSetupID       ,
                         DeductionCost        ,
                         DeductionCostMax     ,
                         Jamsostek            ,
                         JkkAndJK             ,
                         RAEmployee           ,
                         RAHusbandOrWife      ,
                         RAChild              ,
                         RAPrice              ,
                         GradeI               ,
                         GradeIRange          ,
                         GradeII              ,
                         GradeIIRangeFrom     ,
                         GradeIIRangeTo       ,
                         GradeIII             ,
                         GradeIIIRangeFrom    ,
                         GradeIIIRangeTo      ,
                         GradeIV              ,
                         GradeIVRangeFrom     ,
                         GradeIVRangeTo       ,
                         GradeV               ,
                         GradeVRange          ,
                         GradeINPWP           ,
                         GradeIRangeNPWP      ,
                         GradeIINPWP          ,
                         GradeIIRangeFromNPWP ,
                         GradeIIRangeToNPWP   ,
                         GradeIIINPWP         ,
                         GradeIIIRangeFromNPWP,
                         GradeIIIRangeToNPWP  ,
                         GradeIVNPWP          ,
                         GradeIVRangeFromNPWP ,
                         GradeIVRangeToNPWP   ,
                         GradeVNPWP           ,
                         GradeVRangeNPWP      ,
                         TaxExemptionWorker   ,
                         TaxExemptionHusbWife ,
                         TaxExemptionChild    ,
                         FunctionalAllowanceP ,
                         MaxAllowance,
						 RANaturaPrice,
						 RAAstekPrice,
						 MeatPrice
                FROM     Checkroll.TaxAndRiceSetup
                WHERE    EstateID =@EstateID
                ORDER BY ModifiedOn DESC
        END

