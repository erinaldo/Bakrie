USE BSPMS_GB
UPDATE Budget.FieldRubberProduction set Budget.FieldRubberProduction.blockid = General.BlockMaster.blockid
from Budget.FieldRubberProduction 
inner join General.BlockMaster on Right(Budget.FieldRubberProduction.BlockID,6) = Right(General.BlockMaster.BlockID,6)

