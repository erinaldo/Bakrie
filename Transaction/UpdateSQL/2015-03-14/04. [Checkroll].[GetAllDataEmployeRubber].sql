--========================================================================================
--
-- Author     : Chandra
-- Created on : 13 03 2015
-- Desk			: untuk  memanggil semua data
--
--========================================================================================
create PROCEDURE [Checkroll].[GetAllDataEmployeRubber]
@month int,@year int
AS
BEGIN
		select DateRubber,NIK,DailyReceiptionID,Latex,Drc,CupLamp,DRCCupLump,TreeLace,DRCTreeLace,AttCode,DRRubberID from Checkroll.DailyReceptionForRubber where MONTH(DateRubber) = @month and YEAR(DateRubber) = @year
END









