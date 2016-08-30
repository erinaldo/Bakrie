

/****** Object:  StoredProcedure [Checkroll].[CRPieceRateReport]    Script Date: 29/10/2015 4:05:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[CRPieceRateReport]
	-- Add the parameters for the stored procedure here
	@ActiveMonthYearId nvarchar(50)
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN
	DECLARE @DateFrom datetime
	DECLARE @DateTo datetime
	
	select @DateFrom=FromDT,@DateTo=ToDT from General.ActiveMonthYear AM 
	inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
	where am.ActiveMonthYearID = @ActiveMonthYearId
	
		SELECT  
		EmpCode, EmpName, c.ReferenceNo, d.Description, BlockName, YOP, UnitCompleted, JobRate, (UnitCompleted*JobRate) as TotalPaid, a.Remarks,a.date as transdate
		FROM [Checkroll].[PieceRateTransaction] a
		INNER JOIN [Checkroll].[CREmployee] b ON b.EmpId = a.EmpID
		LEFT JOIN [Checkroll].[PieceRateActivity] c ON c.Id = a.PieceRateActivityId
		LEFT JOIN [Checkroll].[PieceRate] d ON d.ReferenceNo = c.ReferenceNo
		LEFT JOIN [General].[BlockMaster] e ON e.BlockID = c.BlockID
		LEFT JOIN [General].[YOP] f ON f.YOPID = e.YOPID
	    WHERE  CONVERT(VARCHAR(10),a.Date,111)  Between CONVERT(VARCHAR(10),@DateFrom,111) and CONVERT(VARCHAR(10),@DateTo,111)
		Order bY a.Date

		
	END

---------------------------

GO


