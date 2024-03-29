
/****** Object:  StoredProcedure [Checkroll].[PieceRateUpdate]    Script Date: 25/11/2015 12:38:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------


ALTER PROCEDURE [Checkroll].[PieceRateUpdate]
	@Id int,
	@EstateID nvarchar(50),
	@ReferenceNo varchar(50),
	@ActivityBy char(1),
	@Description varchar(300),
	@AllowanceDeductionCode varchar(10),
	@Coaid nvarchar(50)
AS	

	
BEGIN TRY
    DECLARE @EstateRefNo nvarchar(50)
	IF @Description is null 
		Begin
			Set @Description =@ReferenceNo
		End
    BEGIN 
		UPDATE Checkroll.PieceRate
			SET
			ReferenceNo = @ReferenceNo,
			EstateID = @EstateID,
			ActivityBy = @ActivityBy,
			[Description] = @Description,
			AllowanceDeductionCode=@AllowanceDeductionCode,
			COAID = @Coaid
		WHERE
			Id = @Id;
	END

	
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;
    
    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

	RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH;
