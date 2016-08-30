
Insert Into Checkroll.DailyGangEmployeeSetup
Select DT.DDate, DT.DailyTeamActivityID, GES.GangEmployeeiD,DT.EstateID, DT.GangMasterId,GES.EmpId,GES.CreatedBy,GES.CreatedOn,GES.ModifiedBy,GES.ModifiedOn
from checkroll.DailyTeamActivity DT
inner join Checkroll.GangEmployeeSetup GES on DT.GangMasterId = GES.GangMasterId
