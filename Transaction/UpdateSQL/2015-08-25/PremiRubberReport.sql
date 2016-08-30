
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CReate PROCEDURE Checkroll.PremiRubberReport
	@EstateId nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	Declare @ZMonth int
	Declare @ZYear int

	Select @ZMonth= A.AMonth,@ZYear = A.AYear  From General.ActiveMonthYear A where A.ActiveMonthYearID=@ActiveMonthYearID

    SELECT        General.BlockMaster.BlockName, General.YOP.YOP, DR.DateRubber, DR.NIK, DR.Name, DR.AttCode, DR.FieldNo, DR.TPH, DR.Latex, DR.CupLamp, DR.TreeLace, DR.DRC, DR.COAglum, DR.DRCCupLump, 
                         DR.DRCTreeLace, DR.DRCCOAglum, DR.PremiDasarLatex, DR.PremiBonusLatex, DR.PremiProgresifLatex, DR.PremiMinggu, CR.EmpCode, CR.EmpName,
						 DR.PremiDasarLump, DR.PremiBonusLump, DR.PremiProgresifLump,
						 DR.PremiTreelace
	FROM            Checkroll.DailyReceptionForRubber AS DR INNER JOIN
                         Checkroll.CREmployee AS CR ON CR.EmpCode = DR.NIK INNER JOIN
                         General.BlockMaster ON DR.FieldNo = General.BlockMaster.BlockID INNER JOIN
                         General.YOP ON General.BlockMaster.YOPID = General.YOP.YOPID AND General.BlockMaster.YOPID = General.YOP.YOPID
						 where Month(DateRubber) = @ZMonth and Year(DateRubber) = @ZYear
						  oRDER BY DR.dATERUBBER

END
GO
