Imports Production_DAL
Imports Production_PPT
Public Class ProductionCrumbRubberBOL
    Public Shared Function Save(ByVal objCrumbRubberPPT As ProductionCrumbRubberPPT) As DataSet
        Return ProductionCrumbRubberDAL.SaveProductionCrumbRubber(objCrumbRubberPPT)
    End Function
    Public Function GetSearchResults(ByVal objCrumbRubberPPT As ProductionCrumbRubberPPT) As List(Of ProductionCrumbRubberPPT)
        Dim objDAL As New ProductionCrumbRubberDAL
        Return objDAL.GetSearchResults(objCrumbRubberPPT)
    End Function
    Public Shared Function DeleteLastCrumbRubber(ByVal objCrumbRubberPPT As ProductionCrumbRubberPPT) As DataSet
        Return ProductionCrumbRubberDAL.DeleteLastCrumbRubber(objCrumbRubberPPT)
    End Function
End Class
