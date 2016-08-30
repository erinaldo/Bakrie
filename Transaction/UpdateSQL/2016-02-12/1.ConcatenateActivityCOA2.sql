
/****** Object:  UserDefinedFunction [Checkroll].[ConcatenateActivityCOA]    Script Date: 16/2/2016 11:59:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



--Function to concatenate last level coa desc with previous actitvities hierarchical levels

CREATE FUNCTION [Checkroll].[ConcatenateActivityCOA2] (
	@COAID nvarchar(50))
RETURNS nvarchar(2000)
AS
BEGIN
	
	DECLARE @COADESC nvarchar(200)
	DECLARE @COADESCConcat nvarchar(2000) = ''
	DECLARE @COACODE nvarchar(100)


	Select @COACODE = COACode  from Accounts.COA where COAID = @COAID

	Select @COADESC = COADescp from Accounts.COA where COACode = LEft(@COACODE,2)
	Set @COADESCConcat = @COADESC

	Select @COADESC = COADescp from Accounts.COA where COACode = left(@COACODE,5)
	Set @COADESCConcat = @COADESCConcat + '-' +  @COADESC

	Select @COADESC = COADescp from Accounts.COA where COACode = left(@COACODE,8)
	Set @COADESCConcat = @COADESCConcat + '-' +  @COADESC

	Select @COADESC = COADescp from Accounts.COA where COACode = left(@COACODE,11)
	Set @COADESCConcat = @COADESCConcat + '-' +  @COADESC

	Select @COADESC = COADescp from Accounts.COA where COACode = left(@COACODE,14)
	Set @COADESCConcat = @COADESCConcat + '-' +  @COADESC

	Select @COADESC = COADescp from Accounts.COA where COACode =@COACODE
	Set @COADESCConcat = @COADESCConcat + '-' +  @COADESC

	--Select @COADESC = ActivityDescription from Accounts.COADescription where COAID = @COAID
	--Set @COADESCConcat =  @COADESC

	RETURN (@COADESCConcat);	
END;




GO


