ALTER TABLE Checkroll.Salary ADD
	Gol numeric(18, 2) NULL
GO
DECLARE @v sql_variant 
SET @v = N'Basic Salary For the month before any deduction for absentism'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'Checkroll', N'TABLE', N'Salary', N'COLUMN', N'Gol'
GO