
/****** Object:  StoredProcedure [Checkroll].[CRBonusInsert]    Script Date: 22/2/2016 3:58:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [Checkroll].[CRBonusInsert]
 @EstateID nvarchar(50),
 @ProcDate datetime,
 @ActiveMonthYearID nvarchar(50),
 @User nvarchar(50),
 @NoofMonths numeric(10,2),
 @DedSPSI numeric(18,2),
 @DedSBSP numeric(18,2),
 @BerasNaturaPrice numeric(18,2),
 @OverwriteSalaryMonth int,
 @OverwriteSalaryYear int
AS

DECLARE @EstateCode nvarchar(50);

DECLARE @EmpID nvarchar(50);
DECLARE @YearPeriod int;
DECLARE @count int;
DECLARE @THRID nvarchar(50);
DECLARE @Bruto numeric(18,2);
DECLARE @Categoy nvarchar(50);
DECLARE @BasicRate numeric(18,2);
DECLARE @HIPMonthlyRate numeric(18,2);
DECLARE @THRPerBulan numeric(18,2);
DECLARE @JoinDate datetime;
DECLARE @Status nvarchar(50);
DECLARE @StatusDate Date;
Declare @TerminResignDays integer;
DECLARE @MaritalStatus nvarchar(5)
DECLARE @Netto numeric(18,2);
DECLARE @RoundUP numeric(18,2);
DECLARE @MasaKerjaDlmTahun int;
DECLARE @MasaKerjaDlmBulan int;
DECLARE @UnionMembership nvarchar(20)
DECLARE @DedIncomeTax numeric(18,2);
Declare @PreviousActiveMonthYearID nvarchar(50)
DECLARE @BerasNatura numeric(18,3);
DECLARE @BANKID nvarchar(50)
DECLARE @empDedSPSI numeric(18,2)
DECLARE @empDedSBSP numeric(18,2)


if @OverwriteSalaryMonth > 0 
begin
	Select @PreviousActiveMonthYearID =  ActivemonthYearID from General.ActiveMonthYear where ModID  =1 and AYear = @OverwriteSalaryYear and AMonth = @OverwriteSalaryMonth
	Set @ProcDate = DATEFROMPARTS(@OverwriteSalaryYear,@OverwriteSalaryMonth,28)
end

SELECT @EstateCode = EstateCode
FROM
	General.Estate
WHERE
	EstateID = @EstateID

SELECT
	@YearPeriod = G_AMY.AYear
FROM
	General.ActiveMonthYear AS G_AMY
WHERE
	ModID = 1 -- Checkroll
	AND EstateID = @EstateID
	AND ActiveMonthYearID = @ActiveMonthYearID
		
		---modified by kumar
			--Select  
			--		@GradeI  =GradeI,
			--		@GradeIRange = GradeIRange,
			--		@GradeII = GradeII,
			--		@GradeIIRangeFrom =GradeIIRangeFrom ,
			--		@GradeIIRangeto =GradeIIRangeto ,
			--		@GradeIII =GradeIII ,
			--		@GradeIIIRangeFrom =GradeIIIRangeFrom ,
			--		@GradeIIIRangeto =GradeIIIRangeto,
			--		@GradeIV =GradeIV,
			--		@GradeIVRangeFrom =GradeIVRangeFrom ,
			--		@GradeIVRangeto  =GradeIVRangeto,
			--		@GradeV =GradeV,
			--		@GradeVRange  =GradeVRange 
			--from Checkroll .TaxAndRiceSetup 
			--where EstateID =@EstateID 


DELETE FROM Checkroll.Bonus
WHERE
	EstateID = @EstateID
	AND ActiveMonthYearID = @ActiveMonthYearID;

DECLARE AttSum_Cursor CURSOR
FOR 
	SELECT C_AS.EmpID, C_EMP.MaritalStatus,C_EMP.UnionMembership 
	FROM Checkroll.AttendanceSummary C_AS
	INNER JOIN Checkroll.CREmployee C_EMP ON C_EMP.EmpID = C_AS .EMPID
	WHERE
		C_AS.EstateID = @EstateID
		AND C_AS.ActiveMonthYearID = @ActiveMonthYearID
		AND C_EMp.Category <> 'KHL'
	Order by MaritalStatus

OPEN AttSum_Cursor

	FETCH NEXT FROM AttSum_Cursor
	INTO @EmpID, @MaritalStatus,@UnionMembership
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SELECT @Categoy = C_EMP.Category,
		 @JoinDate = C_EMP.DOJ,
		 @Status =C_EMP .Status ,
		 @StatusDate = C_EMP .StatusDate,
		 @BANKID = C_EMP.BankID  
		 FROM
			Checkroll.CREmployee C_EMP
			
		WHERE
			EmpID = @EmpID 
			
	Declare @Statuscheck as nvarchar(50) ='True'
	
	 SET @TerminResignDays = 0
	if  (@Status ='Terminated' or @Status ='Resign')
	BEGIN
	  SET @TerminResignDays = DATEDIFF(Day, @StatusDate, @ProcDate)
	   if @TerminResignDays < =30 
	  BEGIN
	   SET @Statuscheck = 'True'
	   END
	   else
	   BEGIN
	    SET @Statuscheck = 'False'
	   END
	END
	
	if @Statuscheck = 'True'
	
	BEGIN
		
	
	if  (@Status ='Terminated' or @Status ='Resign')
		begin
			SELECT @MasaKerjaDlmBulan = Floor(Convert(numeric(18,3),DATEDIFF(d, @JoinDate, @StatusDate)) / 30);
		end
	else
		begin
			SELECT @MasaKerjaDlmBulan = Floor(Convert(numeric(18,3),DATEDIFF(d, @JoinDate, @ProcDate)) / 30);
		end
		
		if @UnionMembership = 'SPSI'
			begin
				SET @empDedSPSI = @DedSPSI
				SET @empDedSBSP = 0
			end
		else
			if @UnionMembership = 'SBSI' 
			begin
				SET @empDedSPSI = 0
				SET @empDedSBSP = @DedSBSP

			end
			else
				begin
					SET @empDedSPSI = 0
					SET @empDedSBSP = 0
				end
		SET @BasicRate = 0
			
		SELECT @BasicRate = Checkroll.GetEmployeeDailyRate(@EmpID)
       	SET @THRPerBulan = Checkroll.GetEmployeeMonthlyRate(@EmpID)
		if @OverwriteSalaryMonth > 0 
			begin
				Select @THRPerBulan = iSNULL(TotalBasic,0) from checkroll.salary where empid = @EmpID and ActiveMonthYearID = @PreviousActiveMonthYearID
			end

		Select TOP 1 @BerasNatura = RAEmployee * @BerasNaturaPrice from Checkroll.TaxAndRiceSetup
		
			IF @MasaKerjaDlmBulan < 12
				BEGIN
				IF @MasaKerjaDlmBulan >= 3
					BEGIN
						SET @Bruto = (@THRPerBulan * @MasaKerjaDlmBulan)/12;
						Set @BerasNatura = (@BerasNatura * @MasaKerjaDlmBulan)/12;
					END
				ELSE
					SET @Bruto = 0;
				END
			ELSE
				bEGIN
					SET @Bruto = @THRPerBulan 
				END
			
		SET @Netto = ((@Bruto + @BerasNatura) * @NoofMonths) - @empDedSPSI - @empDedSBSP 
		
		
		if @BANKID = 'M33' or @BANKID is null or @BANKID = ''
			begin
				SET @RoundUP = ceiling(@Netto /1000.0)*1000 ;
			end
		else
			begin
				SET @RoundUP = @Netto ;
			end

		IF @Bruto  > 0
		BEGIN
		IF EXISTS(
			SELECT EmpID
			FROM
				Checkroll.Bonus
			WHERE
				EstateID = @EstateID
				AND ActiveMonthYearID = @ActiveMonthYearID
				AND EmpID = @EmpID
		)
		BEGIN		
			UPDATE Checkroll.Bonus SET
				YearPeriod = @YearPeriod
				,Bruto = @Bruto
				,DedIncomeTax = @DedIncomeTax
				,DedCooper = @empDedSPSI
				,DedOthers = @empDedSBSP
				,Netto = @Netto
				,RoundUP = @RoundUP
				,BerasNatura = @BerasNatura
				--,DagingNatura = @DagingNatura
				--,
			WHERE
				EstateID = @EstateID
				AND ActiveMonthYearID = @ActiveMonthYearID
				AND CONVERT(DATE, ProcessingDate) = @ProcDate
				AND EmpID = @EmpID
				
		END
		ELSE -- Jika Belum Ada record
		BEGIN
		
		
		  SELECT @THRID  = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                FROM   Checkroll.Bonus
                DECLARE @i INT = 2
                WHILE EXISTS
                (SELECT id
                FROM    Checkroll.Bonus
                WHERE   BonusID  = @THRID
                )
                BEGIN
                        SELECT @THRID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                        FROM   Checkroll.Bonus
                        SET @i = @i + 1
                END
                
                
			INSERT INTO Checkroll.Bonus
			(
			BonusID,
			EstateID,
			ActiveMonthYearID,
			EmpID,
			ProcessingDate,
			YearPeriod,
			Bruto,
			DedIncomeTax,
			DedCooper,
			DedOthers,
			Netto,
			RoundUP,
			CreatedBy,
			CreatedOn,
			ModifiedBy,
			ModifiedOn,
			--DagingNatura,
			BerasNatura
			)
			VALUES
			(
			@THRID,
			@EstateID,
			@ActiveMonthYearID,
			@EmpID,
			@ProcDate,
			@YearPeriod,
			@Bruto,
			@DedIncomeTax,
			@empDedSPSI,
			@empDedSBSP,
			@Netto,
			@RoundUP,
			@User,
			GETDATE(),
			@User,
			GETDATE(),
			--@DagingNatura,
			@BerasNatura
			);
		END
		
		END
		
		END
				
		
		PRINT @EmpID
		FETCH NEXT FROM AttSum_Cursor
		INTO @EmpID,@MaritalStatus,@UnionMembership
	END

CLOSE AttSum_Cursor
DEALLOCATE AttSum_Cursor
