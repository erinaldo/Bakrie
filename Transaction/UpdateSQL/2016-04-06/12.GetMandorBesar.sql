
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Returns mandor besar's that are in Gang Employee Master

CREATE PROCEDURE [Checkroll].[GetMandorBesar] 
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Select  '' as EmpID, '' As EmpName
	union
	select Distinct b.EmpID,b.EmpName from Checkroll.GangMasterBesar a
	inner join Checkroll.CREmployee b on a.GangMasterBesarID = b.EmpID
	where b.EstateID = @EstateID



END
GO
