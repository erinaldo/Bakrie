
/****** Object:  StoredProcedure [Checkroll].[MonthlyTaxProcess]    Script Date: 16/12/2015 5:47:52 PM ******/
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
DECLARE @MAXLOOP int = 1
declare @EmpId nvarchar(50)
declare @until datetime
declare @from datetime
declare @id varchar(15)
DECLARE @AllowDecCode nvarchar(50)
declare @EstateCode varchar(10)
declare @YearlySalary numeric(18,4)
declare @MonthlySalary numeric(18,4)
declare @Tax numeric(18,4)
declare @tanggal datetime
DECLARE @YearlyTaxableSalary numeric(18,4)
DECLARE @Astek numeric(18,4)
DECLARE @PTKP numeric(18,4)
DECLARE @MaritalStatus nvarchar(3)
DECLARE @HaveNPWP char(1)
DECLARE @GROSSUPValue numeric(18,4)
-- Get from TaxandRiceSetup Table
DECLARE @TunjanganJabatan numeric(18,4)
DECLARE @MaxTunjanganJabatan numeric(18,4)
DECLARE @TaxExemptionWorker numeric(18,4)
DECLARE @TaxExemptionHusbWife numeric(18,4)
DECLARE @TaxExemptionChild numeric(18,4)
DECLARE @GrossUP smallint --Used for BSP Tax calculation as it is paid back as allowance

set @tanggal= getDate()
select @estateCode =EstateCode from General.Estate  where EstateID=@EstateId

select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where am.ActiveMonthYearID = @ActiveMonthYearId

Select @MaxTunjanganJabatan = MaxAllowance,@TaxExemptionWorker =TaxExemptionWorker,
@TaxExemptionHusbWife=TaxExemptionHusbWife,@TaxExemptionChild=TaxExemptionChild, @GrossUP = GrossUP
from Checkroll.TaxAndRiceSetup where EstateID = @EstateId


 DECLARE cData CURSOR FOR   

-- THIS IS THE TAX FORMULA USED AT BSP
-- (Jumlah PENDAPATAN  - Tunjangan Jabatan - Astek - PTKP) * rate of salary at Tax setup with table based on npwp
-- Note : Tax must be calculated on a Yearly Basis so some of the formulas are based on Year not month
--Jumlah Pendapatan = Total Basic + Allowance
-- Tunjangan Jabatan = 5% of Jumlah Pendapatan not more than Max Allowance
-- Astek = Deduction Code D02
-- PTKP = Based on Tax And Rice Setup Emp,Wife and CHild and employees Marital Status 
  
select a.EmpID,AllowanceAmount as MonthSalary,
(AllowanceAmount) * 12 as YearlySalary, isnull(deductionAmount,0) as Astek,MaritalStatus,HaveNPWP
 from 
(select Sum(Round(Amount,0)) as AllowanceAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = Month(@until) and YEar(EndDates) = Year(@until) and type = 'A' and AllowDedID Not IN ('BSP04R4','BSP04R3') group by empid) as a
LEFT join 
(select Sum(Round(Amount,0)) as deductionAmount,EmpID from Checkroll.EmpAllowanceDeduction
where month(EndDates) = Month(@until) and YEar(EndDates) = Year(@until) and type = 'D' and AllowDedID = 'BSP04R44' group by empid)as b
on a.EmpID = b.EmpID
inner join 
(Select HaveNPWP,MaritalStatus,EmpID from Checkroll.CREmployee) as c
 on a.EmpID = c.EmpID  
 --where a.empid = 'C00202116'

