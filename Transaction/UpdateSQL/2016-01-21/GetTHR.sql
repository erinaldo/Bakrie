/****** Object:  StoredProcedure [Checkroll].[SalaryEmployee]    Script Date: 21/1/2016 10:10:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [Checkroll].[THREmployee]
	@ActiveMonthYearID nvarchar(50),
	@EstateID nvarchar(50)
AS
BEGIN

Select a.EmpCode,a.EmpName,a.EmpID,a.Category,a.BankID,a.OEEmpLocation,
b.Bruto,b.BerasNatura,b.DedCooper as SPSI,b.DedOthers as SPSB, b.DagingNatura from Checkroll.CREmployee a
inner join Checkroll.THR b on a.EmpID = b.EmpID
WHERE        b.ActiveMonthYearID = @ActiveMonthYearID
and b.EstateID = @EstateID
ORDER BY a.EmpCode ASC

END

