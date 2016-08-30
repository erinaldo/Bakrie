
GO

/****** Object:  StoredProcedure [Checkroll].[GetAllowDedID]    Script Date: 3/3/2015 9:06:24 AM ******/
DROP PROCEDURE [Checkroll].[GetAllowDedID]
GO

/****** Object:  StoredProcedure [Checkroll].[GetAllowDedID]    Script Date: 3/3/2015 9:06:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[GetAllowDedID]
	@AllowDedCode as varchar(50)
AS
BEGIN
	select Top 1 AllowDedID, AllowDedCode from Checkroll.AllowanceDeductionSetup WHERE AllowDedCode = @AllowDedCode
END

GO


