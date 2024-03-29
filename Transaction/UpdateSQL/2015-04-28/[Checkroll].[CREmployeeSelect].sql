
/****** Object:  StoredProcedure [Checkroll].[CREmployeeSelect]    Script Date: 28/04/2015 19:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- ====================================================  
-- Created By : Nelson 
-- Modified By:  SIVA SUBRAMANIAN S
-- Created date: 15 Sep 2009  
-- Last Modified Date: 22 Jun 2010
-- Module     :CheckRoll,Employee Master, RKPMS Web  
-- Screen(s)  : EmployeeMaster.aspx  
-- Description: Selecting  employee
-- ===================================================== 
ALTER PROCEDURE [Checkroll].[CREmployeeSelect]
-- Add the parameters for the stored procedure here

        @EmpCode nvarchar(50),
        @EmpName nvarchar(50),
        @EstateID nvarchar(50)

        --@Id int,
        --@startRowIndex int,
        -- @maximumRows int
AS

if( @EmpCode is NULL) and (@EmpName is null)
begin
         SELECT CREmployee.EmpID ,CREmployee.Category                                   ,
               CREmployee.EmpCode                                    ,
               CREmployee.EmpName                                    ,
               CREmployee.FamilyName                                 ,
               CREmployee.FamilyCardNo                               ,
               CREmployee.Insurance                                  ,
               CREmployee.HomeAdd1                                   ,
               CREmployee.HomeTelMobileNo                            ,
               CREmployee.EthnicGroup                                ,
               CASE 
				WHEN CREmployee.EmpImage IS NOT NULL THEN 'ImageExist'
				ELSe NULL 
			   END as  EmpImage										 ,
               CREmployee.WorkerType                                 ,
               CREmployee.BankID                                     ,
               CREmployee.AccountNo                                  ,
               CREmployee.Position                                   ,
               CREmployee.StationID                                  ,
               CREmployee.Gender                                     ,
               CREmployee.DOB                                        ,
               CREmployee.KTP                                        ,
               CREmployee.PassportNo                                 ,
               CREmployee.JamsostekNo                                ,
               
               CASE CREmployee.NPWP                                 
                                  WHEN 'NO'
                                  THEN ''
                                  ELSE
                                  CREmployee.NPWP                    
               END AS NPWP   ,
               
               --CREmployee.NPWP                                       ,
               CREmployee.Religion                                   ,
               CREmployee.MaritalStatus                              ,
               CREmployee.NoOfChildrenforTax                         ,
               CREmployee.EmpJobDescriptionId as Mandor                                     ,
               CREmployee.Krani                                      ,
               CREmployee.RestDay                                    ,
               CREmployee.DOJ                                        ,
               CREmployee.[Status]            as Empstatus                             ,
               CREmployee.StatusDate                                 ,
               CREmployee.TransferLocation                           ,
               CREmployee.WifeEmpWithREA                             ,
               CREmployee.WifeNotStayinREA                           ,
               CREmployee.WifeStayinREAreceivesRice                         ,
               CREmployee.FatherName                                 ,
               CREmployee.FDobAndPlace                               ,
               CREmployee.FAddress                                   ,
               CREmployee.FTribe                                     ,
               CREmployee.FReligion                                  ,
               CREmployee.MotherName                                 ,
               CREmployee.MDobAndPlace                               ,
               CREmployee.MAddress                                   ,
               CREmployee.MTribe                                     ,
               CREmployee.MReligion                                  ,
               CREmployee.HusbWifeName                               ,
               CREmployee.HWDOBAndPlace                              ,
               CREmployee.HWAddress                                  ,
               CREmployee.HWIDNo                                     ,
               CREmployee.HWMarriageCertNo                           ,
               CREmployee.HWFamilyCardNo                             ,
               CREmployee.HWEthnicGroup                              ,
               CREmployee.HWReligion                                 ,
               CREmployee.Junior                                     ,
               CREmployee.Senior                                     ,
               CREmployee.Diploma                                    ,
               Degree                                                ,
                Elementry ,      
               Accounts.COA .COACode AS COACode                      ,
               Accounts.COA.COADescp AS AccountDescp                ,
               G_T0.TValue           AS TAnalysisCode0               ,
               G_T0.TAnalysisDescp   AS T0Description                ,
               G_T0.TAnalysisID      AS T0AnalysisID                 ,
               G_T1.TValue           AS TAnalysisCode1               ,
               G_T1.TAnalysisDescp   AS T1Description                ,
               G_T1.TAnalysisID      AS T1AnalysisID                 ,
               G_T2.TValue           AS TAnalysisCode2               ,
               G_T2.TAnalysisDescp   AS T2Description                ,
               G_T2.TAnalysisID      AS T2AnalysisID                 ,
               G_T3.TValue           AS TAnalysisCode3               ,
               G_T3.TAnalysisDescp   AS T3Description                ,
               G_T3.TAnalysisID      AS T3AnalysisID                 ,
               G_T4.TValue           AS TAnalysisCode4               ,
               G_T4.TAnalysisDescp   AS T4Description                ,
               G_T4.TAnalysisID      AS T4AnalysisID                 ,
               CREmployeeHIP.COAID                                   ,
               CREmployee.Level as EmpLevel                                ,
               CREmployee.Grade                                   ,
               CREmployeeHIP.HIPEmpID                                ,
               CREmployeeHIP.HIPMonthlyRate                          ,
               CREmployeeHIP.T0                                      ,
               CREmployeeHIP.T1                                      ,
               CREmployeeHIP.T2                                      ,
               CREmployeeHIP.T3                                      ,
               CREmployeeHIP.T4                                      ,
               --EmployeeChildren.CAddress                             ,
               --EmployeeChildren.CDOBAndPlace                         ,
               --EmployeeChildren.CName                                ,
               --EmployeeChildren.EmpChildID                           ,
               --EmpPreviousExperience.CompanyName                     ,
               --EmpPreviousExperience.FromDate AS PrevEmployeeFromDate,
               --EmpPreviousExperience.ToDate   AS PrevEmployeeToDate  ,
               --EmpPreviousExperience.EmpPrevExpID                    ,
               --EmpHistory.History                 AS EmpHistroy                      ,
               --EmpHistory.FromDate                AS EmpHistroyFromDate              ,
               --EmpHistory.ToDate                  AS EmpHistroyTodate                ,
               --EmpHealthHistory.FromDate          AS EmpHealthFromdate               ,
               --EmpHealthHistory.History           AS EmpHealthHistroy                ,
               --EmpHealthHistory.ToDate            AS EmpHealthToDate                 ,
               --CREmpPerformanceAppraisal.ARemarks AS PerformanceRemarks              ,
               --CREmpPerformanceAppraisal.AValue   AS PerformanceRemarks              ,
               --CREmpPerformanceAppraisal.AYear    AS PerformanceYear                 ,
               --CREmpSuspension.Descp              AS suspensionDescription           ,
               --CREmpSuspension.SDate              AS suspensionDate                  ,
               --CREmpSuspension.SRemarks           AS suspensionRemarks               ,
               --CREmpSuspension.SVDate             AS suspensionValidationDate,
               BankMaster.BankCode ,BankMaster.BankName ,BankMaster.Remarks ,BankMaster.BankID ,
               Production.Station.StationCode ,Production.Station.StationDescp ,Production.Station.StationID,
               CREmployee .MedClaimAllowanceLimit ,CREmployee.HaveNPWP,
			   CREmployee.UnionMembership

                

        FROM   Checkroll.CREmployee



        	    LEFT JOIN General.Estate G_ES ON Checkroll.CREmployee.EstateID=G_ES.EstateID

				--LEFT JOIN General.TAnalysis G_T0 ON General.GeneralDistributionSetup.T0=G_T0.TAnalysisID
				--LEFT JOIN General.TAnalysis G_T1 ON General.GeneralDistributionSetup.T1=G_T1.TAnalysisID
				--LEFT JOIN General.TAnalysis G_T2 ON General.GeneralDistributionSetup.T2=G_T2.TAnalysisID
				--LEFT JOIN General.TAnalysis G_T3 ON General.GeneralDistributionSetup.T3=G_T3.TAnalysisID
				--LEFT JOIN General.TAnalysis G_T4 ON General.GeneralDistributionSetup.T4=G_T4.TAnalysisID
                 --LEFT OUTER JOIN Accounts.COA
                 LEFT OUTER JOIN Checkroll.CREmployeeHIP    ON     CREmployee.EmpID=CREmployeeHIP.EmpID
               --ON     CREmployeeHIP.COAID =COA.COAID
               LEFT JOIN General.TAnalysis G_T0
               ON     CREmployeeHIP.T0=G_T0.TAnalysisID
               LEFT JOIN General.TAnalysis G_T1
               ON     CREmployeeHIP.T1=G_T1.TAnalysisID
               LEFT JOIN General.TAnalysis G_T2
               ON     CREmployeeHIP.T2=G_T2.TAnalysisID
               LEFT JOIN General.TAnalysis G_T3
               ON     CREmployeeHIP.T3=G_T3.TAnalysisID
               LEFT JOIN General.TAnalysis G_T4
               ON     CREmployeeHIP.T4=G_T4.TAnalysisID
               LEFT OUTER JOIN Accounts.COA on CREmployeeHIP.COAID=Accounts.COA.COAID 

               --LEFT JOIN General.Estate G_ES
               --ON     CREmployee.EstateID=G_ES.EstateID



               left outer join General.BankMaster on CREmployee.BankID=BankMaster.BankID 
               LEFT outer join Production.Station on CREmployee.StationID=Station.StationID


               --LEFT OUTER JOIN EmployeeChildren
               --ON     CREmployee.EmpID=EmployeeChildren.EmpID
               --LEFT OUTER JOIN EmpPreviousExperience
               --ON     CREmployee.EmpID=EmpPreviousExperience.EmpID
               --LEFT OUTER JOIN EmpHistory
               --ON     CREmployee.EmpID=EmpHistory.EmpID
               --LEFT OUTER JOIN EmpHealthHistory
               --ON     CREmployee.EmpID=EmpHealthHistory.EmpID
               --LEFT OUTER JOIN CREmpPerformanceAppraisal
               --ON     CREmployee.EmpID=CREmpPerformanceAppraisal.EmpID
               --LEFT OUTER JOIN CREmpSuspension
               --ON     CREmployee.EmpID=CREmpSuspension.EmpID



               where CREmployee.EstateID=@EstateID  order by CREmployee.ModifiedOn  desc,CREmployee.Id 
               end


if( @EmpCode is  NULL) and (@EmpName is not null)
begin
           SELECT CREmployee.EmpID ,CREmployee.Category                                   ,
               CREmployee.EmpCode                                    ,
               CREmployee.EmpName                                    ,
               CREmployee.FamilyName                                 ,
               CREmployee.FamilyCardNo                               ,
               CREmployee.Insurance                                  ,
               CREmployee.HomeAdd1                                   ,
               CREmployee.HomeTelMobileNo                            ,
               CREmployee.EthnicGroup                                ,
               CASE 
				WHEN CREmployee.EmpImage IS NOT NULL THEN 'ImageExist'
				ELSe NULL 
			   END as  EmpImage										 ,
               CREmployee.WorkerType                                 ,
               CREmployee.BankID                                     ,
               CREmployee.AccountNo                                  ,
               CREmployee.Position                                   ,
               CREmployee.StationID                                  ,
               CREmployee.Gender                                     ,
               CREmployee.DOB                                        ,
               CREmployee.KTP                                        ,
               CREmployee.PassportNo                                 ,
               CREmployee.JamsostekNo                                ,
                 CASE CREmployee.NPWP                                 
                                  WHEN 'NO'
                                  THEN ''
                                  ELSE
                                  CREmployee.NPWP                    
               END AS NPWP   ,
               
              -- CREmployee.NPWP                                       ,
               CREmployee.Religion                                   ,
               CREmployee.MaritalStatus                              ,
               CREmployee.NoOfChildrenforTax                         ,
               CREmployee.EmpJobDescriptionId as Mandor                                     ,
               CREmployee.Krani                                      ,
               CREmployee.RestDay                                    ,
               CREmployee.DOJ                                        ,
               CREmployee.[Status]            as Empstatus                             ,
               CREmployee.StatusDate                                 ,
               CREmployee.TransferLocation                           ,
               CREmployee.WifeEmpWithREA                             ,
               CREmployee.WifeNotStayinREA                           ,
               CREmployee.WifeStayinREAreceivesRice                         ,
               CREmployee.FatherName                                 ,
               CREmployee.FDobAndPlace                               ,
               CREmployee.FAddress                                   ,
               CREmployee.FTribe                                     ,
               CREmployee.FReligion                                  ,
               CREmployee.MotherName                                 ,
               CREmployee.MDobAndPlace                               ,
               CREmployee.MAddress                                   ,
               CREmployee.MTribe                                     ,
               CREmployee.MReligion                                  ,
               CREmployee.HusbWifeName                               ,
               CREmployee.HWDOBAndPlace                              ,
               CREmployee.HWAddress                                  ,
               CREmployee.HWIDNo                                     ,
               CREmployee.HWMarriageCertNo                           ,
               CREmployee.HWFamilyCardNo                             ,
               CREmployee.HWEthnicGroup                              ,
               CREmployee.HWReligion                                 ,
               CREmployee.Junior                                     ,
               CREmployee.Senior                                     ,
               CREmployee.Diploma                                    ,
               Degree ,
               Elementry ,                                            
               Accounts.COA .COACode AS COACode                      ,
               Accounts.COA.COADescp AS AccountDescp                  ,
               G_T0.TValue           AS TAnalysisCode0               ,
               G_T0.TAnalysisDescp   AS T0Description                ,
               G_T0.TAnalysisID      AS T0AnalysisID                 ,
               G_T1.TValue           AS TAnalysisCode1               ,
               G_T1.TAnalysisDescp   AS T1Description                ,
               G_T1.TAnalysisID      AS T1AnalysisID                 ,
               G_T2.TValue           AS TAnalysisCode2               ,
               G_T2.TAnalysisDescp   AS T2Description                ,
               G_T2.TAnalysisID      AS T2AnalysisID                 ,
               G_T3.TValue           AS TAnalysisCode3               ,
               G_T3.TAnalysisDescp   AS T3Description                ,
               G_T3.TAnalysisID      AS T3AnalysisID                 ,
               G_T4.TValue           AS TAnalysisCode4               ,
               G_T4.TAnalysisDescp   AS T4Description                ,
               G_T4.TAnalysisID      AS T4AnalysisID                 ,
               CREmployeeHIP.COAID                                   ,
               CREmployee.Level as EmpLevel                                ,
               CREmployee.Grade                                   ,
               CREmployeeHIP.HIPEmpID                                ,
               CREmployeeHIP.HIPMonthlyRate                          ,
               CREmployeeHIP.T0                                      ,
               CREmployeeHIP.T1                                      ,
               CREmployeeHIP.T2                                      ,
               CREmployeeHIP.T3                                      ,
               CREmployeeHIP.T4                                      ,
               EmployeeChildren.CAddress                             ,
               EmployeeChildren.CDOBAndPlace                         ,
               EmployeeChildren.CName                                ,
               EmployeeChildren.EmpChildID                           ,
               EmpPreviousExperience.CompanyName                     ,
               EmpPreviousExperience.FromDate AS PrevEmployeeFromDate,
               EmpPreviousExperience.ToDate   AS PrevEmployeeToDate  ,
               EmpPreviousExperience.EmpPrevExpID                    ,
               EmpHistory.History                 AS EmpHistroy                      ,
               EmpHistory.FromDate                AS EmpHistroyFromDate              ,
               EmpHistory.ToDate                  AS EmpHistroyTodate                ,
               EmpHealthHistory.FromDate          AS EmpHealthFromdate               ,
               EmpHealthHistory.History           AS EmpHealthHistroy                ,
               EmpHealthHistory.ToDate            AS EmpHealthToDate                 ,
               CREmpPerformanceAppraisal.ARemarks AS PerformanceRemarks              ,
               CREmpPerformanceAppraisal.AValue   AS PerformanceRemarks              ,
               CREmpPerformanceAppraisal.AYear    AS PerformanceYear                 ,
               CREmpSuspension.Descp              AS suspensionDescription           ,
               CREmpSuspension.SDate              AS suspensionDate                  ,
               CREmpSuspension.SRemarks           AS suspensionRemarks               ,
               CREmpSuspension.SVDate             AS suspensionValidationDate,
               BankMaster.BankCode ,BankMaster.BankName ,BankMaster.Remarks ,BankMaster.BankID ,
               Production.Station.StationCode ,Production.Station.StationDescp ,Production.Station.StationID ,
                CREmployee .MedClaimAllowanceLimit  ,CREmployee.HaveNPWP


        FROM   Checkroll.CREmployee
               LEFT JOIN General.Estate G_ES
               ON     CREmployee.EstateID=G_ES.EstateID
               LEFT OUTER JOIN Checkroll.CREmployeeHIP    ON     CREmployee.EmpID=CREmployeeHIP.EmpID
               left outer join General.BankMaster on CREmployee.BankID=BankMaster.BankID 
               LEFT outer join Production.Station on CREmployee.StationID=Station.StationID


               LEFT OUTER JOIN EmployeeChildren
               ON     CREmployee.EmpID=EmployeeChildren.EmpID
               LEFT OUTER JOIN EmpPreviousExperience
               ON     CREmployee.EmpID=EmpPreviousExperience.EmpID
               LEFT OUTER JOIN EmpHistory
               ON     CREmployee.EmpID=EmpHistory.EmpID
               LEFT OUTER JOIN EmpHealthHistory
               ON     CREmployee.EmpID=EmpHealthHistory.EmpID
               LEFT OUTER JOIN CREmpPerformanceAppraisal
               ON     CREmployee.EmpID=CREmpPerformanceAppraisal.EmpID
               LEFT OUTER JOIN CREmpSuspension
               ON     CREmployee.EmpID=CREmpSuspension.EmpID
               LEFT OUTER JOIN Accounts.COA
               ON     CREmployeeHIP.COAID =COA.COAID
               LEFT JOIN General.TAnalysis G_T0
               ON     CREmployeeHIP.T0=G_T0.TAnalysisID
               LEFT JOIN General.TAnalysis G_T1
               ON     CREmployeeHIP.T1=G_T1.TAnalysisID
               LEFT JOIN General.TAnalysis G_T2
               ON     CREmployeeHIP.T2=G_T2.TAnalysisID
               LEFT JOIN General.TAnalysis G_T3
               ON     CREmployeeHIP.T3=G_T3.TAnalysisID
               LEFT JOIN General.TAnalysis G_T4
               ON     CREmployeeHIP.T4=G_T4.TAnalysisID


               where CREmployee.EstateID=@EstateID and CREmployee.EmpName like '%' ++@EmpName+'%' order by CREmployee.ModifiedOn  desc,CREmployee .Id 

               end


               if( @EmpCode is not NULL) and (@EmpName is  null)
               begin

                     SELECT CREmployee.EmpID ,CREmployee.Category                                   ,
               CREmployee.EmpCode                                    ,
               CREmployee.EmpName                                    ,
               CREmployee.FamilyName                                 ,
               CREmployee.FamilyCardNo                               ,
               CREmployee.Insurance                                  ,
               CREmployee.HomeAdd1                                   ,
               CREmployee.HomeTelMobileNo                            ,
               CREmployee.EthnicGroup                                ,
               CASE 
				WHEN CREmployee.EmpImage IS NOT NULL THEN 'ImageExist'
				ELSe NULL 
			   END as  EmpImage										 ,
               CREmployee.WorkerType                                 ,
               CREmployee.BankID                                     ,
               CREmployee.AccountNo                                  ,
               CREmployee.Position                                   ,
               CREmployee.StationID                                  ,
               CREmployee.Gender                                     ,
               CREmployee.DOB                                        ,
               CREmployee.KTP                                        ,
               CREmployee.PassportNo                                 ,
               CREmployee.JamsostekNo                                ,
                 CASE CREmployee.NPWP                                 
                                  WHEN 'NO'
                                  THEN ''
                                  ELSE
                                  CREmployee.NPWP                    
               END AS NPWP   ,
               
               --CREmployee.NPWP                                       ,
               CREmployee.Religion                                   ,
               CREmployee.MaritalStatus                              ,
               CREmployee.NoOfChildrenforTax                         ,
               CREmployee.EmpJobDescriptionId as Mandor                                     ,
               CREmployee.Krani                                      ,
               CREmployee.RestDay                                    ,
               CREmployee.DOJ                                        ,
               CREmployee.[Status]            as Empstatus                             ,
               CREmployee.StatusDate                                 ,
               CREmployee.TransferLocation                           ,
               CREmployee.WifeEmpWithREA                             ,
               CREmployee.WifeNotStayinREA                           ,
               CREmployee.WifeStayinREAreceivesRice                         ,
               CREmployee.FatherName                                 ,
               CREmployee.FDobAndPlace                               ,
               CREmployee.FAddress                                   ,
               CREmployee.FTribe                                     ,
               CREmployee.FReligion                                  ,
               CREmployee.MotherName                                 ,
               CREmployee.MDobAndPlace                               ,
               CREmployee.MAddress                                   ,
               CREmployee.MTribe                                     ,
               CREmployee.MReligion                                  ,
               CREmployee.HusbWifeName                               ,
               CREmployee.HWDOBAndPlace                              ,
               CREmployee.HWAddress                                  ,
               CREmployee.HWIDNo                                     ,
               CREmployee.HWMarriageCertNo                           ,
               CREmployee.HWFamilyCardNo                             ,
               CREmployee.HWEthnicGroup                              ,
               CREmployee.HWReligion                                 ,
               CREmployee.Junior                                     ,
               CREmployee.Senior                                     ,
               CREmployee.Diploma                                    ,
               Degree    ,
                Elementry ,                                               
               Accounts.COA .COACode AS COACode                      ,
               Accounts.COA.COADescp AS AccountDescp                  ,
               G_T0.TValue           AS TAnalysisCode0               ,
               G_T0.TAnalysisDescp   AS T0Description                ,
               G_T0.TAnalysisID      AS T0AnalysisID                 ,
               G_T1.TValue           AS TAnalysisCode1               ,
               G_T1.TAnalysisDescp   AS T1Description                ,
               G_T1.TAnalysisID      AS T1AnalysisID                 ,
               G_T2.TValue           AS TAnalysisCode2               ,
               G_T2.TAnalysisDescp   AS T2Description                ,
               G_T2.TAnalysisID      AS T2AnalysisID                 ,
               G_T3.TValue           AS TAnalysisCode3               ,
               G_T3.TAnalysisDescp   AS T3Description                ,
               G_T3.TAnalysisID      AS T3AnalysisID                 ,
               G_T4.TValue           AS TAnalysisCode4               ,
               G_T4.TAnalysisDescp   AS T4Description                ,
               G_T4.TAnalysisID      AS T4AnalysisID                 ,
               CREmployeeHIP.COAID                                   ,
               CREmployee.Level as EmpLevel                                ,
               CREmployee.Grade                                   ,
               CREmployeeHIP.HIPEmpID                                ,
               CREmployeeHIP.HIPMonthlyRate                          ,
               CREmployeeHIP.T0                                      ,
               CREmployeeHIP.T1                                      ,
               CREmployeeHIP.T2                                      ,
               CREmployeeHIP.T3                                      ,
               CREmployeeHIP.T4                                      ,
               EmployeeChildren.CAddress                             ,
               EmployeeChildren.CDOBAndPlace                         ,
               EmployeeChildren.CName                                ,
               EmployeeChildren.EmpChildID                           ,
               EmpPreviousExperience.CompanyName                     ,
               EmpPreviousExperience.FromDate AS PrevEmployeeFromDate,
               EmpPreviousExperience.ToDate   AS PrevEmployeeToDate  ,
               EmpPreviousExperience.EmpPrevExpID                    ,
               EmpHistory.History                 AS EmpHistroy                      ,
               EmpHistory.FromDate                AS EmpHistroyFromDate              ,
               EmpHistory.ToDate                  AS EmpHistroyTodate                ,
               EmpHealthHistory.FromDate          AS EmpHealthFromdate               ,
               EmpHealthHistory.History           AS EmpHealthHistroy                ,
               EmpHealthHistory.ToDate            AS EmpHealthToDate                 ,
               CREmpPerformanceAppraisal.ARemarks AS PerformanceRemarks              ,
               CREmpPerformanceAppraisal.AValue   AS PerformanceRemarks              ,
               CREmpPerformanceAppraisal.AYear    AS PerformanceYear                 ,
               CREmpSuspension.Descp              AS suspensionDescription           ,
               CREmpSuspension.SDate              AS suspensionDate                  ,
               CREmpSuspension.SRemarks           AS suspensionRemarks               ,
               CREmpSuspension.SVDate             AS suspensionValidationDate,
               BankMaster.BankCode ,BankMaster.BankName ,BankMaster.Remarks ,BankMaster.BankID ,
               Production.Station.StationCode ,Production.Station.StationDescp ,Production.Station.StationID,
               CREmployee .MedClaimAllowanceLimit  ,CREmployee.HaveNPWP


        FROM   Checkroll.CREmployee
               LEFT JOIN General.Estate G_ES
               ON     CREmployee.EstateID=G_ES.EstateID
               LEFT OUTER JOIN Checkroll.CREmployeeHIP    ON     CREmployee.EmpID=CREmployeeHIP.EmpID
               left outer join General.BankMaster on CREmployee.BankID=BankMaster.BankID 
               LEFT outer join Production.Station on CREmployee.StationID=Station.StationID


               LEFT OUTER JOIN EmployeeChildren
               ON     CREmployee.EmpID=EmployeeChildren.EmpID
               LEFT OUTER JOIN EmpPreviousExperience
               ON     CREmployee.EmpID=EmpPreviousExperience.EmpID
               LEFT OUTER JOIN EmpHistory
               ON     CREmployee.EmpID=EmpHistory.EmpID
               LEFT OUTER JOIN EmpHealthHistory
               ON     CREmployee.EmpID=EmpHealthHistory.EmpID
               LEFT OUTER JOIN CREmpPerformanceAppraisal
               ON     CREmployee.EmpID=CREmpPerformanceAppraisal.EmpID
               LEFT OUTER JOIN CREmpSuspension
               ON     CREmployee.EmpID=CREmpSuspension.EmpID
               LEFT OUTER JOIN Accounts.COA
               ON     CREmployeeHIP.COAID =COA.COAID
               LEFT JOIN General.TAnalysis G_T0
               ON     CREmployeeHIP.T0=G_T0.TAnalysisID
               LEFT JOIN General.TAnalysis G_T1
               ON     CREmployeeHIP.T1=G_T1.TAnalysisID
               LEFT JOIN General.TAnalysis G_T2
               ON     CREmployeeHIP.T2=G_T2.TAnalysisID
               LEFT JOIN General.TAnalysis G_T3
               ON     CREmployeeHIP.T3=G_T3.TAnalysisID
               LEFT JOIN General.TAnalysis G_T4
               ON     CREmployeeHIP.T4=G_T4.TAnalysisID


               where CREmployee.EstateID=@EstateID and  CREmployee.EmpCode like '%' +@EmpCode +'%'  order by CREmployee.ModifiedOn  desc,CREmployee .Id 

              end

                 if( @EmpCode is not NULL) and (@EmpName is not null)
               begin

                  SELECT CREmployee.EmpID ,CREmployee.Category                                   ,
               CREmployee.EmpCode                                    ,
               CREmployee.EmpName                                    ,
               CREmployee.FamilyName                                 ,
               CREmployee.FamilyCardNo                               ,
               CREmployee.Insurance                                  ,
               CREmployee.HomeAdd1                                   ,
               CREmployee.HomeTelMobileNo                            ,
               CREmployee.EthnicGroup                                ,
               CASE 
				WHEN CREmployee.EmpImage IS NOT NULL THEN 'ImageExist'
				ELSe NULL 
			   END as  EmpImage										 ,
               CREmployee.WorkerType                                 ,
               CREmployee.BankID                                     ,
               CREmployee.AccountNo                                  ,
               CREmployee.Position                                   ,
               CREmployee.StationID                                  ,
               CREmployee.Gender                                     ,
               CREmployee.DOB                                        ,
               CREmployee.KTP                                        ,
               CREmployee.PassportNo                                 ,
               CREmployee.JamsostekNo                                ,
                 CASE CREmployee.NPWP                                 
                                  WHEN 'NO'
                                  THEN ''
                                  ELSE
                                  CREmployee.NPWP                    
               END AS NPWP   ,
               
               --CREmployee.NPWP                                       ,
               CREmployee.Religion                                   ,
               CREmployee.MaritalStatus                              ,
               CREmployee.NoOfChildrenforTax                         ,
               CREmployee.EmpJobDescriptionId as Mandor                                     ,
               CREmployee.Krani                                      ,
               CREmployee.RestDay                                    ,
               CREmployee.DOJ                                        ,
               CREmployee.[Status]            as Empstatus                             ,
               CREmployee.StatusDate                                 ,
               CREmployee.TransferLocation                           ,
               CREmployee.WifeEmpWithREA                             ,
               CREmployee.WifeNotStayinREA                           ,
               CREmployee.WifeStayinREAreceivesRice                         ,
               CREmployee.FatherName                                 ,
               CREmployee.FDobAndPlace                               ,
               CREmployee.FAddress                                   ,
               CREmployee.FTribe                                     ,
               CREmployee.FReligion                                  ,
               CREmployee.MotherName                                 ,
               CREmployee.MDobAndPlace                               ,
               CREmployee.MAddress                                   ,
               CREmployee.MTribe                                     ,
               CREmployee.MReligion                                  ,
               CREmployee.HusbWifeName                               ,
               CREmployee.HWDOBAndPlace                              ,
               CREmployee.HWAddress                                  ,
               CREmployee.HWIDNo                                     ,
               CREmployee.HWMarriageCertNo                           ,
               CREmployee.HWFamilyCardNo                             ,
               CREmployee.HWEthnicGroup                              ,
               CREmployee.HWReligion                                 ,
               CREmployee.Junior                                     ,
               CREmployee.Senior                                     ,
               CREmployee.Diploma                                    ,
               Degree                                                ,
                Elementry ,      
               Accounts.COA .COACode AS COACode                      ,
               Accounts.COA.COADescp AS AccountDescp                  ,
               G_T0.TValue           AS TAnalysisCode0               ,
               G_T0.TAnalysisDescp   AS T0Description                ,
               G_T0.TAnalysisID      AS T0AnalysisID                 ,
               G_T1.TValue           AS TAnalysisCode1               ,
               G_T1.TAnalysisDescp   AS T1Description                ,
               G_T1.TAnalysisID      AS T1AnalysisID                 ,
               G_T2.TValue           AS TAnalysisCode2               ,
               G_T2.TAnalysisDescp   AS T2Description                ,
               G_T2.TAnalysisID      AS T2AnalysisID                 ,
               G_T3.TValue           AS TAnalysisCode3               ,
               G_T3.TAnalysisDescp   AS T3Description                ,
               G_T3.TAnalysisID      AS T3AnalysisID                 ,
               G_T4.TValue           AS TAnalysisCode4               ,
               G_T4.TAnalysisDescp   AS T4Description                ,
               G_T4.TAnalysisID      AS T4AnalysisID                 ,
               CREmployeeHIP.COAID                                   ,
               CREmployee.Level as EmpLevel                                ,
               CREmployee.Grade                                   ,
               CREmployeeHIP.HIPEmpID                                ,
               CREmployeeHIP.HIPMonthlyRate                          ,
               CREmployeeHIP.T0                                      ,
               CREmployeeHIP.T1                                      ,
               CREmployeeHIP.T2                                      ,
               CREmployeeHIP.T3                                      ,
               CREmployeeHIP.T4                                      ,
               EmployeeChildren.CAddress                             ,
               EmployeeChildren.CDOBAndPlace                         ,
               EmployeeChildren.CName                                ,
               EmployeeChildren.EmpChildID                           ,
               EmpPreviousExperience.CompanyName                     ,
               EmpPreviousExperience.FromDate AS PrevEmployeeFromDate,
               EmpPreviousExperience.ToDate   AS PrevEmployeeToDate  ,
               EmpPreviousExperience.EmpPrevExpID                    ,
               EmpHistory.History                 AS EmpHistroy                      ,
               EmpHistory.FromDate                AS EmpHistroyFromDate              ,
               EmpHistory.ToDate                  AS EmpHistroyTodate                ,
               EmpHealthHistory.FromDate          AS EmpHealthFromdate               ,
               EmpHealthHistory.History           AS EmpHealthHistroy                ,
               EmpHealthHistory.ToDate            AS EmpHealthToDate                 ,
               CREmpPerformanceAppraisal.ARemarks AS PerformanceRemarks              ,
               CREmpPerformanceAppraisal.AValue   AS PerformanceRemarks              ,
               CREmpPerformanceAppraisal.AYear    AS PerformanceYear                 ,
               CREmpSuspension.Descp              AS suspensionDescription           ,
               CREmpSuspension.SDate              AS suspensionDate                  ,
               CREmpSuspension.SRemarks           AS suspensionRemarks               ,
               CREmpSuspension.SVDate             AS suspensionValidationDate,
               BankMaster.BankCode ,BankMaster.BankName ,BankMaster.Remarks ,BankMaster.BankID ,
               Production.Station.StationCode ,Production.Station.StationDescp ,Production.Station.StationID,
               CREmployee .MedClaimAllowanceLimit  ,CREmployee.HaveNPWP


        FROM   Checkroll.CREmployee
               LEFT JOIN General.Estate G_ES
               ON     CREmployee.EstateID=G_ES.EstateID
               LEFT OUTER JOIN Checkroll.CREmployeeHIP    ON     CREmployee.EmpID=CREmployeeHIP.EmpID
               left outer join General.BankMaster on CREmployee.BankID=BankMaster.BankID 
               LEFT outer join Production.Station on CREmployee.StationID=Station.StationID


               LEFT OUTER JOIN EmployeeChildren
               ON     CREmployee.EmpID=EmployeeChildren.EmpID
               LEFT OUTER JOIN EmpPreviousExperience
               ON     CREmployee.EmpID=EmpPreviousExperience.EmpID
               LEFT OUTER JOIN EmpHistory
               ON     CREmployee.EmpID=EmpHistory.EmpID
               LEFT OUTER JOIN EmpHealthHistory
               ON     CREmployee.EmpID=EmpHealthHistory.EmpID
               LEFT OUTER JOIN CREmpPerformanceAppraisal
               ON     CREmployee.EmpID=CREmpPerformanceAppraisal.EmpID
               LEFT OUTER JOIN CREmpSuspension
               ON     CREmployee.EmpID=CREmpSuspension.EmpID
               LEFT OUTER JOIN Accounts.COA
               ON     CREmployeeHIP.COAID =COA.COAID
               LEFT JOIN General.TAnalysis G_T0
               ON     CREmployeeHIP.T0=G_T0.TAnalysisID
               LEFT JOIN General.TAnalysis G_T1
               ON     CREmployeeHIP.T1=G_T1.TAnalysisID
               LEFT JOIN General.TAnalysis G_T2
               ON     CREmployeeHIP.T2=G_T2.TAnalysisID
               LEFT JOIN General.TAnalysis G_T3
               ON     CREmployeeHIP.T3=G_T3.TAnalysisID
               LEFT JOIN General.TAnalysis G_T4
               ON     CREmployeeHIP.T4=G_T4.TAnalysisID


               where CREmployee.EstateID=@EstateID  and CREmployee.EmpCode like '%' +@EmpCode +'%' AND CREmployee.EmpName like '%' +@EmpName+'%' order by CREmployee.ModifiedOn desc,CREmployee .Id 

              end

















