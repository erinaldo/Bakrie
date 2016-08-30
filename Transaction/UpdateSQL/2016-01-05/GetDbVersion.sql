
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE General.GetDbVersion


AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT vcMajorRelease
      ,vcMinorRelease
      ,vcPatch
      ,dtUpdated from dbo.DBVersion

END
GO
