EXECUTE sp_rename N'Checkroll.DailyReceptionForRubber.PremiDasar', N'Tmp_PremiDasarLatex_1', 'COLUMN' 
GO
EXECUTE sp_rename N'Checkroll.DailyReceptionForRubber.PremiProgresif', N'Tmp_PremiProgresifLatex_2', 'COLUMN' 
GO
EXECUTE sp_rename N'Checkroll.DailyReceptionForRubber.PremiBonus', N'Tmp_PremiBonusLatex_3', 'COLUMN' 
GO
EXECUTE sp_rename N'Checkroll.DailyReceptionForRubber.Tmp_PremiDasarLatex_1', N'PremiDasarLatex', 'COLUMN' 
GO
EXECUTE sp_rename N'Checkroll.DailyReceptionForRubber.Tmp_PremiProgresifLatex_2', N'PremiProgresifLatex', 'COLUMN' 
GO
EXECUTE sp_rename N'Checkroll.DailyReceptionForRubber.Tmp_PremiBonusLatex_3', N'PremiBonusLatex', 'COLUMN' 
GO
ALTER TABLE Checkroll.DailyReceptionForRubber ADD
	PremiDasarLump float(53) NULL,
	PremiBonusLump float(53) NULL,
	PremiProgresifLump float(53) NULL,
	PremiTreelace float(53) NULL
GO