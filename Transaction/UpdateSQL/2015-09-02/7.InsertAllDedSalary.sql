
/****** Object:  StoredProcedure [Checkroll].[InsertAllDedSalary]    Script Date: 2/9/2015 8:57:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[InsertAllDedSalary]
@ActiveMonthYearId nvarchar (50),
@EstateId nvarchar (50),
@User nvarchar (50),
@StartDate as date,
@EndDates as date


AS

Declare @count int
Declare	@pTotRow Numeric(18,0)
Declare @EmpId as Nvarchar (50)
Declare @Type as Nvarchar (50)
Declare @TotalAmount AS Numeric(18,2)

DECLARE @AYear as int
DECLARE @AMonth as int
DECLARE @FromDT as smalldatetime
DECLARE @ToDT as smalldatetime
SELECT @AYear=AYear, @AMonth=AMonth FROM General.ActiveMonthYear WHERE ActiveMonthYearID = @ActiveMonthYearID

select @FromDT=FromDT, @ToDT=ToDT from General.FiscalYear WHERE FYear = @AYear AND Period = @AMonth


BEGIN	

			
SET XACT_ABORT ON
DECLARE CR_DA CURSOR FOR 

SELECT DISTINCT EMPID,Checkroll.EmpAllowanceDeduction.Type,
ISNULL(SUM(Amount),0) as TotalAmount  
FROM Checkroll.EmpAllowanceDeduction  
Inner Join Checkroll.AllowanceDeductionSetup On Checkroll.EmpAllowanceDeduction.AllowDedid = Checkroll.AllowanceDeductionSetup.AllowDedId
WHERE
	Checkroll.AllowanceDeductionSetup.NoTransferToSalary <> 1 AND
(CONVERT(date,EndDates) >=@FromDT and CONVERT(date,EndDates) <=@ToDT)
GROUP BY EmpID,Checkroll.EmpAllowanceDeduction.Type

	Open CR_DA

		FETCH NEXT FROM CR_DA
 		INTO @EmpID,@Type,@TotalAmount
		
	--SELECT  @pTotRow = @@CURSOR_ROWS
		WHILE @@FETCH_STATUS = 0 
		BEGIN
		
								
		
		IF EXISTS(SELECT EmpID from Checkroll.Salary 
		WHERE EstateID = @EstateId AND ActiveMonthYearID =@ActiveMonthYearId 
		AND  EmpID = @EmpID)
					
			IF @Type ='A'
			BEGIN
			UPDATE  Checkroll.Salary 
			SET 
			Allowance =ISNULL(@TotalAmount,0), 
			ModifiedBy=@User ,
			ModifiedOn=GETDATE()
			WHERE EstateID = @EstateId AND ActiveMonthYearID =@ActiveMonthYearId 
			AND  EmpID = @EmpID  
			END
			
			IF @Type ='D'
			BEGIN
			UPDATE  Checkroll.Salary 
			SET 
			DedOther =ISNULL(@TotalAmount,0), 
			ModifiedBy=@User ,
			ModifiedOn=GETDATE()
			WHERE EstateID = @EstateId AND ActiveMonthYearID =@ActiveMonthYearId 
			AND  EmpID = @EmpID  
			END
				
			
			
		FETCH NEXT FROM CR_DA
 		INTO @EmpID,@Type,@TotalAmount
  					
		END
		CLOSE CR_DA

DEALLOCATE CR_DA

Select Top 1 * from Checkroll.EmpAllowanceDeduction
END