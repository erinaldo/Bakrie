Imports Production_DAL
Imports Production_PPT
Public Class ProductionQcdCrumbBOL
    Dim objDAL As New ProductionQcdCrumbDAL
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionQcdCrumbPPT) As List(Of ProductionQcdCrumbPPT)
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastQCRM(ByVal objLPOPPT As ProductionQcdCrumbPPT) As DataSet
        Return ProductionQcdCrumbDAL.DeleteLastQCRM(objLPOPPT)
    End Function
End Class
