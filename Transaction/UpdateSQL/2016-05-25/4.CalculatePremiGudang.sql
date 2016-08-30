CREATE PROCEDURE [Checkroll].[CalculatePremiGudang]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50),
@User nvarchar(50) 
AS     
DECLARE @DateFrom datetime
DECLARE @DateTo datetime
Declare @BlockID nvarchar(50),@EmpID nvarchar(50),@TPH nvarchar(50)
DECLARE @TotalPremi numeric(18,3)
DECLARE @TotalLatex numeric(18,3)
DECLARE @TotalTreeLace numeric(18,3)
DECLARE @TotalCupLump numeric(18,3)
Declare @PremiGudang numeric(18,3)
DECLARE @CountPenderes numeric(18,3)
DECLARE @AllowDecCode nvarchar(50)
DECLARE @id bigint
DECLARE @estateCode nvarchar(50)
DECLARE @tanggal datetime
Declare @Amonth int, @Ayear int
select @estateCode =EstateCode from General.Estate  where EstateID=@EstateId
set @tanggal= getDate()
--Get the allowance id for Premi Gudang Allowance Code
select @AllowDecCode = AllowDedID from Checkroll.AllowanceDeductionSetup where AllowDedCode = 'A48'



--Need to delete all old Allowance Record for the month for the Premi Gudang first, in case of changes in dat
Select @Amonth=AMonth,@Ayear=AYear from General.ActiveMonthYear where ActiveMonthYearID = @ActiveMonthYearId
Delete from Checkroll.EmpAllowanceDeduction where AllowDedID = @AllowDecCode and Month(StartDate) =@Amonth and Year(StartDate) = @Ayear


DECLARE cData CURSOR FOR   
  select  BlockID,EmpID,TPH,RDate from Checkroll.DailyAttendanceMandor a where BlockID is not null and BlockId <> ''
  and ActiveMonthYearId =@ActiveMonthYearId
Open cData  
FETCH NEXT FROM cData  
INTO  @BlockID,@EmpID,@TPH,@DateFrom
     
WHILE @@FETCH_STATUS = 0 
BEGIN
	
	Set @TotalLatex = 0
	Set @TotalTreeLace = 0
	Set @TotalCupLump = 0
	Set @PremiGudang = 0
	
	-- New Formula
	-- Total Premi / No of Penderes for respective day and tph
	
	select @TotalPremi=Sum(ISNULL(PremiDasarLatex,0)+ ISNULL(PremiProgresifLatex,0) + 
	ISNULL(PremibonusLatex,0)+ISNULL(PremiMinggu,0)+ISNULL(PremiDasarLump,0)+ISNULL(PremiBonusLump,0)+ISNULL(PremiProgresifLump,0)
	+ISNULL(PremiTreelace,0)),
	@CountPenderes=COUNT(NIK) from Checkroll.DailyReceptionForRubber
	where FieldNo=@BlockID and TPH = @TPH and DateRubber = @DateFrom

	Set @PremiGudang = @TotalPremi/@CountPenderes
	-- Old Formula is 
	-- Latex Dry / Total Penderes * 80rp
	-- CupLump Dry / Total Penderes * 130 rp
	-- Tree Lace Wet / Total Penderes * 275 rp
	--select @TotalLatex=Sum(Latex*DRC / 100),@TotalCupLump=Sum(CupLamp*DRCCupLump / 100),@TotalTreeLace =Sum(TreeLace),
	--@CountPenderes=COUNT(NIK) from Checkroll.DailyReceptionForRubber
	--where FieldNo=@BlockID and TPH = @TPH and DateRubber = @DateFrom
	
	--Set @PremiGudang = (@TotalLatex /@CountPenderes * 80) + (@TotalCupLump /@CountPenderes * 130) + (@TotalLatex / @CountPenderes * 275)
	--Could be faster if the check for id is removed since all records for that month have been deleted
		
	if @PremiGudang > 0 
	begin
		--select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @DateFrom and EndDates = @DateFrom  
		--if(@@ROWCOUNT=0)
			exec [Checkroll].[EmpAllowanceDeductionInsert]    
			@id output,@EstateId,@EstateCode,@EmpId,@allowDecCode,
	 		 @PremiGudang,'A',@DateFrom,@DateFrom,@User,@tanggal,@User,@tanggal
		--else
		--	exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@allowDecCode,
	 --		 @PremiGudang,'A',@DateFrom,@DateFrom,@User,@tanggal
	end
		
   FETCH NEXT FROM cData  
     INTO @BlockID,@EmpID,@TPH,@DateFrom
 
 END  
  CLOSE cData  
 DEALLOCATE cData 
--insert into Vehicle.VHWSMasterHistory(VHWSMasterHistoryID,VHID,VHCategoryID,EstateID,AYear,AMonth,VHWSCode,PurDate,VHModel,VHDescp,UOM,Job,DateOfCommission,FuelType,ChasisNo,Active,EngineNo,Supplier,RegNo,VHColor,STNK,EMPID,LocationID,Remarks,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,COAID,StandardRate,Type)
