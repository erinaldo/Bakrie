Imports CheckRoll_DAL
Imports CheckRoll_PPT
Public Class AnalysisHarvestingCost_BOL
    Public Function GetTaskComplete(ByVal objSummaryReportsPPT As AnalysisHarvestingCost_PPT) As DataSet
        Dim objHarvesterDAL As New AnalysisHarvestingCost_DAL
        Return objHarvesterDAL.GetTaskComplete(objSummaryReportsPPT)
    End Function
End Class
