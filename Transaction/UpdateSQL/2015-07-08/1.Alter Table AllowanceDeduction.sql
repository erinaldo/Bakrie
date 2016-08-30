Alter Table Checkroll.AllowanceDeductionSetup ADD
	NoTransferToSalary	bit,
	FixedAllowance		bit
GO

Update Checkroll.AllowanceDeductionSetup Set NoTransferToSalary = 0, FixedAllowance = 0
GO