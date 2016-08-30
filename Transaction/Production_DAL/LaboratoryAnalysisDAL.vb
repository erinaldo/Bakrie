Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class LaboratoryAnalysisDAL

    '''LaboratoryAnalysis table

    Public Shared Function LaboratoryAnalysis_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(20) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Parms(4) = New SqlParameter("@CPOProductionFFAP", objLAPPT.CPOProductionFFAP)
        Parms(5) = New SqlParameter("@CPOProductionMoistureP", objLAPPT.CPOProductionMoistureP)
        Parms(6) = New SqlParameter("@CPOProductionDirtP ", objLAPPT.CPOProductionDirtP)
        Parms(7) = New SqlParameter("@KERProductionMoistureP", objLAPPT.KERProductionMoistureP)
        Parms(8) = New SqlParameter("@KERProductionDirtP", objLAPPT.KERProductionDirtP)
        Parms(9) = New SqlParameter("@KERProductionBrokenKernel ", objLAPPT.KERProductionBrokenKernel)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(14) = New SqlParameter("@PKOProductionFFAP", objLAPPT.PKOProductionFFAP)
        Parms(15) = New SqlParameter("@PKOProductionMoistureP", objLAPPT.PKOProductionMoistureP)
        Parms(16) = New SqlParameter("@PKOProductionDirtP ", objLAPPT.PKOProductionDirtP)
        Parms(17) = New SqlParameter("@CPOProductionFFAPMTD", objLAPPT.CPOProductionFFAPMTD)
        Parms(18) = New SqlParameter("@CPOProductionFFAPYTD", objLAPPT.CPOProductionFFAPYTD)
        Parms(19) = New SqlParameter("@PKOProductionFFAPMTD ", objLAPPT.PKOProductionFFAPMTD)
        Parms(20) = New SqlParameter("@PKOProductionFFAPYTD ", objLAPPT.PKOProductionFFAPYTD)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LaboratoryAnalysisInsert]", Parms)
        Return ds
       
    End Function

    Public Shared Function LaboratoryAnalysis_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(17) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(3) = New SqlParameter("@CPOProductionFFAP", objLAPPT.CPOProductionFFAP)
        Parms(4) = New SqlParameter("@CPOProductionMoistureP", objLAPPT.CPOProductionMoistureP)
        Parms(5) = New SqlParameter("@CPOProductionDirtP ", objLAPPT.CPOProductionDirtP)
        Parms(6) = New SqlParameter("@KERProductionMoistureP", objLAPPT.KERProductionMoistureP)
        Parms(7) = New SqlParameter("@KERProductionDirtP", objLAPPT.KERProductionDirtP)
        Parms(8) = New SqlParameter("@KERProductionBrokenKernel ", objLAPPT.KERProductionBrokenKernel)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@PKOProductionFFAP", objLAPPT.PKOProductionFFAP)
        Parms(12) = New SqlParameter("@PKOProductionMoistureP", objLAPPT.PKOProductionMoistureP)
        Parms(13) = New SqlParameter("@PKOProductionDirtP ", objLAPPT.PKOProductionDirtP)
        Parms(14) = New SqlParameter("@CPOProductionFFAPMTD", objLAPPT.CPOProductionFFAPMTD)
        Parms(15) = New SqlParameter("@CPOProductionFFAPYTD", objLAPPT.CPOProductionFFAPYTD)
        Parms(16) = New SqlParameter("@PKOProductionFFAPMTD ", objLAPPT.PKOProductionFFAPMTD)
        Parms(17) = New SqlParameter("@PKOProductionFFAPYTD ", objLAPPT.PKOProductionFFAPYTD)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LaboratoryAnalysisUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LaboratoryAnalysis_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabAnalysisDate", objLAPPT.lLabAnalysisDate)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LaboratoryAnalysisSelect]", Parms)
        Return ds
    End Function

    Public Shared Function LaboratoryAnalysisDuplicateCheck(ByVal objLAPPT As LaboratoryAnalysisPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Dim objExists As New Object
        objExists = objdb.ExecuteScalar("[Production].[LaboratoryAnalysisIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Shared Function LaboratoryAnalysisDelete(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LaboratoryAnalysisDelete]", Parms)
        Return ds
    End Function

    ''LabBoilerWater table 

    Public Shared Function LabBoilerWater_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Descp", objLAPPT.BWADescp)
        Parms(5) = New SqlParameter("@Value", objLAPPT.BWAValue)
        Parms(6) = New SqlParameter("@Type", objLAPPT.BWAType)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabBoilerWaterInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabBoilerWater_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(8) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabBoilerWaterID", objLAPPT.BWALabBoilerWaterID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Descp", objLAPPT.BWADescp)
        Parms(5) = New SqlParameter("@Value", objLAPPT.BWAValue)
        Parms(6) = New SqlParameter("@Type", objLAPPT.BWAType)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabBoilerWaterUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabBoilerWater_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabBoilerWaterSelect]", Parms)
        Return ds
    End Function


    ''' LabEffRippleMill

    Public Shared Function LabEffRippleMill_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Line", objLAPPT.ERPLine)
        Parms(5) = New SqlParameter("@No", objLAPPT.ERPNo)
        Parms(6) = New SqlParameter("@EfficiencyP", objLAPPT.ERPEfficiencyP)
        Parms(7) = New SqlParameter("@Equipment", objLAPPT.ERPEquipment)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabEffRippleMillInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabEffRippleMill_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabEffRippleMillID", objLAPPT.ERPLabEffRippleMillID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Line", objLAPPT.ERPLine)
        Parms(5) = New SqlParameter("@No", objLAPPT.ERPNo)
        Parms(6) = New SqlParameter("@EfficiencyP", objLAPPT.ERPEfficiencyP)
        Parms(7) = New SqlParameter("@Equipment", objLAPPT.ERPEquipment)
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabEffRippleMillUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabEffRippleMill_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabEffRippleMillSelect]", Parms)
        Return ds
    End Function


    '''LabKernelIntake
    ''' 

    Public Shared Function LabKernelIntake_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@SourceLocation", objLAPPT.KISourceLocation)
        Parms(5) = New SqlParameter("@ReceivedTon ", objLAPPT.KIReceivedTon)
        Parms(6) = New SqlParameter("@MoistureP", objLAPPT.KIMoistureP)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@DirtP", objLAPPT.KIDirtP)
        Parms(12) = New SqlParameter("@BrokenKernel", objLAPPT.KIBrokenKernel)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelIntakeInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabKernelIntake_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabKernelIntakeID", objLAPPT.KILabKernelIntakeID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@SourceLocation", objLAPPT.KISourceLocation)
        Parms(5) = New SqlParameter("@ReceivedTon ", objLAPPT.KIReceivedTon)
        Parms(6) = New SqlParameter("@MoistureP", objLAPPT.KIMoistureP)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(9) = New SqlParameter("@DirtP", objLAPPT.KIDirtP)
        Parms(10) = New SqlParameter("@BrokenKernel", objLAPPT.KIBrokenKernel)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelIntakeUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabKernelIntake_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelIntakeSelect]", Parms)
        Return ds
    End Function


    '' LabKernelLossesFFB
    Public Shared Function LabKernelLossesFFB_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Line", objLAPPT.KLFFBLine)
        Parms(5) = New SqlParameter("@LTDS1P ", objLAPPT.KLFFBLTDS1P)
        Parms(6) = New SqlParameter("@LTDS2P ", objLAPPT.KLFFBLTDS2P)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@FibreCycP", objLAPPT.KLFFBFibreCycP)
        Parms(12) = New SqlParameter("@HydroCycP", objLAPPT.KLFFBHydroCycP)
        Parms(13) = New SqlParameter("@FruitinEB", objLAPPT.KLFFBFruitinEB)
        Parms(14) = New SqlParameter("@LTDS3P ", objLAPPT.KLFFBLTDS3P)
        Parms(15) = New SqlParameter("@LTDS4P ", objLAPPT.KLFFBLTDS4P)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesFFBInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabKernelLossesFFB_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabKernelLossesFFBID", objLAPPT.KLFFBLabKernelLossesFFBID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Line", objLAPPT.KLFFBLine)
        Parms(5) = New SqlParameter("@LTDS1P ", objLAPPT.KLFFBLTDS1P)
        Parms(6) = New SqlParameter("@LTDS2P ", objLAPPT.KLFFBLTDS2P)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(9) = New SqlParameter("@FibreCycP", objLAPPT.KLFFBFibreCycP)
        Parms(10) = New SqlParameter("@HydroCycP", objLAPPT.KLFFBHydroCycP)
        Parms(11) = New SqlParameter("@FruitinEB", objLAPPT.KLFFBFruitinEB)
        Parms(12) = New SqlParameter("@LTDS3P ", objLAPPT.KLFFBLTDS3P)
        Parms(13) = New SqlParameter("@LTDS4P ", objLAPPT.KLFFBLTDS4P)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesFFBUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabKernelLossesFFB_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesFFBSelect]", Parms)
        Return ds
    End Function

    '' LabKernelLosses


    Public Shared Function LabKernelLosses_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@StationID", objLAPPT.KLStationID)
        Parms(5) = New SqlParameter("@No ", objLAPPT.KLNo)
        Parms(6) = New SqlParameter("@Line ", objLAPPT.KLLine)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@EfficiencyP", objLAPPT.KLEfficiencyP)
        Parms(12) = New SqlParameter("@LossesP", objLAPPT.KLLossesP)
        Parms(13) = New SqlParameter("@DirtP", objLAPPT.KLDirtP)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabKernelLosses_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabKernelLossesID", objLAPPT.KLLabKernelLossesID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@StationID", objLAPPT.KLStationID)
        Parms(5) = New SqlParameter("@No ", objLAPPT.KLNo)
        Parms(6) = New SqlParameter("@Line ", objLAPPT.KLLine)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(9) = New SqlParameter("@EfficiencyP", objLAPPT.KLEfficiencyP)
        Parms(10) = New SqlParameter("@LossesP", objLAPPT.KLLossesP)
        Parms(11) = New SqlParameter("@DirtP", objLAPPT.KLDirtP)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabKernelLosses_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesSelect]", Parms)
        Return ds
    End Function


    ''LabKernelLossesPCF


    Public Shared Function LabKernelLossesPCF_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@StationID", objLAPPT.KLPCFStationID)
        Parms(5) = New SqlParameter("@No ", objLAPPT.KLPCFNo)
        Parms(6) = New SqlParameter("@Line ", objLAPPT.KLPCFLine)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@TotalNutP ", objLAPPT.KLPCFTotalNutP)
        Parms(12) = New SqlParameter("@SampleP", objLAPPT.KLPCFSampleP)
        Parms(13) = New SqlParameter("@FibreP", objLAPPT.KLPCFFibreP)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesPCFInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabKernelLossesPCF_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabKernelLossesPCFID", objLAPPT.KLPCFLabKernelLossesPCFID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@StationID", objLAPPT.KLPCFStationID)
        Parms(5) = New SqlParameter("@No ", objLAPPT.KLPCFNo)
        Parms(6) = New SqlParameter("@Line ", objLAPPT.KLPCFLine)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(9) = New SqlParameter("@TotalNutP ", objLAPPT.KLPCFTotalNutP)
        Parms(10) = New SqlParameter("@SampleP", objLAPPT.KLPCFSampleP)
        Parms(11) = New SqlParameter("@FibreP", objLAPPT.KLPCFFibreP)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesPCFUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabKernelLossesPCF_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesPCFSelect]", Parms)
        Return ds
    End Function


    '''LabKernelQualityStorage



    Public Shared Function LabKernelQualityStorage_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Line", objLAPPT.KQSLine)
        Parms(5) = New SqlParameter("@Location", objLAPPT.KQSLocation)
        Parms(6) = New SqlParameter("@MoistureP ", objLAPPT.KQSMoistureP)
        Parms(7) = New SqlParameter("@DirtP", objLAPPT.KQSDirtP)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(12) = New SqlParameter("@BrokenKernel ", objLAPPT.KQSBrokenKernel)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelQualityStorageInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabKernelQualityStorage_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabKERQualityID", objLAPPT.KQSLabKERQualityID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Line", objLAPPT.KQSLine)
        Parms(5) = New SqlParameter("@Location", objLAPPT.KQSLocation)
        Parms(6) = New SqlParameter("@MoistureP ", objLAPPT.KQSMoistureP)
        Parms(7) = New SqlParameter("@DirtP", objLAPPT.KQSDirtP)
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@BrokenKernel ", objLAPPT.KQSBrokenKernel)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelQualityStorageUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabKernelQualityStorage_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelQualityStorageSelect]", Parms)
        Return ds
    End Function

    ''LabOilLosses

    Public Shared Function LabOilLosses_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@StationID", objLAPPT.OLStationID)
        Parms(5) = New SqlParameter("@No ", objLAPPT.OLNo)
        Parms(6) = New SqlParameter("@Line", objLAPPT.OLLine)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@ActualP", objLAPPT.OLActualP)
        Parms(12) = New SqlParameter("@STD", objLAPPT.OLSTD)
        Parms(13) = New SqlParameter("@Type", objLAPPT.OLType)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabOilLosses_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabOilLossesID", objLAPPT.OLLabOilLossesID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@StationID", objLAPPT.OLStationID)
        Parms(5) = New SqlParameter("@No ", objLAPPT.OLNo)
        Parms(6) = New SqlParameter("@Line", objLAPPT.OLLine)
        Parms(7) = New SqlParameter("@Type", objLAPPT.OLType)
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@ActualP", objLAPPT.OLActualP)
        Parms(11) = New SqlParameter("@STD", objLAPPT.OLSTD)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabOilLosses_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesSelect]", Parms)
        Return ds
    End Function

    ''LabOilLossesBFFB

    Public Shared Function LabOilLossesBFFB_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Descp", objLAPPT.OLBFFBDescp)
        Parms(5) = New SqlParameter("@ExpellerStageType", objLAPPT.OLBFFBExpellerStageType)
        Parms(6) = New SqlParameter("@ExpellerStageNumber", objLAPPT.OLBFFBExpellerStageNumber)
        Parms(7) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@Amount", objLAPPT.OLBFFBAmount)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesBFFBInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabOilLossesBFFB_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabOilLossesBFFBID ", objLAPPT.OLBFFBLabOilLossesBFFBID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Descp", objLAPPT.OLBFFBDescp)
        Parms(5) = New SqlParameter("@ExpellerStageType", objLAPPT.OLBFFBExpellerStageType)
        Parms(6) = New SqlParameter("@ExpellerStageNumber", objLAPPT.OLBFFBExpellerStageNumber)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(9) = New SqlParameter("@Amount", objLAPPT.OLBFFBAmount)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesBFFBUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabOilLossesBFFB_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesBFFBSelect]", Parms)
        Return ds
    End Function

    ''LabOilLossesFFB


    Public Shared Function LabOilLossesFFB_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Equipment", objLAPPT.OLFFBEquipment)
        Parms(5) = New SqlParameter("@No ", objLAPPT.OLFFBNo)
        Parms(6) = New SqlParameter("@ActualP", objLAPPT.OLFFBActualP)
        Parms(7) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@Type", objLAPPT.OLFFBType)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesFFBInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabOilLossesFFB_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabOilLossesFFBID", objLAPPT.OLFFBLabOilLossesFFBID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Equipment", objLAPPT.OLFFBEquipment)
        Parms(5) = New SqlParameter("@No", objLAPPT.OLFFBNo)
        Parms(6) = New SqlParameter("@ActualP", objLAPPT.OLFFBActualP)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(9) = New SqlParameter("@Type", objLAPPT.OLFFBType)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesFFBUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabOilLossesFFB_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilLossesFFBSelect]", Parms)
        Return ds
    End Function



    ''LabOilQualityStorage

    Public Shared Function LabOilQualityStorage_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@ProductType", objLAPPT.OQSProductType)
        Parms(5) = New SqlParameter("@TankID", objLAPPT.OQSTankID)
        Parms(6) = New SqlParameter("@FFAP", objLAPPT.OQSFFAP)
        Parms(7) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@MoistureP", objLAPPT.OQSMoistureP)
        Parms(12) = New SqlParameter("@DirtP", objLAPPT.OQSDirtP)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilQualityStorageInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabOilQualityStorage_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabOilQualityID", objLAPPT.OQSLabOilQualityID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@ProductType", objLAPPT.OQSProductType)
        Parms(5) = New SqlParameter("@TankID", objLAPPT.OQSTankID)
        Parms(6) = New SqlParameter("@FFAP", objLAPPT.OQSFFAP)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(9) = New SqlParameter("@MoistureP", objLAPPT.OQSMoistureP)
        Parms(10) = New SqlParameter("@DirtP", objLAPPT.OQSDirtP)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilQualityStorageUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabOilQualityStorage_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilQualityStorageSelect]", Parms)
        Return ds
    End Function

    ''LabSoftnerInsert

    Public Shared Function LabSoftner_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Descp", objLAPPT.SDescp)
        Parms(5) = New SqlParameter("@Type ", objLAPPT.SType)
        Parms(6) = New SqlParameter("@Dosage", objLAPPT.SDosage)
        Parms(7) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@Anion", objLAPPT.SAnion)
        'Parms(11) = New SqlParameter("@MoistureP", objLAPPT.OQSMoistureP)
        'Parms(12) = New SqlParameter("@DirtP", objLAPPT.OQSDirtP)


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabSoftnerInsert]", Parms)
        Return ds

    End Function

    Public Shared Function LabSoftner_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(8) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabSoftnerID", objLAPPT.SLabSoftnerID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@Descp", objLAPPT.SDescp)
        Parms(5) = New SqlParameter("@Type ", objLAPPT.SType)
        Parms(6) = New SqlParameter("@Dosage", objLAPPT.SDosage)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabSoftnerUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function LabSoftner_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabSoftnerSelect]", Parms)
        Return ds
    End Function
    ''MachineryOperationInsert

    Public Shared Function MachineryOperation_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@MachineID", objLAPPT.MOHMachineID)
        Parms(5) = New SqlParameter("@MeterFrom ", objLAPPT.MOHMeterFrom)
        Parms(6) = New SqlParameter("@MeterTo", objLAPPT.MOHMeterTo)
        Parms(7) = New SqlParameter("@ProcessHours", objLAPPT.MOHProcessHours)
        Parms(8) = New SqlParameter("@NonProcessHours", objLAPPT.MOHNonProcessHours)
        Parms(9) = New SqlParameter("@TotalHours", objLAPPT.MOHTotalHours)
        Parms(10) = New SqlParameter("@MonthToDateHrs", objLAPPT.MOHMonthToDateHrs)
        Parms(11) = New SqlParameter("@YeartoDateHrs", objLAPPT.MOHYeartoDateHrs)
        Parms(12) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(14) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(15) = New SqlParameter("@ModifiedOn", Date.Today())



        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[MachineryOperationInsert]", Parms)
        Return ds

    End Function

    Public Shared Function MachineryOperation_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@MachinerOperationID", objLAPPT.MOHMachinerOperationID)
        Parms(3) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Parms(4) = New SqlParameter("@MachineID", objLAPPT.MOHMachineID)
        Parms(5) = New SqlParameter("@MeterFrom ", objLAPPT.MOHMeterFrom)
        Parms(6) = New SqlParameter("@MeterTo", objLAPPT.MOHMeterTo)
        Parms(7) = New SqlParameter("@ProcessHours", objLAPPT.MOHProcessHours)
        Parms(8) = New SqlParameter("@NonProcessHours", objLAPPT.MOHNonProcessHours)
        Parms(9) = New SqlParameter("@TotalHours", objLAPPT.MOHTotalHours)
        Parms(10) = New SqlParameter("@MonthToDateHrs", objLAPPT.MOHMonthToDateHrs)
        Parms(11) = New SqlParameter("@YeartoDateHrs", objLAPPT.MOHYeartoDateHrs)
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[MachineryOperationUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function MachineryOperation_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisID", objLAPPT.LabAnalysisID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[MachineryOperationSelect]", Parms)
        Return ds
    End Function

    '''Select 

    Public Shared Function LabAnalCPOPKOKernelQty_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabAnalCPOPKOKernelQtySelect]", Parms)
        Return ds
    End Function

    Public Shared Function LabFFAPMonthYearValue_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabFFAPMonthYearValueSelect]", Parms)
        Return ds
    End Function
    Public Shared Function LabMOHMonthYearHrsSelect(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@MachineID", objLAPPT.MOHMachineID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabMOHMonthYearHrsSelect]", Parms)
        Return ds
    End Function

    Public Shared Function LabOilKernelLossesStationSearch(ByVal objLAPPT As LaboratoryAnalysisPPT, ByVal LossType As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LossType", LossType)

        ds = objdb.ExecQuery("[Production].[LabOilKernelLossesStationSelect]", Parms)
        Return ds

    End Function

    '' For Oil Losses and Kernel Losses Tab
    Public Shared Function LabOilQualityStorageTankNo_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", objLAPPT.OQSProductType)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabOilQualityStorageTankNoSelect]", Parms)
        Return ds
    End Function

    ''For Machinery Operation
    Public Shared Function MachineryOperationMachineName_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataTable
        ds = objdb.ExecQuery("[Production].[MachineryOperationMachineNameSelect]", Parms).Tables(0)
        Return ds
    End Function

    Public Shared Function LabKeyValuePair_Select(ByVal KeyName As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@KeyName", KeyName)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKeyValuePairSelect]", Parms)
        Return ds
    End Function
    ''For Kernel Losses PCF Station Select
    Public Shared Function LabKernelLossesPCFStationIDSelect() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabKernelLossesPCFStationIDSelect]", Parms)
        Return ds
    End Function

    ''' ForFFAP Calculation
    Public Shared Function LAbProductionFFAPSelect(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LAbProductionFFAPSelect]", Parms)
        Return ds
    End Function

    Public Shared Function LabMOHMonthYearHrsCheck(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@MachineID", objLAPPT.MOHMachineID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[LabMOHMonthYearHrsCheck]", Parms)
        Return ds
    End Function

    Public Shared Function LaboratoryMOPGetMonthYearHrs(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@LabAnalysisDate", objLAPPT.LabAnalysisDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(4) = New SqlParameter("@MachineID", objLAPPT.MOHMachineID)

        ds = objdb.ExecQuery("[Production].[LaboratoryMOPGetMonthYearHrs]", Parms)
        Return ds
    End Function
End Class
