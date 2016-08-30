Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports CheckRoll_PPT
Public Class AnalyHarvestingCostBOL

    Public Shared Function GetActiveMonthYear(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Return AnalyHarvestingCostDAL.GetActiveMonthYear(objWBFruitWtDetailsPPT)
    End Function

    Public Shared Function loadCmbYOP() As DataTable
        Return AnalyHarvestingCostDAL.loadCmbYOP()
    End Function

    Public Shared Function saveWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataSet
        Return AnalyHarvestingCostDAL.saveWBFruitWt(objWBFruitWtDetailsPPT)
    End Function

    Public Shared Function saveWBFruitWtDetails(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataSet
        Return AnalyHarvestingCostDAL.saveWBFruitWtDetails(objWBFruitWtDetailsPPT)
    End Function

    Public Shared Function UpdateWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As Object
        Return AnalyHarvestingCostDAL.UpdateWBFruitWt(objWBFruitWtDetailsPPT)
    End Function

    Public Shared Function DeleteWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As Integer
        Return AnalyHarvestingCostDAL.DeleteWBFruitWt(objWBFruitWtDetailsPPT)
    End Function

    Public Shared Function GetWBFruitWtRecs(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Return AnalyHarvestingCostDAL.GetWBFruitWtRecs(objWBFruitWtDetailsPPT)
    End Function

    Public Shared Function GetWBFruitWt(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Return AnalyHarvestingCostDAL.GetWBFruitWt(objWBFruitWtDetailsPPT)
    End Function
    Public Shared Function GetDADLooseFruitsOther(ByVal objWBFruitWtDetailsPPT As AnalyHarvestingCostPPT) As DataTable
        Return AnalyHarvestingCostDAL.GetDADLooseFruitsOther(objWBFruitWtDetailsPPT)
    End Function

End Class
