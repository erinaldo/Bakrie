

/****** Object:  StoredProcedure [Production].[LabSoftnerInsert]    Script Date: 13/01/2015 14:41:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

























--======================================================          
-- Created By : Kumaravel        
-- Created date:  Dec 30 , 2009       
-- Modified By: Kumaravel     
-- Last Modified Date:Dec 30 , 2009           
-- Module     : Production     
-- Screen(s)  : Laboratory Analysis   
-- Description: To Insert LaboratoryAnalysis
--====================================================== 

CREATE PROCEDURE [Production].[LabSoftnerInsert]
 
		   
           @EstateID nvarchar(50),
           @EstateCode nvarchar(50),
           @ActiveMonthYearID nvarchar(50),
           @LabAnalysisID nvarchar(50),
           @Descp nvarchar(80),
           @Type nvarchar(50),
           @Dosage numeric(18,2),
           @CreatedBy nvarchar(50),
           @CreatedOn datetime,
           @ModifiedBy nvarchar(50),
           @ModifiedOn datetime,
           @Anion as varchar(50)
         AS
       

                  
           
BEGIN TRY

    -- Get New Primary key
    
   
  
  Declare @LabSoftnerID nvarchar(50)     
  
  
    
  
                    DECLARE @i INT = 2
                        SELECT @LabSoftnerID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                        FROM   Production.LabSoftner   
                        WHILE EXISTS
                        (SELECT id
                        FROM    Production.LabSoftner
                        WHERE   LabSoftnerID  = @LabSoftnerID
                        )
                        BEGIN
                                SELECT @LabSoftnerID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                                FROM   Production.LabSoftner  
                                SET @i = @i + 1
				END    
 INSERT INTO Production.LabSoftner  
		  ([LabSoftnerID]
           ,[EstateID]
           ,[ActiveMonthYearID]
           ,[LabAnalysisID]
           ,[Descp]
           ,[Type]
           ,[Dosage]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn]
		   ,[Anion])
     Values
			(@LabSoftnerID
           ,@EstateID
           ,@ActiveMonthYearID
           ,@LabAnalysisID
           ,@Descp
           ,@Type
           ,@Dosage
           ,@CreatedBy
           ,GETDATE ()
           ,@ModifiedBy
           ,GETDATE ()
           ,@Anion );
         

  select 1
		
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


