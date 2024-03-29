
/****** Object:  StoredProcedure [Weighbridge].[WBTicketNoSelect_N]    Script Date: 18/3/2015 12:21:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Weighbridge].[WBTicketNoSelect_N]
	-- Add the parameters for the stored procedure here
	@EstateID nvarchar(50),
	@Others bigint
AS 
	SET NOCOUNT ON;
	
BEGIN 

    Declare @WBTicketNocnt bigint;
    Declare @WBTicketYear bigint;
    Declare @SystYear bigint;
    
    SET @WBTicketNocnt = 0;
         
    BEGIN 
    
       SELECT @WBTicketNocnt = (ISNULL(MAX(Convert(bigint,WBTicketNo)),0)) FROM Weighbridge.WBWeighingInOut where Others = @Others  and EstateID = @EstateID and  DateName(year,WeighingDate) = DateName(year,GETDATE())
            IF (@WBTicketNocnt > 0 )
				BEGIN
						SELECT @WBTicketYear =  Max(DateName(year,WeighingDate)) from Weighbridge.WBWeighingInOut where 
						DateName(year,WeighingDate) = DateName(year,GETDATE())
						SELECT @SystYear =  DateName(year,GETDATE())
						
						IF (@WBTicketYear = @SystYear)
						BEGIN
							SELECT (ISNULL(MAX(Convert(bigint,WBTicketNo)),0)+ 1) as WBTicketNo FROM Weighbridge.WBWeighingInOut 
							WHERE Others = @Others AND EstateID = @EstateID and  DateName(year,WeighingDate) = DateName(year,GETDATE())
						END
						
						IF (@WBTicketYear < @SystYear AND @Others = 1)
						BEGIN
							SELECT OtherSerialNo as WBTicketNo FROM Weighbridge.WBTicketNoConfiguration Where EstateID = @EstateID 
						END 
						
						IF (@WBTicketYear < @SystYear AND @Others =0)
						BEGIN
							SELECT SerialNO as WBTicketNo FROM Weighbridge.WBTicketNoConfiguration WHERE EstateID = @EstateID 
						END
				END
			ELSE 
				BEGIN 
					IF (@Others = 1)
						BEGIN
							SELECT OtherSerialNo as WBTicketNo FROM Weighbridge.WBTicketNoConfiguration Where EstateID = @EstateID 
						END 
					ELSE
						BEGIN
							SELECT SerialNO as WBTicketNo FROM Weighbridge.WBTicketNoConfiguration WHERE EstateID = @EstateID 
						END
				END
	END 
END 



   
    










