/****** Object:  StoredProcedure [Checkroll].[CRPieceRateReport]    Script Date: 28/10/2015 11:14:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Checkroll].[CRPieceRateReport]
	-- Add the parameters for the stored procedure here
	--@EmpID nvarchar(50),
	@DateFrom smalldatetime,
	@DateTo smalldatetime
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	BEGIN
		
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
