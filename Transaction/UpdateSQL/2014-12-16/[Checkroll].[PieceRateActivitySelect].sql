
GO

/****** Object:  StoredProcedure [Checkroll].[PieceRateActivitySelect]    Script Date: 28/11/2014 15:47:35 ******/
DROP PROCEDURE [Checkroll].[PieceRateActivitySelect]
GO

/****** Object:  StoredProcedure [Checkroll].[PieceRateActivitySelect]    Script Date: 28/11/2014 15:47:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Ahmed Naxim
-- Alter date: 6 Oct 2012
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[PieceRateActivitySelect]
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50),
	@Id int = null,
	@ReferenceNo nvarchar(50) = null,
	@Description varchar(300) = null,
	@ActivityDate smalldatetime = null
	
AS

	SET NOCOUNT ON;

IF (@Id IS NOT NULL)
	BEGIN
		SELECT        PRA.Id, PRA.BlockID, PRA.ReferenceNo, PRA.JobRate, PRA.MandoreRate, PRA.KeraniRate, PRA.Unit, PRA.TotalUnit, PRA.StartDate, PRA.EndDate, PRA.StationID, 
                          PR.EstateID, PR.ActivityBy, PR.Description, BM.BlockName, Production.Station.StationDescp
FROM            Checkroll.PieceRateActivity AS PRA INNER JOIN
                         Checkroll.PieceRate AS PR ON PRA.ReferenceNo = PR.ReferenceNo LEFT OUTER JOIN
                         Production.Station ON PRA.Id = Production.Station.Id LEFT OUTER JOIN
                         General.BlockMaster AS BM ON PRA.BlockID = BM.BlockID
		WHERE 
			PR.EstateID = @EstateID AND 
			PRA.Id = @Id AND
			PR.Description LIKE '%' + @Description + '%'
		Order By PRA.ReferenceNo Asc
	END
ELSE IF (@ReferenceNo IS NULL)
	BEGIN
		SELECT        PRA.Id, PRA.BlockID, BM.BlockName, PRA.ReferenceNo, PRA.JobRate, PRA.MandoreRate, PRA.KeraniRate, PRA.Unit, UOM.UOM, PRA.TotalUnit, PRA.StartDate, 
                         PRA.EndDate, PR.ActivityBy, PR.Description, PR.EstateID,  Production.Station.StationID , Production.Station.StationDescp
FROM            Checkroll.PieceRateActivity AS PRA INNER JOIN
                         Checkroll.PieceRate AS PR ON PRA.ReferenceNo = PR.ReferenceNo INNER JOIN
                         General.UOM AS UOM ON PRA.Unit = UOM.UOMID LEFT OUTER JOIN
                         Production.Station ON PRA.StationId = Production.Station.StationID LEFT OUTER JOIN
                         General.BlockMaster AS BM ON PRA.BlockID = BM.BlockID
		WHERE 
			PR.EstateID = @EstateID
			and PR.Description LIKE '%' + @Description + '%'
		Order By PRA.Id Desc
	END
ELSE IF (@Description IS NOT NULL AND @ActivityDate IS NOT NULL)
	BEGIN
		SELECT        PRA.Id, PRA.BlockID, PRA.ReferenceNo, PRA.JobRate, PRA.MandoreRate, PRA.KeraniRate, PRA.Unit, PRA.TotalUnit, PRA.StartDate, PRA.EndDate, PRA.StationID, 
                         PR.Id AS Expr1, PR.ReferenceNo AS Expr2, PR.EstateID, PR.ActivityBy, PR.Description, BM.BlockName, Production.Station.StationID AS Expr3, 
                         Production.Station.StationDescp
FROM            Checkroll.PieceRateActivity AS PRA INNER JOIN
                         Checkroll.PieceRate AS PR ON PRA.ReferenceNo = PR.ReferenceNo LEFT OUTER JOIN
                         Production.Station ON PRA.Id = Production.Station.Id LEFT OUTER JOIN
                         General.BlockMaster AS BM ON PRA.BlockID = BM.BlockID
		WHERE 
			PR.EstateID = @EstateID AND 
			PR.Description LIKE '%' + @Description + '%'
			AND @ActivityDate BETWEEN StartDate AND EndDate
		Order By PRA.ReferenceNo Asc
	END
ELSE 
	BEGIN		
		SELECT        PRA.Id, PRA.BlockID, BM.BlockName, PRA.ReferenceNo, PRA.JobRate, PRA.MandoreRate, PRA.KeraniRate, PRA.Unit, UOM.UOM, PRA.TotalUnit, PRA.StartDate, 
                         PRA.EndDate, PR.ActivityBy, PR.Description, PR.EstateID, Production.Station.StationDescp, Production.Station.StationID
FROM            Checkroll.PieceRateActivity AS PRA INNER JOIN
                         Checkroll.PieceRate AS PR ON PRA.ReferenceNo = PR.ReferenceNo INNER JOIN
                         General.UOM AS UOM ON PRA.Unit = UOM.UOMID LEFT JOIN
                         Production.Station ON PRA.StationID = Production.Station.StationID LEFT OUTER JOIN
                         General.BlockMaster AS BM ON PRA.BlockID = BM.BlockID
		WHERE 
			PR.EstateID = @EstateID AND 
			PRA.ReferenceNo = @ReferenceNo
		Order By PRA.ReferenceNo Asc
	END


GO


