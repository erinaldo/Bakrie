

/****** Object:  StoredProcedure [Checkroll].[PieceRateTransactionUpdate]    Script Date: 26/07/2015 15:20:40 ******/
DROP PROCEDURE [Checkroll].[PieceRateTransactionUpdate]
GO

/****** Object:  StoredProcedure [Checkroll].[PieceRateTransactionUpdate]    Script Date: 26/07/2015 15:20:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-----------------------------------


--================================================
-- Created By : Naxim
-- Created date: 1-Nove-2012 
-- Modified By:
-- Last Modified Date: 
-- Module     : PieceRate
-- Screen(s)  : PieceRate Transaction
-- Description: Add records to PieceRate Transaction
 --================================================  
CREATE PROCEDURE [Checkroll].[PieceRateTransactionUpdate]
	@Id int = Null,
	@PieceRateActivityId int,
	@Date smalldatetime,
	@VHID nvarchar(50),
	@SubStationID nvarchar(50),
	@UnitCompleted decimal(18,2),
	@Remarks nvarchar(300),
	@EmpID nvarchar(50),
	@ContractID nvarchar(50),
	@CreatedBy nvarchar(50),
	@ModifiedBy nvarchar(50),
	@Production decimal(18,2)
AS	

	
BEGIN TRY
    
    IF @Id IS Null 
		BEGIN 
	    
			INSERT INTO [Checkroll].[PieceRateTransaction]
				(
				PieceRateActivityId, 
				Date,
				VHID,
				SubStationID,
				UnitCompleted,
				Remarks,
				EmpID,
				ContractID,
				CreatedBy,
				CreatedOn,
				Production
				)
			VALUES
				(
				@PieceRateActivityId, 
				@Date,
				@VHID,
				@SubStationID,
				@UnitCompleted,
				@Remarks,
				@EmpID,
				@ContractID,
				@CreatedBy,
				GetDate(),
				@Production
				);
		END
	ELSE
		BEGIN 
	    
			UPDATE [Checkroll].[PieceRateTransaction]
				SET
				PieceRateActivityId = @PieceRateActivityId, 
				Date = @Date,
				VHID = @VHID,
				SubStationID = @SubStationID,
				UnitCompleted = @UnitCompleted,
				Remarks = @Remarks,
				EmpID = @EmpID,
				ContractID = @ContractID,
				ModifiedBy = @ModifiedBy,
				ModifiedOn = GetDate(),
				Production = @Production
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

GO


