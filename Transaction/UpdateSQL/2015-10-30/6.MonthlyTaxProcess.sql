
/****** Object:  StoredProcedure [Checkroll].[CalculatePremiMandorBesar]    Script Date: 29/10/2015 12:09:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[MonthlyTaxProcess]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50),  
@User nvarchar (50)    
AS     
  
BEGIN  
declare @EmpId nvarchar(50)
declare @until datetime
declare @from datetime
declare @id varchar(15)
DECLARE @AllowDecCode nvarchar(50)
declare @EstateCode varchar(10)
declare @YearlySalary numeric(18,3)
declare @MonthlySalary numeric(18,3)
declare @Tax numeric(18,3)
declare @tanggal datetime
set @tanggal= getDate()
select @estateCode =EstateCode from General.Estate  where EstateID=@EstateId

select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where am.ActiveMonthYearID = @ActiveMonthYearId

 DECLARE cData CURSOR FOR   
  
select a.EmpID,AllowanceAmount - deductionAmount as MonthSalary,
(AllowanceAmount - deductionAmount) * 12 as YearlySalary
 from 
(select Sum(Amount) as AllowanceAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = Month(@until) and YEar(EndDates) = Year(@until) and type = 'A' and AllowDedID <> 'BSP04R4' group by empid) as a
inner join 
(select Sum(Amount) * -1 as deductionAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = Month(@until) and YEar(EndDates) = Year(@until) and type = 'D' and AllowDedID <> 'BSP04R50' group by empid)as b
on a.EmpID = b.EmpID

Open cData  
  
 FETCH NEXT FROM cData  
 INTO  @EmpId, @MonthlySalary,@YearlySalary
     
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	SET @TAX = 
	CASE 
		WHEN @YearlySalary > 20000000 and @YearlySalary < 50000000  then  @MonthlySalary * 5 /100 
		WHEN @YearlySalary > 50000001 and  @YearlySalary > 250000000 then  @MonthlySalary * 15/100		
		WHEN @YearlySalary > 50000001 and  @YearlySalary > 250000000 then @MonthlySalary * 25 /100
		ELSE  0
	end
	if @Tax <> 0 
		set @AllowDecCode = 'BSP04R50'
		select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until  
		if(@@ROWCOUNT=0)
			exec [Checkroll].[EmpAllowanceDeductionInsert]    
			@id output,@EstateId,@EstateCode,@EmpId,@allowDecCode,
	 		@Tax,'D',@from,@until,@User,@tanggal,@User,@tanggal
		else
			exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@allowDecCode,
	 		@Tax,'D',@from,@until,@User,@tanggal

		set @AllowDecCode = 'BSP04R4'
		select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until  
		if(@@ROWCOUNT=0)
			exec [Checkroll].[EmpAllowanceDeductionInsert]    
			@id output,@EstateId,@EstateCode,@EmpId,@allowDecCode,
	 		@Tax,'A',@from,@until,@User,@tanggal,@User,@tanggal
		else
			exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@allowDecCode,
	 		@Tax,'A',@from,@until,@User,@tanggal
	
   FETCH NEXT FROM cData  
		INTO  @EmpId, @MonthlySalary,@YearlySalary
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData  

END
