/****** Object:  StoredProcedure [Checkroll].[UpdateCheckrollSalary]    Script Date: 14/10/2015 10:07:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO











-- ==============================================
--
-- Author      : Dadang Adi Hendradi     
--
-- Update: Jum'at, 25 Dec 2009, 22:13
-- Update: Rabu, 30 Dec 2009, 16:47
--         - Adding @NPWP and @TotalBruto
--         - Adding Condition for employee who dont have NPWP
-- Description :  Estate Monthly Production Report (EMP Report)
--
-- update : Sabtu, 16 Jan 2010, 00:56
--          Forget DedAdvance and DedOthers belum masuk perhitungan
--
-- update: Sabtu, 30 Jan 2010, 15:08
-- update: Senin, 01 Feb 2010, 01:19 
--         Astek (Jamsostek) ambil dari JHT saja  (Jamsostek take from JHT only)
--
-- update: Sabtu, 13 Feb 2010, 00:59
--         - THR ambil nilainya dari RoundUP di THR table (THR takes its value from RoundUp in THR table)
--         - Jamsostek tidak jadi dipake, soalnya sudah dipotong di AdvancePayment(Gaji Tengah Bulan / Pinjaman)
--           jadi di Salary Jamsostek (Astek) tidak perlu dipotong lagi  
--           (Jamsostek not applicable. It has already been deducted in AdvancePayment (mid-month Salary 
-- ==============================================

ALTER PROCEDURE [Checkroll].[UpdateCheckrollSalary]
 @ActiveMonthYearID nvarchar (50),
 @EstateId nvarchar(50),
 @User nvarchar(50)

AS

Declare @count int
Declare	@pTotRow Numeric(18,0)
Declare @EmpId as Nvarchar (50)
Declare @AttIncentive as Numeric (18,0)

DECLARE @Year int; -- by GUE
DECLARE @TotalGrossArray table (
	col int,
	iMonth int,
	iYear int,
	vTotalBruto numeric(18,2));

	
DECLARE @TotalBrutoTemp numeric(18,2)
DECLARE @MonthTemp int;
DECLARE @YearTemp int;

DECLARE @Counter int;

DECLARE @EmpSalaryArray table
	(
		iMonth int,
		iYear int,
		TotalBruto numeric(18,2),
		Netto numeric(18,2),
		PPh21Sebulan numeric(18,2)
	);
	
DECLARE @iMonth int, @iYear int, @TotalBruto numeric(18,2);
DECLARE @NettPerMonth numeric(18,2);
DECLARE @NettAnnualised numeric(18,2);
DECLARE @ActiveMonth int;
DECLARE @MaritalStatus nvarchar(10);
DECLARE @PTKP numeric(18,2);
DECLARE @PKP numeric(18,2);
DECLARE @PPh21PerYear numeric(18,2);
DECLARE @PPh21PerMonth numeric(18,2);

DECLARE @NettPerMonthPreviousMonth numeric(18,2);
DECLARE @PPh21PerMonthPreviousMonth numeric(18,2);

-- Jum'at, 25 Dec 2009, 21:48
-- Ini untuk yg punya NPWP
DECLARE @GradeINPWP numeric(18,2); -- Dalam persen contoh : 5 berarti nilainya 5 dibagi 100 (Example in Percent : 5 means value 5 divided by 100)
DECLARE @GradeIRangeNPWP numeric(18,2) -- 

DECLARE @GradeIINPWP numeric(18,2);  -- Dalam persen
DECLARE @GradeIIRangeFromNPWP numeric(18,2);
DECLARE @GradeIIRangeToNPWP numeric(18,2);

DECLARE @GradeIIINPWP numeric(18,2);  -- Dalam persen
DECLARE @GradeIIIRangeFromNPWP numeric(18,2);
DECLARE @GradeIIIRangeToNPWP numeric(18,2);

DECLARE @GradeIVNPWP numeric(18,2);
DECLARE @GradeIVRangeFromNPWP numeric(18,2);
DECLARE @GradeIVRangeToNPWP numeric(18,2);

-- Ini untuk tidak punya NPWP
-- Rabu, 30 Dec 2009, 15:53
DECLARE @GradeI numeric(18,2); -- Dalam persen contoh : 5 berarti nilainya 5 dibagi 100 (Example in Percent : 5 means value 5 divided by 100)
DECLARE @GradeIRange numeric(18,2) -- 

DECLARE @GradeII numeric(18,2);  -- Dalam persen
DECLARE @GradeIIRangeFrom numeric(18,2);
DECLARE @GradeIIRangeTo numeric(18,2);

DECLARE @GradeIII numeric(18,2);  -- Dalam persen
DECLARE @GradeIIIRangeFrom numeric(18,2);
DECLARE @GradeIIIRangeTo numeric(18,2);

DECLARE @GradeIV numeric(18,2);
DECLARE @GradeIVRangeFrom numeric(18,2);
DECLARE @GradeIVRangeTo numeric(18,2);

DECLARE @NPWP nvarchar(50);
DECLARE @DedAstek numeric(18,2);
DECLARE @DedTaxEmployee numeric(18,2);
DECLARE @DedTaxCompany numeric(18,2);
DECLARE @DedAdvance numeric(18,2);
DECLARE @DedOther numeric(18,2);
DECLARE @TotalDed numeric(18,2);

DECLARE @TotalNett numeric(18,2);
DECLARE @TotalRoundUP numeric(18,2);

DECLARE @JHTPercent numeric(18,2);
DECLARE @JHT numeric(18,2);
DECLARE @JKKAndJKMPercent numeric(18,2);
DECLARE @JKKAndJKM numeric(18,2);

DECLARE @BasicRate numeric(18,2);
DECLARE @HIPMonthlyRate numeric(18,2);
DECLARE @Category nvarchar(50);
DECLARE @JHTEmployerPercent numeric(18,2);
DECLARE @JHTEmployer numeric(18,2);

DECLARE @THR numeric(18,2);

--END Rabu, 30 Dec 2009, 15:53

-- Sabtu, 30 Jan 2010, 14:55
DECLARE @JKKPercent numeric(18,2);
DECLARE @JKK numeric(18,2);
DECLARE @JKPercent numeric(18,2);
DECLARE @JK numeric(18,2);

-- Sabtu, 20 Mar 2010, 17:06
DECLARE @AccidentInsurance numeric(18,2); -- => (Jkk + Jk) / 100) * (BasicRate * 30)
DECLARE @RiceDividerDays int;
DECLARE @AdvancePremium int;
DECLARE @FunctionalAllowance numeric(18,2);
DECLARE @IuranTHT numeric(18,2);

-- END Sabtu, 20 Mar 2010, 17:06

BEGIN

	SELECT @ActiveMonth = AMonth, @Year = AYear	
	FROM
		General.ActiveMonthYear 
	WHERE
		EstateID = @EstateId AND
		ActiveMonthYearID = @ActiveMonthYearID
				
	SELECT 
		@GradeINPWP = GradeINPWP * 0.01,
		@GradeIRangeNPWP = GradeIRangeNPWP,
		
		@GradeIINPWP = GradeIINPWP * 0.01,
		@GradeIIRangeFromNPWP = GradeIIRangeFromNPWP,
		@GradeIIRangeToNPWP = GradeIIRangeToNPWP,
		
		@GradeIIINPWP = GradeIIINPWP * 0.01,
		@GradeIIIRangeFromNPWP = GradeIIIRangeFromNPWP,
		@GradeIIIRangeToNPWP = GradeIIIRangeToNPWP,
		
		@GradeIVNPWP = GradeIVNPWP * 0.01,
		@GradeIVRangeFromNPWP = GradeIVRangeFromNPWP,
		@GradeIVRangeToNPWP = GradeIVRangeToNPWP
		
		-- Rabu, 30 Dec 2009, 15:56
		,@GradeI = GradeI * 0.01
		,@GradeIRange = GradeIRange
		
		,@GradeII = GradeII * 0.01
		,@GradeIIRangeFrom = GradeIIRangeFrom
		,@GradeIIRangeTo = GradeIIRangeTo
		
		,@GradeIII = GradeIII * 0.01
		,@GradeIIIRangeFrom = GradeIIIRangeFrom
		,@GradeIIIRangeTo = GradeIIIRangeTo
		
		,@GradeIV = GradeIV * 0.01
		,@GradeIVRangeFrom = GradeIVRangeFrom
		,@GradeIVRangeTo = GradeIVRangeTo
		
		,@JKKAndJKMPercent = JkkAndJK
	FROM
		Checkroll.TaxAndRiceSetup
	WHERE
		EstateID = @EstateId
	
	IF @JKKAndJKMPercent IS NULL
		SET @JKKAndJKMPercent = 0;
	ELSE
		SET @JKKAndJKMPercent = @JKKAndJKMPercent / 100;
	
SET XACT_ABORT ON
DECLARE CR_DA CURSOR FOR 

SELECT     ActiveMonthYearId,EstateID,Empid, MStatus, NPWP, TotalBruto, Category
		, DedAdvance
		, DedOther
		, DedAstek 
		 
FROM       Checkroll.Salary
WHERE	   ActiveMonthYearID =@ActiveMonthYearId and EstateID =@EstateId 

	
	Open CR_DA

		FETCH NEXT FROM CR_DA
 		INTO @ActiveMonthYearId,@EstateID,@Empid, @MaritalStatus, @NPWP, @TotalBruto, @Category
		, @DedAdvance
		, @DedOther
		, @DedAstek
		
	    SELECT  @pTotRow = @@CURSOR_ROWS
		WHILE @@FETCH_STATUS = 0 
		BEGIN
			
				-- Jum'at, 25 Des 2009, 20:13
				IF @MaritalStatus = 'TK0' OR @MaritalStatus = 'T'
					SET @PTKP = 15840000
				ELSE IF @MaritalStatus = 'K0' OR @MaritalStatus = 'K' OR @MaritalStatus = 'TK1' OR @MaritalStatus = 'TK/1'
					SET @PTKP = 15840000 + 1320000;
				ELSE IF @MaritalStatus = 'K1' OR @MaritalStatus = 'TK2' OR @MaritalStatus = 'TK/2'
					SET @PTKP = 15840000 + 1320000 + 1320000;
				ELSE IF @MaritalStatus = 'K2' OR @MaritalStatus = 'TK3' OR @MaritalStatus = 'TK/3'
					SET @PTKP = 15840000 + 1320000 + 1320000 + 1320000;
				ELSE IF @MaritalStatus = 'K3'
					SET @PTKP = 15840000 + 1320000 + 1320000 + 1320000 + 1320000;
				
				-- Baca THR jika ada (Read if there is THR)
				SELECT 
					--@THR = Bruto - ISNULL(DedIncomeTax, 0) - ISNULL(DedCooper, 0) - ISNULL(DedOthers, 0)
					-- Sabtu, 13 Feb 2010, 01:00
					@THR = Bruto 
				FROM
					Checkroll.THR
				WHERE
					EstateID = @EstateId
					--ActiveMonthYearID = @ActiveMonthYearID
					AND YearPeriod = @Year -- Kamis, 7 Jan 2009, 01:28
					AND EmpID = @EmpId     -- Sabtu, 30 Jan 2010, 13:54


				IF @Category = 'KHT' OR @Category = 'KHL'
				BEGIN
					SET @BasicRate = 0
					
					SELECT 
						@BasicRate = Checkroll.GetEmployeeDailyRate(@EmpId)
						,@JHTPercent = JHT
						,@JKKPercent = JKK
						,@JKPercent = JK
						,@JHTEmployerPercent = JHTEmployer
						,@RiceDividerDays = RiceDividerDays
						,@AdvancePremium= AdvancePremium 
					FROM
						Checkroll.RateSetup 
					WHERE
						Category = @Category
						AND EstateID = @EstateId
					
					IF @JHTPercent IS NULL
						SET @JHTPercent = 0;
					ELSE
						SET @JHTPercent = @JHTPercent / 100;
						
					SET @JHT = @BasicRate * @JHTPercent;
					
					IF @JKKPercent IS NULL
						SET @JKKPercent = 0;
					ELSE
						SET @JKKPercent = @JKKPercent / 100;
					
					SET @JKK = @BasicRate * @JKKPercent;
					
					IF @JKPercent IS NULL
						SET @JKPercent = 0;
					ELSE
						SET @JKPercent = @JKPercent / 100;
					
					SET @JK = @BasicRate * @JKPercent;

					-- Sabtu, 20 Mar 2010, 17:09
					SET @AccidentInsurance = (@JKKPercent + @JKPercent) * @BasicRate * @RiceDividerDays
					-- END Sabtu, 20 Mar 2010, 17:09
					
					IF @JHTEmployerPercent IS NULL
						SET @JHTEmployerPercent = 0
					ELSE
						SET @JHTEmployerPercent = @JHTEmployerPercent / 100;
					
					SET @JHTEmployer = @BasicRate * @JHTEmployerPercent;
				END
				ELSE
				BEGIN
					-- ini untuk KT
					SET @HIPMonthlyRate = Checkroll.GetEmployeeDailyRate(@EmpId)
					SELECT 
						@JHTPercent = JHT
						,@JKKPercent = JKK
						,@JKPercent = JK
						,@JHTEmployerPercent = JHTEmployer
						,@RiceDividerDays = RiceDividerDays
					FROM
						Checkroll.RateSetup
					WHERE
						Category = @Category
						AND EstateID = @EstateId

					IF @JHTPercent IS NULL
						SET @JHTPercent = 0;
					ELSE
						SET @JHTPercent = @JHTPercent / 100;

					SET @JHT = @HIPMonthlyRate * @JHTPercent;
					
					IF @JKKPercent IS NULL
						SET @JKKPercent = 0;
					ELSE
						SET @JKKPercent = @JKKPercent / 100;
					
					SET @JKK = @BasicRate * @JKKPercent;
					
					IF @JKPercent IS NULL
						SET @JKPercent = 0;
					ELSE
						SET @JKPercent = @JKPercent / 100;
					
					SET @JK = @BasicRate * @JKPercent;

					-- Sabtu, 20 Mar 2010, 17:09
					SET @AccidentInsurance = (@JKKPercent + @JKPercent) * @HIPMonthlyRate;
					-- END Sabtu, 20 Mar 2010, 17:09

					IF @JHTEmployerPercent IS NULL
						SET @JHTEmployerPercent = 0
					ELSE
						SET @JHTEmployerPercent = @JHTEmployerPercent / 100;
					
					SET @JHTEmployer = @HIPMonthlyRate * @JHTEmployerPercent;
				END

				
				-- Hitung biaya Jabatan -> (5% x Gaji) + (5% x THR)/ Calculation of Employer's contribution (5% x Salary) + (5% x THR)
				-- Sabtu, 20 Mar 2010, 17:21, tambah AccidentInsurance / add Accident Insurance
				--SET @NettPerMonth = @TotalBruto + ISNULL(@THR, 0) - (0.05 * @TotalBruto) + @AccidentInsurance
				SET @NettPerMonth = @TotalBruto + ISNULL(@THR, 0) + @AccidentInsurance;
				SET @NettAnnualised = @NettPerMonth * 12
				
				--@NettPerMonth  - Net per month
				--@TotalBruto -  Gross per month
				
				-- Sabtu, 20 Mar 2010, 19:21
				
				
				IF @Category = 'KHT' OR @Category = 'KHL' or @Category = 'PKWT'			
					SET @IuranTHT = (@BasicRate * @RiceDividerDays * 12) * @JHTPercent;
				ELSE IF @Category = 'KT'
					SET @IuranTHT = (@HIPMonthlyRate * 12) * @JHTPercent;
				
				IF (@NettAnnualised * 0.05) > (@ActiveMonth * 500000)
					SET @FunctionalAllowance = @ActiveMonth * 500000;
				ELSE
					SET @FunctionalAllowance = @NettAnnualised * 0.05;
						
				SET @NettAnnualised = @NettAnnualised - ROUND(@FunctionalAllowance,0) - ROUND(@IuranTHT,0)
				-- END Sabtu, 20 Mar 2010, 19:21
				 
				 --@IuranTHT  - Pension for the month
				 
				SET @PKP = @NettAnnualised - @PTKP
				IF @PKP < 0 
					SET @PKP = 0
					
				IF @NPWP = 'NO'
				BEGIN
					-- Untuk yg tidak punya NPWP
					-- Rabu, 30 Dec 2009, 16:37
					
					--Tax for 1 year (i.e Annualized tax)
					--@NettAnnualised  - Annualized Net
					--@PPh21PerYear   - Tax annaulized.
					
					IF @NettAnnualised <= @GradeIRange
						SET @PPh21PerYear = @GradeI * @PKP
						
					IF @NettAnnualised > @GradeIIRangeFrom AND @NettAnnualised <= @GradeIIRangeTo
						SET @PPh21PerYear = @GradeII * @PKP
						
					IF @NettAnnualised > @GradeIIIRangeFrom AND @NettAnnualised <= @GradeIIIRangeTo
						SET @PPh21PerYear = @GradeIII * @PKP
						
					IF @NettAnnualised > @GradeIVRangeFrom
						SET @PPh21PerYear = @GradeIV * @PKP;
				END
				ELSE
				BEGIN
					-- Untuk yg punya NPWP
					
					IF @NettAnnualised <= @GradeIRangeNPWP
						SET @PPh21PerYear = @GradeINPWP * @PKP;
						
					IF @NettAnnualised > @GradeIIRangeFromNPWP AND @NettAnnualised <= @GradeIIRangeToNPWP
						SET @PPh21PerYear = @GradeIINPWP * @PKP;
						
					IF @NettAnnualised > @GradeIIIRangeFromNPWP AND @NettAnnualised <= @GradeIIIRangeToNPWP
						SET @PPh21PerYear = @GradeIIINPWP * @PKP;
						
					IF @NettAnnualised > @GradeIVRangeFromNPWP
						SET @PPh21PerYear = @GradeIVNPWP * @PKP;

				END
									
				SET @PPh21PerMonth = @PPh21PerYear / 12
				
				-- Rabu, 30 Dec 2009, 17:00
				-- Update, Kamis, 07 Jan 2009, 01:39
				--IF @TotalBruto < (@PTKP / 12)
				IF @NettPerMonth < (@PTKP / 12)
					SET @PPh21PerMonth = 0;
				
				SET @DedTaxEmployee = @PPh21PerMonth
				
				-- Hitung Deduction Astek ( Sekarang Jamsostek )
				
				-- DedTaxCompany hanya untuk diperlihatkan tidak dikalkulasi
				SET @DedTaxCompany = @JHTEmployer
				-- END Hitung Deduction Astek ( Sekarang Jamsostek )
				
				if @DedAstek IS NULL OR @DedAstek =0
				BEGIN
				SET @DedAstek=@AdvancePremium * @RiceDividerDays *@JHTPercent
				END
				else
				BEGIN
				SET @DedAstek = 0;
				END
				
				--SET @DedAstek = 0;
				-- Sabtu, 13 Feb 2010, 01:31
				-- Jamsostek tidak jadi dipake, soalnya sudah dipotong di AdvancePayment(Gaji Tengah Bulan / Pinjaman)
				
				--SET @DedAstek = @JHT; --+ @JKK + @JK;
				
				SET @TotalDed = 
					ISNULL(@DedAstek, 0) +
					ISNULL(@DedTaxEmployee, 0) + 
					--ISNULL(@DedTaxCompany, 0) +
					ISNULL(@DedAdvance, 0) +
					ISNULL(@DedOther, 0)
												

				-- Update, Kamis, 07 Jan 2009, 01:40
				SET @TotalBruto = @TotalBruto + ISNULL(@THR, 0);
				-- END Update, Kamis, 07 Jan 2009, 01:40
				
				SET @TotalNett = ABS(@TotalBruto - @TotalDed)
				
				
				SET @TotalRoundUP=ceiling(@TotalNett /1000.0)*1000
				--SET @TotalRoundUP = ROUND(@TotalNett ,-4);
				--SET @TotalRoundUP=0
				
				
				
				UPDATE  Checkroll.Salary 
				SET 
					DedTaxEmployee = @DedTaxEmployee,
					DedAstek = @DedAstek,
					DedTaxCompany = @DedTaxCompany,
					THR = @THR,
					TotalBruto = @TotalBruto,
					TotalDed = @TotalDed,
					TotalNett = @TotalNett,
					TotalRoundUP = @TotalRoundUP,
					ModifiedBy = @User ,
					ModifiedOn = GETDATE()
				WHERE 
					EstateID = @EstateId AND 
					ActiveMonthYearID = @ActiveMonthYearID AND
					EmpID = @EmpID
									
				-- END Rabu, 30 Dec 2009, 17:00
				
				--END Jum'at, 25 Des 2009, 20:13
				
				
			
			-- END by DADANG
			
				--UPDATE  Checkroll.Salary 
				--SET 
				--	TotalNett = ISNULL(TotalBruto,0) - ISNULL(TotalDed,0),  
				--	TotalRoundUP = Round(((ISNULL(TotalBruto,0) - ISNULL(TotalDed,0))*0.001),0)*1000,
				--	ModifiedBy=@User ,
				--	ModifiedOn=GETDATE()
				--WHERE 
				--	EstateID = @EstateId AND ActiveMonthYearID =@ActiveMonthYearId 
				--	AND  EmpID = @EmpID  
							
						
			FETCH NEXT FROM CR_DA
 			INTO @ActiveMonthYearId,@EstateID,@Empid, @MaritalStatus, @NPWP, @TotalBruto, @Category
			, @DedAdvance
			, @DedOther
			, @DedAstek
  					
		END
		CLOSE CR_DA

DEALLOCATE CR_DA

--SELECT     ActiveMonthYearId,EstateID,Empid
--FROM       Checkroll.Salary
--WHERE	   ActiveMonthYearID =@ActiveMonthYearId and EstateID =@EstateId 



END
	










