
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorInsert]    Script Date: 23/12/2014 16:02:57 ******/
DROP PROCEDURE [Checkroll].[DailyAttendanceMandorInsert]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceMandorInsert]    Script Date: 23/12/2014 16:02:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyAttendanceMandorInsert]
	-- Add the parameters for the stored procedure here
	@EstateID	as nvarchar(50),
	@ActiveMonthYearID	as nvarchar(50),
	@RDate	as datetime,
	@EmpID	as nvarchar(50),
	@AttendanceSetupID as	nvarchar(50),
	@DailyOT as int,
	@CreatedBy as	nvarchar(50),
	@CreatedOn as	datetime,
	@ModifiedBy as	nvarchar(50),
	@ModifiedOn	as datetime
AS
BEGIN TRY

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Checkroll.DailyAttendanceMandor(
	EstateID, 
	ActiveMonthYearID, 
	RDate, 
	EmpID, 
	AttendanceSetupID, 
	DailyOt,
	CreatedBy, 
	CreatedOn, 
	ModifiedBy, 
	ModifiedOn)
	VALUES(
	@EstateID,
	@ActiveMonthYearID,
	@RDate,
	@EmpID,
	@AttendanceSetupID,
	@DailyOT,
	@CreatedBy,
	@CreatedOn,
	@ModifiedBy,
	@ModifiedOn
	)

END TRY
BEGIN CATCH
DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    
    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

	RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH


GO


