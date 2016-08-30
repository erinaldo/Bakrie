select a.DDate,a.MilWeight,a.Bunches, c.BlockID,d.CropCode,c.PlantedHect,e.EstateName,b.Name from BSPMS_SR.Checkroll.CropStatement a
inner join BSPMS_SR.General.YOP b on a.YOPID = b.YOPID
inner join BSPMS_SR.General.BlockMaster c on a.BlockID = c.BlockID
inner join BSPMS_SR.General.CropMaster d on c.CropID = d.CropID
inner join BSPMS_SR.General.Estate e on a.EstateID = e.EstateID

UNION

select a.DDate,a.MilWeight,a.Bunches, c.BlockID,d.CropCode,c.PlantedHect,e.EstateName,b.Name from BSPMS_TR.Checkroll.CropStatement a
inner join BSPMS_TR.General.YOP b on a.YOPID = b.YOPID
inner join BSPMS_TR.General.BlockMaster c on a.BlockID = c.BlockID
inner join BSPMS_TR.General.CropMaster d on c.CropID = d.CropID
inner join BSPMS_TR.General.Estate e on a.EstateID = e.EstateID


UNION

select a.DDate,a.MilWeight,a.Bunches, c.BlockID,d.CropCode,c.PlantedHect,e.EstateName,b.Name from BSPMS_GB.Checkroll.CropStatement a
inner join BSPMS_GB.General.YOP b on a.YOPID = b.YOPID
inner join BSPMS_GB.General.BlockMaster c on a.BlockID = c.BlockID
inner join BSPMS_GB.General.CropMaster d on c.CropID = d.CropID
inner join BSPMS_GB.General.Estate e on a.EstateID = e.EstateID


UNION

select a.DDate,a.MilWeight,a.Bunches, c.BlockID,d.CropCode,c.PlantedHect,e.EstateName,b.Name from BSPMS_KP.Checkroll.CropStatement a
inner join BSPMS_KP.General.YOP b on a.YOPID = b.YOPID
inner join BSPMS_KP.General.BlockMaster c on a.BlockID = c.BlockID
inner join BSPMS_KP.General.CropMaster d on c.CropID = d.CropID
inner join BSPMS_KP.General.Estate e on a.EstateID = e.EstateID

UNION

select a.DDate,a.MilWeight,a.Bunches, c.BlockID,d.CropCode,c.PlantedHect,e.EstateName,b.Name from BSPMS_SB.Checkroll.CropStatement a
inner join BSPMS_SB.General.YOP b on a.YOPID = b.YOPID
inner join BSPMS_SB.General.BlockMaster c on a.BlockID = c.BlockID
inner join BSPMS_SB.General.CropMaster d on c.CropID = d.CropID
inner join BSPMS_SB.General.Estate e on a.EstateID = e.EstateID

UNION

select a.DDate,a.MilWeight,a.Bunches, c.BlockID,d.CropCode,c.PlantedHect,e.EstateName,b.Name from BSPMS_AS.Checkroll.CropStatement a
inner join BSPMS_AS.General.YOP b on a.YOPID = b.YOPID
inner join BSPMS_AS.General.BlockMaster c on a.BlockID = c.BlockID
inner join BSPMS_AS.General.CropMaster d on c.CropID = d.CropID
inner join BSPMS_AS.General.Estate e on a.EstateID = e.EstateID



