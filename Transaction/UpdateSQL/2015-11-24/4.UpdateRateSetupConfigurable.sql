
/****** Object:  StoredProcedure [Checkroll].[UpdateRateSetupAddConfigurable]    Script Date: 24/11/2015 5:02:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[UpdateRateSetupAddConfigurable]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50),  
@User nvarchar (50)    
AS     
  
BEGIN  
declare @Percentage float
declare @EmpId varchar(25)
declare @AllowDecCode varchar(50)
declare @type varchar(1) --A = Allowance D= Deduction
declare @calcType smallint --0 = Gaji Pokok , 1= Gaji Pokok + Tunjangan Beras , 2 = Gaji Bruto, 3 = Gaji Netto
declare @id varchar(15)
declare @until datetime
declare @tanggal datetime
declare @from datetime
declare @GajiPokok money
declare @GajiPokokTunjanganBeras money
declare @GajiBruto money
declare @GajiNetto money
declare @EstateCode varchar(10)
select @estateCode =EstateCode from General.Estate  where EstateID=@EstateId
set @tanggal= getDate()

select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where ModID  = 1 and Status = 'A'

 DECLARE cData CURSOR FOR   
  
 
SELECT        Checkroll.RateSetupAddConfigurable.Percentage, Checkroll.CREmployee.EmpID, Checkroll.AllowanceDeductionSetup.Type, 
                         Checkroll.RateSetupAddConfigurable.CalcType, Checkroll.Salary.Gol, Checkroll.Salary.TotalBasic + ISNULL(Checkroll.Salary.AllowanceRiceAstek,0), Checkroll.Salary.TotalBruto, Checkroll.Salary.TotalNett, 
                         Checkroll.RateSetupAddConfigurable.AllowDeductionCode
FROM            Checkroll.RateSetupAddConfigurable INNER JOIN
                         Checkroll.CREmployee ON Checkroll.RateSetupAddConfigurable.Category = Checkroll.CREmployee.Category INNER JOIN
                         Checkroll.Salary ON Checkroll.CREmployee.EmpID = Checkroll.Salary.EmpID INNER JOIN
                         Checkroll.AllowanceDeductionSetup ON Checkroll.RateSetupAddConfigurable.AllowDeductionCode = Checkroll.AllowanceDeductionSetup.AllowDedID AND 
                         Checkroll.RateSetupAddConfigurable.EstateId = Checkroll.AllowanceDeductionSetup.EstateID
where Checkroll.Salary.ActiveMonthYearID=@ActiveMonthYearId and Checkroll.Salary.EstateID = @EstateId
						 Open cData  
  
 FETCH NEXT FROM cData  
 INTO @Percentage, @EmpId, @type,@calcType,@GajiPokok,@GajiPokokTunjanganBeras,@GajiBruto,@GajiNetto,@AllowDecCode
     
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	declare @SalaryCalculation Money
    if(@calcType = 0)       -- Gaji Pokok = Upah
		set @SalaryCalculation=@GajiPokok*@Percentage /100
    else if(@calcType = 1)       -- Gaji Pokok + Tunjangan Beras		 = TotalBasic
		set @SalaryCalculation =@GajiPokokTunjanganBeras*@Percentage/100
	else if(@calcType = 2)       -- Gaji Bruto =TotalBruto
		set @SalaryCalculation =@GajiBruto*@Percentage/100
	else if(@calcType = 3)       -- Gaji Neto =TotalNetto
		set @SalaryCalculation =@GajiNetto*@Percentage/100
  
  if(@type='D')
	update Checkroll.Salary set TotalDed = @SalaryCalculation  , TotalNett =TotalNett-@SalaryCalculation
	where ActiveMonthYearID=@ActiveMonthYearId and EstateID=@EstateId and @EmpId=EmpID
  else
	update Checkroll.Salary set Allowance = @SalaryCalculation  , TotalNett =TotalNett+@SalaryCalculation
	where ActiveMonthYearID=@ActiveMonthYearId and EstateID=@EstateId and @EmpId=EmpID

	--tanggal start date dan end date saat insert/update EmpAllowanceDeduction  itu dari mana  ?
	select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllowDecCode and StartDate = @from and EndDates = @until
	if(@@ROWCOUNT=0)
	 exec [Checkroll].[EmpAllowanceDeductionInsert]    
		@id output,@EstateId,@EstateCode,@EmpId,@allowDecCode,
	 	 @SalaryCalculation,@type,@from,@until,@User,@tanggal,@User,@tanggal
	else
	exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@allowDecCode,
	 	 @SalaryCalculation,@type,@from,@until,@User,@tanggal
   FETCH NEXT FROM cData  
     INTO @Percentage, @EmpId, @type,@calcType,@GajiPokok,@GajiPokokTunjanganBeras,@GajiBruto,@GajiNetto,@AllowDecCode
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData  
    
     
END
