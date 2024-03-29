
/****** Object:  StoredProcedure [Checkroll].[UpdatePremiRubber]    Script Date: 26/8/2015 10:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--========================================================================================
--
-- Author     : Chandra
-- Created on : 14 03 2015
-- Desk			: untuk update harga premi jika terjadi perubahan
--
--========================================================================================
ALTER PROCEDURE [Checkroll].[UpdatePremiRubber]
@AttCode varchar(3), @DateRubber datetime ,@NIk varchar(15),@DRRubberID varchar(50),@DailyReceiptionID varchar(50),@EstateCode varchar(50),@Latex numeric (18,2),@Drc numeric (18,2),@CupLamp numeric (18,2),@DRCCupLump numeric (18,2),@TreeLace numeric (18,2),@DRCTreeLace numeric (18,2)
AS
BEGIN
			declare @index int	
			declare @FieldNo nvarchar(50)
			declare @DRCLatexCalc numeric (18,2)  -- used because drc tph for premi needs to be recalculated

			Select @FieldNo = FieldNo from Checkroll.DailyReceptionForRubber where  DailyReceiptionID=@DailyReceiptionID and DRRubberID=@DRRubberID	
	
			SELECT @index =CHARINDEX('R',@EstateCode)
			SELECT @EstateCode=LEFT(@EstateCode,6-1)
			declare @PremiDasarLatex money=0,@PremiProgresifLatex money =0 ,@PremiBonusLatex money =0  , @PremiMinggu money=0
			declare @PremiDasarLump money=0,@PremiProgresifLump money =0 ,@PremiBonusLump money =0
			declare @PremiTreeLace money=0
			if(@AttCode <>'M1')
				begin		
					if @Latex = 0 
						begin
							Set @DRCLatexCalc = 0
							set @PremiDasarLatex =0
							set @PremiProgresifLatex =0
							set @PremiBonusLatex = 0
						end
					else
						begin
							Set @DRCLatexCalc = (@Latex * @Drc / 100) / @Latex * 100
							set @PremiDasarLatex =@PremiDasarLatex+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@DRCLatexCalc,'Latex','D',@FieldNo)
							set @PremiProgresifLatex =@PremiProgresifLatex + [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@DRCLatexCalc,'Latex','P',@FieldNo)
							set @PremiBonusLatex = @PremiBonusLatex + [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@DRCLatexCalc,'Latex','B',@FieldNo)
						end 

					--DRC Cup Lump should be 50% as per Bakrie premi calculation standards
					set @PremiDasarLump =@PremiDasarLump + [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,18,@CupLamp,50,'Cup Lump','D',@FieldNo)
					set @PremiProgresifLump =@PremiProgresifLump + [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,18,@CupLamp,50,'Cup Lump','P',@FieldNo)
					set @PremiBonusLump = @PremiBonusLump +[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,18,@CupLamp,50,'Cup Lump','B',@FieldNo)

					--Treelace is calculated by wet not dry, so drc fixed to 100
					set @PremiTreeLace =@PremiTreeLace+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,2,@TreeLace,100,'Tree Lace','D',@FieldNo)
--					set @PremiProgresif =@PremiProgresif+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','P',@FieldNo)
--					set @PremiBonus = @PremiBonus+[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','B',@FieldNo)
				end 
			else if(@AttCode ='M1')
				begin
					set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@DRC,'Latex','M',@FieldNo)
					set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','M',@FieldNo)
					set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','M',@FieldNo)
				end
			update Checkroll.DailyReceptionForRubber set 
			PremiBonusLatex=@PremiBonusLatex,
			PremiDasarLatex=@PremiDasarLatex,
			PremiMinggu=@PremiMinggu, 
			PremiProgresifLatex=@PremiProgresifLatex, 
			PremiBonusLump=@PremiBonusLump,
			PremiDasarLump=@PremiDasarLump,
			PremiProgresifLump=@PremiProgresifLump,
			PremiTreelace = @PremiTreeLace
			where DailyReceiptionID=@DailyReceiptionID and DRRubberID=@DRRubberID			
END









