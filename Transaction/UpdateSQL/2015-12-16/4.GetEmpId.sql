/****** Object:  StoredProcedure [Checkroll].[GetEmpId]    Script Date: 16/12/2015 3:44:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [Checkroll].[GetEmpIdFromEmpCode]
	@EmpCode as nvarchar(50)
AS
BEGIN
	select Top 1 Empid from Checkroll.CREmployee WHERE EmpCode = @EmpCode
END

