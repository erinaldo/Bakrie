
GO

/****** Object:  StoredProcedure [Checkroll].[CREmployeeByWorktypePenderes]    Script Date: 07/01/2015 11:20:52 ******/
DROP PROCEDURE [Checkroll].[CREmployeeByWorktypePenderes]
GO

/****** Object:  StoredProcedure [Checkroll].[CREmployeeByWorktypePenderes]    Script Date: 07/01/2015 11:20:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Checkroll].[CREmployeeByWorktypePenderes]
	-- Add the parameters for the stored procedure here
	@EstateID as varchar(50),
	@DateRubber as varchar(50)
AS
BEGIN

SELECT        SumRubber.Latex, SumRubber.CupLump, SumRubber.TreeLace, Checkroll.CREmployee.Id, Checkroll.CREmployee.EmpID, Checkroll.CREmployee.EstateID, 
                         Checkroll.CREmployee.Category, Checkroll.CREmployee.EmpCode, Checkroll.CREmployee.EmpName, Checkroll.CREmployee.OEEmpCode, 
                         Checkroll.CREmployee.OEEmpLocation, Checkroll.CREmployee.FamilyName, Checkroll.CREmployee.FamilyCardNo, Checkroll.CREmployee.Insurance, 
                         Checkroll.CREmployee.HomeAdd1, Checkroll.CREmployee.HomeAdd2, Checkroll.CREmployee.HomeAdd3, Checkroll.CREmployee.HomeTelMobileNo, 
                         Checkroll.CREmployee.EthnicGroup, Checkroll.CREmployee.EmpImage, Checkroll.CREmployee.WorkerType, Checkroll.CREmployee.BankID, 
                         Checkroll.CREmployee.AccountNo, Checkroll.CREmployee.Position, Checkroll.CREmployee.StationID, Checkroll.CREmployee.Gender, Checkroll.CREmployee.DOB, 
                         Checkroll.CREmployee.KTP, Checkroll.CREmployee.PassportNo, Checkroll.CREmployee.JamsostekNo, Checkroll.CREmployee.NPWP, 
                         Checkroll.CREmployee.Religion, Checkroll.CREmployee.MaritalStatus, Checkroll.CREmployee.NoOfChildrenforTax, Checkroll.CREmployee.Mandor, 
                         Checkroll.CREmployee.Krani, Checkroll.CREmployee.RestDay, Checkroll.CREmployee.DOJ, Checkroll.CREmployee.Status, Checkroll.CREmployee.StatusDate, 
                         Checkroll.CREmployee.TransferLocation, Checkroll.CREmployee.WifeEmpWithREA, Checkroll.CREmployee.WifeNotStayinREA, 
                         Checkroll.CREmployee.WifeStayinREAreceivesRice, Checkroll.CREmployee.FatherName, Checkroll.CREmployee.FDobAndPlace, Checkroll.CREmployee.FAddress, 
                         Checkroll.CREmployee.FTribe, Checkroll.CREmployee.FReligion, Checkroll.CREmployee.MotherName, Checkroll.CREmployee.MDobAndPlace, 
                         Checkroll.CREmployee.MAddress, Checkroll.CREmployee.MTribe, Checkroll.CREmployee.MReligion, Checkroll.CREmployee.FatherILName, 
                         Checkroll.CREmployee.FILDobAndPlace, Checkroll.CREmployee.FILAddress, Checkroll.CREmployee.FILTribe, Checkroll.CREmployee.FILReligion, 
                         Checkroll.CREmployee.MotherILName, Checkroll.CREmployee.MILDobAndPlace, Checkroll.CREmployee.MILAddress, Checkroll.CREmployee.MILTribe, 
                         Checkroll.CREmployee.MILReligion, Checkroll.CREmployee.HusbWifeName, Checkroll.CREmployee.HWDOBAndPlace, Checkroll.CREmployee.HWAddress, 
                         Checkroll.CREmployee.HWIDNo, Checkroll.CREmployee.HWMarriageCertNo, Checkroll.CREmployee.HWFamilyCardNo, Checkroll.CREmployee.HWEthnicGroup, 
                         Checkroll.CREmployee.HWReligion, Checkroll.CREmployee.Elementry, Checkroll.CREmployee.Junior, Checkroll.CREmployee.Senior, 
                         Checkroll.CREmployee.Diploma, Checkroll.CREmployee.Degree, Checkroll.CREmployee.ConcurrencyId, Checkroll.CREmployee.CreatedBy, 
                         Checkroll.CREmployee.CreatedOn, Checkroll.CREmployee.ModifiedBy, Checkroll.CREmployee.ModifiedOn, Checkroll.CREmployee.MedClaimAllowanceLimit, 
                         Checkroll.CREmployee.HaveNPWP, Checkroll.CREmployee.EmpJobDescriptionId
FROM            Checkroll.CREmployee LEFT OUTER JOIN
                             (SELECT        NIK, SUM(Latex) AS Latex, SUM(CupLamp) AS CupLump, SUM(TreeLace) AS TreeLace, CONVERT(char(7), DateRubber, 20) AS daterubber
                               FROM            Checkroll.DailyReceptionForRubber
                               WHERE        (CONVERT(char(7), DateRubber, 20) = @DateRubber) --2014-10 example format
                               GROUP BY NIK, CONVERT(char(7), DateRubber, 20)) AS SumRubber ON Checkroll.CREmployee.EmpCode = SumRubber.NIK
WHERE        (Checkroll.CREmployee.WorkerType = 'Penderes') AND (Checkroll.CREmployee.EstateID = @EstateID)
END

GO


