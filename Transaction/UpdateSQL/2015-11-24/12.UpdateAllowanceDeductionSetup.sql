
UPDATE Checkroll.AllowanceDeductionSetup set NoTransferToSalary = '1' where AllowDedCode IN ('A03','A04','A07','D30','D31','D34','D35','D08','D01','D02','D03','D05','D06')
GO

delete from Checkroll.EmpAllowanceDeduction where AllowDedID IN ('BSP04R50','BSP04R4')