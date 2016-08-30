
GO

/****** Object:  StoredProcedure [Production].[GradingFFBSelect]    Script Date: 20/01/2015 11:53:53 ******/
DROP PROCEDURE [Production].[GradingFFBSelect]
GO

/****** Object:  StoredProcedure [Production].[GradingFFBSelect]    Script Date: 20/01/2015 11:53:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--======================================================          
-- ALTERd By : Kumaravel        
-- ALTERd date:  Nov 7 , 2009       
-- Modified By: Naxim     
-- Last Modified Date: Oct 23 2013        
-- Module     : Production     
-- Screen(s)  : Grading FFB
-- Description: To Select Grading FFB          
--======================================================  

CREATE PROCEDURE [Production].[GradingFFBSelect]

	-- Add the parameters for the stored procedure here
	
	@EstateID nvarchar(50),
	@WBTicketNo nvarchar(50),
	@GradingDate Datetime,
	@ActiveMonthYearID nvarchar(50)
	
	
		
AS   
			BEGIN
				
			
				SELECT        WB_WeighINOUT.WBTicketNo, P_GFFB.GradingID, P_GFFB.WeighingID, P_GFFB.GradingDate, P_GFFB.MinMaturity, P_GFFB.LosseFruitPerBunche, 
                         P_GFFB.UnripeFruitJ AS UnRipeFruitJ, P_GFFB.UnripeFruitP AS UnRipeFruitP, P_GFFB.UnripeFruitT AS UnRipeFruitT, P_GFFB.UnderripeJ, P_GFFB.UnderripeP, 
                         P_GFFB.UnderripeT, P_GFFB.RipeFruitJ, P_GFFB.RipeFruitP, P_GFFB.RipeFruitT, P_GFFB.OverRipeFruitJ, P_GFFB.OverRipeFruitP, P_GFFB.OverRipeFruitT, 
                         P_GFFB.EmptyBunchFruitJ, P_GFFB.EmptyBunchFruitP, P_GFFB.EmptyBunchFruitT, P_GFFB.TotalNormalFruitsJ, P_GFFB.TotalNormalFruitsP, 
                         P_GFFB.TotalNormalFruitsT, P_GFFB.PartheJ, P_GFFB.PartheP, P_GFFB.PartheT, P_GFFB.HardBunchJ, P_GFFB.HardBunchP, P_GFFB.HardBunchT, 
                         P_GFFB.TotalAbnormalFruitsJ, P_GFFB.TotalAbnormalFruitsP, P_GFFB.TotalAbnormalFruitsT, P_GFFB.GTActualBunchesJ, P_GFFB.GTActualBunchesP, 
                         P_GFFB.GTActualBunchesT, P_GFFB.LooseFruitsP, P_GFFB.KgOfLooseFruit, P_GFFB.UnDamageJ, P_GFFB.UnDamageP, P_GFFB.UnDamageT, 
                         P_GFFB.LightDamageJ, P_GFFB.LightDamageP, P_GFFB.LightDamageT, P_GFFB.MediumDamageJ, P_GFFB.DamageJ, P_GFFB.DamageP, P_GFFB.DamageT, 
                         P_GFFB.TotalJ, P_GFFB.TotalP, P_GFFB.TotalT, P_GFFB.Comment, P_GFFB.GradingTime, P_GFFB.BatuKerikil, P_GFFB.LongStalksJ, P_GFFB.DirtAndStonesJ, 
                         P_GFFB.SmallBunchesJ, P_GFFB.BuahRestanJ, P_GFFB.UnripeFruitComment, P_GFFB.UnderRipeComment, P_GFFB.OverRipeFruitComment, 
                         P_GFFB.EmptyBunchFruitComment, P_GFFB.LongStalksComment, P_GFFB.LooseFruitsComment, P_GFFB.DirtAndStonesComment, P_GFFB.SmallBunchesComment,
                          P_GFFB.BuahRestanComment, P_GFFB.HardBunchComment, P_GFFB.PartheComment, P_GFFB.LightDamageComment, P_GFFB.MediumDamageComment, 
                         P_GFFB.DamageComment, P_GFFB.DocumentNumber, P_GFFB.TotalGradedBunches, P_GFFB.Abnormal, P_GFFB.AbnormalComment
FROM            Production.GradingFFB AS P_GFFB INNER JOIN
                         Weighbridge.WBWeighingInOut AS WB_WeighINOUT ON WB_WeighINOUT.WeighingID = P_GFFB.WeighingID	 			 
				Where P_GFFB.EstateID =@EstateID 
				AND P_GFFB.ActiveMonthYearID = @ActiveMonthYearID 
				AND (Case When @WBTicketNo IS NULL Then 1 end =1 or WB_WeighINOUT .WBTicketNo Like '%' + @WBTicketNo +'%') 
				AND (case when @GradingDate = '01/01/1900' then 1  end =1 or P_GFFB.GradingDate   =@GradingDate   ) 
				Order by P_GFFB.id Desc
			END	
		


GO


