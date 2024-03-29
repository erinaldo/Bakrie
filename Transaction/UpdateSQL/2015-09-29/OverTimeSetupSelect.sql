
/****** Object:  StoredProcedure [Checkroll].[OverTimeSetupSelect]    Script Date: 30/9/2015 2:18:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO









-- ====================================================
-- Created By : Gopinath
-- Modified By:
-- Created date: 25 Sep 2009
-- Last Modified Date:
-- Module     : CheckRoll, RKPMS Web
-- Screen(s)  : OverTimeSetup.aspx
-- Description: Procedure to get OverTime Setup
-- =====================================================
ALTER PROCEDURE [Checkroll].[OverTimeSetupSelect]
-- Add the parameters for the stored procedure here
@EstateID NVARCHAR(50)--,
--@AttendanceSetupID NVARCHAR(50) --,
--@AttendType NVARCHAR(50)
AS
        SET NOCOUNT ON;
        BEGIN
         SELECT        OTS.OvertimeSetupID, CAS.AttendanceCode, CAS.AttendType, OTS.AttendanceSetupID, OTS.DayStatus, OTS.OvertimeTimes1, OTS.OvertimeMaxOTHours1, 
                         OTS.OvertimeTimes2, OTS.OvertimeMaxOTHours2, OTS.OvertimeTimes3, OTS.OvertimeMaxOTHours3, OTS.OvertimeTimes4, OTS.OvertimeMaxOTHours4, 
                         OTS.CropID, OTS.CropID as CropCode
		FROM            Checkroll.OverTimeSetup AS OTS INNER JOIN
                         Checkroll.AttendanceSetup AS CAS ON OTS.AttendanceSetupID = CAS.AttendanceSetupID 
                WHERE    OTS.EstateID                   = @EstateID
                ORDER BY OTS.ModifiedOn DESC,OTS .Id 


        END








