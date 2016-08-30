GO
/****** Object:  StoredProcedure [Checkroll].[[CRDEresTeamPrint]]    Script Date: 27/8/2015 11:09:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [Checkroll].[CRDeresTeamPrint]

@EstateID nvarchar(50),
@ActiveMonthYearID nvarchar(50)

AS 

DECLARE @FROMDT as date;
DECLARE @TODT as date;

Select @FROMDT= Convert(date,Fromdt,103), @TODT = Convert(date,ToDT,103) from General.FiscalYear FY
inner join General.ActiveMonthYear AM on FY.FYear = AM.AYear and AM.AMonth = FY.Period
where am.ActiveMonthYearID = @ActiveMonthYearID

select GS.EmpID,emp.EmpCode,emp.EmpName,Mandor.EmpCode as MandorNik,Mandor.EmpName as MandorName,
Kerani.EmpCode as KeraniNik, Kerani.EmpName as KeraniName , MandorBesar.EmpCode as MandorBesarNik, MandorBesar.EmpName as MandorBesarName,
GM.GangName,gm.Category,@FROMDT as FromDate,@TODT as ToDate
from Checkroll.GangEmployeeSetup GS
inner join Checkroll.GangMaster GM on GS.GangMasterID = GM.GangMasterID
inner join Checkroll.GangMasterBesar GMB ON gm.GangMasterID = GMB.GangMasterID
inner join Checkroll.CREmployee Emp ON gs.EmpID = Emp.EmpID
left join Checkroll.CREmployee Mandor ON GM.MandoreID = Mandor.EmpID
left join Checkroll.CREmployee Kerani ON GM.KraniID = Kerani.EmpID
left join Checkroll.CREmployee MandorBesar ON GMB.GangMasterBesarID = MandorBesar.EmpID
WHERE gm.EstateID = @EstateID And Gm.Category = 'Deres'