/****** Object:  StoredProcedure [Production].[MachineryMasterSelect]    Script Date: 30/9/2015 5:55:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







ALTER PROCEDURE [Production].[MachineryMasterSelect]

-- Add the parameters for the stored procedure here

@MachineID nvarchar(50),
        @MachineCode nvarchar(50),
        @MachineName nvarchar(80),
        @EstateID nvarchar(50)




AS
        SET NOCOUNT ON;

        IF (@MachineID IS NULL) -- Select all
        BEGIN

                IF (@MachineCode IS NULL)
                SET @MachineCode='';

                IF (@MachineName IS NULL)
                SET @MachineName='';




                SELECT   ROW_NUMBER() OVER(ORDER BY P_Mmas.id) AS RowRank,
                         P_Mmas.MachineID                                ,
                         P_Mmas.EstateID                                 ,
                         P_Mmas.MachineCode                              ,
                         P_Mmas.MachineName                              ,
                         P_Mmas.Descp                                    ,
                         P_Mmas.Capacity                                 ,
                         P_Mmas.UOMID                                    ,
                         P_Mmas.Type                                     ,
                         P_Mmas.BFProcessedHourTD                        ,
                         P_Mmas.BFProcessedHourYTD                       ,
                         P_Mmas.CreatedBy                                ,
                         P_Mmas.CreatedOn                                ,
                         P_Mmas.ModifiedBy                               ,
                         P_Mmas.ModifiedOn                               ,

                         G_UO.UOM
                FROM     Production.MachineryMaster P_Mmas
                         LEFT JOIN General.UOM G_UO
                         ON       G_UO.UOMID =P_Mmas.UOMID
                WHERE    P_Mmas.MachineCode LIKE '%'+ @MachineCode +'%'
                     AND P_Mmas.MachineName LIKE '%'+ @MachineName + '%'
                     AND EstateID=@EstateID
                ORDER BY P_Mmas.ModifiedOn DESC
        END

        ELSE

        BEGIN

                SELECT   ROW_NUMBER() OVER(ORDER BY id) AS RowRank,
                         MachineID                                ,
                         EstateID                                 ,
                         MachineCode                              ,
                         MachineName                              ,
                         Descp                                    ,
                         Capacity                                 ,
                         UOMID                                    ,
                         Type                                     ,
                         BFProcessedHourTD                        ,
                         BFProcessedHourYTD                       ,
                         CreatedBy                                ,
                         CreatedOn                                ,
                         ModifiedBy                               ,
                         ModifiedOn

                FROM     Production.MachineryMaster
                WHERE    MachineID=@MachineID
                     AND EstateID =@EstateID
                ORDER BY ModifiedOn DESC
        END

