Open cData  
  
 FETCH NEXT FROM cData  
 INTO  @EmpId, @MonthlySalary,@YearlySalary,@Astek,@MaritalStatus,@HaveNPWP
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	set @MaritalStatus = RTRIM(@MaritalStatus)
	if Left(@MaritalStatus,1) = 'K' -- Means Worker is married so has tax exemption for wife as well
		begin
			
			Set @PTKP = @TaxExemptionWorker + @TaxExemptionHusbWife + (@TaxExemptionChild * Cast(RIGHT(@MaritalStatus,1) as int))
		end
	else
		begin
			Set @PTKP = @TaxExemptionWorker  + (@TaxExemptionChild * Cast(RIGHT(@MaritalStatus,1) as int))
		end
	SET @Tax =0
	SET @MAXLOOP = 0
	--set @PTKP = @PTKP * 12
	if @GrossUP = 1
		begin
			-- Iterate for gross up calculation
			SET @GROSSUPValue = 0
			SET @TAX = 1
			WHILE @Tax <> @GROSSUPValue
				BEGIN
					Set @TunjanganJabatan = (@YearlySalary + @GROSSUPValue) * 5 / 100
					if @TunjanganJabatan  > @MaxTunjanganJabatan  -- This is so that Max Deduction is not more than Max Allowance for that Year
					begin
						Set @TunjanganJabatan = @MaxTunjanganJabatan
					end
					Set @YearlyTaxableSalary = @YearlySalary + @GROSSUPValue - @TunjanganJabatan - (@Astek *12) - @PTKP
					SET @GROSSUPValue = Round(Checkroll.GetTaxRate(@YearlyTaxableSalary,'Y',@EstateId) ,0) 
					Set @TunjanganJabatan = (@YearlySalary + @GROSSUPValue) * 5 / 100
					if @TunjanganJabatan  > @MaxTunjanganJabatan  -- This is so that Max Deduction is not more than Max Allowance for that Year
					begin
						Set @TunjanganJabatan = @MaxTunjanganJabatan
					end
					Set @YearlyTaxableSalary = @YearlySalary + @GROSSUPValue - @TunjanganJabatan - (@Astek *12) - @PTKP
					SET @Tax = Round(Checkroll.GetTaxRate(@YearlyTaxableSalary,'Y',@EstateId),0)
					Set @MAXLOOP = @MAXLOOP + 1
					if @MAXLOOP > 100 
						break
				END
				
		end
	else
		begin
			Set @TunjanganJabatan = @YearlySalary * 5 / 100
			if @TunjanganJabatan  > @MaxTunjanganJabatan  -- This is so that Max Deduction is not more than Max Allowance for that Year
				begin
					Set @TunjanganJabatan = @MaxTunjanganJabatan
				end
			 Set @YearlyTaxableSalary = @YearlySalary - @TunjanganJabatan - (@Astek *12) - @PTKP
			 if @YearlyTaxableSalary > 0 
				begin
					SET @Tax = Checkroll.GetTaxRate(@YearlyTaxableSalary,@HaveNPWP,@EstateId) / 12 
				end
			 else
				begin
					Set @Tax = 0
				end
		end	
	SET @Tax = @TAx / 12 
	if @Tax > 0 
	begin

		set @AllowDecCode = 'BSP04R50'
		set @id = null
		select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until  
		if(@id is null)
			begin	
				exec [Checkroll].[EmpAllowanceDeductionInsert]    
						@id output,@EstateId,@EstateCode,@EmpId,@allowDecCode,
	 					@Tax,'D',@from,@until,@User,@tanggal,@User,@tanggal
			end
		else
			begin
				exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@allowDecCode,
	 			@Tax,'D',@from,@until,@User,@tanggal
			end
		
		set @AllowDecCode = 'BSP04R4'
		set @id = null
		select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until  
		if(@id is null)
			begin
				exec [Checkroll].[EmpAllowanceDeductionInsert]    
				@id output,@EstateId,@EstateCode,@EmpId,@allowDecCode,
	 			@Tax,'A',@from,@until,@User,@tanggal,@User,@tanggal
			end
		else
			begin
				exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@allowDecCode,
	 			@Tax,'A',@from,@until,@User,@tanggal
			end
	end

	else
		begin
			set @AllowDecCode = 'BSP04R50'
			Delete from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until  
			set @AllowDecCode = 'BSP04R4'
			Delete from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until  
		end
		

   FETCH NEXT FROM cData  
		INTO  @EmpId, @MonthlySalary,@YearlySalary,@Astek,@MaritalStatus,@HaveNPWP
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData  

END
