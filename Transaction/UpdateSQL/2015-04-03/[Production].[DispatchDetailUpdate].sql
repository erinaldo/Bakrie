

/****** Object:  StoredProcedure [Production].[DispatchDetailUpdate]    Script Date: 4/3/2015 6:07:45 PM ******/
DROP PROCEDURE [Production].[DispatchDetailUpdate]
GO

/****** Object:  StoredProcedure [Production].[DispatchDetailUpdate]    Script Date: 4/3/2015 6:07:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Production].[DispatchDetailUpdate]
	-- Add the parameters for the stored procedure here
		   @DispatchDetailID nvarchar(50),
		   @EstateID nvarchar(50),
           @ActiveMonthYearID nvarchar(50),
           @DispatchID nvarchar(50),
		   @Position int,
           @FFAP numeric(18,2),
           @MoistureP numeric(18,2),
           @DirtP numeric(18,3),
           @BrokenKernel numeric(18,2),
           @Temp numeric(18,2),
           @ModifiedBy nvarchar(50),
           @ModifiedOn datetime
 
AS

BEGIN TRY


		UPDATE Production.CPODispatchDetail   SET 
			--DispatchDetailID =@DispatchDetailID 
           EstateID=@EstateID
           ,ActiveMonthYearID=@ActiveMonthYearID
           --,DispatchID =@DispatchID 
           ,Position =@Position 
           ,FFAP =@FFAP 
           ,MoistureP =@MoistureP 
           ,DirtP =@DirtP 
           ,BrokenKernel =@BrokenKernel 
           ,Temp =@Temp 
           ,ModifiedBy=@ModifiedBy
           ,ModifiedOn =GETDATE()  
		
		
		WHERE  DispatchDetailID  =@DispatchDetailID   ;
		
		
END TRY
BEGIN CATCH
	
	DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

	RAISERROR (@ErrorMessage, -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState -- State.
               );

END CATCH;























GO


