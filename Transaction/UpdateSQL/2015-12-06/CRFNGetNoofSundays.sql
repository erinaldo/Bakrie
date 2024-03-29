
/****** Object:  UserDefinedFunction [Checkroll].[CRFnGetNoOfSundays]    Script Date: 8/12/2015 10:37:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--===
-- Author : Dadang Adi Hendradi
-- Created On : Sabtu, 13 Mar 2010, 10:50
-- Descp      : Untuk menghitung jumlah hari minggu dalam fiscal month tertentu
--
--===
ALTER FUNCTION [Checkroll].[CRFnGetNoOfSundays] (
	@EstateID nvarchar(50)
	,@AMonth int
	,@AYear int)
RETURNS int
AS
BEGIN

	DECLARE @NoOfSundays int;
	DECLARE @FirstDateofYearMonth DATETIME



	SELECT @FirstDateofYearMonth = CONVERT (datetime, convert(varchar,@AYear)+'/'+
                                                  convert(varchar,@AMonth)+'/01') 
	
	;WITH cteDaysInMonth 
     AS (SELECT 1                             AS DayNo, 
                @FirstDateofYearMonth         AS RunningDate 
         UNION ALL 
         SELECT cteDaysInMonth.DayNo + 1                 AS DayNo, 
                DATEADD(dd,1,cteDaysInMonth.RunningDate) 
         FROM   cteDaysInMonth 
         WHERE  DATEADD(dd,1,cteDaysInMonth.RunningDate) <= 
                 DATEADD(dd,-1,DATEADD(MM,1,@FirstDateofYearMonth))) 
		
		SELECT   @NoOfSundays=COUNT(*)         
		FROM     cteDaysInMonth 
		WHERE    DATENAME(WEEKDAY,RunningDate) ='Sunday' 
		option (MaxRecursion 370)
	
	RETURN (@NoOfSundays);	
END;


