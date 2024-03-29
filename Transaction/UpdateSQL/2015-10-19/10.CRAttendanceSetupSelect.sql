/****** Object:  StoredProcedure [Checkroll].[CRAttendanceSetupSelect]    Script Date: 20/10/2015 1:10:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






ALTER PROCEDURE [Checkroll].[CRAttendanceSetupSelect]
@AttendanceCode as nvarchar(50),
@AttendType as nvarchar (50),
@EstateId as nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- declare @rowcount as int = 0
	
	SET NOCOUNT OFF;
	
IF @AttendanceCode  = '' and @AttendType=''
BEGIN
SELECT    Checkroll.AttendanceSetup.AttendanceCode AS [Att Code], Checkroll.AttendanceSetup.AttendanceSetupID, 
          Checkroll.AttendanceSetup.AttendType AS [Att Descp], Checkroll.AttendanceSetup.BasicPay, Checkroll.AttendanceSetup.TimesBasic, 
          Checkroll.AttendanceSetup.Remarks, 0 as  OvertimeTimes1, 0 as OvertimeMaxOTHours1, 
          0 as OvertimeTimes2, 0 as  OvertimeMaxOTHours2, 0 as OvertimeTimes3, 
          0 as OvertimeMaxOTHours3, 0 as OvertimeTimes4, 0 as OvertimeMaxOTHours4
FROM      Checkroll.AttendanceSetup 
--FULL OUTER JOIN
 --         Checkroll.OverTimeSetup ON Checkroll.AttendanceSetup.AttendanceSetupID = Checkroll.OverTimeSetup.AttendanceSetupID 
WHERE
		Checkroll.AttendanceSetup.EstateID = @EstateId
END

IF @AttendanceCode  <> '' and @AttendType=''
BEGIN
SELECT    Checkroll.AttendanceSetup.AttendanceCode AS [Att Code], Checkroll.AttendanceSetup.AttendanceSetupID, 
          Checkroll.AttendanceSetup.AttendType AS [Att Descp], Checkroll.AttendanceSetup.BasicPay, Checkroll.AttendanceSetup.TimesBasic, 
          Checkroll.AttendanceSetup.Remarks,  0 as  OvertimeTimes1, 0 as OvertimeMaxOTHours1, 
          0 as OvertimeTimes2, 0 as  OvertimeMaxOTHours2, 0 as OvertimeTimes3, 
          0 as OvertimeMaxOTHours3, 0 as OvertimeTimes4, 0 as OvertimeMaxOTHours4
FROM      Checkroll.AttendanceSetup 
--FULL OUTER JOIN
 --         Checkroll.OverTimeSetup ON Checkroll.AttendanceSetup.AttendanceSetupID = Checkroll.OverTimeSetup.AttendanceSetupID
Where Checkroll.AttendanceSetup.AttendanceCode like '%'+ @AttendanceCode + '%' and Checkroll.AttendanceSetup.EstateID =@EstateID
ORDER BY Checkroll.AttendanceSetup.AttendanceCode
END

IF @AttendanceCode  = '' and @AttendType <> ''
BEGIN
SELECT    Checkroll.AttendanceSetup.AttendanceCode AS [Att Code], Checkroll.AttendanceSetup.AttendanceSetupID, 
          Checkroll.AttendanceSetup.AttendType AS [Att Descp], Checkroll.AttendanceSetup.BasicPay, Checkroll.AttendanceSetup.TimesBasic, 
          Checkroll.AttendanceSetup.Remarks,  0 as  OvertimeTimes1, 0 as OvertimeMaxOTHours1, 
          0 as OvertimeTimes2, 0 as  OvertimeMaxOTHours2, 0 as OvertimeTimes3, 
          0 as OvertimeMaxOTHours3, 0 as OvertimeTimes4, 0 as OvertimeMaxOTHours4
FROM      Checkroll.AttendanceSetup 
--0FULL OUTER JOIN
--          Checkroll.OverTimeSetup ON Checkroll.AttendanceSetup.AttendanceSetupID = Checkroll.OverTimeSetup.AttendanceSetupID
Where Checkroll.AttendanceSetup.AttendType  like '%'+ @AttendType + '%' and Checkroll.AttendanceSetup.EstateID =@EstateID
ORDER BY Checkroll.AttendanceSetup.AttendanceCode
END

IF @AttendanceCode  <> '' and @AttendType <> ''
BEGIN
SELECT    Checkroll.AttendanceSetup.AttendanceCode AS [Att Code], Checkroll.AttendanceSetup.AttendanceSetupID, 
          Checkroll.AttendanceSetup.AttendType AS [Att Descp], Checkroll.AttendanceSetup.BasicPay, Checkroll.AttendanceSetup.TimesBasic, 
          Checkroll.AttendanceSetup.Remarks, 0 as  OvertimeTimes1, 0 as OvertimeMaxOTHours1, 
          0 as OvertimeTimes2, 0 as  OvertimeMaxOTHours2, 0 as OvertimeTimes3, 
          0 as OvertimeMaxOTHours3, 0 as OvertimeTimes4, 0 as OvertimeMaxOTHours4
FROM      Checkroll.AttendanceSetup 
--FULL OUTER JOIN
--          Checkroll.OverTimeSetup ON Checkroll.AttendanceSetup.AttendanceSetupID = Checkroll.OverTimeSetup.AttendanceSetupID
Where (Checkroll.AttendanceSetup.AttendanceCode like '%'+ @AttendanceCode + '%' or Checkroll.AttendanceSetup.AttendType  like '%'+ @AttendType + '%') and Checkroll.AttendanceSetup.EstateID =@EstateID
ORDER BY Checkroll.AttendanceSetup.AttendanceCode
END

END








