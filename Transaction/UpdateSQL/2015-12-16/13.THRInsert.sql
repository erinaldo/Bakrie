
/****** Object:  StoredProcedure [Checkroll].[CRTHRInsert]    Script Date: 16/12/2015 10:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--======
--
-- By Dadang
-- Created : Senin, 28 Dec 2009, 12:02
-- Modified: Selasa, 29 Dec 2009, 09:06 
--        -> Penambahan DOJ
--         : Selasa, 29 Dec 2009, 11:46
--        -> Penambahan DedIncomeTax, DedCooper, dan DedOthers
--        -> HIPMonthlyRate (untuk karyawan KT)
--
-- Modified: Jum'at, 12 Feb 2010, 23:38
--           Ahad, 14 Feb 2010, 02:22
--           - THR Kena biaya jabatan (5%)
--           Penambahan field:
--           - Netto
--           - RoundUP
--
-- Modified: Selasa, 09 Mar 2010, 17:34
--           - Masa kerja lebih dari 3 bln dapat THR

-- Modified: Kumaravel, oct 07 2010, 
--          
-- Modified: Stanley, 27-09-2011 
--           -- Delete THR records for @ActiveMonthYearID and  not Active Year
-- Modified: Stanley, 25-11-2011 
--           -- Update the THR.RoundUp formula to follow same as Salary.TotalRoundUp
--
--
--===
ALTER PROCEDURE [Checkroll].[CRTHRInsert]
 @EstateID nvarchar(50),
 @ProcDate datetime,
 @ActiveMonthYearID nvarchar(50),
 @User nvarchar(50)
AS
--DECLARE @ProcDate datetime;
--DECLARE @EstateID nvarchar(50);
DECLARE @EstateCode nvarchar(50);
--DECLARE @ActiveMonthYearID nvarchar(50);

DECLARE @EmpID nvarchar(50);
DECLARE @YearPeriod int;
DECLARE @count int;
DECLARE @THRID nvarchar(50);
DECLARE @Bruto numeric(18,2);
--DECLARE @User nvarchar(50);
DECLARE @Categoy nvarchar(50);
DECLARE @BasicRate numeric(18,2);
DECLARE @HIPMonthlyRate numeric(18,2);
DECLARE @THRPerBulan numeric(18,2);
DECLARE @JoinDate datetime;
DECLARE @Status nvarchar(50);
DECLARE @StatusDate Date;
Declare @TerminResignDays integer;
DECLARE @MaritalStatus nvarchar(5)

DECLARE @MasaKerjaDlmTahun int;
DECLARE @MasaKerjaDlmBulan int;

DECLARE @DedIncomeTax numeric(18,2);
DECLARE @DedCooper numeric(18,2);
DECLARE @DedOthers numeric(18,2);

DECLARE @Netto numeric(18,2);
DECLARE @RoundUP numeric(18,2);
DECLARE @BerasNaturaPrice numeric(18,3);
DECLARE @DagingNatura numeric(18,3);
DECLARE @BerasNatura numeric(18,3);
DECLARE @EmpKg numeric(18,3);
DECLARE @SpouseKg numeric(18,3);
DECLARE @ChildKg numeric(18,3);

----- modified kumar
DECLARE @GradeI numeric(18,2);
DECLARE @GradeIRange numeric(18,2);
DECLARE @GradeII numeric(18,2);
DECLARE @GradeIIRangeFrom numeric(18,2);
DECLARE @GradeIIRangeto numeric(18,2);
DECLARE @GradeIII numeric(18,2);
DECLARE @GradeIIIRangeFrom numeric(18,2);
DECLARE @GradeIIIRangeto numeric(18,2);
DECLARE @GradeIV numeric(18,2);
DECLARE @GradeIVRangeFrom numeric(18,2);
DECLARE @GradeIVRangeto numeric(18,2);
DECLARE @GradeV numeric(18,2);
DECLARE @GradeVRange numeric(18,2);


Select @DagingNatura = a.MeatPrice, @BerasNaturaPrice = RANaturaPrice,@EmpKg=RAEmployee,@SpouseKg=RAHusbandOrWife,@ChildKg=RAChild  from Checkroll.TaxAndRiceSetup a	

SELECT @EstateCode = EstateCode
FROM
	General.Estate
WHERE
	EstateID = @EstateID

SELECT
	--@ActiveMonthYearID = G_AMY.ActiveMonthYearID,
	@YearPeriod = G_AMY.AYear
FROM
	General.ActiveMonthYear AS G_AMY
WHERE
	ModID = 1 -- Checkroll
	AND EstateID = @EstateID
	AND ActiveMonthYearID = @ActiveMonthYearID
			--AND G_AMY.AMonth = MONTH(@ProcDate)
			--AND G_AMY.AYear = YEAR(@procdate)
		
		---modified by kumar
			Select  
					@GradeI  =GradeI,
					@GradeIRange = GradeIRange,
					@GradeII = GradeII,
					@GradeIIRangeFrom =GradeIIRangeFrom ,
					@GradeIIRangeto =GradeIIRangeto ,
					@GradeIII =GradeIII ,
					@GradeIIIRangeFrom =GradeIIIRangeFrom ,
					@GradeIIIRangeto =GradeIIIRangeto,
					@GradeIV =GradeIV,
					@GradeIVRangeFrom =GradeIVRangeFrom ,
					@GradeIVRangeto  =GradeIVRangeto,
					@GradeV =GradeV,
					@GradeVRange  =GradeVRange 
			from Checkroll .TaxAndRiceSetup 
			where EstateID =@EstateID 


DELETE FROM Checkroll.THR
WHERE
	EstateID = @EstateID
	--stanley@27-09-2011 AND YearPeriod = @YearPeriod;
	AND ActiveMonthYearID = @ActiveMonthYearID;

DECLARE AttSum_Cursor CURSOR
FOR 
	SELECT C_AS.EmpID, C_EMP.MaritalStatus 
	FROM Checkroll.AttendanceSummary C_AS
	INNER JOIN Checkroll.CREmployee C_EMP ON C_EMP.EmpID = C_AS .EMPID
	WHERE
		C_AS.EstateID = @EstateID
		AND C_AS.ActiveMonthYearID = @ActiveMonthYearID

OPEN AttSum_Cursor

	FETCH NEXT FROM AttSum_Cursor
	INTO @EmpID, @MaritalStatus
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SELECT @Categoy = C_EMP.Category,
		 @JoinDate = C_EMP.DOJ,
		 @Status =C_EMP .Status ,
		 @StatusDate = C_EMP .StatusDate 
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
		
		-- SELECT @MasaKerjaDlmTahun = DATEDIFF(Year, @JoinDate, @ProcDate);
		
	if  (@Status ='Terminated' or @Status ='Resign')
		begin
			SELECT @MasaKerjaDlmBulan = DATEDIFF(Day, @JoinDate, @StatusDate);
		end
	else
		begin
			SELECT @MasaKerjaDlmBulan = DATEDIFF(Day, @JoinDate, @ProcDate);
		end
		
		
		
		SET @BasicRate = 0
			
		SELECT @BasicRate = Checkroll.GetEmployeeDailyRate(@EmpID)
       	SET @THRPerBulan = Checkroll.GetEmployeeMonthlyRate(@EmpID)
		if Left(@MaritalStatus,1) = 'K'
			begin 
				Set @BerasNatura = (@BerasNaturaPrice * @EmpKg) + (@BerasNaturaPrice * @SpouseKg) + (@BerasNaturaPrice * Right(@MaritalStatus,1))
			end
		else
			begin
				Set @BerasNatura = (@BerasNaturaPrice * @EmpKg) + (@BerasNaturaPrice * Right(@MaritalStatus,1))
			end  
		
		
			-- IF @MasaKerjaDlmTahun = 0 
			IF @MasaKerjaDlmBulan < 365
				BEGIN
				IF @MasaKerjaDlmBulan > 88
					BEGIN
					SET @Bruto = (@THRPerBulan * @MasaKerjaDlmBulan)/365;
					Set @DagingNatura = (@DagingNatura * @MasaKerjaDlmBulan)/365;
					Set @BerasNatura = (@BerasNatura * @MasaKerjaDlmBulan)/365;
					END
				ELSE
					SET @Bruto = 0;
				END
			ELSE
				SET @Bruto = @THRPerBulan 
				
			
		
		-- Palani & Enger
		-- Commented on 24-Apr-2011 20:37 because customer requested THR tax not to be deducted in THR Report 
		-- Tax calculation to be done for overall monthly income only
		
		--SET @DedIncomeTax = (@Bruto * 5) /100
		SET @DedIncomeTax = 0
		
				
		if @DedCooper > 0
		BEGIN
		SET @DedCooper = @DedCooper /12 
		END
		
		if @DedOthers > 0
		BEGIN
		SET @DedOthers = @DedOthers /12 
		END
				
		

		SET @Netto = @Bruto + @DagingNatura + @BerasNatura - @DedIncomeTax;
		
		--modified by kumar
		--25-11-2011 SET @RoundUP = ROUND(@Netto , -3) ;
		SET @RoundUP = ceiling(@Netto /1000.0)*1000 ;
		-- END Sabtu, 13 Feb 2010, 00:08
		IF @Bruto  > 0
		BEGIN
		IF EXISTS(
			SELECT EmpID
			FROM
				Checkroll.THR
			WHERE
				EstateID = @EstateID
				--25-11-2011 AND YearPeriod = @YearPeriod
				AND ActiveMonthYearID = @ActiveMonthYearID
				AND EmpID = @EmpID
		)
		BEGIN		
			UPDATE Checkroll.THR SET
				YearPeriod = @YearPeriod
				,Bruto = @Bruto
				,DedIncomeTax = @DedIncomeTax
				,DedCooper = @DedCooper
				,DedOthers = @DedOthers
				,Netto = @Netto
				,RoundUP = @RoundUP
				,DagingNatura = @DagingNatura
				,BerasNatura = @BerasNatura
			WHERE
				EstateID = @EstateID
				AND ActiveMonthYearID = @ActiveMonthYearID
				AND CONVERT(DATE, ProcessingDate) = @ProcDate
				AND EmpID = @EmpID
				
		END
		ELSE -- Jika Belum Ada record
		BEGIN
		
		
		  SELECT @THRID  = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + 1) AS VARCHAR)
                FROM   Checkroll.THR
                DECLARE @i INT = 2
                WHILE EXISTS
                (SELECT id
                FROM    Checkroll.THR
                WHERE   THRID  = @THRID
                )
                BEGIN
                        SELECT @THRID = @EstateCode + 'R' + CAST ( (ISNULL(MAX(id),0) + @i) AS VARCHAR)
                        FROM   Checkroll.THR
                        SET @i = @i + 1
                END
                
                
			INSERT INTO Checkroll.THR
			(
			THRID,
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
			DagingNatura,
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
			@DedCooper,
			@DedOthers,
			@Netto,
			@RoundUP,
			@User,
			GETDATE(),
			@User,
			GETDATE(),
			@DagingNatura,
			@BerasNatura
			);
		END
		
		---- Updating the Salary Table
		--		UPDATE Checkroll.Salary SET 
		--		THR  = @Netto,
		--		TotalBruto = @Bruto 
		--		WHERE
		--		EstateID = @EstateID
		--		AND ActiveMonthYearID = @ActiveMonthYearID
		--		AND EmpID = @EmpID
		
		END
		
		END
				
		
		PRINT @EmpID
		FETCH NEXT FROM AttSum_Cursor
		INTO @EmpID,@MaritalStatus
	END

CLOSE AttSum_Cursor
DEALLOCATE AttSum_Cursor
