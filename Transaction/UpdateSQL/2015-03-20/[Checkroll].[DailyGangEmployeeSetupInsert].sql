
GO

/****** Object:  StoredProcedure [Checkroll].[DailyGangEmployeeSetupInsert]    Script Date: 20/03/2015 16:04:03 ******/
DROP PROCEDURE [Checkroll].[DailyGangEmployeeSetupInsert]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyGangEmployeeSetupInsert]    Script Date: 20/03/2015 16:04:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Muhamad Ramandani>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[DailyGangEmployeeSetupInsert]
	@DDAte	as datetime,
	@DailyTeamActivityID as nchar(50),
	@GangEmployeeID	as nvarchar(50),
	@EstateID	as nvarchar(50),
	@GangMasterID as 	nvarchar(50),
	@EmpID	as nvarchar(50),
	@CreatedBy	as nvarchar(50),
	@ModifiedBy	as nvarchar(50)
AS
BEGIN
	declare @isExist as int
	Select  @isExist =  Count(*) from Checkroll.DailyGangEmployeeSetup 
	where Checkroll.DailyGangEmployeeSetup.GangMasterID = @GangMasterID 
	AND Checkroll.DailyGangEmployeeSetup.GangEmployeeID = @GangEmployeeID
	AND Checkroll.DailyGangEmployeeSetup.DDAte = @DDAte

	if @isExist = 0
	begin 
	INSERT INTO [Checkroll].[DailyGangEmployeeSetup]
           ([DDAte]
           ,[DailyTeamActivityID]
           ,[GangEmployeeID]
           ,[EstateID]
           ,[GangMasterID]
           ,[EmpID]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn])
     VALUES
           (@DDAte
           ,@DailyTeamActivityID
           ,@GangEmployeeID
           ,@EstateID
           ,@GangMasterID
           ,@EmpID
           ,@CreatedBy
           ,Getdate()
           ,@ModifiedBy
           ,Getdate())
	end	
END


GO


