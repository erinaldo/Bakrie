Imports Budget_PPT
Imports Budget_DAL
Public Class StandardConfigurationBOL
    Public Shared Function InsertStandardConfiguration(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
        Return StandardConfigurationDAL.InsertStandardConfiguration(objPPT)
    End Function
    'Public Shared Function InsertStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
    '    Return StandardConfigurationDAL.InsertStandardHarvestingQuarter(objPPT)
    'End Function
    Public Shared Function SelectAllStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As DataTable
        Return StandardConfigurationDAL.SelectAllStandardHarvestingQuarter(objPPT)
    End Function
    'Public Shared Function IsPeriodExistStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As DataTable
    '    Return StandardConfigurationDAL.IsPeriodExistStandardHarvestingQuarter(objPPT)
    'End Function
    'Public Shared Function UpdateStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
    '    Return StandardConfigurationDAL.UpdateStandardHarvestingQuarter(objPPT)
    'End Function
    Public Shared Function IsYearExistStandardConfiguration(ByVal objPPT As StandardConfigurationPPT) As DataTable
        Return StandardConfigurationDAL.IsYearExistStandardConfiguration(objPPT)
    End Function
    Public Shared Function UpdateStandardConfiguration(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
        Return StandardConfigurationDAL.UpdateStandardConfiguration(objPPT)
    End Function
    Public Shared Function DeleteStandardConfiguration(ByVal objPPT As StandardConfigurationPPT)
        Return StandardConfigurationDAL.DeleteStandardConfiguration(objPPT)
    End Function
End Class
