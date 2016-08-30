
GO

/****** Object:  StoredProcedure [Checkroll].[DailyReceptionForRubberSelect]    Script Date: 16/03/2015 10:37:18 ******/
DROP PROCEDURE [Checkroll].[DailyReceptionForRubberSelect]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyReceptionForRubberSelect]    Script Date: 16/03/2015 10:37:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [Checkroll].[DailyReceptionForRubberSelect] 
	-- Add the parameters for the stored procedure here
	@DailyReceiptionID AS VARCHAR(50)
AS
BEGIN
SELECT        Checkroll.DailyReceptionForRubber.NIK, Checkroll.DailyReceptionForRubber.Name, Checkroll.DailyReceptionForRubber.AttCode, 
                         Checkroll.DailyReceptionForRubber.Location, Checkroll.DailyReceptionForRubber.OTHour, Checkroll.DailyReceptionForRubber.Afdeling AS Afdelling, 
                         Checkroll.DailyReceptionForRubber.YOP, Checkroll.DailyReceptionForRubber.FieldNo, Checkroll.DailyReceptionForRubber.TPH, 
                         Checkroll.DailyReceptionForRubber.Latex, Checkroll.DailyReceptionForRubber.CupLamp AS CupLump, Checkroll.DailyReceptionForRubber.TreeLace, 
                         Checkroll.DailyReceptionForRubber.DailyReceiptionID, Checkroll.DailyReceptionForRubber.DRRubberID, Checkroll.DailyReceptionForRubber.DateRubber, 
                         Checkroll.DailyReceptionForRubber.COAglum, Checkroll.DailyReceptionForRubber.DRC, Checkroll.DailyReceptionForRubber.DRCCupLump, 
                         Checkroll.DailyReceptionForRubber.DRCTreeLace, Checkroll.DailyReceptionForRubber.DRCCOAglum 
						 , Checkroll.DailyReceptionForRubber.DRC * Checkroll.DailyReceptionForRubber.Latex / 100 as Dry
						 , Checkroll.DailyReceptionForRubber.DRCCupLump * Checkroll.DailyReceptionForRubber.CupLamp / 100 as DryCupLump
						 , Checkroll.DailyReceptionForRubber.DRCTreeLace * Checkroll.DailyReceptionForRubber.TreeLace / 100 as DryTreeLace
						 , Checkroll.DailyReceptionForRubber.DRCCOAglum * Checkroll.DailyReceptionForRubber.COAglum / 100 as DryCoaglum
FROM            Checkroll.DailyReceptionForRubber LEFT OUTER JOIN
                         Checkroll.DailyReceiption ON Checkroll.DailyReceptionForRubber.DailyReceiptionID = Checkroll.DailyReceiption.DailyReceiptionID
WHERE        (Checkroll.DailyReceptionForRubber.DailyReceiptionID = @DailyReceiptionID)
END



GO


