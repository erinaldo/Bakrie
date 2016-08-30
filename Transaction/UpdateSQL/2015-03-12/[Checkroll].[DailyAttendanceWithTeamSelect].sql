
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceWithTeamSelect]    Script Date: 12/03/2015 15:52:17 ******/
DROP PROCEDURE [Checkroll].[DailyAttendanceWithTeamSelect]
GO

/****** Object:  StoredProcedure [Checkroll].[DailyAttendanceWithTeamSelect]    Script Date: 12/03/2015 15:52:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--========================================================================================
--
-- Author : Dadang Adi Hendradi
-- Modified : 16 Oct 2009, 14:41
-- Modified : Monday, 19 Oct 2009, 22:31 -> DailyAttendance Connect to DailyTeamActivity
-- Modified : Kamis, 22 Oct 2009, 22:54 -> add DDate in where clause
--
-- Modified : Ahad, 22 Nov 2009, 23:51
--            Adding sorting ORDER BY EMP.EmpCode

---   Modified : KUMAR JUL 15 2010
--               DESCP -- INCLUDED CASE Statement as per Enger Said\
				---KUMAR Nov 26112010
--
--========================================================================================
CREATE PROCEDURE [Checkroll].[DailyAttendanceWithTeamSelect]
@EstateID nvarchar(50),
@TeamName nvarchar(50),
@RDate Date,
@SaveUPDate nvarchar(50)


AS
--Declare @PHDateCalc as Date
SET NOCOUNT ON;
dECLARE	@aTT AS VARCHAR(50)
BEGIN
	
	IF @SaveUPDate = 'Save'
					BEGIN
					
				SELECT 
								A.DailyReceiptionID, 
								EstateID, 
								ActiveMonthYearID, 
								RDate, 
								DailyTeamActivityID, 
								EmpID, 
								OtherEstateEmpNo, 
								OtherEstateName,
								C.AttendanceSetupID ,
								TotalOT,
								DistributionSetupID,
								TotalOTValue,
								ConcurrencyId,
								CreatedBy, 
								CreatedOn, 
								ModifiedBy, 
								ModifiedOn,
								GangName,
								EstateCode, 
								EmpCode,
								AccountNo,							 
								EmpName,
								Category,
								BasicPay, 
								LooseFruitNormal,
								LooseFruitBorongan,
								HarvestedNormal,
								HarvestedBorongan,
								--NActualBunches AS JjgActualNormal ,
								--BActualBunches AS JjgActualBorongan ,
								--NLooseFruits AS BrdNormal,
								--BLooseFruits AS BrdBorongan ,
								A.AttendanceCode
								
				
				FROM 
				(
				
					SELECT		
								DISTINCT
								C_DA.DailyReceiptionID, 
								C_DA.EstateID, 
								C_DA.ActiveMonthYearID, 
								C_DA.RDate, 
								C_DA.DailyTeamActivityID, 
								C_DA.EmpID, 
								C_DA.OtherEstateEmpNo, 
								C_DA.OtherEstateName,
								C_DA.AttendanceSetupID,
								C_DA.TotalOT,
								C_DA.DistributionSetupID,
								C_DA.TotalOTValue,
								C_DA.ConcurrencyId,
								C_DA.CreatedBy, 
								C_DA.CreatedOn, 
								C_DA.ModifiedBy, 
								C_DA.ModifiedOn,
								C_DTA.GangName,
								C_EST.EstateCode, 
								EMP.EmpCode, 
								EMP.EmpName,
								EMP.AccountNo,
								EMP.Category,
								--CR_AS.AttendanceCode, 
								CR_AS.BasicPay, 
								CASE 
													WHEN EMP.Category ='KHT'
													THEN  
														CASE  
																	WHEN ( EMP.RestDay = SUBSTRING( DATENAME(WEEKDAY ,@RDate),0,4) ) 
																	Then 'M1' 
																	
																	WHEN (EMP.RestDay <> SUBSTRING( DATENAME(WEEKDAY ,@RDate),0,4) ) 
																	THEN 															
																			CASE 
																			WHEN  exists(Select  C_PHS.PHDate  from Checkroll .PublicHolidaySetup C_PHS
																				   INNER JOIN Checkroll.CREmployee  C_EMP ON C_EMP.EstateID  = C_PHS .EstateID
																				   WHERE  C_EMP.EstateID = @EstateID  AND 
																		   				C_PHS .PHDate = @RDate
																						AND (C_PHS .Religion = C_EMP .Religion or C_PHS .Religion = 'All'))	 
																						
																			Then 'L1'
																			WHEN (DATENAME(WEEKDAY ,@RDate)= 'Friday') 
																			THEN 
																			CASE 
																			WHEN exists(Select  C_PHS.PHDate  from Checkroll .PublicHolidaySetup C_PHS
																				   INNER JOIN Checkroll.CREmployee  C_EMP ON C_EMP.EstateID  = C_PHS .EstateID
																				   WHERE  C_EMP.EstateID = @EstateID  AND 
																		   				C_PHS .PHDate = @RDate
																						AND (C_PHS .Religion = C_EMP .Religion or C_PHS .Religion = 'All'))	 
																						
																			 Then 'JL'
																			 ELSE
																			     'J1'
																			 END	
																																																															
																			 WHEN (DATENAME(WEEKDAY ,@RDate)<> 'Friday') 
																			 Then '11'
																			
																			 END
																	
																											
																													
														END	
														
													WHEN EMP.Category ='KHL'
													THEN 
															CASE  
																	WHEN (EMP.RestDay = SUBSTRING( DATENAME(WEEKDAY ,@RDate),0,4) ) 
																	Then 'M0'
																	
																	WHEN (EMP.RestDay <> SUBSTRING( DATENAME(WEEKDAY ,@RDate),0,4) ) 
																	THEN 															
																			CASE 
																			WHEN  exists(Select  C_PHS.PHDate  from Checkroll .PublicHolidaySetup C_PHS
																				   INNER JOIN Checkroll.CREmployee  C_EMP ON C_EMP.EstateID  = C_PHS .EstateID
																				   WHERE  C_EMP.EstateID = @EstateID  AND 
																		   				C_PHS .PHDate = @RDate
																						AND (C_PHS .Religion = C_EMP .Religion or C_PHS .Religion = 'All'))	 
																						
																			Then 'L0'
																			WHEN (DATENAME(WEEKDAY ,@RDate)= 'Friday') 
																			THEN 
																			CASE 
																			WHEN exists(Select  C_PHS.PHDate  from Checkroll .PublicHolidaySetup C_PHS
																				   INNER JOIN Checkroll.CREmployee  C_EMP ON C_EMP.EstateID  = C_PHS .EstateID
																				   WHERE  C_EMP.EstateID = @EstateID  AND 
																		   				C_PHS .PHDate = @RDate
																						AND (C_PHS .Religion = C_EMP .Religion or C_PHS .Religion = 'All'))	 
																						
																			 Then 'L0'
																			 ELSE
																			     '11'
																			 END	
																																																															
																			 WHEN (DATENAME(WEEKDAY ,@RDate)<> 'Friday') 
																			 Then '11'
																			
																			 END
																													
														END	
															
													WHEN EMP.Category ='KT'
													THEN CR_AS.AttendanceCode									
														
													END AS AttendanceCode
								
								
												

					FROM
						Checkroll.DailyAttendance AS C_DA
						INNER JOIN Checkroll.DailyTeamActivity AS C_DTA on C_DA.DailyTeamActivityID = C_DA.DailyTeamActivityID
					--	INNER JOIN Checkroll.DailyGangEmployeeSetup AS C_GES on C_DTA.GangMasterID = C_GES.GangMasterID AND
					--	C_DA.EmpID = C_GES.EmpID AND
					--	C_DA.EstateID = C_GES.EstateID
						INNER JOIN Checkroll.CREmployee AS EMP on C_DA.EmpID = EMP.EmpID
						INNER JOIN General.Estate AS C_EST on C_DA.EstateID = C_EST.EstateID
						INNER JOIN Checkroll.AttendanceSetup CR_AS on C_DA.AttendanceSetupID = CR_AS.AttendanceSetupID
						LEFT JOIN General.GeneralDistributionSetup AS G_GDS on C_DA.DistributionSetupID = G_GDS.DistributionSetupID 
						INNER JOIN Checkroll.PublicHolidaySetup as C_PHS ON C_PHS .EstateID = C_DA .EstateID 
						
						
						
					WHERE
						C_DTA.GangName = @TeamName AND
						CONVERT(DATE, C_DA.RDate) = @RDate AND
						CONVERT(DATE, C_DTA.DDate) = @RDate AND
						C_DA.EstateID = @EstateID
						AND EMP .DOJ <= @RDate 
			--			AND EMP .Status ='Active' 
						--AND EMP.StatusDate IS NULL
						 AND ((case when Emp.StatusDate IS NOT NULL then 1  end =1 AND Emp.StatusDate >= @RDate   )
									or (case when Emp.StatusDate IS NULL then 1 end= 1 AND Emp.Status= 'Active' ))
					
				) A 
				
				LEFT JOIN 
				
				(SELECT AttendanceSetupID,AttendanceCode FROM Checkroll .AttendanceSetup WHERE EstateID =@EstateID ) C ON A .AttendanceCode =C.AttendanceCode 
				
				LEFT JOIN
				
				(select 	ISNULL(sum(C_DRWT.LooseFruitNormal),0) as LooseFruitNormal,
							ISNULL(sum(C_DRWT.LooseFruitBorongan),0) AS LooseFruitBorongan,
							ISNULL(sum(C_DRWT.HarvestedNormal),0) AS HarvestedNormal,
							ISNULL(sum(C_DRWT.HarvestedBorongan),0) AS HarvestedBorongan,
							--ISNULL(sum(C_DR.NActualBunches),0) as NActualBunches,ISNULL(sum(C_DR.BActualBunches),0) AS BActualBunches,
							--ISNULL(sum(C_DR.NLooseFruits ),0) as NLooseFruits,ISNULL(sum(C_DR.BLooseFruits ),0) AS BLooseFruits,
							C_DR.DailyReceiptionID 	FROM
							Checkroll.DailyAttendance AS C_DA	
						INNER JOIN Checkroll.DailyReceiption AS C_DR ON C_DA.DailyReceiptionID = C_DR.DailyReceiptionID
						INNER JOIN Checkroll.DailyReceptionWithTeam AS C_DRWT ON C_DRWT.DailyReceiptionDetID=C_DR.DailyReceiptionDetID
						WHERE
						C_DA.EstateID = @EstateID
						group by C_DR.DailyReceiptionID,C_DR .EstateID  )B
						on a.DailyReceiptionID =B.DailyReceiptionID 
				
					ORDER BY EmpName
END

ELSE

					BEGIN
								
					SELECT 
								C.DailyReceiptionID, 
								EstateID, 
								ActiveMonthYearID, 
								RDate, 
								DailyTeamActivityID, 
								EmpID, 
								OtherEstateEmpNo, 
								OtherEstateName,
								AttendanceSetupID,
								TotalOT,
								DistributionSetupID,
								TotalOTValue,
								ConcurrencyId,
								CreatedBy, 
								CreatedOn, 
								ModifiedBy, 
								ModifiedOn,
								GangName,
								EstateCode, 
								EmpCode, 
								AccountNo,
								EmpName, 
								Category,
								AttendanceCode ,
								BasicPay, 
								LooseFruitNormal,
								LooseFruitBorongan,
								HarvestedNormal,
								HarvestedBorongan
								--NActualBunches AS JjgActualNormal ,
								--BActualBunches AS JjgActualBorongan ,
								--NLooseFruits AS BrdNormal,
								--BLooseFruits AS BrdBorongan 
								
				
				FROM 
				(
									SELECT		
											DISTINCT
											C_DA.DailyReceiptionID, 
											C_DA.EstateID, 
											C_DA.ActiveMonthYearID, 
											C_DA.RDate, 
											C_DA.DailyTeamActivityID, 
											C_DA.EmpID, 
											C_DA.OtherEstateEmpNo, 
											C_DA.OtherEstateName,
											C_DA.AttendanceSetupID,
											C_DA.TotalOT,
											C_DA.DistributionSetupID,
											C_DA.TotalOTValue,
											C_DA.ConcurrencyId,
											C_DA.CreatedBy, 
											C_DA.CreatedOn, 
											C_DA.ModifiedBy, 
											C_DA.ModifiedOn,
											C_DTA.GangName,
											C_EST.EstateCode, 
											EMP.EmpCode,
											EMP.AccountNo,
											EMP.EmpName, 
											EMP.Category,
											CR_AS.AttendanceCode, 
											CR_AS.BasicPay								

								FROM
									Checkroll.DailyAttendance AS C_DA
									INNER JOIN Checkroll.DailyTeamActivity AS C_DTA on C_DA.DailyTeamActivityID = C_DA.DailyTeamActivityID
						--			INNER JOIN Checkroll.DailyGangEmployeeSetup AS C_GES on C_DTA.GangMasterID = C_GES.GangMasterID AND
						--			C_DA.EmpID = C_GES.EmpID AND
						--			C_DA.EstateID = C_GES.EstateID
									INNER JOIN Checkroll.CREmployee AS EMP on C_DA.EmpID = EMP.EmpID
									INNER JOIN General.Estate AS C_EST on C_DA.EstateID = C_EST.EstateID
									INNER JOIN Checkroll.AttendanceSetup CR_AS on C_DA.AttendanceSetupID = CR_AS.AttendanceSetupID
									LEFT JOIN General.GeneralDistributionSetup AS G_GDS on C_DA.DistributionSetupID = G_GDS.DistributionSetupID 
									INNER JOIN Checkroll.PublicHolidaySetup as C_PHS ON C_PHS .EstateID = C_DA .EstateID 
									
									
									
								WHERE
									C_DTA.GangName = @TeamName AND
									CONVERT(DATE, C_DA.RDate) = @RDate AND
									CONVERT(DATE, C_DTA.DDate) = @RDate AND
									C_DA.EstateID = @EstateID AND
								    EMP .DOJ <= @RDate 
								  --  AND EMP .Status ='Active'
								   AND ((case when Emp.StatusDate IS NOT NULL then 1  end =1 AND Emp.StatusDate >= @RDate   )
									or (case when Emp.StatusDate IS NULL then 1 end= 1 AND Emp.Status= 'Active' ))
						)C
						
						LEFT JOIN
				
								(select 	
									ISNULL(sum(C_DRWT.LooseFruitNormal),0) as LooseFruitNormal,
									ISNULL(sum(C_DRWT.LooseFruitBorongan),0) AS LooseFruitBorongan,
									ISNULL(sum(C_DRWT.HarvestedNormal),0) AS HarvestedNormal,
									ISNULL(sum(C_DRWT.HarvestedBorongan),0) AS HarvestedBorongan,
									--ISNULL(sum(C_DR.NActualBunches),0) as NActualBunches,ISNULL(sum(C_DR.BActualBunches),0) AS BActualBunches,
									--ISNULL(sum(C_DR.NLooseFruits ),0) as NLooseFruits,ISNULL(sum(C_DR.BLooseFruits ),0) AS BLooseFruits,
									C_DR.DailyReceiptionID 	FROM	
									Checkroll.DailyAttendance AS C_DA	
									INNER JOIN Checkroll.DailyReceiption AS C_DR ON C_DA.DailyReceiptionID = C_DR.DailyReceiptionID
									INNER JOIN Checkroll.DailyReceptionWithTeam AS C_DRWT ON C_DRWT.DailyReceiptionDetID=C_DR.DailyReceiptionDetID
									WHERE
									C_DA.EstateID = @EstateID
									group by C_DR.DailyReceiptionID,C_DR .EstateID  )D
									on C .DailyReceiptionID =D .DailyReceiptionID 
				
					ORDER BY EmpName
				END
	
	
END


GO


