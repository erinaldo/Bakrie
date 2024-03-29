--========================================================================================
--
-- Author     : Chandra
-- Created on : 14 03 2015
-- Desk			: untuk update harga premi jika terjadi perubahan
--
--========================================================================================
create PROCEDURE [Checkroll].[UpdatePremiRubber]
@AttCode varchar(3), @DateRubber datetime ,@NIk varchar(15),@DRRubberID varchar(50),@DailyReceiptionID varchar(50),@EstateCode varchar(50),@Latex float,@Drc float,@CupLamp float,@DRCCupLump float,@TreeLace float,@DRCTreeLace float
AS
BEGIN
			declare @index int		
			set @DailyReceiptionID=@EstateCode
			SELECT @index =CHARINDEX('R',@EstateCode)
			SELECT @EstateCode=LEFT(@EstateCode,6-1)
			declare @PremiDasar money=0,@PremiProgresif money =0 ,@PremiBonus money =0  , @PremiMinggu money=0
			if(@AttCode ='11')
				begin		
					set @PremiDasar =@PremiDasar+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@Drc,'Latex','D')
					set @PremiProgresif =@PremiProgresif+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@Drc,'Latex','P')
					set @PremiBonus = @PremiBonus+[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@Drc,'Latex','B')

					set @PremiDasar =@PremiDasar+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','D')
					set @PremiProgresif =@PremiProgresif+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','P')
					set @PremiBonus = @PremiBonus+[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','B')

					set @PremiDasar =@PremiDasar+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','D')
					set @PremiProgresif =@PremiProgresif+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','P')
					set @PremiBonus = @PremiBonus+[Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','B')
				end 
			else if(@AttCode ='M1')
				begin
					set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,80,@Latex,@DRC,'Latex','M')
					set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,12,@CupLamp,@DRCCupLump,'Cup Lump','M')
					set @PremiMinggu = @PremiMinggu+ [Checkroll].[CalculatePremi](@DateRubber,@NIk,@EstateCode,8,@TreeLace,@DRCTreeLace,'Tree Lace','M')
				end
			update Checkroll.DailyReceptionForRubber set PremiBonus=@PremiBonus,PremiDasar=@PremiDasar,PremiMinggu=@PremiMinggu, PremiProgresif=@PremiProgresif where DailyReceiptionID=@DailyReceiptionID and DRRubberID=@DRRubberID			
END









