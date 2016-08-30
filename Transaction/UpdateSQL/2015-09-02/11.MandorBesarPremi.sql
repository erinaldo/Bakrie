
/****** Object:  StoredProcedure [Checkroll].[TransferSalaryToAllowance]    Script Date: 26/8/2015 10:50:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [Checkroll].[CalculatePremiMandorBesar]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50),  
@User nvarchar (50)    
AS     
  
BEGIN  
declare @EmpId nvarchar(50)
declare @TotalPremi numeric(18,2)
declare @MandorDiawasi numeric(18,2)
declare @ddate date
declare @until datetime
declare @tanggal datetime
declare @from datetime
declare @id varchar(15)
declare @DailyTeamActivityId nvarchar(50)
declare @HaDiawasi numeric(18,2)
set @tanggal= getDate()


select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where am.ActiveMonthYearID = @ActiveMonthYearId

 DECLARE cData CURSOR FOR   
  
 --Panen
Select MandorBesarId, Count(MandoreID), Sum(MandorPremi),DDate,DailyTeamActivityID from checkroll.DailyTeamActivity
where Activity = 'Panen' AND DDate between @from and @Until
Group By MandorBEsarId,DDate,DailyTeamActivityID

Open cData  
  
 FETCH NEXT FROM cData  
 INTO  @EmpId, @MandorDiawasi,@TotalPremi,@DDate,@DailyTeamActivityID
     
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	
	-- Premi Panen
	set @HaDiawasi = Checkroll.CRGetHA(@Empid,'Panen',@DailyTeamActivityId)
	select @id = id from Checkroll.MandorBesarPremi where EmpID=@EmpId and DDate = @DDate
	if(@@ROWCOUNT=0)
		insert into checkroll.mandorbesarpremi(EmpId,EstateId,MandorPanenDiawasi,HaPanenDiawasi,PremiPanen,DDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)
		Values (@Empid,@EstateId,@MandorDiawasi,@HaDiawasi,@TotalPremi,@DDate,'system', GetDate(),'system',GetDate())
	else
		Update checkroll.MandorBesarPremi Set MandorPanenDiawasi = @MandorDiawasi, PremiPanen= @TotalPremi,DDate = @DDate,HaPanenDiawasi=@HaDiawasi,
		ModifiedBy = 'system', ModifiedDate = GetDate() where id = @id

   FETCH NEXT FROM cData  
     INTO @EmpId, @MandorDiawasi,@TotalPremi,@DDate,@DailyTeamActivityID
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData  
  
 --DERES
 DECLARE cData CURSOR FOR   
  
 --Deres
Select MandorBesarId, Count(MandoreID), Sum(MandorPremi),DDate,DailyTeamActivityID from checkroll.DailyTeamActivity
where Activity = 'DERES' AND DDate between @from and @Until
Group By MandorBEsarId,DDate,DailyTeamActivityID

Open cData  
  
 FETCH NEXT FROM cData  
 INTO  @EmpId, @MandorDiawasi,@TotalPremi,@DDate,@DailyTeamActivityID
     
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	set @HaDiawasi = Checkroll.CRGetHA(@Empid,'Deres',@DailyTeamActivityId)
	select @id = id from Checkroll.MandorBesarPremi where EmpID=@EmpId and DDate = @DDate
	if(@@ROWCOUNT=0)
		insert into checkroll.mandorbesarpremi(EmpId,EstateId,MandorDeresDiawasi,HaDeresDiawasi,PremiDeres,DDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)
		Values (@Empid,@EstateId,@MandorDiawasi,@HaDiawasi,@TotalPremi,@DDate,'system', GetDate(),'system',GetDate())
	else
		Update checkroll.MandorBesarPremi Set MandorDeresDiawasi = @MandorDiawasi, PremiDeres= @TotalPremi,DDate = @DDate,HaDeresDiawasi = @HaDiawasi,
		ModifiedBy = 'system', ModifiedDate = GetDate() where id = @id
   FETCH NEXT FROM cData  
     INTO @EmpId, @MandorDiawasi,@TotalPremi,@DDate,@DailyTeamActivityID
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData 
 
 --Update premi total based on ha diawasi if 2 crop
 Update Checkroll.MandorBesarPremi set MandorDeresDiawasi = 0, HaDeresDiawasi =0, PremiDeres = 0 where MandorDeresDiawasi is null
 Update Checkroll.MandorBesarPremi set MandorPanenDiawasi = 0, HaPanenDiawasi =0, PremiPanen = 0 where MandorPanenDiawasi is null 
 Update Checkroll.MandorBesarPremi set PremiDibayar = 
	Case 
		when PremiDeres > 0 and PremiPanen > 0 then
			((HaDeresDiawasi/(HaDeresDiawasi + HaPanenDiawasi)) * (((PremiDeres/ MandorDeresDiawasi * 2)  + (PremiPanen / MandorPanenDiawasi * 2)) / 2)) + ((HaPanenDiawasi/(HaDeresDiawasi + HaPanenDiawasi)) * (((PremiDeres/ MandorDeresDiawasi * 2)  + (PremiPanen / MandorPanenDiawasi * 2)) / 2) )
		when PremiDeres > 0 then
			PremiDeres / MandorDeresDiawasi * 2
		when PremiPanen > 0 then
			PremiPanen / MandorPanenDiawasi * 2
	end 

END
