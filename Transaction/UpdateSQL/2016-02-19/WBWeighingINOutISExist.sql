
/****** Object:  StoredProcedure [Weighbridge].[WBWeighingInOutIsExistInGradingFFB]    Script Date: 23/2/2016 10:16:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







ALTER PROCEDURE [Weighbridge].[WBWeighingInOutIsExistInGradingFFB]

	-- Add the parameters for the stored procedure here
	
	@WeighingID nvarchar(50),
	@EstateID nVarchar(50),
	@ActiveMonthYearID nVarchar(50)
		
AS
	
		BEGIN
			SELECT COUNT(*) AS WeighingID FROM Production.GradingFFB 
			WHERE WeighingID = 'sai' AND EstateID = @EstateID;
		END	

			
			
		






