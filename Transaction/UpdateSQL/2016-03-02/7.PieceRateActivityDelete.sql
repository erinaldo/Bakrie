
/****** Object:  StoredProcedure [Checkroll].[PieceRateActivityDelete]    Script Date: 3/3/2016 10:33:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ahmed Naxim
-- Alter date: 6 Oct 2012
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Checkroll].[PieceRateActivityDelete]
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50),
	@Id int
	
AS

	SET NOCOUNT ON;
	
	BEGIN		
		
		--DELETE Related Piece Rate Data
		delete from checkroll.PieceRateEmployee where PieceRateActivityId = @ID
		DELETE From Checkroll.PieceRateContractor where PieceRateActivityId = @ID
		DELETE FROM Checkroll.PieceRateTransaction where PieceRateActivityId = @Id
		
		DELETE FROM [Checkroll].[PieceRateActivity] 
		WHERE 
			--EstateID = @EstateID AND 
			Id = @Id;
		SELECT 3 -- show deleted msg
	END
