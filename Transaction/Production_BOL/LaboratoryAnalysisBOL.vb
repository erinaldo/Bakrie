Imports Production_DAL
Imports Production_PPT
Public Class LaboratoryAnalysisBOL

    '''LaboratoryAnalysis table

    Public Shared Function LaboratoryAnalysis_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LaboratoryAnalysis_Save(objLAPPT)
    End Function

    Public Shared Function LaboratoryAnalysis_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LaboratoryAnalysis_Update(objLAPPT)
    End Function
    Public Shared Function LaboratoryAnalysis_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LaboratoryAnalysis_Select(objLAPPT)
    End Function

    Public Shared Function LaboratoryAnalysisDuplicateCheck(ByVal objLAPPT As LaboratoryAnalysisPPT) As Object
        Return LaboratoryAnalysisDAL.LaboratoryAnalysisDuplicateCheck(objLAPPT)
    End Function

    Public Shared Function LaboratoryAnalysisDelete(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LaboratoryAnalysisDelete(objLAPPT)
    End Function


    ''LabBoilerWater table 

    Public Shared Function LabBoilerWater_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabBoilerWater_Save(objLAPPT)
    End Function

    Public Shared Function LabBoilerWater_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabBoilerWater_Update(objLAPPT)
    End Function
    Public Shared Function LabBoilerWater_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabBoilerWater_Select(objLAPPT)
    End Function

    ''' LabEffRippleMill

    Public Shared Function LabEffRippleMill_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabEffRippleMill_Save(objLAPPT)
    End Function

    Public Shared Function LabEffRippleMill_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabEffRippleMill_Update(objLAPPT)
    End Function
    Public Shared Function LabEffRippleMill_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabEffRippleMill_Select(objLAPPT)
    End Function

    ''LabKernelIntake

    Public Shared Function LabKernelIntake_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelIntake_Save(objLAPPT)
    End Function

    Public Shared Function LabKernelIntake_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelIntake_Update(objLAPPT)
    End Function
    Public Shared Function LabKernelIntake_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelIntake_Select(objLAPPT)
    End Function

    ''LabKernelLossesFFB
    Public Shared Function LabKernelLossesFFB_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLossesFFB_Save(objLAPPT)
    End Function

    Public Shared Function LabKernelLossesFFB_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLossesFFB_Update(objLAPPT)
    End Function
    Public Shared Function LabKernelLossesFFB_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLossesFFB_Select(objLAPPT)
    End Function


    ''LabKernelLosses

    Public Shared Function LabKernelLosses_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLosses_Save(objLAPPT)
    End Function

    Public Shared Function LabKernelLosses_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLosses_Update(objLAPPT)
    End Function
    Public Shared Function LabKernelLosses_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLosses_Select(objLAPPT)
    End Function

    ''LabKernelLossesPCF

    Public Shared Function LabKernelLossesPCF_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLossesPCF_Save(objLAPPT)
    End Function

    Public Shared Function LabKernelLossesPCF_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLossesPCF_Update(objLAPPT)
    End Function
    Public Shared Function LabKernelLossesPCF_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLossesPCF_Select(objLAPPT)
    End Function

    ''LabKernelQualityStorage

    Public Shared Function LabKernelQualityStorage_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelQualityStorage_Save(objLAPPT)
    End Function

    Public Shared Function LabKernelQualityStorage_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelQualityStorage_Update(objLAPPT)
    End Function
    Public Shared Function LabKernelQualityStorage_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabKernelQualityStorage_Select(objLAPPT)
    End Function

    ''LabOilLosses

    Public Shared Function LabOilLosses_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLosses_Save(objLAPPT)
    End Function

    Public Shared Function LabOilLosses_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLosses_Update(objLAPPT)
    End Function
    Public Shared Function LabOilLosses_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLosses_Select(objLAPPT)
    End Function

    ''LabOilLossesBFFB

    Public Shared Function LabOilLossesBFFB_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLossesBFFB_Save(objLAPPT)
    End Function

    Public Shared Function LabOilLossesBFFB_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLossesBFFB_Update(objLAPPT)
    End Function
    Public Shared Function LabOilLossesBFFB_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLossesBFFB_Select(objLAPPT)
    End Function

    ''LabOilLossesFFB
    Public Shared Function LabOilLossesFFB_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLossesFFB_Save(objLAPPT)
    End Function

    Public Shared Function LabOilLossesFFB_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLossesFFB_Update(objLAPPT)
    End Function
    Public Shared Function LabOilLossesFFB_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilLossesFFB_Select(objLAPPT)
    End Function


    ''LabOilQualityStorage

    Public Shared Function LabOilQualityStorage_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilQualityStorage_Save(objLAPPT)
    End Function

    Public Shared Function LabOilQualityStorage_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilQualityStorage_Update(objLAPPT)
    End Function
    Public Shared Function LabOilQualityStorage_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilQualityStorage_Select(objLAPPT)
    End Function

    '' LabSoftner

    Public Shared Function LabSoftner_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabSoftner_Save(objLAPPT)
    End Function

    Public Shared Function LabSoftner_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabSoftner_Update(objLAPPT)
    End Function
    Public Shared Function LabSoftner_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabSoftner_Select(objLAPPT)
    End Function

    ''MachineryOperation

    Public Shared Function MachineryOperation_Save(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.MachineryOperation_Save(objLAPPT)
    End Function

    Public Shared Function MachineryOperation_Update(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.MachineryOperation_Update(objLAPPT)
    End Function
    Public Shared Function MachineryOperation_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.MachineryOperation_Select(objLAPPT)
    End Function

    ''Select Functions


    Public Shared Function LabAnalCPOPKOKernelQty_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabAnalCPOPKOKernelQty_Select(objLAPPT)
    End Function

    Public Shared Function LabFFAPMonthYearValue_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabFFAPMonthYearValue_Select(objLAPPT)
    End Function

    Public Shared Function LabMOHMonthYearHrsSelect(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabMOHMonthYearHrsSelect(objLAPPT)
    End Function

    Public Shared Function LabOilKernelLossesStationSearch(ByVal objLAPPT As LaboratoryAnalysisPPT, ByVal LossType As String) As DataSet
        Return LaboratoryAnalysisDAL.LabOilKernelLossesStationSearch(objLAPPT, LossType)
    End Function


    Public Shared Function LabOilQualityStorageTankNo_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabOilQualityStorageTankNo_Select(objLAPPT)
    End Function

    Public Shared Function MachineryOperationMachineName_Select(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataTable
        Return LaboratoryAnalysisDAL.MachineryOperationMachineName_Select(objLAPPT)
    End Function

    Public Shared Function LabMOHMonthYearHrsCheck(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LabMOHMonthYearHrsCheck(objLAPPT)
    End Function

    Public Shared Function LAbProductionFFAPSelect(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LAbProductionFFAPSelect(objLAPPT)
    End Function

    Public Shared Function LabKeyValuePair_Select(ByVal KeyName As String) As DataSet
        Return LaboratoryAnalysisDAL.LabKeyValuePair_Select(KeyName)
    End Function

    Public Shared Function LabKernelLossesPCFStationIDSelect() As DataSet
        Return LaboratoryAnalysisDAL.LabKernelLossesPCFStationIDSelect()
    End Function

    Public Shared Function LaboratoryMOPGetMonthYearHrs(ByVal objLAPPT As LaboratoryAnalysisPPT) As DataSet
        Return LaboratoryAnalysisDAL.LaboratoryMOPGetMonthYearHrs(objLAPPT)
    End Function
End Class
