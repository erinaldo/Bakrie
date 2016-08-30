
/****** Object:  StoredProcedure [Checkroll].[PieceRateSelect]    Script Date: 7/3/2016 1:25:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ahmed Naxim
-- Alter date: 6 Oct 2012
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[PieceRateSelectMaster]
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50),
	@ReferenceNo nvarchar(50) = null,
	@ActiveMonthYearID nvarchar(50) = ''
	
AS

	SET NOCOUNT ON;
DECLARE @from date
DECLARE @until date
select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where ActiveMonthYearID = @ActiveMonthYearId

IF (@ReferenceNo IS NULL)
	BEGIN
		SELECT   DISTINCT     Checkroll.PieceRate.Id, Checkroll.PieceRate.ReferenceNo, Checkroll.PieceRate.EstateID, Checkroll.PieceRate.ActivityBy, Checkroll.PieceRate.Description, 
                         Checkroll.PieceRate.AllowanceDeductionCode, Checkroll.AllowanceDeductionSetup.Remarks,Checkroll.PieceRate.COAID
FROM            Checkroll.PieceRate LEFT OUTER JOIN
                         Checkroll.AllowanceDeductionSetup ON Checkroll.PieceRate.AllowanceDeductionCode = Checkroll.AllowanceDeductionSetup.AllowDedID AND 
                         Checkroll.PieceRate.EstateID = Checkroll.AllowanceDeductionSetup.EstateID
				left join Checkroll.PieceRateActivity ON Checkroll.PieceRate.ReferenceNo = Checkroll.PieceRateActivity.ReferenceNo
		WHERE 
			[Checkroll].[PieceRate].EstateID = @EstateID 
		Order By [Checkroll].[PieceRate].Id Desc
	END
ELSE 
	BEGIN		
		SELECT    DISTINCT    Checkroll.PieceRate.Id, Checkroll.PieceRate.ReferenceNo, Checkroll.PieceRate.EstateID, Checkroll.PieceRate.ActivityBy, Checkroll.PieceRate.Description, 
                         Checkroll.PieceRate.AllowanceDeductionCode, Checkroll.AllowanceDeductionSetup.Remarks,Checkroll.PieceRate.COAID
FROM            Checkroll.PieceRate LEFT OUTER JOIN
                         Checkroll.AllowanceDeductionSetup ON Checkroll.PieceRate.AllowanceDeductionCode = Checkroll.AllowanceDeductionSetup.AllowDedID AND 
                         Checkroll.PieceRate.EstateID = Checkroll.AllowanceDeductionSetup.EstateID
				left join Checkroll.PieceRateActivity ON Checkroll.PieceRate.ReferenceNo = Checkroll.PieceRateActivity.ReferenceNo
		WHERE 
			[Checkroll].[PieceRate].EstateID = @EstateID AND 
			[Checkroll].[PieceRate].ReferenceNo = @ReferenceNo
		Order By [Checkroll].[PieceRate].ReferenceNo Asc
	END
