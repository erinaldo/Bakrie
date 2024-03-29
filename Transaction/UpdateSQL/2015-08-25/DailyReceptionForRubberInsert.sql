
/****** Object:  StoredProcedure [Checkroll].[DailyReceptionForRubberInsert]    Script Date: 1/9/2015 7:38:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Checkroll].[DailyReceptionForRubberInsert]
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
	@DailyReceiptionID varchar(50),
	@TeamId nvarchar(50)

AS

BEGIN TRY

BEGIN
	DECLARE 
	@DRRubberID varchar(50), @result as varchar(50),
	@i INT = 2,@PremiDasar money=0,@PremiProgresif money =0 ,@PremiBonus money =0  , @PremiMinggu money=0
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
						
	

	--if(@AttCode ='11')
	--	begin		
	--		set @PremiDasar =@PremiDasar+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@Drc,'Latex','D')
	--		set @PremiProgresif =@PremiProgresif+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@Drc,'Latex','P')
	--		set @PremiBonus = @PremiBonus+[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@Drc,'Latex','B')

	--		set @PremiDasar =@PremiDasar+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','D')
	--		set @PremiProgresif =@PremiProgresif+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','P')
	--		set @PremiBonus = @PremiBonus+[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','B')

	--		set @PremiDasar =@PremiDasar+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','D')
	--		set @PremiProgresif =@PremiProgresif+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','P')
	--		set @PremiBonus = @PremiBonus+[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','B')
	--	end 
	--else if(@AttCode ='M1')
	--	begin
	--		set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@DRC,'Latex','M')
	--		set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','M')
	--		set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','M')
	--	end
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



