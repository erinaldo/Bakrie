
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [Checkroll].[TransferPieceRateToAllowance]  
@ActiveMonthYearId nvarchar (50),  
@EstateId nvarchar (50),
@User nvarchar(50) 
AS     
  
BEGIN  
declare @PDate datetime
declare @UnitCompleted float
declare @EmpID nvarchar(50)
declare @JobRate float
declare @AllDedCode nvarchar(50)
declare @COADesc nvarchar(2000)
declare @until datetime
declare @tanggal datetime
declare @from datetime
declare @EstateCode varchar(10)
declare @id bigint
select @estateCode =EstateCode from General.Estate  where EstateID=@EstateId
set @tanggal= getDate()

select @from=FromDT,@until=ToDT from General.ActiveMonthYear AM 
inner join General.FiscalYear FY on AM.AMonth = FY.Period and  AM.AYear = FY.FYear
where ModID  = 1 and Status = 'A'

 DECLARE cData CURSOR FOR   
  
 
SELECT PT.Date,PT.EmpID,PA.JobRate * PT.UnitCompleted as TotalPaid,PR.AllowanceDeductionCode,PR.Description as COADesc from Checkroll.PieceRateTransaction PT
inner join Checkroll.PieceRateActivity PA on PT.PieceRateActivityId = PA.Id
inner join Checkroll.PieceRate PR on PA.ReferenceNo = PR.ReferenceNo
where Pt.Date BETWEEN @from and @until and PR.EstateID = @EstateId AND PR.AllowanceDeductionCode is not null
Open cData  
  
 FETCH NEXT FROM cData  
 INTO @PDate,@EmpID,@JobRate,@AllDedCode,@COADesc
     
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	select @id = EmpAllowDedID from Checkroll.EmpAllowanceDeduction where EmpID=@EmpId and AllowDedID =@AllDedCode and StartDate = @from and EndDates = @until
	if(@@ROWCOUNT=0)
	 exec [Checkroll].[EmpAllowanceDeductionInsert]    
		@id output,@EstateId,@EstateCode,@EmpId,@AllDedCode,
	 	 @JobRate,'A',@from,@until,@User,@tanggal,@User,@tanggal
	else
	exec[Checkroll].[EmpAllowanceDeductionUpdate] @id output,@EstateId,@EmpId,@AllDedCode,
	 	 @JobRate,'A',@from,@until,@User,@tanggal
   FETCH NEXT FROM cData  
     INTO @PDate,@EmpID,@JobRate,@AllDedCode,@COADesc
         
 END  
    
 CLOSE cData  
 DEALLOCATE cData  
    
     
END
