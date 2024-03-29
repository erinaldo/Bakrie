
GO
/****** Object:  StoredProcedure [Vehicle].[WorkshoplogMonthYearGET]    Script Date: 11/2/2015 10:56:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		SARAVANA
-- Create date: 5th Aug 2010
-- Description:	InterfaceYear for summary reports
-- =============================================
ALTER PROCEDURE [Vehicle].[WorkshoplogMonthYearGET] 
   @ModID int,
   @EstateID NVARCHAR(50)
                                             
AS
DECLARE @Query NVARCHAR(4000)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		SELECT distinct GAM.AYear FROM  General.ActiveMonthYear GAM  
		WHERE ActiveMonthYearID in (SELECT ActiveMonthYearID FROM Vehicle.VHDistribution   where EstateID=@EstateID   )order by AYear 

	SELECT distinct	case  
		when GAM.AMonth=1 then 'January' 
		when GAM.AMonth=2 then 'February' 
		when GAM.AMonth=3 then 'March' 
		when GAM.AMonth=4 then 'April' 
		when GAM.AMonth=5 then 'May' 
		when GAM.AMonth=6 then 'June' 
		when GAM.AMonth=7 then 'July' 
		when GAM.AMonth=8 then 'August' 
		when GAM.AMonth=9 then 'September' 
		when GAM.AMonth=10 then 'October' 
		when GAM.AMonth=11 then 'November' 
		when GAM.AMonth=12 then 'December' 
				
		end as 'MONTH',
		GAM.AMonth ,
		GAM.ActiveMonthYearID as 'ActiveMonthYearID'
				 
 FROM  General.ActiveMonthYear GAM 
		WHERE ActiveMonthYearID in (SELECT ActiveMonthYearID FROM Vehicle .VHDistribution   WHERE EstateID=@EstateID   ) order by AMonth 
 
END



