GO
/****** Object:  StoredProcedure [Vehicle].[EmployeeSelect]    Script Date: 18/05/2015 20:11:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








                 
-- ====================================================
-- Created By : Chandra
-- Modified By:
-- Created date: 18 05 2015
-- Last Modified Date:
-- Module     : Checkroll, RKPMS Web
-- Screen(s)  : EmployeeLookup.aspx
-- Description: Get Employee 
-- =====================================================
alter PROCEDURE [Checkroll].[EmployeeSelect]
-- Add the parameters for the stored procedure here
		@EstateID NVARCHAR(50),
        @EmpCode NVARCHAR(50),
        @EmpName NVARCHAR(80),
        @Category NVARCHAR(50),
        @IsDriver NVARCHAR(50)
AS
        SET NOCOUNT ON;
        BEGIN
                IF @Category IS NULL
                BEGIN
                
					IF @IsDriver IS NULL
					BEGIN
                
                        SELECT   EmpID  ,
                                 EmpName,
                                 EmpCode
                        FROM     Checkroll.CREmployee
                        WHERE    EstateID = @EstateID and EmpJobDescriptionId=1
                        AND Status ='Active'
                             AND
                                 (
                                          CASE
                                                   WHEN @EmpCode IS NULL
                                                   THEN 1
                                          END = 1
                                       OR EmpCode LIKE @EmpCode + '%'
                                 )
                             AND
                                 (
                                          CASE
                                                   WHEN @EmpName IS NULL
                                                   THEN 1
                                          END = 1
                                       OR EmpName LIKE @EmpName + '%'
                                 )
                        ORDER BY ID DESC
                    END
					ELSE
					BEGIN
						SELECT   EmpID  ,
                                 EmpName,
                                 EmpCode
                        FROM     Checkroll.CREmployee
                        WHERE    EstateID = @EstateID
  --                      AND Status ='Active'
                             AND Checkroll.CREmployee.Mandor = 'D' AND
                                 (
                                          CASE
                                                   WHEN @EmpCode IS NULL
                                                   THEN 1
                                          END = 1
                                       OR EmpCode LIKE @EmpCode + '%'
                                 )
                             AND
                                 (
                                          CASE
                                                   WHEN @EmpName IS NULL
                                                   THEN 1
                                          END = 1
                                       OR EmpName LIKE @EmpName + '%'
                                 )
                        ORDER BY ID DESC
					END
                END
                ELSE
                BEGIN
                        SELECT   EmpID  ,
                                 EmpName,
                                 EmpCode
                        FROM     Checkroll.CREmployee
                        WHERE    EstateID = @EstateID AND Checkroll.CREmployee.Mandor = 'N' and EmpJobDescriptionId=1
                        AND Status ='Active'
                             AND
                                 (
                                          CASE
                                                   WHEN @EmpCode IS NULL
                                                   THEN 1
                                          END = 1
                                       OR EmpCode LIKE @EmpCode + '%'
                                 )
                             AND
                                 (
                                          CASE
                                                   WHEN @EmpName IS NULL
                                                   THEN 1
                                          END = 1
                                       OR EmpName LIKE @EmpName + '%'
                                 )
                             --AND
                             --    (
                             --             CASE
                             --                      WHEN @Category IS NULL
                             --                            OR @Category = ''
                             --                      THEN 1
                             --             END      = 1
                             --          OR Category = @Category
                             --    )
                        ORDER BY ID DESC
                END
        END






		select * from Checkroll.CREmployee



