GO
/****** Object:  StoredProcedure [Checkroll].[[CRPanenTeamPrint]]    Script Date: 27/8/2015 11:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Checkroll].[CRPanenTeamPrint]

@EstateID nvarchar(50),
@ActiveMonthYearID nvarchar(50),
@Category nvarchar(50)

AS 

DECLARE @FROMDT as date;
DECLARE @TODT as date;


Declare @myScalerTempTable Table
(
EmpID nvarchar(50),
EmpCode nvarchar(255),
EmpName nvarchar(255),
MandorNik nvarchar(50),
MandorName nvarchar(255),
KeraniNik nvarchar(50),
KeraniName nvarchar(255),
MandorBesarNik nvarchar(50),
MandorBesarName nvarchar(255),
GangName nvarchar(50),
Category nvarchar(50),
FromDate datetime,
ToDate datetime
);


Select @FROMDT= Convert(date,Fromdt,103), @TODT = Convert(date,ToDT,103) from General.FiscalYear FY
inner join General.ActiveMonthYear AM on FY.FYear = AM.AYear and AM.AMonth = FY.Period
where am.ActiveMonthYearID = @ActiveMonthYearID

Insert Into @myScalerTempTable(EmpID,EmpCode,EmpName,MandorNik,MandorName,KeraniNik,KeraniName,MandorBesarNik,MandorBesarName, GangName, Category,FromDate,ToDate)
select GS.EmpID,emp.EmpCode,emp.EmpName,Mandor.EmpCode as MandorNik,Mandor.EmpName as MandorName,
Kerani.EmpCode as KeraniNik, Kerani.EmpName as KeraniName , MandorBesar.EmpCode as MandorBesarNik, MandorBesar.EmpName as MandorBesarName,
GM.GangName,gm.Category,@FROMDT as FromDate,@TODT as ToDate
from Checkroll.GangEmployeeSetup GS
inner join Checkroll.GangMaster GM on GS.GangMasterID = GM.GangMasterID
left join Checkroll.GangMasterBesar GMB ON gm.GangMasterID = GMB.GangMasterID
inner join Checkroll.CREmployee Emp ON gs.EmpID = Emp.EmpID
left join Checkroll.CREmployee Mandor ON GM.MandoreID = Mandor.EmpID
left join Checkroll.CREmployee Kerani ON GM.KraniID = Kerani.EmpID
left join Checkroll.CREmployee MandorBesar ON GMB.GangMasterBesarID = MandorBesar.EmpID
WHERE gm.EstateID = @EstateID And Gm.Category = @Category

Declare @ttlCount as int;
Declare @tmpGangName as nvarchar(50);
DECLARE CR_DA CURSOR FOR   
select Count(GS.EmpID), GM.GangName
from Checkroll.GangEmployeeSetup GS
inner join Checkroll.GangMaster GM on GS.GangMasterID = GM.GangMasterID
inner join Checkroll.CREmployee Emp ON gs.EmpID = Emp.EmpID
WHERE gm.EstateID = @EstateID And Gm.Category = @Category
group by gm.GangName
Open CR_DA  
FETCH NEXT FROM CR_DA  
INTO   
 @ttlCount  
 ,@tmpGangName
 
 
 WHILE @@FETCH_STATUS = 0   
 BEGIN  
	While @ttlCount < 25
		BEGIN
			Insert Into @myScalerTempTable(EmpID,EmpCode,GangName)
			Values (@ttlCount,'',@tmpGangName)
			SET @ttlCount= @ttlCount + 1
		EnD
    FETCH NEXT FROM CR_DA  
    INTO   
    @ttlCount  
    ,@tmpGangName  
END  
 CLOSE CR_DA  
  
 DEALLOCATE CR_DA  
select * from @myScalerTempTable;