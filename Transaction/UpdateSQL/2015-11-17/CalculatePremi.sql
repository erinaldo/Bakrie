

/****** Object:  UserDefinedFunction [Checkroll].[CalculatePremi]    Script Date: 18/11/2015 4:49:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





--===
-- Author : Chandra
-- Created On : 13-03-2015
-- Descp      :  DIgunakan untuk menghitung premi dari rubber
--
--===
Alter FUNCTION [Checkroll].[CalculatePremi] (
	@DateRubber datetime,	-- Tanggal Rubber
	@EmpId varchar(20), -- Emp ID
	@EstateCode varchar(10),		-- Estate Code
	@PersenProduct int,		-- 80% pengkali Product
	@ProductValue numeric (18,4),		-- nilai Product
	@ProductDrc numeric (18,4),		-- nilai drc	
	@ProductName varchar(20),		-- Product 
	@Status varchar(1), -- D = Dasar, P= Progressive , B = Bonus
	@BlockId nvarchar(50)
	)
RETURNS money
AS
BEGIN
	declare @TotalBudget numeric (18,4),@PremiDasar money=0,@PremiProgresif money =0 ,@PremiBonus money =0  , @PremiMinggu money=0
	declare @BudgetPerHariProduct  numeric (18,4)
	declare @JumlahPenderes  numeric (18,4)
	declare @ProduksiNormal  numeric (18,4)
	declare @JumlahHariPerBulan int
	declare @ProduksiKeringProduct  numeric (18,4)
	declare @PersenPremiProduct  numeric (18,4)
	declare @RateProduct  numeric (18,4)
	declare @monthId int
	declare @class varchar(1),@estateId varchar(5)
	declare @Min numeric (18,4),@max numeric (18,4), @rate numeric (18,4), @permiType varchar(20)

	--Select respective budget data for individual fields
	Select @JumlahHariPerBulan=JumlahHariKerja, @JumlahPenderes=JumlahTask, @ProduksiNormal = BudgetProduksi/(JumlahHariKerja * JumlahTask) from Budget.FieldRubberProduction
	where ZMonth= MONTH(@DateRubber) and ZYear= YEAR(@DateRubber) and BlockID = @BlockId
	
	Set @MonthId = Month(@DateRubber)
	
	--The Empid passed is actually the nik no
	Select @class=Class FROM Checkroll.GradeMonthDetails 
	INNER JOIN Checkroll.GradeMonth ON 
	Checkroll.GradeMonthDetails.GradeMonthId = Checkroll.GradeMonth.Id
	inner join Checkroll.CREmployee on Checkroll.GradeMonthDetails.EmpId = Checkroll.CREmployee.EmpID
	where Checkroll.GradeMonth.ZMonth=MONTH(@DateRubber) and Checkroll.GradeMonth.ZYear= YEAR(@DateRubber) and EmpCode=@EmpId
	

    set @BudgetPerHariProduct = @ProduksiNormal * @PersenProduct / 100
	set @ProduksiKeringProduct =(@ProductValue * @ProductDrc / 100)
	set @PersenPremiProduct= @ProduksiKeringProduct / @BudgetPerHariProduct * 100
	DECLARE cProduct CURSOR local read_only FOR
		select Min,Max,Rate,PremiType from Checkroll.PremiSetupRubber where Class=@class and Product=@ProductName and min < @PersenPremiProduct order by min
		OPEN cProduct
		FETCH FROM cProduct INTO @min,@max,@rate,@permiType
		WHILE @@fetch_status = 0 
		BEGIN
			if(@permiType ='Dasar')					
				begin
					if(@PersenPremiProduct < @max)
						Set @PremiDasar =@PremiDasar+ (@ProduksiKeringProduct * @rate)
					else
						Set @PremiDasar =@PremiDasar+  (@BudgetPerHariProduct * @rate * @max/100)
				end
				else if(@permiType ='Progressive')					
				begin
					if(@PersenPremiProduct < @max)
						Set @PremiProgresif =@PremiProgresif+ (@ProduksiKeringProduct * @rate * (@PersenPremiProduct - @min + 1) / 100)
					else
						Set @PremiProgresif =@PremiProgresif+ (@BudgetPerHariProduct * @rate	* (@max-@min+1)/100)
				end
				else if(@permiType ='Bonus')					
						Set @PremiBonus =@PremiBonus+ ((@ProduksiKeringProduct-@BudgetPerHariProduct) * @rate)					
				else if(@permiType ='Deres')					
						Set @PremiMinggu =@PremiMinggu+ ((@ProduksiKeringProduct) * @rate)					
				FETCH NEXT FROM cProduct INTO  @min,@max,@rate,@permiType
			END
			CLOSE cProduct
			DEALLOCATE cProduct
	if(@Status ='D')
		return @PremiDasar
	if(@Status ='P')
		return @PremiProgresif	
	if(@Status ='M')
		return @PremiMinggu
	return @PremiBonus
END;




GO


