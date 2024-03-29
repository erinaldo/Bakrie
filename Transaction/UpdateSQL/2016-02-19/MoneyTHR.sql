
/****** Object:  StoredProcedure [Checkroll].[CRMoneyDenominationTHRReport]    Script Date: 23/2/2016 12:33:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--===============================================
-- Description : THR Money DENOMINATION
-- Created By : Stanley
-- Created Date : 23-Nov-2011
-- Modified By :  
-- Modified Date : 
--===============================================

ALTER PROCEDURE [Checkroll].[CRMoneyDenominationTHRReport]

	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50)
		
AS

DECLARE @angka numeric(18,2);
DECLARE @TotalRoundUP numeric(18,2);
DECLARE @EmpID nvarchar(50);
DECLARE @EmpName nvarchar(50);
DECLARE @Category nvarchar(50);
DECLARE @GangName nvarchar(50);

DECLARE @CategoryTmp nvarchar(50);
DECLARE @GangNameTmp nvarchar(50);

DECLARE @AMonth int;
DECLARE @AYear int;

DECLARE @Satuan100rb int;
DECLARE @Satuan50rb int;
DECLARE @Satuan20rb int;
DECLARE @Satuan10rb int;
DECLARE @Satuan5rb int;
DECLARE @Satuan1rb int;

DECLARE @HasilBagiDecimal100rb numeric(18,2);
DECLARE @HasilBagiDecimal50rb numeric(18,2);
DECLARE @HasilBagiDecimal20rb numeric(18,2);
DECLARE @HasilBagiDecimal10rb numeric(18,2);
DECLARE @HasilBagiDecimal5rb numeric(18,2);
DECLARE @HasilBagiDecimal1rb numeric(18,2);

DECLARE @HasilBagi100rb int;
DECLARE @HasilBagi50rb int;
DECLARE @HasilBagi20rb int;
DECLARE @HasilBagi10rb int;
DECLARE @HasilBagi5rb int;
DECLARE @HasilBagi1rb int;

DECLARE @Sisa100rb numeric(18,2);
DECLARE @Sisa50rb numeric(18,2);
DECLARE @Sisa20rb numeric(18,2);
DECLARE @Sisa10rb numeric(18,2);
DECLARE @Sisa5rb numeric(18,2);
DECLARE @Sisa1rb numeric(18,2);

DECLARE @JmlUang100rb numeric(18,2);
DECLARE @JmlUang50rb numeric(18,2);
DECLARE @JmlUang20rb numeric(18,2);
DECLARE @JmlUang10rb numeric(18,2);
DECLARE @JmlUang5rb numeric(18,2);
DECLARE @JmlUang1rb numeric(18,2);

DECLARE @JmlLembar100rb int;
DECLARE @JmlLembar50rb int;
DECLARE @JmlLembar20rb int;
DECLARE @JmlLembar10rb int;
DECLARE @JmlLembar5rb int;
DECLARE @JmlLembar1rb int;

SET @Satuan100rb = 100000;
SET @Satuan50rb = 50000;
SET @Satuan20rb = 20000;
SET @Satuan10rb = 10000;
SET @Satuan5rb = 5000;
SET @Satuan1rb = 1000;

DECLARE @SisaUang numeric(18,2);

-- Selasa, 26 Jan 2010, 16:54
DECLARE @MD as table
(
	Category nvarchar(50),
	GangName nvarchar(50),
	Qty100rb int,
	Qty50rb int,
	Qty20rb int,
	Qty10rb int,
	Qty5rb int,
	Qty1rb int,
	EstateID nvarchar(50),
	ActiveMonthYearID nvarchar(50),
	AMonth int,
	AYear int);


SET @JmlLembar100rb = 0;
SET @JmlLembar50rb = 0;
SET @JmlLembar20rb = 0;
SET @JmlLembar10rb = 0;
SET @JmlLembar5rb = 0;
SET @JmlLembar1rb = 0;

DECLARE THR_CUR CURSOR FOR
	SELECT C_THR.EmpID
		,C_THR.RoundUP
		,C_EMP.EmpName 
		,C_SAL.Category
		,ISNULL(C_GM.GangName,'') as GangName
		,C_THR.EstateID
		,C_THR.ActiveMonthYearID
		,G_AMY.AMonth
		,G_AMY.AYear
	FROM
		Checkroll.THR AS C_THR
		LEFT JOIN Checkroll.CREmployee AS C_EMP ON C_EMP.EmpID = C_THR.EmpID AND C_EMP.EstateID = C_THR.EstateID
		LEFT JOIN Checkroll.Salary AS C_SAL ON C_SAL.EmpID = C_THR.EmpID AND C_SAL.ActiveMonthYearID = C_THR.ActiveMonthYearID AND C_SAL.EstateID = C_THR.EstateID
		LEFT JOIN Checkroll.GangMaster AS C_GM ON C_GM.GangMasterID = C_SAL.GangMasterID AND C_GM.EstateID = C_THR.EstateID
		LEFT JOIN General.ActiveMonthYear AS G_AMY ON G_AMY.ActiveMonthYearID = C_THR.ActiveMonthYearID AND G_AMY.EstateID = C_THR.EstateID
	WHERE
		C_THR.RoundUP IS NOT NULL
		AND C_THR .EstateID = @EstateID 
		AND C_THR .ActiveMonthYearID = @ActiveMonthYearID  
		AND (BankID = 'M33' or BankID = '' or BankID is null)
	ORDER BY C_SAL.Category, C_GM.GangName
	
	
	OPEN THR_CUR;

	FETCH NEXT FROM THR_CUR
	INTO @EmpID, @TotalRoundUP, @EmpName, @Category, @GangName
		,@EstateID
		,@ActiveMonthYearID
		,@AMonth
		,@AYear

	WHILE @@FETCH_STATUS = 0
	BEGIN
		
		SET @HasilBagi100rb = 0;
		SET @HasilBagi50rb = 0;
		SET @HasilBagi20rb = 0;
		SET @HasilBagi10rb = 0;
		SET @HasilBagi5rb = 0;
		SET @HasilBagi1rb = 0;
		
		--SET @TotalRoundUP = 2337000;
		
		-- 100rb
		SET @HasilBagiDecimal100rb = @TotalRoundUP / @Satuan100rb;
		SET @HasilBagi100rb = FLOOR(@HasilBagiDecimal100rb);
		SET @Sisa100rb = @HasilBagiDecimal100rb - @HasilBagi100rb;
		
		SET @JmlUang100rb = @HasilBagi100rb * @Satuan100rb;
		
		SET @SisaUang = @Sisa100rb * @Satuan100rb;
		
		-- 50rb
		IF @HasilBagi100rb = 0
			IF @SisaUang / @Satuan50rb = 0
				SET @JmlUang50rb = 0;
			ELSE
			BEGIN
				SET @HasilBagiDecimal50rb = @SisaUang / @Satuan50rb;
				SET @HasilBagi50rb = FLOOR(@HasilBagiDecimal50rb);
				SET @Sisa50rb = @HasilBagiDecimal50rb - @HasilBagi50rb;
				
				SET @JmlUang50rb = @HasilBagi50rb * @Satuan50rb;
				
				SET @SisaUang = @Sisa50rb * @Satuan50rb;
			END
		ELSE
		BEGIN
			SET @HasilBagiDecimal50rb = @SisaUang / @Satuan50rb;
			SET @HasilBagi50rb = FLOOR(@HasilBagiDecimal50rb);
			SET @Sisa50rb = @HasilBagiDecimal50rb - @HasilBagi50rb;
			
			SET @JmlUang50rb = @HasilBagi50rb * @Satuan50rb;
			
			SET @SisaUang = @Sisa50rb * @Satuan50rb;
		END
		
		
		-- 20rb
		IF @HasilBagi50rb = 0
			IF @SisaUang / @Satuan20rb = 0
				SET @JmlUang20rb = 0;
			ELSE
			BEGIN
				SET @HasilBagiDecimal20rb = @SisaUang / @Satuan20rb;
				SET @HasilBagi20rb = FLOOR(@HasilBagiDecimal20rb);
				SET @Sisa20rb = @HasilBagiDecimal20rb - @HasilBagi20rb;
				
				SET @JmlUang20rb = @HasilBagi20rb * @Satuan20rb;
				
				SET @SisaUang = @Sisa20rb * @Satuan20rb;
			END
		ELSE
		BEGIN
			SET @HasilBagiDecimal20rb = @SisaUang / @Satuan20rb;
			SET @HasilBagi20rb = FLOOR(@HasilBagiDecimal20rb);
			SET @Sisa20rb = @HasilBagiDecimal20rb - @HasilBagi20rb;
			
			SET @JmlUang20rb = @HasilBagi20rb * @Satuan20rb;
			
			SET @SisaUang = @Sisa20rb * @Satuan20rb;
		END
		
		-- 10rb
		IF @HasilBagi20rb = 0
			IF @SisaUang / @Satuan10rb = 0
				SET @JmlUang10rb = 0;
			ELSE
			BEGIN
				SET @HasilBagiDecimal10rb = @SisaUang / @Satuan10rb;
				SET @HasilBagi10rb = FLOOR(@HasilBagiDecimal10rb);
				SET @Sisa10rb = @HasilBagiDecimal10rb - @HasilBagi10rb;
				
				SET @JmlUang10rb = @HasilBagi10rb * @Satuan10rb;
				
				SET @SisaUang = @Sisa10rb * @Satuan10rb;
			END
		ELSE
		BEGIN
			SET @HasilBagiDecimal10rb = @SisaUang / @Satuan10rb;
			SET @HasilBagi10rb = FLOOR(@HasilBagiDecimal10rb);
			SET @Sisa10rb = @HasilBagiDecimal10rb - @HasilBagi10rb;
			
			SET @JmlUang10rb = @HasilBagi10rb * @Satuan10rb;
			
			SET @SisaUang = @Sisa10rb * @Satuan10rb;
		END
		
		-- 5rb
		IF @HasilBagi10rb = 0
			IF @SisaUang / @Satuan5rb = 0
				SET @JmlUang5rb = 0;
			ELSE
			BEGIN
				SET @HasilBagiDecimal5rb = @SisaUang / @Satuan5rb;
				SET @HasilBagi5rb = FLOOR(@HasilBagiDecimal5rb);
				SET @Sisa5rb = @HasilBagiDecimal5rb - @HasilBagi5rb;
				
				SET @JmlUang5rb = @HasilBagi5rb * @Satuan5rb;
				
				SET @SisaUang = @Sisa5rb * @Satuan5rb;
			END
		ELSE
		BEGIN
			SET @HasilBagiDecimal5rb = @SisaUang / @Satuan5rb;
			SET @HasilBagi5rb = FLOOR(@HasilBagiDecimal5rb);
			SET @Sisa5rb = @HasilBagiDecimal5rb - @HasilBagi5rb;
			
			SET @JmlUang5rb = @HasilBagi5rb * @Satuan5rb;
			
			SET @SisaUang = @Sisa5rb * @Satuan5rb;
		END
		
		-- 1rb (seribu)
		IF @HasilBagi5rb = 0
			IF @SisaUang / @Satuan1rb = 0
				SET @JmlUang1rb = 0;
			ELSE
			BEGIN
				SET @HasilBagiDecimal1rb = @SisaUang / @Satuan1rb;
				SET @HasilBagi1rb = FLOOR(@HasilBagiDecimal1rb);
				SET @Sisa1rb = @HasilBagiDecimal1rb - @HasilBagi1rb;
				
				SET @JmlUang1rb = @HasilBagi1rb * @Satuan1rb;
				
			END
		ELSE
		BEGIN
			SET @HasilBagiDecimal1rb = @SisaUang / @Satuan1rb;
			SET @HasilBagi1rb = FLOOR(@HasilBagiDecimal1rb);
			SET @Sisa1rb = @HasilBagiDecimal1rb - @HasilBagi1rb;
			
			SET @JmlUang1rb = @HasilBagi1rb * @Satuan1rb;
			
		END

		--IF (@CategoryTmp <> @Category OR @GangNameTmp <> @GangName)
		--	OR (@CategoryTmp IS NULL AND @GangNameTmp IS NULL)
		--BEGIN
			SET @CategoryTmp = @Category
			SET @GangNameTmp = @GangName
					
			SET @JmlLembar100rb = 0;
			SET @JmlLembar50rb = 0;
			SET @JmlLembar20rb = 0;
			SET @JmlLembar10rb = 0;
			SET @JmlLembar5rb = 0;
			SET @JmlLembar1rb = 0;
		--END
		
		SET @JmlLembar100rb += @HasilBagi100rb;
		SET @JmlLembar50rb += @HasilBagi50rb;
		SET @JmlLembar20rb += @HasilBagi20rb;
		SET @JmlLembar10rb += @HasilBagi10rb;
		SET @JmlLembar5rb += @HasilBagi5rb;
		SET @JmlLembar1rb += @HasilBagi1rb;
			

		IF EXISTS(
			SELECT * FROM @MD 
			WHERE
				Category = @Category
				AND GangName = @GangName)
		BEGIN
			UPDATE @MD SET 
				Qty100rb = Qty100rb + @HasilBagi100rb
				,Qty50rb = Qty50rb + @HasilBagi50rb
				,Qty20rb = Qty20rb + @HasilBagi20rb
				,Qty10rb = Qty10rb + @HasilBagi10rb
				,Qty5rb = Qty5rb + @HasilBagi5rb
				,Qty1rb = Qty1rb + @HasilBagi1rb
			WHERE
				Category = @Category
				AND GangName = @GangName;
		END
		ELSE
		BEGIN
			INSERT INTO @MD (Category, GangName, Qty100rb, Qty50rb, Qty20rb, Qty10rb, Qty5rb, Qty1rb
				,EstateID
				,ActiveMonthYearID
				,AMonth
				,AYear)
			VALUES
			(@Category, @GangName, 
			@JmlLembar100rb, 
			@JmlLembar50rb,
			@JmlLembar20rb,
			@JmlLembar10rb,
			@JmlLembar5rb,
			@JmlLembar1rb
			,@EstateID
			,@ActiveMonthYearID
			,@AMonth
			,@AYear);
		END
		
		FETCH NEXT FROM THR_CUR
		INTO @EmpID, @TotalRoundUP, @EmpName, @Category, @GangName
		,@EstateID
		,@ActiveMonthYearID
		,@AMonth
		,@AYear

	END

	CLOSE THR_CUR;
	DEALLOCATE THR_CUR;

SELECT
	G_E.EstateName
	,MD.*
	, 
	(Qty100rb * 100000) + 
	(Qty50rb * 50000) + 
	(Qty20rb * 20000) +
	(Qty10rb * 10000) +
	(Qty5rb * 5000) +
	(Qty1rb * 1000) AS Value 
FROM 
	@MD AS MD
	INNER JOIN General.Estate G_E ON MD.EstateID = G_E.EstateID
WHERE MD .EstateID = @EstateID 
	AND MD.ActiveMonthYearID = @ActiveMonthYearID
