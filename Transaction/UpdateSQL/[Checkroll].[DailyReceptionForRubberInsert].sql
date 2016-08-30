
GO

/****** Object:  StoredProcedure [Checkroll].[DailyReceptionForRubberInsert]    Script Date: 16/12/2014 8:37:51 ******/
DROP PROCEDURE [Checkroll].[DailyReceptionForRubberInsert]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyReceptionForRubberInsert]    Script Date: 16/12/2014 8:37:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyReceptionForRubberInsert]
	-- Add the parameters for the stored procedure here
	@DateRubber datetime,
	@NIK varchar(50),
	@Name varchar(100),
	@AttCode varchar(50),
	@Location varchar(100),
	@OTHour varchar(50),
	@Afdeling varchar(50),
	@YOP varchar(50),
	@FieldNo varchar(50),
	@TPH varchar(50),
	@Latex float,
	@CupLamp float,
	@TreeLace float,
	@Coaglum float,
	@DRC float,
	@DRCCupLump float,
	@DRCTreeLace float,
	@DRCCoaglum float,
	@EstateCode nvarchar(50),
	@DailyReceiptionID varchar(50)

AS

BEGIN TRY

BEGIN
	DECLARE 
	@DRRubberID varchar(50), @result as varchar(50),
	@i INT = 2
                        SELECT @DRRubberID= @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                        FROM   Checkroll.DailyReceptionForRubber
                        WHILE EXISTS
                        (SELECT id
                        FROM    Checkroll.DailyReceptionForRubber
                        WHERE   DRRubberID  = @DRRubberID
                        )
                        BEGIN
                                SELECT @DRRubberID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                                FROM   Checkroll.DailyReceptionForRubber
                                SET @i = @i + 1
						END						
						
						 
	INSERT INTO Checkroll.DailyReceptionForRubber 
	(
	DailyReceiptionID,
	DRRubberID,
	DateRubber,
	NIK,
	Name,
	AttCode,
	Location,
	OTHour,
	Afdeling,
	YOP,
	FieldNo,
	TPH,
	Latex,
	CupLamp,
	TreeLace,
	COAglum,
	DRC,
	DRCCupLump,
	DRCTreeLace,
	DRCCOAglum
	) VALUES 
	(
	@DailyReceiptionID,
	@DRRubberID,
	@DateRubber,
	@NIK,
	@Name,
	@AttCode,
	@Location,
	@OTHour,
	@Afdeling,
	@YOP,
	@FieldNo,
	@TPH,
	@Latex,
	@CupLamp,
	@TreeLace,
	@Coaglum,
	@DRC,
	@DRCCupLump,
	@DRCTreeLace,
	@DRCCoaglum
	)
END

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


