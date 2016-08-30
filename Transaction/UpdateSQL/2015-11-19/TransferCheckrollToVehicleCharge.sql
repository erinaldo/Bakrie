Create PROCEDURE Checkroll.TransferCheckrollToVehicleCharge
@EstateId nvarchar (50),
@ActiveMonthYearId nvarchar (50),    
@User nvarchar (50)  
AS

Declare @AMonth int
Declare @AYear numeric(18,0)
DECLARE @EstateCode nvarchar(50)
DECLARE @VHWSCode nvarchar(50)
DECLARE @VHDetailCostCode nvarchar(50)
DECLARE @DailyRate numeric(18,0)
DECLARE @CreatedDate datetime

SELECT @AMonth= AMonth,@AYear =AYear from General.ActiveMonthYear where ActiveMonthYearID = @ActiveMonthYearId
SET @CreatedDate = GETDATE()
--First delete vehicle that is part of checkroll for that month
Delete from Vehicle.VHChargeDetail where ModID = 1 And AMonth = @Amonth and AYear = @AYear

DECLARE cData CURSOR FOR   

select b.EstateCode,  d.VHWSCode,
 c.VHDetailCostCode,Checkroll.GetTeamActualDailyRate(a.GangMasterId,a.DistbDate) * TotalHK from checkroll.DailyActivityDistribution  a 
inner join General.Estate b on a.EstateID = b.EstateID
inner join Vehicle.VHDetailCostCode c on a.VHDetailCostCodeID = c.VHDetailCostCodeID
inner join Vehicle.VHMaster d on a.VHID = d.VHID
where a.vhid is not null and a.ActiveMonthYearID = @ActiveMonthYearId
Open cData  
  
 FETCH NEXT FROM cData  
 INTO  @EstateCode, @VHWSCode,@VHDetailCostCode,@DailyRate

 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	execute Vehicle.VHChargeDetailInsert @EstateCode,@VhwsCode,@EstateCode,@VhDetailCostCode,'V','Checkroll',@Ayear,
	@Amonth,@DailyRate,'Wages',@User,@CreatedDate,@User,@CreatedDate,'Checkroll','Checkroll'

   FETCH NEXT FROM cData  
     INTO @EstateCode, @VHWSCode,@VHDetailCostCode,@DailyRate
 END  
     
 CLOSE cData  
 DEALLOCATE cData  
