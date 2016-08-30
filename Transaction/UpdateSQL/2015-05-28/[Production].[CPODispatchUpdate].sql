
GO

/****** Object:  StoredProcedure [Production].[CPODispatchUpdate]    Script Date: 5/28/2015 8:22:25 PM ******/
DROP PROCEDURE [Production].[CPODispatchUpdate]
GO

/****** Object:  StoredProcedure [Production].[CPODispatchUpdate]    Script Date: 5/28/2015 8:22:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
























--======================================================          
-- ALTERd By : Kumaravel        
-- ALTERd date:  Feb 20 , 2010      
-- Modified By: Kumaravel     
-- Last Modified Date:        
-- Module     : Production     
-- Screen(s)  : Dispatch     
-- Description: To Update Dispatch 
--======================================================  


CREATE PROCEDURE [Production].[CPODispatchUpdate]
	-- Add the parameters for the stored procedure here
		   @DispatchID nvarchar(50),
		   @EstateID nvarchar(50),
		   @ProductID nvarchar(50),
           @ActiveMonthYearID nvarchar(50),
           @DispatchDate date,
           @BAPNo nvarchar(50),
           @ShipPontoon nvarchar(80),
           @DOA Date,
           @DOATime Time(7),
           @DOL Date,
           @DOLTime Time(7),
           @DCL Date,
           @DCLTime Time(7),
           @DepartureDate Date,
           @DepartureTime time(7),
           @MillWeight numeric (18,3),
           @LoadingLocationID  nvarchar(50),
           @ModifiedBy nvarchar(50),
           @ModifiedOn datetime
 
AS

BEGIN TRY

Declare @BFQty float, @MillWeightOld float

	select @MillWeightOld = CPODispatch.MillWeight from Production.CPODispatch WHERE  DispatchID  =@DispatchID 		AND EstateID =@EstateID 		AND ActiveMonthYearID =@ActiveMonthYearID    
		UPDATE Production.CPODispatch   SET 
	       DispatchDate  =@DispatchDate 
           ,BAPNo  =@BAPNo  
           ,DOA  =@DOA  
           ,DOATime  =@DOATime  
           ,DOL  =@DOL  
           ,DOLTime  =@DOLTime   
           ,DCL  =@DCL  
           ,DCLTime  =@DCLTime 
           ,ShipPontoon  =@ShipPontoon
           ,DepartureDate =@DepartureDate 
           ,DepartureTime =@DepartureTime 
           ,MillWeight =@MillWeight 
           ,LoadingLocationID =@LoadingLocationID  
           ,ModifiedBy=@ModifiedBy
           ,ModifiedOn =GETDATE() 
		
		
		WHERE  DispatchID  =@DispatchID 
		AND EstateID =@EstateID 
		AND ActiveMonthYearID =@ActiveMonthYearID   ;
						
		select @BFQty = Production.TankMaster.BFQty from Production.TankMaster where Production.TankMaster.TankNo = @LoadingLocationID
		
		 if @BFQty <> 0
		 begin
			Update Production.TankMaster set Production.TankMaster.BFQty = (Production.TankMaster.BFQty + @MillWeightOld) - @MillWeight where Production.TankMaster.TankNo = @LoadingLocationID
			end
		
		
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


