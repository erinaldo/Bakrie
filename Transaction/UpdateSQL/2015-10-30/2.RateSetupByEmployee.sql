
/****** Object:  StoredProcedure [Checkroll].[CRRateSetupSelectByEmp]    Script Date: 29/10/2015 2:43:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Gets Data from Rate setup based on Employee Category And GRade
ALTER PROCEDURE [Checkroll].[CRRateSetupSelectByEmp]
@EstateID nvarchar(50),
@EmpID nvarchar(50)
AS
BEGIN
	DECLARE @Grade nvarchar(10)
	DECLARE @Category nvarchar(50)
	DECLARE @Level nvarchar(10)

	Select @Grade=Grade,@Category = Category, @Level = Level from Checkroll.CREmployee where Empid = @EmpID

	if @Category = 'KHT' or @Category = 'KHL' or @Category = 'PKWT'
	begin
		SELECT
				RateSetupID, EstateID, Category, Code, Grade,
				HIPLevel, 
				StdRate, 
				BasicRate, 
				JHT,
				JHTEmployer,
				JKK, 
				JK, 
				OTDivider,
				RiceDividerDays ,
				case @Category
					when 'KHT' THEN (Select RAPrice * RAEmployee from Checkroll.TaxAndRiceSetup WHere EstateID = @EstateID)
					when 'PKWT' THEN (Select RAPrice * RAEmployee from Checkroll.TaxAndRiceSetup WHere EstateID = @EstateID)
					else 0
					End				
				 as RicePayment,
				AdvancePremium,
				MandorPremium, 
				KraniPremium
			FROM
				Checkroll.RateSetup 
			WHERE
				EstateID = @EstateID AND
				Category = @Category 
			
	end 
	else
		BEGIN
			SELECT
				RateSetupID, EstateID, Category, Code, Grade,
				HIPLevel, 
				StdRate/RiceDividerDays as BasicRate, 
				BasicRate as BasicRate1, 
				JHT,
				JHTEmployer,
				JKK, 
				JK, 
				OTDivider,
				RiceDividerDays ,				
				(Select RAPrice * RAEmployee from Checkroll.TaxAndRiceSetup WHere EstateID = @EstateID) as RicePayment,
				AdvancePremium,
				MandorPremium, 
				KraniPremium
			FROM
				Checkroll.RateSetup 
			WHERE
				EstateID = @EstateID AND
				 HIPLevel = @Level AND Grade = @Grade and Category = 'KT'
				 -- Category is hardcoded to KT cause some idiot did a wrong requirment study
		EnD
END









