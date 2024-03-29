
/****** Object:  StoredProcedure [Checkroll].[EmpAllowanceDeductionisSelect]    Script Date: 26/11/2015 9:47:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [Checkroll].[EmpAllowanceDeductionisSelect]
	-- Add the parameters for the stored procedure here
	@EmpAllowDedID nvarchar(50),
	@EstateID nvarchar(50)

AS
	
	SET NOCOUNT ON;
	
	BEGIN
		SELECT     Checkroll.EmpAllowanceDeduction.EmpAllowDedID AS [Emp Allow Ded ID], Checkroll.EmpAllowanceDeduction.EstateID AS [Estate ID], 
                      General.Estate.EstateCode AS [Estate Code], Checkroll.EmpAllowanceDeduction.EmpID AS [Employee ID], 
                      Checkroll.CREmployee.EmpCode AS [Employee Code], Checkroll.CREmployee.EmpName AS [Employee Name], 
                      Checkroll.EmpAllowanceDeduction.AllowDedID AS [Allow Ded ID], Checkroll.AllowanceDeductionSetup.AllowDedCode AS [Allow Ded Code], 
                      Checkroll.AllowanceDeductionSetup.Remarks, Checkroll.AllowanceDeductionSetup.COAID AS [COA Id], Accounts.COA.COACode AS [COA Code], 
                      Accounts.COA.COADescp AS [COA Descp], Checkroll.EmpAllowanceDeduction.Amount, Checkroll.EmpAllowanceDeduction.Type, 
                      Checkroll.EmpAllowanceDeduction.StartDate AS [Start Date], Checkroll.EmpAllowanceDeduction.EndDates AS [End Date], 
                      Checkroll.EmpAllowanceDeduction.CreatedBy AS [Created By], Checkroll.EmpAllowanceDeduction.CreatedOn AS [Created On], 
                      Checkroll.EmpAllowanceDeduction.ModifiedBy AS [Modified By], Checkroll.EmpAllowanceDeduction.ModifiedOn AS [Modified On]
FROM         Checkroll.EmpAllowanceDeduction INNER JOIN
                      Checkroll.CREmployee ON Checkroll.EmpAllowanceDeduction.EmpID = Checkroll.CREmployee.EmpID INNER JOIN
                      Checkroll.AllowanceDeductionSetup ON Checkroll.EmpAllowanceDeduction.AllowDedID = Checkroll.AllowanceDeductionSetup.AllowDedID AND 
                      Checkroll.EmpAllowanceDeduction.AllowDedID = Checkroll.AllowanceDeductionSetup.AllowDedID INNER JOIN
                      Accounts.COA ON Checkroll.AllowanceDeductionSetup.COAID = Accounts.COA.COAID INNER JOIN
                      General.Estate ON Checkroll.EmpAllowanceDeduction.EstateID = General.Estate.EstateID
		
		WHERE EmpAllowDedID=@EmpAllowDedID and EmpAllowanceDeduction.EstateID = @EstateID AND Checkroll.AllowanceDeductionSetup.NoTransferToSalary=0 ;
	END













