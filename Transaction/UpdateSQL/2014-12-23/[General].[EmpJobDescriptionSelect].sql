
GO

/****** Object:  StoredProcedure [General].[EmpJobDescriptionSelect]    Script Date: 23/12/2014 16:01:38 ******/
DROP PROCEDURE [General].[EmpJobDescriptionSelect]
GO

/****** Object:  StoredProcedure [General].[EmpJobDescriptionSelect]    Script Date: 23/12/2014 16:01:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [General].[EmpJobDescriptionSelect]
	-- Add the parameters for the stored procedure here
	@Temp as varchar(5)
AS
BEGIN
if @Temp is null or @Temp = ''
	select * from General.EmpJobDescription
	else
	select * from General.EmpJobDescription where EmpJobDescription.Description like '%'+@Temp+'%'
END

GO


