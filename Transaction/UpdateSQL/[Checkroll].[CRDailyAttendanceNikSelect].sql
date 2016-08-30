GO

/****** Object:  StoredProcedure [Checkroll].[CRDailyAttendanceNikSelect]    Script Date: 15/12/2014 13:27:48 ******/
DROP PROCEDURE [Checkroll].[CRDailyAttendanceNikSelect]
GO

/****** Object:  StoredProcedure [Checkroll].[CRDailyAttendanceNikSelect]    Script Date: 15/12/2014 13:27:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




---- modified by kumar 26112010











CREATE PROCEDURE [Checkroll].[CRDailyAttendanceNikSelect]
@EmpCode nvarchar(50),
@EmpName nvarchar (50),
@EstateID nvarchar(50),
@Status nvarchar (50),
@Mandor nvarchar (50),
@AttDate Date



AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

IF @EmpCode = ''  and @EmpName=''  and @Mandor = ''
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
                       
WHERE    CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY Checkroll.CREmployee.Category ,Checkroll.CREmployee.EmpName  
			
END
		
IF @EmpCode <> ''  and @EmpName='' and @Mandor <> '' 
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
WHERE  (EmpCode LIKE '%'+ @empcode	+ '%') and  CREmployee.EmpJobDescriptionId =@Mandor  and CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY Checkroll.CREmployee.Category ,Checkroll.CREmployee.EmpName  
END

IF @EmpCode <> ''  and @EmpName='' and @Mandor = '' 
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
WHERE  (EmpCode LIKE '%'+ @empcode	+ '%') and CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY Checkroll.CREmployee.Category ,Checkroll.CREmployee.EmpName  
END		
		
		
IF @EmpCode = ''  and @EmpName <>'' and @Mandor <>'' 
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
WHERE (EmpName LIKE  '%'+ @EmpName	+ '%') and  CREmployee.EmpJobDescriptionId =@Mandor and   CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY [Name]
END

IF @EmpCode  <>''  and @EmpName ='' and @Mandor <>'' 
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
WHERE (EmpCode  LIKE '%'+ @EmpCode	+ '%') and  CREmployee.EmpJobDescriptionId =@Mandor and   CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY [Name]
END

IF @EmpCode <> ''  and @EmpName <>'' and @Mandor ='' 
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
WHERE (EmpCode LIKE '%'+ @EmpCode	+ '%' and EmpName LIKE '%'+ @EmpName	+ '%')  and   CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY [Name]
END


IF @EmpCode = ''  and @EmpName ='' and @Mandor <>'' 
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
WHERE CREmployee.EmpJobDescriptionId =@Mandor and   CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY Checkroll.CREmployee.Category ,Checkroll.CREmployee.EmpName  
END

IF @EmpCode <> ''  and @EmpName <>'' and @Mandor <>'' 
BEGIN
SELECT    DISTINCT Checkroll.CREmployee.EmpCode AS NIK, Checkroll.CREmployee.EmpName AS Name, Checkroll.CREmployee.EmpID AS [Employee ID], 
          Checkroll.CREmployee.TransferLocation AS [Transfer Location], Checkroll.CREmployee.Category, Checkroll.RateSetup.BasicRate AS [Basic Rate], 
          Checkroll.RateSetup.OTDivider, Checkroll.CREmployee.Mandor, Checkroll.CREmployee.Krani, Checkroll.CREmployee.Status, 
          Checkroll.GangEmployeeSetup.GangEmployeeID, Checkroll.CREmployee.RestDay
FROM      Checkroll.CREmployee FULL OUTER JOIN
          Checkroll.GangEmployeeSetup ON Checkroll.CREmployee.EmpID = Checkroll.GangEmployeeSetup.EmpID FULL OUTER JOIN
          Checkroll.RateSetup ON Checkroll.CREmployee.Category = Checkroll.RateSetup.Category
WHERE EmpCode LIKE '%'+ @empcode	+ '%' and EmpName LIKE '%'+ @EmpName  + '%' and  CREmployee.EmpJobDescriptionId =@Mandor 
and  CREmployee.EstateID =@EstateID 
AND ( CREmployee .DOJ < = @AttDate ) 
 AND ((case when CREmployee.StatusDate IS NOT NULL then 1  end =1 AND CREmployee.StatusDate > @AttDate    )
 or (case when CREmployee.StatusDate IS NULL then 1 end= 1 AND CREmployee.Status= 'Active' ))
ORDER BY Checkroll.CREmployee.Category ,Checkroll.CREmployee.EmpName  
			
END
	
END

		
	















GO


