

/****** Object:  StoredProcedure [Production].[CPOProductionStockInsert]    Script Date: 13/01/2015 14:40:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Production].[CPOProductionStockInsert]
 
		 --  @GradingID nvarchar(50) output,
           @EstateID nvarchar(50),
           @EstateCode nvarchar(50),
           @ProductionID nvarchar(50),
           @StockTankID nvarchar(50),
        
          
            @Capacity  numeric(18,3)
           ,@PrevDayReading  numeric(18,3)
           ,@CurrentReading  numeric(18,3)
           ,@Writeoff numeric(18,3)
           ,@Reason nvarchar(150)
           ,@Measurement  numeric(18,2)
           ,@Temp  numeric(18,2)
           ,@FFAP  numeric(18,2)
           ,@MoistureP numeric(18,2)  
           ,@DirtP numeric(18,3),   
           
           @ActiveMonthYearID nvarchar(50),
           @CropYieldID nvarchar(50),
           
           @CreatedBy nvarchar(50),
           @CreatedOn datetime,
           @ModifiedBy nvarchar(50),
           @ModifiedOn datetime,

		   @BeritaAcara as varchar(50)
 

AS

--INSERT FOR PRODUCT STOCK CPO-----

BEGIN 

    -- Get New Primary key
    
    --Declare @countStock int;
    Declare @ProdStockID nvarchar(50);


    --SET @countStock = 0;
    
    --SELECT @countStock = (ISNULL(MAX(Id),0) + 1) FROM Production.CPOProductionStockCPO ;
    --SET @ProdStockID = @EstateCode+ 'R' + CONVERT(NVARCHAR,@countStock);
    
       -- Get New Primary key
                SELECT @ProdStockID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                FROM   Production.CPOProductionStockCPO
                DECLARE @i INT = 2
                WHILE EXISTS
                (SELECT id
                FROM    Production.CPOProductionStockCPO
                WHERE   ProdStockID = @ProdStockID
                )
                BEGIN
                        SELECT @ProdStockID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                        FROM  Production.CPOProductionStockCPO
                        SET @i = @i + 1
                END
    
    
 INSERT INTO Production.CPOProductionStockCPO    
			([ProdStockID] 
			,[EstateID]
			,[ActiveMonthYearID]
           ,[ProductionID]
           ,[TankID]
          -- ,[KernelStorageID] 
           ,[Capacity] 
           ,[PrevDayReading]  
           ,[CurrentReading] 
           ,[Writeoff] 
           ,[Reason]
           ,[Measurement]  
           ,[Temp]   
           ,[FFAP]   
           ,[MoistureP]   
           ,[DirtP]    
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn]
		   ,[BeritaAcara])
   
     Values
			(
			@ProdStockID
           ,@EstateID
           ,@ActiveMonthYearID
           ,@ProductionID
           ,@StockTankID 
           ,@Capacity  
           ,@PrevDayReading
           ,@CurrentReading 
           ,@Writeoff 
           ,@Reason
           ,@Measurement 
           ,@Temp 
           ,@FFAP 
           ,@MoistureP 
           ,@DirtP 
           ,@CreatedBy
           ,GETDATE ()
           ,@ModifiedBy
           ,GETDATE ()
		   ,@BeritaAcara );
	
END

GO


