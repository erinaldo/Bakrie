
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--===
-- Author : Chandra
-- Created On : 13-03-2015
-- Descp      :  Untuk mengambil jumlah hari kecuali hari minggu
--
--===
Create FUNCTION dbo.CountDayInTheMonth (
	@currentYear int,
	@currentMonth int
	)
RETURNS int
AS
BEGIN
	DECLARE @temp  bit
	DECLARE @countDay  int
	DECLARE @currentName  varchar(10)
	DECLARE @currentDate  Datetime
	SET @currentMonth = 10
	SET @countDay=0
	SET @currentYear = 2012
	SET @currentDate =  CONVERT(datetime,CONVERT(varchar(4), @currentYear) + '-'+CONVERT(varchar(2), @currentMonth)+'-01 00:00:00')
	--SELECT @currentDate
	SET @temp = 0
	WHILE @temp =0
	BEGIN
	
		SELECT @currentName= DATENAME(dw, @currentDate) 
		--PRINT @currentName
		IF(@currentName <> 'Sunday')
			BEGIN
				SET @countDay=@countDay+1
				--PRINT @currentDate
			end
		set @currentDate=dateadd(dd,1,@currentDate)
	
	
		IF(MONTH(@currentDate)!=@currentMonth)
			SET @temp=1 
	END




	RETURN @countDay
END;



