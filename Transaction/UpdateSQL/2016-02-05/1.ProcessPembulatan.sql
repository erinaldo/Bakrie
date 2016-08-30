
CREATE PROCEDURE [Checkroll].[ProcessPembulatan]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50),  
@User nvarchar (50)    
AS
--declare @ActiveMonthYearId nvarchar (50)
--declare @EstateId nvarchar (50) 
--declare @User nvarchar (50) 

declare @tanggal datetime
declare @EmpId nvarchar(50)
declare @until datetime
declare @from datetime
declare @EstateCode varchar(10)
Declare @Income numeric(18,2)
Declare @Deduction numeric(18,2)
DEclare @BankId nvarchar(10)
Declare @BankAccountNo nvarchar(50)
DECLARE @Pembulatan integer
DECLARE @AllowDecCode nvarchar(50)
Declare @Id as nvarchar(50)
Declare @nextStartDate as date


Select @ActiveMonthYearId =  ActivemonthYearID from General.ActiveMonthYear where Status ='A' and ModID = 1
set @tanggal= getDate()
select @estateCode =EstateCode from General.Estate  where EstateID=@EstateId

select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where am.ActiveMonthYearID = @ActiveMonthYearId

Set @nextStartDate = DATEADD(mm,1,@from)
Delete from Checkroll.EmpAllowanceDeduction where  AllowDedID ='BSP04R45' and StartDate = @nextStartDate and EndDates = @nextStartDate  

DECLARE cData CURSOR FOR 
	select a.EmpID,AllowanceAmount as Income, isnull(deductionAmount,0) as Deduction,BankID,BankAccountNo
 from 
(select Sum(Round(Amount,0)) as AllowanceAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = Month(@until) and YEar(EndDates) = Year(@until) and type = 'A'  group by empid) as a
LEFT join 
(select Sum(Round(Amount,0)) as deductionAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = Month(@until) and YEar(EndDates) = Year(@until) and type = 'D'  group by empid)as b
on a.EmpID = b.EmpID
inner join 
(Select BankID,BankAccountNo,EmpID from Checkroll.CREmployee where BankID = 'M33' or BankID = '' or BankID is null) as c
 on a.EmpID = c.EmpID  

Open cData  
  
 FETCH NEXT FROM cData  
 INTO  @EmpId,@Income,@Deduction,@BankId,@BankAccountNo
 WHILE @@FETCH_STATUS = 0   
 BEGIN

	Set @Pembulatan = (CEILING((@Income - @Deduction)/ 1000) * 1000) - (@Income - @Deduction)
	
	if @Pembulatan > 0 
	begin

		set @AllowDecCode = 'BSP04R45'
		set @id = null
		select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until  
		if(@id is null)
			begin	
				exec [Checkroll].[EmpAllowanceDeductionInsert]    
						@id output,@EstateId,@EstateCode,@EmpId,@allowDecCode,
	 					@Pembulatan,'D',@nextStartDate,@nextStartDate,@User,@tanggal,@User,@tanggal
			end
		else
			begin
				exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@allowDecCode,
	 			@Pembulatan,'D',@nextStartDate,@nextStartDate,@User,@tanggal
			end
	end

	else
		begin
			set @AllowDecCode = 'BSP04R45'
			Delete from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @nextStartDate and EndDates = @nextStartDate  
		end
	Print @EmpId 
	Print @Pembulatan

FETCH NEXT FROM cData  
INTO  @EmpId,@Income,@Deduction,@BankId,@BankAccountNo
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData  