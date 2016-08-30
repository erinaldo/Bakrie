DECLARE @PremiSetupYOPID nvarchar(50)
DECLARE @MaxID as int	
DECLARE cData CURSOR FOR   
  Select a.PremiSetupYOPID from Checkroll.PremiSetupYOP a where AttendanceSetupID = '02R94'
Open cData  
FETCH NEXT FROM cData  
INTO  @PremiSetupYOPID
     
WHILE @@FETCH_STATUS = 0 
BEGIN
	SELECT @MaxID = Max(ID) + 1 from Checkroll.PremiSetupYOP 
	
	--insert into Checkroll.PremiSetupYOP(PremiSetupYOPID,EstateID,DivID,YOPID,AttendanceSetupID,MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate)
	--select 'BSPR03'+ CAST(@MaxID AS VARCHAR),EstateID,DivID,YOPID,'02R132',MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate from Checkroll.PremiSetupYOP
	--where PremiSetupYOPID = @PremiSetupYOPID

	SELECT @MaxID = @MAxid + 1
	insert into Checkroll.PremiSetupYOP(PremiSetupYOPID,EstateID,DivID,YOPID,AttendanceSetupID,MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate)
	select 'BSPR03'+ CAST(@MaxID AS VARCHAR),EstateID,DivID,YOPID,'02R131',MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate from Checkroll.PremiSetupYOP
	where PremiSetupYOPID = @PremiSetupYOPID

	SELECT @MaxID = @MAxid + 1
	insert into Checkroll.PremiSetupYOP(PremiSetupYOPID,EstateID,DivID,YOPID,AttendanceSetupID,MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate)
	select 'BSPR03'+ CAST(@MaxID AS VARCHAR),EstateID,DivID,YOPID,'02R130',MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate from Checkroll.PremiSetupYOP
	where PremiSetupYOPID = @PremiSetupYOPID

	SELECT @MaxID = @MAxid + 1
	insert into Checkroll.PremiSetupYOP(PremiSetupYOPID,EstateID,DivID,YOPID,AttendanceSetupID,MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate)
	select 'BSPR03'+ CAST(@MaxID AS VARCHAR),EstateID,DivID,YOPID,'02R129',MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate from Checkroll.PremiSetupYOP
	where PremiSetupYOPID = @PremiSetupYOPID

	SELECT @MaxID = @MAxid + 1
	insert into Checkroll.PremiSetupYOP(PremiSetupYOPID,EstateID,DivID,YOPID,AttendanceSetupID,MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate)
	select 'BSPR03'+ CAST(@MaxID AS VARCHAR),EstateID,DivID,YOPID,'02R128',MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate from Checkroll.PremiSetupYOP
	where PremiSetupYOPID = @PremiSetupYOPID

	SELECT @MaxID = @MAxid + 1
	insert into Checkroll.PremiSetupYOP(PremiSetupYOPID,EstateID,DivID,YOPID,AttendanceSetupID,MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate)
	select 'BSPR03'+ CAST(@MaxID AS VARCHAR),EstateID,DivID,YOPID,'02R118',MinBunches,MaxBunches,BunchRate,MinLooseFruits,MaxLooseFruits,LooseFruitsRate from Checkroll.PremiSetupYOP
	where PremiSetupYOPID = @PremiSetupYOPID

   FETCH NEXT FROM cData  
     INTO @PremiSetupYOPID
         
 END  
  CLOSE cData  
 DEALLOCATE cData 
--insert into Vehicle.VHWSMasterHistory(VHWSMasterHistoryID,VHID,VHCategoryID,EstateID,AYear,AMonth,VHWSCode,PurDate,VHModel,VHDescp,UOM,Job,DateOfCommission,FuelType,ChasisNo,Active,EngineNo,Supplier,RegNo,VHColor,STNK,EMPID,LocationID,Remarks,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,COAID,StandardRate,Type)
