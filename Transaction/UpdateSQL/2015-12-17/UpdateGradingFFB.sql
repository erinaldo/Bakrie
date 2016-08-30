select * from Production.GradingFFB

Update Production.GradingFFB set 
UnripeFruitT = UnripeFruitJ,
UnderripeT = UnderripeJ,
RipeFruitT = RipeFruitJ,
OverRipeFruitT = OverRipeFruitJ,
EmptyBunchFruitT = EmptyBunchFruitJ,
TotalNormalFruitsT= RipeFruitJ + UnderripeJ + OverRipeFruitJ,
PartheT = PartheJ,
HardBunchT = HardBunchJ,
TotalAbnormalFruitsT = TotalAbnormalFruitsJ,
GTActualBunchesT = GTActualBunchesJ,
LightDamageT = LightDamageJ,
TotalT = TotalJ,

UnripeFruitP = UnripeFruitJ / TotalGradedBunches * 100,
UnderripeP = UnderripeJ / TotalGradedBunches * 100,
RipeFruitP = RipeFruitJ / TotalGradedBunches * 100,
OverRipeFruitP = OverRipeFruitJ / TotalGradedBunches * 100,
EmptyBunchFruitP = EmptyBunchFruitJ / TotalGradedBunches * 100,
TotalNormalFruitsP= TotalNormalFruitsJ / TotalGradedBunches * 100 ,
TotalAbnormalFruitsP = TotalAbnormalFruitsJ / TotalGradedBunches * 100 
