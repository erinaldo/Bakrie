

/****** Object:  StoredProcedure [General].[EmpJobDescriptionSelect]    Script Date: 15/12/2014 13:28:04 ******/
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
	select * from General.EmpJobDescription
END

GO


