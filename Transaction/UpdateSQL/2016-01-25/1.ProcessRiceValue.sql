
/****** Object:  StoredProcedure [Checkroll].[ProcessRiceValue]    Script Date: 26/1/2016 12:31:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Process Rice  for Tunjangan Calculation
ALTER PROCEDURE [Checkroll].[ProcessRiceValue]  
  
 @EstateID nvarchar(50),  
 @ActiveMonthYearID nvarchar(50)  
   
AS  

DECLARE @RiceEmp numeric(18,3)
DECLARE @RiceWife numeric(18,3)
DECLARE @RiceChild numeric(18,3)
DECLARE @RiceMax numeric(18,3)
DECLARE @Husband numeric(18,3)
DECLARE @Wife numeric(18,3)
Declare @EmpId nvarchar(50)
Declare @RAPrice numeric(18,3)
Declare @Bruto numeric(18,3)
Declare @RAstekPrice numeric(18,3)
-- Take natura price instead of RAPrice

SELECT  
				@RiceEmp = ISNULL(RAEmployee, 0), 
				@RiceWife = ISNULL(RAHusbandOrWife, 0),
				@RiceChild = ISNULL(RAChild, 0),
				@RaPrice = Isnull(RANaturaPrice,0),
				@RAstekPrice = ISNULL(RAAstekPrice,0)
			FROM
				Checkroll.TaxAndRiceSetup
			WHERE
				EstateID = @EstateID

DECLARE CR_DA CURSOR FOR   

Select RA.EmpID, case 
when  (ISNULL(RA.RiceEmp + RiceHusbund + RiceWife + RiceChild,0)* Riceday )  /  (WorkingDays) <= isnull(RiceEmp + RiceHusbund + RiceWife + RiceChild,0) then 
  (ISNULL(RiceEmp + RiceHusbund + RiceWife + RiceChild,0)* Riceday )  / (WorkingDays) else isnull(RiceEmp + RiceHusbund + RiceWife + RiceChild,0) 
  end AS Bruto  
  from (
SELECT  
 Distinct  
 C_EMP.EmpID,
 atsum.ActiveMonthYearID,  
 C_EMP.EstateID,  
 G_ESTATE.EstateName,  
 (SELECT  G_FY.ToDT  
  FROM  
   General.FiscalYear AS G_FY  
  WHERE  
   G_FY.FYear = G_AMY.AYear AND  
   G_FY.Period = G_AMY.AMonth )aS AdvProcessingDate,  
 WorkingDays,  
   
 C_EMP.EmpCode,  
 C_EMP.EmpName,  
 C_EMP.MaritalStatus,  
 1 AS Employee,
  CASE
	WHEN C_EMP.Gender = 'F' AND C_EMP.WifeStayinREAreceivesRice  = 'Y' THEN 1
	ELSE 0
  END as Husband,
--ISNULL(C_RAL.Husband,0) as Husband,  
	CASE 
	WHEN C_EMP.Gender = 'M' AND C_EMP.WifeStayinREAreceivesRice  = 'Y'  THEN 1
		ELSE 0
		END as Wife,  
  ISNULL(C_EMP.NoOfChildrenforTax, 0) as Child,  
  
 @RiceEmp as RiceEmp,  
 CASE
	WHEN C_EMP.Gender = 'F' AND C_EMP.WifeStayinREAreceivesRice  = 'Y' THEN  @RiceWife
	ELSE 0
  END as RiceHusbund,
CASE
  WHEN C_EMP.Gender = 'M' AND C_EMP.WifeStayinREAreceivesRice  = 'Y'  THEN  @RiceWife  
  else 0
 END AS RiceWife  
 ,  
 Isnull(@RiceChild * ISNULL(C_EMP.NoOfChildrenforTax, 0),0 ) as RiceChild, 

 HK,Leave , Sick , Rain , 
 --C_RAL.RiceMax AS Bruto,  
 IsNULL(C_RAL.RiceAdvance,0) as RiceAdvance,  
 G_AMY.AMonth,  
 G_AMY.AYear,
 Riceday  
FROM  
Checkroll.CREmployee AS C_EMP
LEft JOIN (Select * from Checkroll.RiceAdvanceLog where ActiveMonthYearID = @ActiveMonthYearID) AS C_RAL  ON C_EMP.EmpID = C_RAL.EmpID 
INNER JOIN General.Estate AS G_ESTATE ON G_ESTATE.EstateID = C_EMP.EstateID  
inner JOIN (select EmpID ,ActiveMonthYearID,
  HK=ISNULL(C_ASUM.[11],0) +  ISNULL(C_ASUM.J1, 0) +  ISNULL(C_ASUM.[51], 0) ---+ ISNULL(C_ASUM.[52M],0) --+ ISNULL(C_ASUM.[53M],0)  + ISNULL(C_ASUM.[54M],0)  + ISNULL(C_ASUM.[55M],0) + ISNULL(C_ASUM.[56M],0)
 , Leave = ISNULL(C_ASUM.CB, 0) + ISNULL(C_ASUM.CH, 0) + ISNULL(C_ASUM.CT, 0) + ISNULL(C_ASUM.I1, 0) + ISNULL(C_ASUM.I2, 0) +  ISNULL(C_ASUM.TPM, 0) +  ISNULL(C_ASUM.TP1M, 0) + ISNULL(C_ASUM.TP2M, 0) +  ISNULL(C_ASUM.TP3M, 0)
 , Sick = ISNULL(C_ASUM.S1, 0) + ISNULL(C_ASUM.S2, 0) + ISNULL(C_ASUM.S3, 0) + ISNULL(C_ASUM.S4, 0) + ISNULL(C_ASUM.CD, 0)  
 , Rain=ISNULL(C_ASUM.H1,0),
 Riceday= (ISNULL(C_ASUM.[11],0) +ISNULL(C_ASUM.J1, 0) +ISNULL(C_ASUM.[51], 0) + ISNULL(C_ASUM.CB, 0) + ISNULL(C_ASUM.CH, 0)  
 + ISNULL(C_ASUM.CT, 0) + ISNULL(C_ASUM.I1, 0) + ISNULL(C_ASUM.I2, 0)+ ISNULL(C_ASUM.S1, 0) + ISNULL(C_ASUM.S2, 0) + ISNULL(C_ASUM.S3, 0)  
 + ISNULL(C_ASUM.S4, 0) + ISNULL(C_ASUM.CD, 0)  + ISNULL(C_ASUM.H1,0)) --+ ISNULL(C_ASUM.[52M],0) + ISNULL(C_ASUM.[53M],0)  + ISNULL(C_ASUM.[54M],0)  + ISNULL(C_ASUM.[55M],0) + ISNULL(C_ASUM.[56M],0) +  ISNULL(C_ASUM.TPM, 0) +  ISNULL(C_ASUM.TP1M, 0) + ISNULL(C_ASUM.TP2M, 0) +  ISNULL(C_ASUM.TP3M, 0) ) 
 from  Checkroll .AttendanceSummary as C_ASUM
 where ActiveMonthYearID=@ActiveMonthYearID ) as atsum on atsum.EmpID = C_EMP.EmpID 

Inner JOIN General.ActiveMonthYear AS G_AMY ON atsum.ActiveMonthYearID = G_AMY.ActiveMonthYearID          
--AND C_DTA.DDate = C_RAL.AdvProcessingDate  

inner JOIN (SELECT (DATEDIFF(DAY , G_FY1.FromDT, G_FY1.ToDT) +1) - 
(DATEDIFF(wk,G_FY1.FromDT,G_FY1.ToDT) + ( CASE WHEN DATENAME(dw,G_FY1.FromDT)='SUNDAY' then 1 else 0 End ) + (CASE WHEN DATENAME(dw,G_FY1.ToDT)='SUNDAY' then 1 else 0 End)) 
-(SELECT COUNT(*) FROM Checkroll.PublicHolidaySetup
WHERE  PHDate >= G_FY1.FromDT AND PHDate <= G_FY1.ToDT AND not DATENAME(dw,PHDate)='SUNDAY' and 
EstateID = @EstateID  ) as WorkingDays,G_AMY1.ActiveMonthYearID 
FROM General.FiscalYear G_FY1 inner join General.ActiveMonthYear AS G_AMY1 ON (Year(G_FY1.ToDT) = G_AMY1.AYear) AND (Month(G_FY1.ToDT) = G_AMY1.AMonth)
 WHERE G_AMY1.ActiveMonthYearID= @ActiveMonthYearID) as wkdy on wkdy.ActiveMonthYearID=G_AMY.ActiveMonthYearID 
where C_EMP.EstateID = @EstateID   
 --AND C_RAL.ActiveMonthYearID = @ActiveMonthYearID   
 AND C_EMP.Category IN ('KHT','HIP','HIPS','PKWT') or Right(EmpCode,1) = 'P'
 AND atsum.ActiveMonthYearID =  @ActiveMonthYearID
 ) as RA

  
 Open CR_DA  
  
 FETCH NEXT FROM CR_DA  
 INTO   
 @EmpID,@Bruto

WHILE @@FETCH_STATUS = 0   
BEGIN  
	if RIGHT(@Empid,1) = 'P' -- PKWT only gets Employee Rice, no wife or child
		begin
			Update Checkroll.Salary Set AllowanceRiceForKT = @RiceEmp * @RAPrice, AllowanceRiceAstek = @RiceEmp * @RAstekPrice where EmpID = @EmpId And ActiveMonthYearID = @ActiveMonthYearID
		end
	else
		begin
		Update Checkroll.Salary Set AllowanceRiceForKT = @Bruto * @RAPrice, AllowanceRiceAstek = @RiceEmp * @RAstekPrice where EmpID = @EmpId And ActiveMonthYearID = @ActiveMonthYearID
		end
	Print @EmpID
 FETCH NEXT FROM CR_DA  
 INTO   
 @EmpID,@Bruto
END
CLOSE CR_DA  

DEALLOCATE CR_DA  


















