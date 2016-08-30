
/****** Object:  StoredProcedure [Checkroll].[AnalyHarvestingCostInsert]    Script Date: 14/3/2016 11:17:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Checkroll].[AnalyRubberCostInsert]

	@EstateID nvarchar(50),
	@ActiveMonthYearID nvarchar(50),
	@CreatedBy nvarchar(50) 
	
AS

BEGIN
	Declare @Amonth int    
	Declare @Ayear int    
	Select @Amonth =Amonth, @Ayear =ayear from General.ActiveMonthYear where EstateID = @EstateID and ActiveMonthYearID = @ActiveMonthYearID    
	DECLARE @Yop nvarchar(10)

	--DIstCRPanenTable Stores PENDERES and OnCost YOP, HK and RPHK values that will be inserted later on to AnalyLatexTable
	CREATE TABLE #DistCRPanen (
				Descript nVArChar(50),
				Descript2 nVArChar(50),
				YOP nVArChar(50),
				HK decimal(18,2),
				RpHK decimal(18,2),
				Jumlah decimal(18,2) )

	
    INSERT INTO #DistCRPanen 
	--PENDERES Basic
	select 'PENDERES' AS DESCRIPTION,'-Basic' as Description2,SubResult.YOP as YOP,sum(isnull(HK,0)) as AktualHK,               
	sum(isnull(HK,0) * isnull(RPHK,0)) as RpHK, sum(isnull(HK,0) * isnull(RPHK,0)) as Jumlah -- Lembur Not applicable, Lembur field is not included in Report
	from               
	(              	
	select DTA.GangName,GYOP.Name as YOP,DA.RDate,   
	G_Bl.T0,G_Bl.T1,G_Bl.T2,G_Bl.T3,G_Bl.T4,          
	--case when ASE.AttendanceCode in ('11','J1') then COUNT(*)*1 else COUNT(*)*0.5 end as HK,                   
	SUM(ISNULL(ASE.TimesBasic,0)) as HK,	
	(select FromDT  From General .FiscalYear where Period = @AMonth and FYear =@AYear) as FromDT ,                    
	(select ToDT   From General .FiscalYear where Period = @AMonth and FYear =@AYear) as ToDT,
	Checkroll.GetTeamActualDailyRate(DTA.GangMasterID,DA.RDate) as RPHk   	                   
	from Checkroll.DailyAttendance DA                      
	inner join (select DailyReceiptionID,Afdeling,YOP,FieldNo from Checkroll.DailyReceptionForRubber) DR on (DA.DailyReceiptionID = DR.DailyReceiptionID)                    
	left JOIN General.yop AS GYOP on DR.YOP = GYOP.YOPID                    
	left join Checkroll.AttendanceSetup ASE on (DA.AttendanceSetupID = ASE.AttendanceSetupID)                
	left join Checkroll.DailyTeamActivity DTA on (DA.DailyTeamActivityID = DTA.DailyTeamActivityID)                    
	left outer join General.BlockMaster G_Bl  on DR.FieldNo=G_Bl.BlockID and DR.YOP = G_Bl.YOPID and DR.Afdeling = G_Bl.DivID
	where (DA.ActiveMonthYearID = @ActiveMonthYearID) and upper(DTA.Activity) = 'DERES'   
	--AND ASE.AttendanceCode in ('11','J1','51','52','53','54','55')                  
	group by DTA.GangName,GYOP.Name,DA.RDate,ASE.AttendanceCode, G_Bl.T0,G_Bl.T1,G_Bl.T2,G_Bl.T3,G_Bl.T4,Checkroll.GetTeamActualDailyRate(DTA.GangMasterID,DA.RDate)
	) SubResult group by SubResult.YOP
	
	----PRemi
	--UNION

	--select 'PENDERES' AS DESCRIPTION,'-On Cost' as Description2,SubResult.YOP, 0 as AktualHK, 0 as RpHK , sum(isnull(SubResult.TotalPremi,0)) as Jumlah
 --   from  
	--(              
	--SELECT G_ESTATE.EstateID                
	--,G_ESTATE.EstateName                
	--,C_DA.ActiveMonthYearID                
	--,C_GM.GangName                
	--,C_EMP.EmpCode                
	--,C_EMP.EmpName                
	--,C_RTD.DateRubber                
	--,G_BM.BlockName                
	--,G_YOP.YOP                
	--,G_DIV.DivName                
	--,TotalPremi =                
	--ISNULL(C_RTD.PremiDasarLatex, 0)                 
	--+ ISNULL(C_RTD.PremiProgresifLatex, 0)                 
	--+ ISNULL(C_RTD.PremiBonusLatex, 0)            
	--FROM                
	--Checkroll.DailyReceptionForRubber AS C_RTD  
	--INNER JOIN Checkroll.DailyAttendance AS C_DA ON C_RTD.DailyReceiptionID = C_DA.DailyReceiptionID                        
	--INNER JOIN Checkroll.CREmployee AS C_EMP ON C_DA.EmpID = C_EMP.EmpID                
	--INNER JOIN General.Estate AS G_ESTATE ON C_EMP.EstateID = G_ESTATE.EstateID                
	--inner join Checkroll.DailyTeamActivity C_DTA on C_DA.DailyTeamActivityID = C_DTA.DailyTeamActivityID
	--INNER JOIN Checkroll.GangMaster  AS C_GM ON C_DTA.GangMasterID = C_GM.GangMasterID                
	--LEFT JOIN General.BlockMaster AS G_BM ON C_RTD.FieldNo = G_BM.BlockID                
	--LEFT JOIN General.YOP AS G_YOP ON C_RTD.YOP = G_YOP.YOPID                
	--LEFT JOIN General.Division AS G_DIV ON C_RTD.Afdeling = G_DIV.DivID       
	--where C_EMP.EstateID = @EstateID                 
	--AND    C_DA.ActiveMonthYearID = @ActiveMonthYEarID    ) as SubResult    
	--Group by SubResult.YOP          

	-- First delete all the records from [Checkroll].[AnalyLatexCost] table for the given @ActiveMonthYearID
	delete from [Checkroll].[AnalyLatexCost] where ActiveMonthYearID = @ActiveMonthYearID

	-- inserting the [Mandays] & [Cost]
	insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	SELECT @EstateID, @ActiveMonthYearID,'PENDERES','-Basic',temp.YOP, 
	2,2,0,0,0,isnull(HK,0),0,temp.Jumlah,0,0,	
	0,0,@CreatedBy,GetDate()
	from 
	(
	Select #DistCRPanen.YOP,#DistCRPanen.HK,#DistCRPanen.Jumlah from #DistCRPanen where #DistCRPanen.Descript = 'PENDERES' and #DistCRPanen.Descript2 = '-Basic') as temp
	
	
	-- Taking the total HK from the above Query (PENDERES / -Basic)
	declare @TotalHK decimal(18,2)
	select @TotalHK = SUM(isnull(Mandays,0)) from 
	checkroll.AnalyLatexCost where MainDescription ='PENDERES' and SubDescription = '-Basic' and EstateID = @EstateID 
	and ActiveMonthYearID = @ActiveMonthYearID
	print 'totalp HK'
	print @TotalHK
    

	
	-- PENDERES , -On Cost
	insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	SELECT @EstateID,@ActiveMonthYearID,'PENDERES',CONVERT(nvarchar(20), '-On Cost'),temp.YOP,
	2,3,0,0,0,0,0, temp.Jumlah ,0,0,
	0,0,@CreatedBy,GetDate()
	from  
	(
	Select #DistCRPanen.YOP,#DistCRPanen.HK,#DistCRPanen.Jumlah from #DistCRPanen where #DistCRPanen.Descript = 'PENDERES' and #DistCRPanen.Descript2 = '-On Cost') as temp
	
	
	
	-- Calculating Latex Dry per YOP & inserting record into checkroll.AnalyLatexCost
	insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	
	SELECT temp.EstateID,temp.ActiveMonthYearID, 'PENDERES Produk' , CONVERT(nvarchar(20), 'Latex (Dry)') ,temp.YOP,
	3, 8, temp.TotalBunches, temp.TotalBunches, 1, 0, 0, 0, 0, 0, temp.TotalBunches ,0, 'SuperAdmin',GetDate() 
	from 
	(
	SELECT C_DA.EstateID, C_DA.ActiveMonthYearID,  
	G_YOP.YOP, Sum(C_DRT.Latex * DRC) as TotalBunches   
	FROM  Checkroll.DailyAttendance AS C_DA  
	INNER JOIN Checkroll.DailyReceptionForRubber AS C_DRT ON C_DA.DailyReceiptionID = C_DRT.DailyReceiptionID
	INNER JOIN Checkroll.DailyTeamActivity AS C_DTA ON C_DA.DailyTeamActivityID = C_DTA.DailyTeamActivityID  
	AND C_DA.RDate = C_DTA.DDate  
	INNER JOIN Checkroll.GangMaster AS C_GM ON C_DTA.GangMasterID = C_GM.GangMasterID  
	INNER JOIN Checkroll.CREmployee AS C_EMP ON C_DA.EmpID = C_EMP.EmpID  
	INNER JOIN Checkroll.AttendanceSetup AS C_AS ON C_DA.AttendanceSetupID = C_AS.AttendanceSetupID  
	AND C_DA.EstateID = C_AS.EstateID  
	LEFT JOIN General.BlockMaster AS G_BM ON C_DRT.FieldNo = G_BM.BlockID  
	LEFT JOIN General.YOP AS G_YOP ON C_DRT.YOP = G_YOP.YOPID  
	LEFT JOIN General.Division AS G_DIV ON C_DRT.Afdeling = G_DIV.DivID  
	INNER JOIN General.Estate AS G_ESTATE ON C_DA.EstateID = G_ESTATE.EstateID  
	INNER JOIN General.ActiveMonthYear AS G_AMY ON C_DA.ActiveMonthYearID = G_AMY.ActiveMonthYearID  
	WHERE  
	C_DA.ActiveMonthYearID = @ActiveMonthYearID
	AND C_DA.EstateID = @EstateID
	group by C_DA.EstateID, C_DA.ActiveMonthYearID, G_YOP.YOP
	) temp 	
	
		-- Calculating Other Rubber per YOP & inserting record into checkroll.AnalyLatexCost
	insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	
	SELECT temp.EstateID,temp.ActiveMonthYearID, 'PENDERES Produk' , CONVERT(nvarchar(20), 'Offgrade') ,temp.YOP,
	3, 8, temp.TotalBunches, temp.TotalBunches, 1, 0, 0, 0, 0, 0, temp.TotalBunches ,0, 'SuperAdmin',GetDate() 
	from 
	(
	SELECT C_DA.EstateID, C_DA.ActiveMonthYearID,  
	G_YOP.YOP, ISNull(Sum(C_DRT.CupLamp * DRCCupLump),0) + ISNull(Sum(C_DRT.TreeLace),0) + ISNull(Sum(C_DRT.COAglum),0)    as TotalBunches   
	FROM  Checkroll.DailyAttendance AS C_DA  
	INNER JOIN Checkroll.DailyReceptionForRubber AS C_DRT ON C_DA.DailyReceiptionID = C_DRT.DailyReceiptionID
	INNER JOIN Checkroll.DailyTeamActivity AS C_DTA ON C_DA.DailyTeamActivityID = C_DTA.DailyTeamActivityID  
	AND C_DA.RDate = C_DTA.DDate  
	INNER JOIN Checkroll.GangMaster AS C_GM ON C_DTA.GangMasterID = C_GM.GangMasterID  
	INNER JOIN Checkroll.CREmployee AS C_EMP ON C_DA.EmpID = C_EMP.EmpID  
	INNER JOIN Checkroll.AttendanceSetup AS C_AS ON C_DA.AttendanceSetupID = C_AS.AttendanceSetupID  
	AND C_DA.EstateID = C_AS.EstateID  
	LEFT JOIN General.BlockMaster AS G_BM ON C_DRT.FieldNo = G_BM.BlockID  
	LEFT JOIN General.YOP AS G_YOP ON C_DRT.YOP = G_YOP.YOPID  
	LEFT JOIN General.Division AS G_DIV ON C_DRT.Afdeling = G_DIV.DivID  
	INNER JOIN General.Estate AS G_ESTATE ON C_DA.EstateID = G_ESTATE.EstateID  
	INNER JOIN General.ActiveMonthYear AS G_AMY ON C_DA.ActiveMonthYearID = G_AMY.ActiveMonthYearID  
	WHERE  
	C_DA.ActiveMonthYearID = @ActiveMonthYearID
	AND C_DA.EstateID = @EstateID
	group by C_DA.EstateID, C_DA.ActiveMonthYearID, G_YOP.YOP
	) temp 		
   	
   
	-- Checkroll Report
	--===========================
	-- Premi
	--===========================
    insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	SELECT C_DA.EstateID, C_DA.ActiveMonthYearID, 'Premi',CONVERT(nvarchar(20),'-Dasar'),G_YOP.YOP,
	4,9,0,0,0,0,0,SUM(isnull(C_RTD.PremiDasarLatex,0)) + SUM(isnull(C_RTD.PremiDasarLump,0)) + SUM(isnull(C_RTD.PremiTreelace,0)) ,0,0,
	0,0, @CreatedBy,GetDate() 
	FROM
	Checkroll.DailyReceptionForRubber AS C_RTD
	inner join Checkroll.DailyAttendance C_DA on C_RTD.DailyReceiptionID = C_DA.DailyReceiptionID
	INNER JOIN General.YOP AS G_YOP ON C_RTD.YOP = G_YOP.YOPID
	INNER JOIN General.Estate AS G_ESTATE ON C_DA.EstateID = G_ESTATE.EstateID
	INNER JOIN General.ActiveMonthYear AS G_AMY ON C_DA.ActiveMonthYearID = G_AMY.ActiveMonthYearID
	where C_DA.EstateID = @EstateID 
		AND C_DA.ActiveMonthYearID = @ActiveMonthYearID 
	GROUP BY
		C_DA.EstateID
		,G_ESTATE.EstateName
		,C_DA.ActiveMonthYearID
		,G_AMY.AMonth
		,G_AMY.AYear
		,G_YOP.YOP
	
	insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	SELECT C_DA.EstateID, C_DA.ActiveMonthYearID, 'Premi',CONVERT(nvarchar(20),'-Progressif'),G_YOP.YOP,
	4,9,0,0,0,0,0,SUM(isnull(C_RTD.PremiProgresifLatex,0)) + SUM(isnull(C_RTD.PremiProgresifLump,0)),0,0,
	0,0, @CreatedBy,GetDate() 
	FROM
	Checkroll.DailyReceptionForRubber AS C_RTD
	inner join Checkroll.DailyAttendance C_DA on C_RTD.DailyReceiptionID = C_DA.DailyReceiptionID
	INNER JOIN General.YOP AS G_YOP ON C_RTD.YOP = G_YOP.YOPID
	INNER JOIN General.Estate AS G_ESTATE ON C_DA.EstateID = G_ESTATE.EstateID
	INNER JOIN General.ActiveMonthYear AS G_AMY ON C_DA.ActiveMonthYearID = G_AMY.ActiveMonthYearID
	where C_DA.EstateID = @EstateID 
		AND C_DA.ActiveMonthYearID = @ActiveMonthYearID 
	GROUP BY
		C_DA.EstateID
		,G_ESTATE.EstateName
		,C_DA.ActiveMonthYearID
		,G_AMY.AMonth
		,G_AMY.AYear
		,G_YOP.YOP

	insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	SELECT C_DA.EstateID, C_DA.ActiveMonthYearID, 'Premi',CONVERT(nvarchar(20),'-Bonus'),G_YOP.YOP,
	4,9,0,0,0,0,0,SUM(isnull(C_RTD.PremiBonusLatex,0)) + SUM(isnull(C_RTD.PremiBonusLump,0)),0,0,
	0,0, @CreatedBy,GetDate() 
	FROM
	Checkroll.DailyReceptionForRubber AS C_RTD
	inner join Checkroll.DailyAttendance C_DA on C_RTD.DailyReceiptionID = C_DA.DailyReceiptionID
	INNER JOIN General.YOP AS G_YOP ON C_RTD.YOP = G_YOP.YOPID
	INNER JOIN General.Estate AS G_ESTATE ON C_DA.EstateID = G_ESTATE.EstateID
	INNER JOIN General.ActiveMonthYear AS G_AMY ON C_DA.ActiveMonthYearID = G_AMY.ActiveMonthYearID
	where C_DA.EstateID = @EstateID 
		AND C_DA.ActiveMonthYearID = @ActiveMonthYearID 
	GROUP BY
		C_DA.EstateID
		,G_ESTATE.EstateName
		,C_DA.ActiveMonthYearID
		,G_AMY.AMonth
		,G_AMY.AYear
		,G_YOP.YOP

	-- Premi Minggu
		insert into checkroll.AnalyLatexCost([EstateID],[ActiveMonthYearID],[MainDescription],[SubDescription],[YOP],
	[MainOrderCounter],[SubOrderCounterMain],[PayrollBunches],[FactoryKG],[KGPerBunches],[Mandays],[KGPerMandays],[Cost],[CostPerKG],[CostPerBunches],
	[FactoryBunches],[DifferenceBunches],[CreatedBy],[CreatedOn]) 
	SELECT C_DA.EstateID, C_DA.ActiveMonthYearID, 'Premi',CONVERT(nvarchar(20),'-Minggu'),G_YOP.YOP,
	4,9,0,0,0,0,0,SUM(isnull(C_RTD.PremiMinggu,0)),0,0,
	0,0, @CreatedBy,GetDate() 
	FROM
	Checkroll.DailyReceptionForRubber AS C_RTD
	inner join Checkroll.DailyAttendance C_DA on C_RTD.DailyReceiptionID = C_DA.DailyReceiptionID
	INNER JOIN General.YOP AS G_YOP ON C_RTD.YOP = G_YOP.YOPID
	INNER JOIN General.Estate AS G_ESTATE ON C_DA.EstateID = G_ESTATE.EstateID
	INNER JOIN General.ActiveMonthYear AS G_AMY ON C_DA.ActiveMonthYearID = G_AMY.ActiveMonthYearID
	where C_DA.EstateID = @EstateID 
		AND C_DA.ActiveMonthYearID = @ActiveMonthYearID 
	GROUP BY
		C_DA.EstateID
		,G_ESTATE.EstateName
		,C_DA.ActiveMonthYearID
		,G_AMY.AMonth
		,G_AMY.AYear
		,G_YOP.YOP

	
 --This portion calculates values used in reports
--Added by stanley@04-08-2011.b
	Declare @FactoryKG_YOP_Total decimal(18,2)
	Declare @MainDescription nVarChar(50)
	Declare @SubDescription	 nVarChar(50)
	Declare @TotalCost_PENDERES decimal(18,2)
	DECLARE @TotalMandays decimal(18,2)
	Declare CursAnalyHarvCost cursor for 
	select YOP, MainDescription, SubDescription from Checkroll.AnalyLatexCost
	where EstateID = @EstateID and ActiveMonthYearID =@ActiveMonthYearID
	and MainDescription = 'PENDERES Produk' 
	--and SubDescription = 'Latex (Dry)'
	
		Open CursAnalyHarvCost
		Fetch next from CursAnalyHarvCost into @YOP,  @MainDescription, @SubDescription
			While @@FETCH_STATUS = 0 
				BEGIN 
				
					SET @TotalCost_PENDERES = (
						SELECT SUM(COST) FROM Checkroll.AnalyLatexCost
						WHERE EstateID = @EstateID AND ActiveMonthYearID =@ActiveMonthYearID AND YOP = @YOP
						AND MainDescription = 'PENDERES' 
						AND SubDescription in ( '-Basic', '-On Cost', '-Jamsostek', '-Rice', '-THR')
						GROUP BY YOP, MainDescription
					)
					
					SET @TotalMandays = (
						SELECT SUM(Mandays) FROM Checkroll.AnalyLatexCost
						WHERE EstateID = @EstateID AND ActiveMonthYearID =@ActiveMonthYearID AND YOP = @YOP
						AND MainDescription = 'PENDERES' 
						AND SubDescription in ( '-Basic', '-On Cost')
						GROUP BY YOP, MainDescription
					)
					SET @FactoryKG_YOP_Total = ( 
						SELECT ISNULL(SUM(FactoryKG),0) FROM Checkroll.AnalyLatexCost
						where EstateID = @EstateID AND ActiveMonthYearID =@ActiveMonthYearID AND YOP = @YOP
						GROUP BY YOP 
					)
					
					--UPDATE Checkroll.AnalyLatexCost set
					-- 		CostPerKG = Case FactoryKG When 0 then 0 else (@TotalCost_PENDERES / NULLIF((FactoryKG),0)) end,	
					--		CostPerBunches = (@TotalCost_PENDERES / NULLIF(PayrollBunches,0))
					--	WHERE EstateID = @EstateID AND ActiveMonthYearID =@ActiveMonthYearID AND YOP = @YOP
					--		AND MainDescription = 'PENDERES Produk' 
					--		AND SubDescription = 'Latex (Dry)' 
									
					UPDATE Checkroll.AnalyLatexCost SET CostPerKG = Case FactoryKG When 0 then 0 else (@TotalCost_PENDERES / NULLIF(FactoryKG,0)) end,	
							CostPerBunches = (@TotalCost_PENDERES / NULLIF(PayrollBunches,0)),
							KGPerBunches = (FactoryKG / NULLIF(PayrollBunches,0)), KGPerMandays = FactoryKG/@TotalMandays
						WHERE EstateID = @EstateID AND ActiveMonthYearID =@ActiveMonthYearID AND YOP = @YOP
							AND MainDescription = 'PENDERES Produk' 
							AND SubDescription = @SubDescription

					Fetch next from CursAnalyHarvCost into @YOP,  @MainDescription, @SubDescription
				END
		close CursAnalyHarvCost
	DEALLOCATE CursAnalyHarvCost
	
	UPDATE Checkroll.AnalyLatexCost SET MainDescription = 'PENDERES', MainOrderCounter = 2,
	SubOrderCounterMain = 7 	
	WHERE EstateID = @EstateID AND ActiveMonthYearID =@ActiveMonthYearID
	AND MainDescription = 'PENDERES Produk' 
	drop table #DistCRPanen
	
END