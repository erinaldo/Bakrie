USE [BSPMS_SR]
GO
/****** Object:  StoredProcedure [Checkroll].[OnCostProcessDet]    Script Date: 12/6/2014 5:22:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Remarks: SAI: this SP can be modified by using sum and group instead of cursors

--Exec [CheckRoll].[OnCostProcessDet] 'M1','01R81','Admin'
--select * from Checkroll.OnCostProcessingDet 
--delete from Checkroll.OnCostProcessingDet 

ALTER PROCEDURE [Checkroll].[OnCostProcessDet]
@EstateId nvarchar(50),
@ActiveMonthYearID nvarchar(50),
@Createdby nvarchar(50)
AS
BEGIN


Delete from Checkroll .OnCostProcessingDet where EstateID =@EstateId and ActivemonthyearID=@ActiveMonthYearID 

DECLARE GangPANEN_Cursor CURSOR READ_ONLY FOR
	
	Select GangMaster.GangMasterID, DailyReceiption.DivID,DailyReceiption.YOPID , DailyReceiption.BlockID    
, GangMaster.Descp   From Checkroll.DailyReceiption 
INNER JOIN Checkroll.DailyAttendance ON DailyAttendance.DailyReceiptionID = DailyReceiption.DailyReceiptionID 
INNER JOIN General.YOP ON YOP.YOPID = DailyReceiption.YOPID
INNER JOIN General.BlockMaster  ON BlockMaster.YOPID = YOP.YOPID 
INNER JOIN Checkroll.DailyTeamActivity ON DailyTeamActivity.DailyTeamActivityID = DailyAttendance.DailyTeamActivityID 
INNER JOIN Checkroll.GangMaster ON GangMaster.GangMasterID = DailyTeamActivity.GangMasterID 
Where GangMaster.Descp = 'PANEN' AND GangMaster.EstateID = @EstateId
Group by  GangMaster.GangMasterID, DailyReceiption.DivID,DailyReceiption.YOPID , DailyReceiption.BlockID
, GangMaster.Descp 
	
		
	DECLARE @GangMasterID VARCHAR(50)   
	DECLARE @DivID VARCHAR(50)   
	DECLARE @YOPID VARCHAR(50)   
	DECLARE @BlockID VARCHAR(50)   
	DECLARE @Descp VARCHAR(50)       
	OPEN GangPANEN_Cursor    
	   
		FETCH NEXT FROM GangPANEN_Cursor INTO @GangMasterID ,@DivID ,@YOPID  ,@BlockID ,@Descp     
		WHILE @@FETCH_STATUS = 0   
		Begin
				DECLARE @HA Numeric(18,2)
				DECLARE @TotHK Numeric(18,2) 
				DECLARE @OnCost Numeric(18,2)
				DECLARE @PremiValue Numeric(18,2)
				
				Select @HA=ISNULL(BlockMaster.PlantedHect,0)  From General.BlockMaster where DivID=@DivID and YOPID=@YOPID and BlockID=@BlockID
				
				Select @TotHK=ISNULL(sum(BlkHK),0)   from Checkroll.DailyReceiption where DivID=@DivID and YOPID=@YOPID and BlockID=@BlockID
				
				select @OnCost=ISNULL(OnCost,0)  from Checkroll.OnCostProcessing where GangMasterID=@GangMasterID
				
				select @PremiValue=ISNULL(SUM(PremiValue),0) from Checkroll.DailyReceiption where DivID=@DivID and YOPID=@YOPID and BlockID=@BlockID
				IF Not Exists(select ID from Checkroll.OnCostProcessingDet where EstateID=@EstateId and ActiveMonthYearID=@ActiveMonthYearID and GangMasterID=@GangMasterID and Activity=@Descp and TotHK=@TotHK and DivID=@DivID and YOPID=@YOPID and BlockID=@BlockID and HA=@HA and OnCost=@OnCost and PremiValue=@PremiValue )
				BEGIN
					INSERT INTO Checkroll.OnCostProcessingDet (EstateID,ActiveMonthYearID,GangMasterID,Activity,TotHk,DivID,YOPID,BlockID,HA,OnCost,PremiValue,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn ) 
					Values(@EstateId,@ActiveMonthYearID,@GangMasterID,@Descp,@TotHK,@DivID,@YOPID,@BlockID,@HA,@OnCost,@PremiValue,@Createdby,GETDATE(),@Createdby,GETDATE())
				END
		FETCH NEXT FROM GangPANEN_Cursor INTO @GangMasterID ,@DivID ,@YOPID  ,@BlockID ,@Descp     
		End
		
		CLOSE GangPANEN_Cursor        
		DEALLOCATE GangPANEN_Cursor
		
		
		END
