delete from Checkroll.EmpAllowanceDeduction where AllowDedID = 'BSP04R86' and Empid = 'C00202604' and MONTH(StartDate) = 2 and YEAR(StartDate) = 2016

delete from Checkroll.MandorBesarPremi where month(Ddate) = 2 and Year(Ddate) = 2016

update Checkroll.DailyTeamActivity set MandorBesarID = 'C00202474' where MandorBesarID = 'C00202604' and MONTH(DDate) = 2 and Year(DDate) = 2016 and Activity = 'Panen'
